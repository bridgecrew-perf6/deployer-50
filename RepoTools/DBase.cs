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
	/// Basic data elements describing the repository, URLs for main parts of the repo
	/// </summary>
	public class DBase
	{
		// http://svn.myserver.com/MyRepo/
		string _repoRootUrl = String.Empty;
		public string RepoRootUrl
		{
			get { return _repoRootUrl; }
			set {
				if( String.IsNullOrEmpty(value ) )
					_repoRootUrl = String.Empty;
				else					
				if( !value.EndsWith("/") )
					_repoRootUrl = value + "/";
				else
					_repoRootUrl = value;
			}
		}

		public readonly string ShrSegm = "shared";
		public readonly string RelSegm = "release";
		public readonly string InstSegm = "install";

		public string GetSharedRootUrl(string ModuleName) => $"{RepoRootUrl}{ShrSegm}/{ModuleName}";
		public string GetReleaseRootUrl() => $"{RepoRootUrl}{RelSegm}";
		public string GetReleaseModuleUrl(string ModuleName) => $"{RepoRootUrl}{RelSegm}/{ModuleName}";
		public string GetInstallRootUrl() => $"{RepoRootUrl}{InstSegm}";

		public SvnClient svnClient = new SvnClient();

		public bool IsRepoValid = false;
		
		public bool InitFromWCDir( string wcDir )
		{
			try
			{
				SvnInfoEventArgs info;
				if( svnClient.GetInfo( new SvnPathTarget(wcDir), out info ) )
				{
					RepoRootUrl = info.RepositoryRoot.AbsoluteUri;
					IsRepoValid = true;
					return true;
				}
			}
			catch( SvnException )
			{
			}
			IsRepoValid = false;
			return false;
		}

		public bool InitFromUrl( string repoUrl )
		{
			try
			{
				SvnInfoEventArgs info;
				if( svnClient.GetInfo( new SvnUriTarget(repoUrl), out info ) )
				{
					RepoRootUrl = info.RepositoryRoot.AbsoluteUri;
					IsRepoValid = true;
					return true;
				}
			}
			catch( SvnException )
			{
			}
			IsRepoValid = false;
			return false;
		}

		public bool RunTortoiseProc( string cmdLine )
		{
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
			startInfo.FileName = "TortoiseProc.exe";
			startInfo.Arguments = cmdLine;
			process.StartInfo = startInfo;
			return process.Start();
		}

	}
}
