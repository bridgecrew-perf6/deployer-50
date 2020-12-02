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
		public static bool Copy( SvnClient client, string srcUrl, string destUrl, Exter.EPinType pinType, string releaseName=null )
		{
			/*
			  - udělá svn copy (to zkopíruje externalsy jak jsou)
			  - pozmění kořenové externalsy tak, že každý z nich napinuje (pokud ještě není) na konkrétní revizi
			*/

			// args check
			if( pinType == Exter.EPinType.Branch || pinType == Exter.EPinType.Tag )
			{
				if( String.IsNullOrEmpty( releaseName ) )
				{
					throw new ArgumentException("release Name can't be empty", "releaseName");
				}
			}

			// read externals from the root directory and parse them
			string externalsHostUrl = srcUrl;

            SvnExternalItem[] extItems;
			if( !Exter.ReadExternals( client, externalsHostUrl, out extItems ) )
				return false;

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
			if( !Exter.WriteExternals( client, destUrl, extItems, dstRevision ) )
				return false;

			return true;

		}

		static bool ModifyExternal( SvnClient client, ref SvnExternalItem ei, Exter.EPinType newType, string hostUrl, string releaseName=null )
		{
			switch( newType )
			{
				case Exter.EPinType.Head:
				{
					if( !MakeHead( client, ref ei, hostUrl ) )
						return false;
					break;
				}

				case Exter.EPinType.Peg:
				{
					if( !MakePeg( client, ref ei, hostUrl ) )
						return false;
					break;
				}

				case Exter.EPinType.Branch:
				{
					if( !MakeBranch( client, ref ei, hostUrl, releaseName ) )
						return false;
					break;
				}

				case Exter.EPinType.Tag:
				{
					if( !MakeTag( client, ref ei, hostUrl, releaseName ) )
						return false;
					break;
				}
			}

			return true;
		}

		
		static bool MakeHead( SvnClient client, ref SvnExternalItem ei, string hostUrl )
		{
			Exter.EPinType oldType;
			if( !Exter.GetExternalType( ei, out oldType ) )
				return false;

			switch( oldType )
			{
				case Exter.EPinType.Head:
				{
					// no change needed, already a head external
					return true;
				}

				case Exter.EPinType.Peg:
				{
					// remove peg
					ei = new SvnExternalItem( ei.Target, ei.Reference );
					return true;
				}

				case Exter.EPinType.Branch:
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

				case Exter.EPinType.Tag:
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

		static bool MakePeg( SvnClient client, ref SvnExternalItem ei, string hostUrl )
		{
			Exter.EPinType oldType;
			if( !Exter.GetExternalType( ei, out oldType ) )
				return false;

			switch( oldType )
			{
				case Exter.EPinType.Head:
				case Exter.EPinType.Branch:
				{
					// resolve relative url references
					string fullRefUrl;
					if( !Exter.GetFullReferenceUrl( client, ei, hostUrl, out fullRefUrl ) )
						return false;

					// find the revision of the external
					SvnInfoEventArgs info;
					if( !client.GetInfo( new SvnUriTarget(fullRefUrl, SvnRevision.Head), out info) )
						return false;

					// change to peg revision
					ei = new SvnExternalItem( ei.Target, ei.Reference, info.Revision );

					return true;
				}

				case Exter.EPinType.Peg:
				{
					// no change needed, already a peg external
					return true;
				}

				case Exter.EPinType.Tag:
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

		static bool MakeBranch( SvnClient client, ref SvnExternalItem ei, string hostUrl, string releaseName )
		{
			return MakeTagBranch( client, ref ei, hostUrl, releaseName, "branches" );
		}

		static bool MakeTag( SvnClient client, ref SvnExternalItem ei, string hostUrl, string releaseName )
		{
			return MakeTagBranch( client, ref ei, hostUrl, releaseName, "tags" );
		}

		static bool MakeTagBranch( SvnClient client, ref SvnExternalItem ei, string hostUrl, string releaseName, string branchTagType )
		{
			Exter.EPinType oldType;
			if( !Exter.GetExternalType( ei, out oldType ) )
				return false;

			string fullRefUrl;
			if( !Exter.GetFullReferenceUrl( client, ei, hostUrl, out fullRefUrl ) )
				return false;

			var origBaseUrl = Exter.StripStdSvnLayoutFromUrl( ei.Reference );
			var origTaggizedUrl =  $"{origBaseUrl}/{branchTagType}/{releaseName}";

			var fullBaseUrl = Exter.StripStdSvnLayoutFromUrl( fullRefUrl );
			var fullTaggizedUrl =  $"{fullBaseUrl}/{branchTagType}/{releaseName}";

			switch( oldType )
			{
				case Exter.EPinType.Head:
				case Exter.EPinType.Branch:
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

				case Exter.EPinType.Peg:
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

				case Exter.EPinType.Tag:
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

		public static bool Delete( SvnClient client, string srcUrl )
		{
			SvnDeleteArgs args = new SvnDeleteArgs();
			args.LogMessage ="";
			return client.RemoteDelete( new Uri( srcUrl ), args );
		}

	}




}
