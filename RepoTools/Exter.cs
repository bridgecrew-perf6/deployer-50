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

	}




}
