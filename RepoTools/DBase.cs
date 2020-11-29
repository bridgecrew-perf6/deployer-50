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
		public string RepoRootUrl = @"D:\Work\svn\my-test-sandbox";

		string ShrSegm = "shared";
		string RelSegm = "release";
		string InstSegm = "install";

		public string GetSharedRootUrl(string ModuleName) => $"{RepoRootUrl}/{ShrSegm}/{ModuleName}";
		public string GetReleaseRootUrl() => $"{RepoRootUrl}/{RelSegm}";
		public string GetReleaseModuleUrl(string ModuleName) => $"{RepoRootUrl}/{RelSegm}/{ModuleName}";
		public string GetInstRootUrl(string instSubPath, string ModuleName) => $"{RepoRootUrl}/{InstSegm}/{instSubPath}/{ModuleName}";

		public SvnClient svnClient = new SvnClient();

	}
}
