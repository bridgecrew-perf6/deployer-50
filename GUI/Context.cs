using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deployer.Repo;

namespace Deployer
{
	public class Context : IDisposable
	{
		public DBase dBase = new DBase();
		public FrmRel frmRel = new FrmRel();
		public FrmInst frmInst = new FrmInst();

        public void Dispose()
        {
            frmRel.Dispose();
            frmRel = null;
            frmInst.Dispose();
            frmInst = null;
        }

        // singleton pattern
		private static Context instance=null;

        private Context()
        {
        }

        public static Context Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Context();
                }
                return instance;
            }
        }

	}
}
