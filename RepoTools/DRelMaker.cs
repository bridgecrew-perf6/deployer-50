using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using SharpSvn;

namespace Deployer.Repo
{
	public static class ReleaseMaker
	{
	    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

		public enum EPinType
		{
			Invalid,
			Head, // following the head of the trunk
			Peg, // pinned to peg revision of whatever
			Branch, // branch using given releaseName
			Tag // tag using given releaseName
		}

		/// <summary>
		/// Creates a release by copying an existing one and changing the externals type
		/// Only the root externals are changed. All in repository, no WC involved.
		/// </summary>
		/// <param name="srcUrl">
		///    svn://server/releases/head
		///    svn://server/releases/candidate/2.0.1
		///    svn://server/releases/final/2.0.1
		/// </param>
		/// <param name="destUrl">new url
		///    svn://server/releases/head
		///    svn://server/releases/candidate/2.0.1
		///    svn://server/releases/final/2.0.1
		/// </param>
		/// <param name="pinType">the resulting type of externals</param>
		/// <param name="releaseName">name of the release Can contain sub-folders like 'sub1/sub2/version'</param>
		/// <returns></returns>
		public static bool Copy( SvnClient client, string srcUrl, string destUrl, EPinType pinType, string releaseName=null )
		{
			/*
			  - udělá svn copy (to zkopíruje externalsy jak jsou)
			  - pozmění kořenové externalsy tak, že každý z nich napinuje (pokud ještě není) na konkrétní revizi
			*/

			// args check
			if( pinType == EPinType.Branch || pinType == EPinType.Tag )
			{
				if( String.IsNullOrEmpty( releaseName ) )
				{
					throw new ArgumentException("release Name can't be empty", "releaseName");
				}
			}

			// read externals from the root directory and parse them
			string externalsHostUrl = srcUrl;

            SvnExternalItem[] extItems;
			{
				string externalsPropVal;
				if( !client.GetProperty( new SvnUriTarget( externalsHostUrl ), "svn:externals", out externalsPropVal ))
					return false;

				if( !String.IsNullOrEmpty( externalsPropVal ) )
				{

					if( !SvnExternalItem.TryParse( externalsPropVal, out extItems) )
						return false;
				}
				else
				{
					// empty array
					extItems = new SvnExternalItem[0];
				}
			}

			// modify each of them (will create new tags if needed on referenced shared resources!)
			{
				
				for( int i=0; i < extItems.Length; i++  )
				{
					if( !ModifyExternal( client, ref extItems[i], pinType, externalsHostUrl, releaseName ) )
						return false;
				}
			}

			long dstRevision;

			if( srcUrl != destUrl )
			{
				// make svn copy Head Candidate/2.0.1 (copies the externals as they are)
				try
				{
					SvnCommitResult copyResult;
					var args = new SvnCopyArgs();
					args.LogMessage = "";
					args.CreateParents = true;
					if( !client.RemoteCopy( new SvnUriTarget( srcUrl, SvnRevision.Head ), new Uri( destUrl ), args, out copyResult ) )
						return false;

					dstRevision = copyResult.Revision;
				}
				catch( SvnException ex )
				{
					Logger.Error( ex, $"Failed creating '{destUrl}'");
					return false;
				}
			}
			else
			{
				SvnInfoEventArgs info;
				if( !client.GetInfo( new Uri(srcUrl), out info) )
					return false;
				dstRevision = info.Revision;
			}


			// update its root externals
			if( extItems.Length > 0 )
			{
				// reassemble value from parsed items
				var sb = new StringBuilder();
				foreach( var ei in extItems )
				{
					ei.WriteTo( sb, false );
					sb.Append("\r\n");
				}
				var externalsPropValue = sb.ToString();

				//  - set svn:external property back to given url + ext.LocalPath
				var args = new SvnSetPropertyArgs();
				args.BaseRevision = dstRevision;
				args.LogMessage = "";
				if( !client.RemoteSetProperty( new Uri(destUrl), "svn:externals", externalsPropValue, args ) )
					return false;
			}

			return true;

		}

