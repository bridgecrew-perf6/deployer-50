using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public BindingList<string> Modules = new BindingList<string>();

        /// <summary>
        /// Releases for Current Module
        /// </summary>
        public BindingList<string> CurrentModuleReleases = new BindingList<string>();

        /// <summary>
        /// Currently selected dmodule
        /// </summary>
        public string CurrentModule;

        /// <summary>
        /// Currently selected release
        /// </summary>
        public string CurrentRelease;


        public BindingList<string> Installs = new BindingList<string>();

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
            ReloadModules();
            ReloadReleases();
            ReloadInstalls();
        }

        public void ReloadModules()
        {
            List<string> modules;
            ModuleScanner.Scan( dBase.svnClient, dBase.GetReleaseRootUrl(), out modules );
            Modules.Clear();        
            foreach( var i in modules ) Modules.Add(i);

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
        }

        public void ReloadReleases()
        {
            if( !String.IsNullOrEmpty( CurrentModule ) )
            {
                List<string> releases;
                ReleaseScanner.Scan(
                    dBase.svnClient,
                    dBase.GetReleaseModuleUrl(CurrentModule),
                    out releases
                   );
                CurrentModuleReleases.Clear();
                foreach( var i in releases ) CurrentModuleReleases.Add(i);
            }
            else
            {
                CurrentModuleReleases.Clear();
            }


            // if current release still exist in the list, reload its releases
            if( !String.IsNullOrEmpty( CurrentRelease ) && CurrentModuleReleases.Contains( CurrentRelease ) )
            {
            }
            else if( Modules.Count > 0 )
            {
                CurrentRelease = CurrentModuleReleases[0];    
            }
            else
            {
                CurrentRelease = String.Empty;
            }
        }

        public void ReloadInstalls()
        {
            List<string> installs;
            InstallScanner.Scan(
                dBase.svnClient,
                dBase.GetInstallRootUrl(),
                out installs
            );

            Installs.Clear();
            foreach( var i in installs ) Installs.Add(i);
        }




	}
}                               
