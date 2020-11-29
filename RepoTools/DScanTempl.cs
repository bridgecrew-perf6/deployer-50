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
	/// <summary>
	/// Helper class to scan existing "application module templates" in the repository
	/// </summary>
	public static class TemplateScanner
	{

		/// <summary>
		/// Returns a list in templates found under given rootUrl in the repository
		/// </summary>
		/// <param name="rootUrl">must point to the "templates" area of the repository</param>
		/// <returns>false on some error</returns>
		/// <remarks>
		/// Templates are searched under the "templates" area, as part of the url ending with  "Content"
		///  templates/The/Template/Ends/Here/Content
		/// </remarks>
		public static bool Scan( SvnClient client, string rootUrl, out List<string> modules )
		{
			string[] stoppers = new string[] { "Content" };
			return RepoScanner.Scan( client, rootUrl, stoppers, out modules );
		}

		
		/// <summary>
		/// Returns a list of external definitions read from the template in the repository
		/// </summary>
		public static bool GetExtDefs( SvnClient client, string templateUrl, out ExtDefList list )
		{
			list = new ExtDefList();

			// read the "externals.xml" file
			var externalsUrl = $"{templateUrl}/externals.xml";
			var externalsUri = new SvnUriTarget(externalsUrl, SvnRevisionType.Head);
			var stream = new System.IO.MemoryStream();
			if( client.Write( externalsUri, stream ) )
			{
				stream.Seek(0, SeekOrigin.Begin);
				if( list.LoadFromXMLStream( stream ) )
				{
					return true;
				}
			}
			return false;
		}


	}




}
