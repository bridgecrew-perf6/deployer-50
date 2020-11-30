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
	/// Helper class to scan existing "application modules" in the repository
	/// </summary>
	public static class ModuleScanner
	{
		// App modules are searched under the "releases" area, as part of the url ending with one of "Head", "Candidate", "Final"
		//  releases/The/Module/Ends/Here/Head
		//  releases/The/Module/Ends/Here/Candidate/2.0.1
		//  releases/The/Module/Ends/Here/Final/2.0.1

		public static string[] Stoppers = new string[] { "head", "integration", "candidate", "final" };
		
		
		/// <param name="url">must point to the "releases" area of the repository</param>
		/// <returns>false on some error</returns>
		public static bool Scan( SvnClient client, string url, out List<string> modules )
		{
			return RepoScanner.ScanTillStopper( client, url, Stoppers, out modules );
		}


	}




}
