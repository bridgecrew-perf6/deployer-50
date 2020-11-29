using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSvn;

namespace Deployer.Repo
{
	/// <summary>
	/// Describes an installation package stored as a folder	in the repository
	/// </summary>
	public class DInst
	{
		DBase dBase;

		DInst( DBase dBase )
		{
			this.dBase = dBase;
		}

		//public enum EInstType
		//{
		//	Head,
		//	Candidate,
		//	Final
		//}

		//public EInstType InstType { get; }
		//public string VersionName { get; }
		
		
		//public string InstSegm = "IL/Holon/BigEnv1";
		//public string GetRootPath() => dBase.GetInstRootUrl(InstSegm);
	
	}
}
