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
	public static class Exter
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


		public static void ParseRepoRootUrlToServerAndRepo( string repoRootUrl, out string serverRootUrl, out string repoName )
		{
			if( repoRootUrl.EndsWith("/") )
				repoRootUrl = repoRootUrl.Substring(0, repoRootUrl.Length-1);// strip ending '/'

			serverRootUrl = System.IO.Path.GetDirectoryName( repoRootUrl.Replace('/', '\\') ).Replace('\\', '/')+"/";
			repoName = System.IO.Path.GetFileName( repoRootUrl.Replace('/', '\\') ).Replace('\\', '/');
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
			
			if( url.StartsWith("^/../") )
			{
				var relativeUrl = url.Substring(1);

				// get repo root
				SvnInfoEventArgs info;
				if( !client.GetInfo( new Uri(hostUrl), out info) )
					return false;

				// normalize <server>/repo1/../repo2/xxx to <server>/repo2/xxx
				string combinedUrl = CombineUrls( info.RepositoryRoot.AbsoluteUri, relativeUrl );
				var combinedNormalizedUri = SvnTools.GetNormalizedUri( new Uri(combinedUrl) );
				result = combinedNormalizedUri.AbsoluteUri;

				return true;
			}
			else
			if( url.StartsWith("^/") )
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
				throw new Exception($"Unsupported relative external '{url}'");
				//return false;
			}
			else
			if( url.StartsWith("..") )
			{
				// FIXME: add support
				Logger.Error($"Unsupported relative external '{url}'");
				throw new Exception($"Unsupported relative external '{url}'");
				//return false;
			}
			else
			if( url.StartsWith("/") )
			{
				// FIXME: add support
				Logger.Error($"Unsupported relative external '{url}'");
				throw new Exception($"Unsupported relative external '{url}'");
				//return false;
			}
			else
			{
				// leave the result same as url
				return true;
			}


			//return false;
		}

		// tries to find relative external reference
		// it true is returned, relativeRef contains relativized path
		// if false is returned, relativeRef contains original absUrl
		public static bool TryMakeRelativeReference( SvnClient client, string absUrl, string repoRootUrl, out string relativeRef )
		{
			relativeRef = absUrl;

			if( !repoRootUrl.EndsWith("/") )
				repoRootUrl+="/";


			// same server & repository?
			if( absUrl.StartsWith( repoRootUrl ) )
			{
				var relativePart = absUrl.Substring( repoRootUrl.Length );
				relativeRef = $"^/{relativePart}";
				return true;
			}

			string homeServerRootUrl;
			string homeRepoName;
			Exter.ParseRepoRootUrlToServerAndRepo( repoRootUrl, out homeServerRootUrl, out homeRepoName );

			
			SvnInfoEventArgs tgtInfo;
			if( !client.GetInfo( new SvnUriTarget( absUrl ), out tgtInfo ) )
				return false;
			
			string tgtRepoRootUrl = tgtInfo.RepositoryRoot.AbsoluteUri;
			string tgtServerRootUrl;
			string tgtRepoName;
			Exter.ParseRepoRootUrlToServerAndRepo( tgtRepoRootUrl, out tgtServerRootUrl, out tgtRepoName );

			if( !absUrl.StartsWith( tgtRepoRootUrl ) ) 
					return false; // this should not happen!
			string inRepoPath = absUrl.Substring( tgtRepoRootUrl.Length );

			// same server? (different repo name then...)
			if( homeServerRootUrl == tgtServerRootUrl )
			{
				relativeRef = $"^/../{tgtRepoName}/{inRepoPath}";
				return true;
			}

			return false;
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

		public static bool ReadExternals( SvnClient client, string externalsHostUrl, out SvnExternalItem[] extItems )
		{
            //SvnExternalItem[] extItems;
			extItems = new SvnExternalItem[0];
			{
				string externalsPropVal;
				if( !client.GetProperty( new SvnUriTarget( externalsHostUrl ), "svn:externals", out externalsPropVal ))
					return false;

				if( !String.IsNullOrEmpty( externalsPropVal ) )
				{

					if( !SvnExternalItem.TryParse( externalsPropVal, out extItems) )
						return false;
				}
			}
			return true;
		}

		public static bool WriteExternals( SvnClient client, string externalsHostUrl, SvnExternalItem[] extItems, long revision )
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
			args.BaseRevision = revision;
			args.LogMessage = "";
			if( !client.RemoteSetProperty( new Uri(externalsHostUrl), "svn:externals", externalsPropValue, args ) )
				return false;

			return true;
		}
	}




}
