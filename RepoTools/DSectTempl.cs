using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSvn;

namespace Deployer.Repo
{
	/// <summary>
	/// Template of a directory/folder structure (stored somewhere in a repo)
	/// and with a list of externals to be applied to this structure
	/// in different ways (as follow-head externals, as revision-pinned externals, as tag externals..)
	/// </summary>
	public class DSectTempl
	{
		public string ContentUrl; // full svn url to the root of the template directory structure
		public ExtDefList Externals = new ExtDefList(); // externals associated with this template
		
		public bool LoadFromRepo( SvnClient client, string url )
		{
			// read the "externals.xml" file
			// get url to the "Content" subdirectory
			ContentUrl = $"{url}/Content";
			
			var externalsUri = new SvnUriTarget(url, SvnRevisionType.Head);
			var stream = new System.IO.MemoryStream();
			if( client.Write( externalsUri, stream ) )
			{
				if( Externals.LoadFromXMLStream( stream ) )
				{
					return true;
				}
			}
			return false;
		}
	}
}
