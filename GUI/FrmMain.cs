using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deployer.Repo;

namespace Deployer
{
	public partial class FrmMain : Form
	{
		Context ctx = Context.Instance;

		public FrmMain()
		{
			InitializeComponent();
			
			
			lbModules.DataSource = ctx.Modules;
			lbReleases.DataSource = ctx.Releases;
			lbInstalls.DataSource = ctx.Installs;
			lbReleaseExternals.DataSource = ctx.ReleaseExternals;
			lbInstallExternals.DataSource = ctx.InstallExternals;

			// releases are shown for currently selected module
			lbModules.SelectedIndexChanged += (object sender, System.EventArgs e) =>
			{
				int index = lbModules.SelectedIndex;
				ctx.ModuleIndex = index;
				ctx.ReloadReleases();
				ctx.ReloadReleaseExternals();
			};

			lbReleases.SelectedIndexChanged += (object sender, System.EventArgs e) =>
			{
				int index = lbReleases.SelectedIndex;
				ctx.ReleaseIndex = index;
				ctx.ReloadReleaseExternals();
			};

			lbInstalls.SelectedIndexChanged += (object sender, System.EventArgs e) =>
			{
				int index = lbInstalls.SelectedIndex;
				ctx.InstallIndex = index;
				ctx.ReloadInstallExternals();
			};

		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			txtRepoUrl.Text = ctx.dBase.RepoRootUrl;
			ctx.ScanRepo();
		}


		private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			ctx.Dispose();
		}


		private void btnNewRel_Click(object sender, EventArgs e)
		{
			var f = new FrmNewRel();
			f.Module = ctx.Module;
			f.SourceReleaseName = ctx.Release;
			var res = f.ShowDialog();
			if( res == DialogResult.OK )
			{
				string srcReleaseName = ctx.Release;
				string destReleaseName = f.CompleteName;
				if( ReleaseMaker.Copy(
					ctx.dBase.svnClient, 
					ctx.GetReleaseUrl(srcReleaseName),
					ctx.GetReleaseUrl(destReleaseName),
					f.PinType,
					destReleaseName
				) )
				{
					ctx.ScanRepo();
				}
			}
		}

		bool IsHeadRelease( string relName )
		{
			return relName.StartsWith("head/", StringComparison.OrdinalIgnoreCase);
		}

		private void btnRelRemove_Click(object sender, EventArgs e)
		{
			string relToDelete = ctx.Release;

			var numHeadReleases =
				(from x in ctx.Releases
				where IsHeadRelease( x )
				select x).Count();

			if( IsHeadRelease(relToDelete) && numHeadReleases == 1 )
			{
				MessageBox.Show("Can't remove the last head release", "Deployer", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}


			if( MessageBox.Show(
					$"Really remove release '{relToDelete}' of module '{ctx.Module}'?"
					, "Deployer"
					, MessageBoxButtons.OKCancel
					, MessageBoxIcon.Question
				) == DialogResult.OK )
			{
				if( ReleaseMaker.Delete(
					ctx.dBase.svnClient, 
					ctx.GetReleaseUrl(relToDelete)
				) )
				{
					ctx.ScanRepo();
				}
				return;
			}
		}

		private void btnScanRepo_Click(object sender, EventArgs e)
		{
			string repoUrl = txtRepoUrl.Text.Trim();
			if( !String.IsNullOrWhiteSpace( repoUrl ) )
			{
				if( ctx.dBase.InitFromUrl( repoUrl ) )
				{
					ctx.ScanRepo();
				}
			}
		}

		private void btnEditReleaseExternals_Click(object sender, EventArgs e)
		{
			// /command:properties /path:"file:///D:/Work/svn/xxx/repo/releases/IG/Head" /property:svn:externals	
			string url = ctx.GetReleaseUrl( ctx.Release );
			//string cmdLine = $"/command:properties /path:\"{url}\" /property:svn:externals";
			string cmdLine = $"/command:repobrowser /path:\"{url}\"";
			ctx.dBase.RunTortoiseProc( cmdLine );
		}

		private void cmdBrowseRepo_Click(object sender, EventArgs e)
		{
			string repoUrl = txtRepoUrl.Text;
			string cmdLine = $"/command:repobrowser /path:\"{repoUrl}\"";
			ctx.dBase.RunTortoiseProc( cmdLine );
		}

		private void btnEditInstallExternals_Click(object sender, EventArgs e)
		{
			string url = ctx.GetInstallUrl( ctx.Install );
			//string cmdLine = $"/command:properties /path:\"{url}\" /property:svn:externals";
			string cmdLine = $"/command:repobrowser /path:\"{url}\"";
			ctx.dBase.RunTortoiseProc( cmdLine );
		}

		private void btnPinInstallToRelease_Click(object sender, EventArgs e)
		{
			InstallMaker.LinkModule(
				ctx.dBase.svnClient, 
				ctx.GetInstallUrl( ctx.Install ),
				ctx.Module,
				ctx.GetReleaseUrl( ctx.Release )
			);
			ctx.ReloadInstallExternals();
		}

		private void btnCheckout_Click(object sender, EventArgs e)
		{
			string installUrl = ctx.GetInstallUrl( ctx.Install );
			string cmdLine = $"/command:checkout /url:\"{installUrl}\"";
			ctx.dBase.RunTortoiseProc( cmdLine );
		}
	}
}
