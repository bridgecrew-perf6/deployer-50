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
	/// Describes an installation package stored as a folder	in the repository
	/// </summary>
	public class DBase
	{
		// http://svn.myserver.com/MyRepo/
		string RepoRoot = @"D:\Work\svn\my-test-sandbox";

		string ModuleName = "IG";
		string ShrSegm = "Shared";
		string RelHeadSegm = "Release/Head";
		string RelFinalSegm = "Release/Final";
		string RelCandidateSegm = "Release/Candidate";
		string InstSegm = "Install";

		public string GetShrRoot() => $"{RepoRoot}/{ShrSegm}/{ModuleName}";
		public string GetRelHeadRoot() => $"{RepoRoot}/{RelHeadSegm}/{ModuleName}";
		public string GetRelCandidateRoot() => $"{RepoRoot}/{RelCandidateSegm}/{ModuleName}";
		public string GetRelFinalRoot() => $"{RepoRoot}/{RelFinalSegm}/{ModuleName}";
		public string GetInstRoot(string instSubPath) => $"{RepoRoot}/{InstSegm}/{instSubPath}/{ModuleName}";

		public SvnClient svnClient = new SvnClient();

		public List<DRel> ScanRel()
		{
			var list = new List<DRel>();
			Collection<SvnListEventArgs> contents;
			if( svnClient.GetList( new Uri( GetRelCandidateRoot() ), out contents ) )
			{
				foreach(SvnListEventArgs item in contents)
				{
					var uri = new Uri( item.Path );
					var versionName = uri.Segments.LastOrDefault();
					if( !string.IsNullOrEmpty( versionName ) )
					{
						var dRel = new DRel( this, DRel.ERelType.Candidate, versionName );
						list.Add( dRel );
					}
				}				
			}

			return list;
		}
	}
}