		public static bool ModifyExternal( SvnClient client, ref SvnExternalItem ei, EPinType newType, string hostUrl, string releaseName=null )
		{
			switch( newType )
			{
				case EPinType.Head:
				{
					if( !MakeHead( client, ref ei, hostUrl ) )
						return false;
					break;
				}

				case EPinType.Peg:
				{
					if( !MakePeg( client, ref ei, hostUrl ) )
						return false;
					break;
				}

				case EPinType.Branch:
				{
					if( !MakeBranch( client, ref ei, hostUrl, releaseName ) )
						return false;
					break;
				}

				case EPinType.Tag:
				{
					if( !MakeTag( client, ref ei, hostUrl, releaseName ) )
						return false;
					break;
				}
			}

			return true;
		}

		
		public static bool GetExternalType( SvnExternalItem ei, out EPinType oldType )
		{
			if( ei.Revision.RevisionType == SvnRevisionType.None )
			{
				oldType = EPinType.Head;
				return true;
			}

			if( ei.Revision.RevisionType == SvnRevisionType.Number )
			{
				oldType = EPinType.Peg;
				return true;
			}

			if( ei.Reference.Contains("/branches/") )
			{
				oldType = EPinType.Branch;
				return true;
			}

			if( ei.Reference.Contains("/tags/") )
			{
				oldType = EPinType.Tag;
				return true;
			}

			oldType = EPinType.Invalid;
			Logger.Error($"Pin type of external ref '{ei}' can't be determmined");

			return false;
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		/// <param name="ei"></param>
		/// <param name="hostUrl">url of directory where the svn external is defined</param>
		/// <returns></returns>
		public static bool GetFullReferenceUrl( SvnClient client, SvnExternalItem ei, string hostUrl, out string result )
		{
			var url = ei.Reference;
			result = url;
			
			if( url.StartsWith("^") )
			{
				var relativeUrl = url.Substring(1);

				// get repo root
				SvnInfoEventArgs info;
				if( !client.GetInfo( new Uri(hostUrl), out info) )
					return false;

				result = CombineUrls( info.RepositoryRoot.AbsoluteUri, relativeUrl );
				return true;
			}
			else
			if( url.StartsWith("//") )
			{
				// FIXME: add support
				Logger.Error($"Unsupported relative external '{url}'");
				return false;
			}
			else
			if( url.StartsWith("..") )
			{
				// FIXME: add support
				Logger.Error($"Unsupported relative external '{url}'");
				return false;
			}
			else
			if( url.StartsWith("/") )
			{
				// FIXME: add support
				Logger.Error($"Unsupported relative external '{url}'");
				return false;
			}
			else
			{
				// leave the result same as url
				return true;
			}


			//return false;
		}

		public static string CombineUrls(string url1, string url2 )
		{
			if( url1.EndsWith("/") && url2.StartsWith("/") )
				return url1 + url2.Substring(1);
			else if( !url1.EndsWith("/") && !url2.StartsWith("/") )
				return url1 + "/" + url2.Substring(1);
			else
				return url1 + url2;
		}



		public static bool MakeHead( SvnClient client, ref SvnExternalItem ei, string hostUrl )
		{
			EPinType oldType;
			if( !GetExternalType( ei, out oldType ) )
				return false;

			switch( oldType )
			{
				case EPinType.Head:
				{
					// no change needed, already a head external
					return true;
				}

				case EPinType.Peg:
				{
					// remove peg
					ei = new SvnExternalItem( ei.Target, ei.Reference );
					return true;
				}

				case EPinType.Branch:
				{
					// replace the /branches/... part with /trunk
					var orig = ei.Reference;
					int tagPos = orig.IndexOf("/branches/");
					if( tagPos >= 0 )
					{
						var trunkized = orig.Substring(0, tagPos) + "/trunk";
						ei = new SvnExternalItem( ei.Target, trunkized );
						return true;
					}
					else
					{
						Logger.Error($"external '{orig}' is not a branch!");
						return false;
					}
				}

				case EPinType.Tag:
				{
					// replace the /tags/... part with /trunk
					var orig = ei.Reference;
					int tagPos = orig.IndexOf("/tags/");
					if( tagPos >= 0 )
					{
						var trunkized = orig.Substring(0, tagPos) + "/trunk";
						ei = new SvnExternalItem( ei.Target, trunkized );
						return true;
					}
					else
					{
						Logger.Error($"external '{orig}' is not a tag!");
						return false;
					}
				}

				default:
				{
					// unknown Pin type
					return false;
				}
			}

			//return true;
		}

		public static bool MakePeg( SvnClient client, ref SvnExternalItem ei, string hostUrl )
		{
			EPinType oldType;
			if( !GetExternalType( ei, out oldType ) )
				return false;

			switch( oldType )
			{
				case EPinType.Head:
				case EPinType.Branch:
				{
					// resolve relative url references
					string fullRefUrl;
					if( !GetFullReferenceUrl( client, ei, hostUrl, out fullRefUrl ) )
						return false;

					// find the revision of the external
					SvnInfoEventArgs info;
					if( !client.GetInfo( new SvnUriTarget(fullRefUrl, SvnRevision.Head), out info) )
						return false;

					// change to peg revision
					ei = new SvnExternalItem( ei.Target, ei.Reference, info.Revision );

					return true;
				}

				case EPinType.Peg:
				{
					// no change needed, already a peg external
					return true;
				}

				case EPinType.Tag:
				{
					// no change needed, tag is considered unchangeable, keep it as it is
					return true;
				}

				default:
				{
					// unknown Pin type
					return false;
				}
			}

			//return true;
		}

		public static bool MakeBranch( SvnClient client, ref SvnExternalItem ei, string hostUrl, string releaseName )
		{
			return MakeTagBranch( client, ref ei, hostUrl, releaseName, "branches" );
		}

		public static bool MakeTag( SvnClient client, ref SvnExternalItem ei, string hostUrl, string releaseName )
		{
			return MakeTagBranch( client, ref ei, hostUrl, releaseName, "tags" );
		}

		public static bool MakeTagBranch( SvnClient client, ref SvnExternalItem ei, string hostUrl, string releaseName, string branchTagType )
		{
			EPinType oldType;
			if( !GetExternalType( ei, out oldType ) )
				return false;

			string fullRefUrl;
			if( !GetFullReferenceUrl( client, ei, hostUrl, out fullRefUrl ) )
				return false;

			var origBaseUrl = StripStdSvnLayoutFromUrl( ei.Reference );
			var origTaggizedUrl =  $"{origBaseUrl}/{branchTagType}/{releaseName}";

			var fullBaseUrl = StripStdSvnLayoutFromUrl( fullRefUrl );
			var fullTaggizedUrl =  $"{fullBaseUrl}/{branchTagType}/{releaseName}";

			switch( oldType )
			{
				case EPinType.Head:
				case EPinType.Branch:
				{
					// create tag by svncopying from the head

					try
					{
						SvnCommitResult copyResult;
						var args = new SvnCopyArgs();
						args.LogMessage = "";
						args.CreateParents = true;
						if( !client.RemoteCopy( new SvnUriTarget( fullRefUrl, SvnRevision.Head ), new Uri( fullTaggizedUrl ), args, out copyResult ) )
							return false;
					}
					catch( SvnException ex )
					{
						Logger.Warn( ex, $"Failed creating tag/branch '{fullTaggizedUrl}'");
					}

					ei = new SvnExternalItem( ei.Target, origTaggizedUrl );

					return true;
				}

				case EPinType.Peg:
				{
					// create tag by svncopying from given peg revision
					try
					{
						SvnCommitResult copyResult;
						var args = new SvnCopyArgs();
						args.LogMessage = "";
						args.CreateParents = true;
						if( !client.RemoteCopy( new SvnUriTarget( fullRefUrl, ei.Revision ), new Uri( fullTaggizedUrl ), args, out copyResult ) )
							return false;
					}
					catch( SvnException ex )
					{
						Logger.Warn( ex, $"Failed creating tag/branch '{fullTaggizedUrl}'");
					}

					ei = new SvnExternalItem( ei.Target, origTaggizedUrl );

					return true;
				}

				case EPinType.Tag:
				{
					// leave the tag as is
					return false;
				}

				default:
				{
					// unknown Pin type
					return false;
				}
			}

			//return false;
		}

		// strips "/trunk" or "/braches/..." or "/tags/..." from the url
		public static string StripStdSvnLayoutFromUrl( string url )
		{
			int pos;
			pos = url.LastIndexOf("/trunk");
			if( pos >= 0 )
				return url.Substring( 0, pos );
			pos = url.LastIndexOf("/branches/");
			if( pos >= 0 )
				return url.Substring( 0, pos );
			pos = url.LastIndexOf("/tags/");
			if( pos >= 0 )
				return url.Substring( 0, pos );
			return url;
		}

		public static bool Delete( SvnClient client, string srcUrl )
		{
			SvnDeleteArgs args = new SvnDeleteArgs();
			args.LogMessage ="";
			return client.RemoteDelete( new Uri( srcUrl ), args );
		}




	}




}
