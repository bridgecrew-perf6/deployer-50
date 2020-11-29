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

		// Something like "candidate/2.0.1"
		// Expected to apper in svn repo <root>/release/IG/
		public string Name { get; }

		public DRel( DBase dBase, string name )
		{
			this.dBase = dBase;
			this.Name = name;
		}

	}
}
