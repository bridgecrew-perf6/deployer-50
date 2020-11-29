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
	/// List of externals to be appliead to a folder tree.
	/// </summary>
	public class ExtDefList
	{
		public List<ExtDef> Externals = new List<ExtDef>();

		public bool LoadFromXMLStream( Stream stream )
		{
			Externals.Clear();
			var xdoc = XDocument.Load( stream );
			foreach( var xelem in xdoc.Root.Elements() )
			{
				var ext = new ExtDef();
				if( !ext.LoadFromXElem( xelem ) )
					return false;
				Externals.Add( ext );
			}
			return true;
		}

		// Installs all externals to a folder structure pointed bu given url
		public void Install( SvnClient client, string url, ExtDef.InstCmd cmd )
		{
			foreach( var ext in Externals )
			{
				ext.Install( client, url, ext, cmd );
			}
		}
	}




}
