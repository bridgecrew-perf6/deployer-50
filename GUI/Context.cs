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

        /// <summary>
        /// All existing modules
        /// </summary>
        public List<string> Modules = new List<string>();

        /// <summary>
        /// Releases for Current Module
        /// </summary>
        public List<string> CurrentModuleReleases = new List<string>();

        /// <summary>
        /// Currently selected dmodule
        /// </summary>
        public string CurrentModule;

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

        public void ScanRepo()
        {
            ModuleScanner.Scan( dBase.svnClient, dBase.GetReleaseRootUrl(), out Modules );
            
            // if current module still exists, reload its releases
            if( !String.IsNullOrEmpty( CurrentModule ) && Modules.Contains( CurrentModule ) )
            {
            }
            else if( Modules.Count > 0 )
            {
                CurrentModule = Modules[0];    
            }
            else
            {
                CurrentModule = String.Empty;
            }

            if( !String.IsNullOrEmpty( CurrentModule ) )
            {
                ReleaseScanner.Scan(
                    dBase.svnClient,
                    dBase.GetReleaseModuleUrl(CurrentModule),
                    out CurrentModuleReleases
                   );
            }

        }


	}
}                               
