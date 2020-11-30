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
        public BindingList<string> Releases = new BindingList<string>();

        /// <summary>
        /// Externals for current release of current module
        /// </summary>
        public BindingList<string> Externals = new BindingList<string>();


        public int ModuleIndex;

        /// <summary>
        /// Currently selected dmodule
        /// </summary>
        public string Module
        {
            get{
                if( ModuleIndex < 0 || ModuleIndex >= Modules.Count )
                    return String.Empty;
                return Modules[ModuleIndex];
            }
            set{

                ModuleIndex = Modules.IndexOf( value );
            }
        }

        public int ReleaseIndex;

        /// <summary>
        /// Currently selected release
        /// </summary>
        public string Release
        {
            get{
                if( ReleaseIndex < 0 ||ReleaseIndex >= Releases.Count )
                    return String.Empty;
                return Releases[ReleaseIndex];
            }
            set{

                ReleaseIndex = Releases.IndexOf( value );
            }
        }

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

		 
         /// <summary>
         /// url of given release for currently selected module
         /// </summary>
		public string GetReleaseUrl( string relName )
		{
			string releaseBaseUrl = dBase.GetReleaseModuleUrl( Module ); 
			return $"{releaseBaseUrl}/{relName}";
		}

        public void ScanRepo()
        {
            ReloadModules();
            ReloadReleases();
            ReloadExternals();
            ReloadInstalls();
        }

        public void ReloadModules()
        {
            string prevModule = Module;

            List<string> modules;
            ModuleScanner.Scan( dBase.svnClient, dBase.GetReleaseRootUrl(), out modules );
            Modules.Clear();        
            foreach( var i in modules ) Modules.Add(i);

            // if current module still exists, reload its releases
            if( !String.IsNullOrEmpty( prevModule ) && Modules.Contains( prevModule ) )
            {
                ModuleIndex = Modules.IndexOf( prevModule );
            }
            else if( Modules.Count > 0 )
            {
                ModuleIndex = 0;    
            }
            else
            {
                ModuleIndex = -1;
            }
        }

        public void ReloadReleases()
        {
            string prevRelease = Release;

            if( !String.IsNullOrEmpty( Module ) )
            {
                List<string> releases;
                ReleaseScanner.Scan(
                    dBase.svnClient,
                    dBase.GetReleaseModuleUrl(Module),
                    out releases
                   );
                Releases.Clear();
                foreach( var i in releases ) Releases.Add(i);
            }
            else
            {
                Releases.Clear();
            }


            // if current release still exist in the list, reload its releases
            if( !String.IsNullOrEmpty( prevRelease ) && Releases.Contains( prevRelease ) )
            {
                ReleaseIndex = Releases.IndexOf( prevRelease );
            }
            else if( Releases.Count > 0 )
            {
                ReleaseIndex = 0;    
            }
            else
            {
                ReleaseIndex = -1;
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

        public void ReloadExternals()
        {
            Externals.Clear();
            if( !String.IsNullOrEmpty( Release ) )
            {
                SharpSvn.SvnExternalItem[] extItems;
                ReleaseMaker.GetExternals(
                    dBase.svnClient, 
                    GetReleaseUrl( Release ),
                    out extItems
                );

                foreach( var i in extItems )
                {
                    var s = "";
                    if( i.Revision.RevisionType == SharpSvn.SvnRevisionType.Number )
                    {
                        s = $"{i.Target} => {i.Reference}@{i.Revision.Revision}";
                    }
                    else
                    {
                        s = $"{i.Target} => {i.Reference}";
                    }

                    Externals.Add( s );
                }
            }

        }



	}
}                               
