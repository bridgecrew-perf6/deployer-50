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
	/// Helper class to scan existing "installations" in the repository
	/// </summary>
	public static class InstallScanner
	{
		// Istallations are searched under the "installs" area, as part of the url ending with one of "Head", "Candidate", "Final"
		//  install/The/Site/Name/Ends/Here/trunk
		//  install/The/Site/Name/Ends/Here/branches
		//  install/The/Site/Name/Ends/Here/tags

		/// <param name="url">must point to the "install" area of the repository</param>
		/// <returns>false on some error</returns>
		public static bool Scan( SvnClient client, string url, out List<string> installs )
		{
			string[] stoppers = new string[] { "trunk", "branches", "tags" };
			return RepoScanner.ScanTillStopper( client, url, stoppers, out installs );
		}
	}




}
