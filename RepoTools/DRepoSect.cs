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
	/// Manages subpart of a SVN repository using Template
	/// </summary>
	public class DRepoSect
	{
		/// <summary>
		/// Creates the section in the repository by
		///   1. copying the template content
		///   2. applying the externals
		/// 
		/// </summary>
		//public bool Create( string url, DSectTempl templ,  )
		//{
		//}

		public enum EExtApplyMode
		{
			Head, // simple head-following external
			PinToRev, // external pinned to a concrete revision
			Tag
		}

		public struct ExtApplySpec
		{
			public EExtApplyMode Mode;
			public int Revision; // used for PinToRev
		}

		//public void ApplyExternals( DExtList extList
	}
}
