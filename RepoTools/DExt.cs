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
	/// Description of a generalized link to a shared resource
	/// Also how to install the link in various ways
	/// </summary>
	public class ExtDef
	{
		public string LocalPath; // local subpath of the repo section the external
		public string Target; // the directory to be created in the local path
		public string BaseUrl; // the base not including the final part

		public bool LoadFromXElem( XElement xelem )
		{
			LocalPath = xelem.Attribute("LocalPath").Value;
			Target = xelem.Attribute("Target").Value;
			BaseUrl = xelem.Attribute("BaseUrl").Value;
			return true;
		}

		public enum EInstallMode
		{
			Head, // simple head-following external
			PinToRev, // external pinned to a concrete revision
			Tag
		}

		/// <summary>
		/// Describes the way how to instal the link to a base url
		/// </summary>
		public class InstCmd
		{
			public EInstallMode Mode;
			public int Revision;
			public int Tag;
		}

		public SvnExternalItem GetExtItem( ExtDef extDef, InstCmd cmd )
		{
			switch( cmd.Mode )
			{
				case EInstallMode.Head:
					return new SvnExternalItem( extDef.Target, $"{extDef.BaseUrl}/trunk" );
				case EInstallMode.PinToRev:
					return new SvnExternalItem( extDef.Target, $"{extDef.BaseUrl}/trunk", new SvnRevision(cmd.Revision), null);
				case EInstallMode.Tag:
					return new SvnExternalItem( extDef.Target, $"{extDef.BaseUrl}/tags/{cmd.Tag}");
			}
			return null;
		}

		/// <summary>
		/// Installs the external def to given base url (not including trunk/branches/tags)
		/// </summary>
		public bool Install( SvnClient client, string baseUrl, ExtDef extDef, InstCmd cmd )
		{
			string url = baseUrl + "/" + extDef.LocalPath;

			// get the base revision we will set the property to
			SvnInfoEventArgs info;
			if( !client.GetInfo( new Uri(url), out info) )
				return false;

			//  - get svn:external property
			string value;
			if (!client.GetProperty( new SvnUriTarget(url), "svn:externals", out value))
				return false;

			//  - parse each line of it
            SvnExternalItem[] items;
            if( !SvnExternalItem.TryParse( value, out items) )
				return false;

			// 	- if found one with matching target, replace with new value
			//  - if not found, add new line with new value at the end
			int foundAt = -1;
			for( int i=0; i < items.Length; i++ )
			{
				var ei = items[i];

				if( String.Equals( ei.Target, extDef.Target, StringComparison.OrdinalIgnoreCase ) )
				{
					foundAt = i;
					break;
				}
			}
			
			var newExtItem = GetExtItem( extDef, cmd ); 

			if( foundAt >= 0 )
			{
				items[foundAt] = newExtItem;
			}
			else
			{
				Array.Resize(ref items, items.Length + 1);	
				items[items.Length-1] = newExtItem;
			}

			// reassemble value from parsed items
			var sb = new StringBuilder();
			foreach( var ei in items )
			{
				ei.WriteTo( sb, false );
				sb.Append("\r\n");
			}

			//  - set svn:external property back to given url + ext.LocalPath
			var newValue = sb.ToString();
			var args = new SvnSetPropertyArgs();
			args.BaseRevision = info.Revision;
			args.LogMessage = "";
			//if( !client.SetProperty( new Uri(url), "svn:externals", newValue, args ) )
			if( !client.RemoteSetProperty( new Uri(url), "svn:externals", newValue, args ) )
				return false;

			return true;
		}
	}




}
