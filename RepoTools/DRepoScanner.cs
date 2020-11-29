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
	/// Helper class to scan existing subpaths in the repository that end with a set of given "stoppers"
	/// The stopper is NOT included
	/// </summary>
	public static class RepoScanner
	{
		// App modules are searched under the "releases" area, as part of the url ending with one of "Head", "Candidate", "Final"
		//  releases/The/Module/Ends/Here/Head
		//  releases/The/Module/Ends/Here/Candidate/2.0.1
		//  releases/The/Module/Ends/Here/Final/2.0.1

		/// <param name="url">must point to the "installs" area of the repository</param>
		/// <returns>false on some error</returns>
		public static bool ScanTillStopper( SvnClient client, string baseUrl, string[] stoppers, out List<string> subPaths )
		{
			subPaths = new List<string>();	

			if( !CheckChildrenForStoppers( client, new Uri( baseUrl ), "", stoppers, ref subPaths ) )
				return false;

			return true;
		}

		// lists immediate children; checks if one of them is a stopper
		public static bool CheckChildrenForStoppers( SvnClient client, Uri uri, string subPath, string[] stoppers, ref List<string> modules )
		{
			Collection<SvnListEventArgs> list;
			SvnListArgs args = new SvnListArgs();
			args.Depth = SvnDepth.Children;
			args.IncludeExternals = false;
			if( !client.GetList( new SvnUriTarget( uri ), args, out list ) )
				return false;

			bool first = true;
			foreach( var li in list )
			{
				// skip first item as it is the base directory
				if( first )
				{
					first = false;
					continue;
				}

				if( li.Entry.NodeKind == SvnNodeKind.Directory )
				{
					if( IsStopper( li.Name, stoppers ) )
					{
						// found a stopper, stop recursion
						modules.Add( subPath );
						return true;
					}

					// continue recursion
					var childrenSubPath = String.IsNullOrEmpty(subPath) ? li.Name : $"{subPath}/{li.Name}";
					if( !CheckChildrenForStoppers( client, li.Uri, childrenSubPath, stoppers, ref modules ) )
						return false;
				}
			}
			
			return true;
		}

		public static bool IsStopper( string name, string[] stoppers )
		{
			foreach( var s in stoppers )
			{
				if( name.StartsWith( s, StringComparison.OrdinalIgnoreCase ) )
				{
					return true;
				}
			}
			return false;
		}


		public static bool EndsWithStopper( string path, string[] stoppers )
		{
			// does it end with one of the stoppers?
			int stopperFoundAt = -1;
			var segments = path.Split( new char[] {'/'} );
			for( int i=0; i < segments.Length; i++ )
			{
				foreach( var s in stoppers )
				{
					if( segments[i].StartsWith( s, StringComparison.OrdinalIgnoreCase ) )
					{
						stopperFoundAt = i;
						break;
					}
				}
				if( stopperFoundAt >= 0 ) break;
			}

			if( stopperFoundAt >= 0 )
			{
				return true;		
			}

			return false;
		}


		/// <summary>
		/// Scans from given root till the leaf directory.
		/// Under the root there must be at least two levels (intermediat and final).
		/// The names returned contain all the levels
		/// </summary>
		/// <returns>true if succefull (results list filled)</returns>
		public static bool ScanTillLeaf( SvnClient client, string baseUrl, int minDepth, out List<string> results )
		{
			results = new List<string>();	

			if( !CheckChildrenLeaf( client, new Uri( baseUrl ), "", 0, minDepth, ref results ) )
				return false;

			return true;
		}

		// lists immediate children;
		// if no one found (leaf) and depth >= minLevel, add the path to the result
		public static bool CheckChildrenLeaf( SvnClient client, Uri uri, string subPath, int depth, int minDepth, ref List<string> results )
		{
			Collection<SvnListEventArgs> list;
			SvnListArgs args = new SvnListArgs();
			args.Depth = SvnDepth.Children;
			args.IncludeExternals = false;
			if( !client.GetList( new SvnUriTarget( uri ), args, out list ) )
				return false;

			// if leaf
			if( list.Count <= 1 )
			{
				if( depth >= minDepth )
				{
					results.Add( subPath );
				}
				return true;
			}

			bool first = true;
			foreach( var li in list )
			{
				// skip first item as it is the base directory
				if( first )
				{
					first = false;
					continue;
				}

				if( li.Entry.NodeKind == SvnNodeKind.Directory )
				{
					// continue recursion
					var childrenSubPath = String.IsNullOrEmpty(subPath) ? li.Name : $"{subPath}/{li.Name}";
					var childrenDepth = depth + 1;
					if( !CheckChildrenLeaf( client, li.Uri, childrenSubPath, childrenDepth, minDepth, ref results ) )
						return false;
				}
			}
			
			return true;
		}
	}




}
