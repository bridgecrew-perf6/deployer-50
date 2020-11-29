using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployer.Repo
{
	// describes the release
	public class DRel
	{
		DBase dBase;

		public DRel( DBase dBase, ERelType type, string verName )
		{
			this.dBase = dBase;
			this.RelType = type;
			this.VersionName = verName;
		}

		public enum ERelType
		{
			Head,
			Candidate,
			Final
		}

		public ERelType RelType { get; }

		// Something like "2.0.1"
		// Expected to apper in svn repo <root>/IG/Candidate/<version>
		public string VersionName { get; }

		// "<root>/Releases/IG/Candidate/<version>"
		public string GetRootPath()
		{
			switch( RelType )
			{
				case ERelType.Head:
					return dBase.GetRelHeadRoot();
				case ERelType.Candidate:
					return $"{dBase.GetRelCandidateRoot()}/{VersionName}";
				case ERelType.Final:
					return $"{dBase.GetRelFinalRoot()}/{VersionName}";
			}
			return String.Empty;
		}

	}
}
