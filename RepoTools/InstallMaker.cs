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
	public static class InstallMaker
	{
	    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

		public static bool LinkModule( SvnClient client, string installUrl, string moduleName, string releaseUrl )
		{
			// check if a link for given module exists at all
			SvnExternalItem[] extItems;
			if( !Exter.ReadExternals( client, installUrl, out extItems ) )
				return false;

			// if not, do not do anything
			// (adding a new module to an installation is too responsible operation to be done automatically)
			int foundAt = -1;
			for(int i=0; i < extItems.Length; i++)
			{
				if( extItems[i].Target == moduleName )
				{
					foundAt = i;
					break;
				}
			}

			if( foundAt < 0 ) // module not linked yet
				return true;

			SvnInfoEventArgs info;
			if( !client.GetInfo( new SvnUriTarget( installUrl ), out info ) )
				return false;
			
			// replace the link with a new one
			var ei = extItems[foundAt];
			var relativizedUrl = Exter.TryMakeRelativeReference( releaseUrl, info.RepositoryRoot.AbsoluteUri );
			var newEI = new SvnExternalItem( ei.Target, relativizedUrl );
			extItems[foundAt] = newEI;

			
			if( !Exter.WriteExternals( client, installUrl, extItems, info.Revision ) )
				return false;

			return true;
		}
	}




}
