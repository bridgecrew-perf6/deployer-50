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
			
			ctx.ScanRepo();
			
			lbModules.DataSource = ctx.Modules;
			lbReleases.DataSource = ctx.Releases;
			lbInstalls.DataSource = ctx.Installs;

			// releases are shown for currently selected module
			lbModules.SelectedIndexChanged += (object sender, System.EventArgs e) =>
			{
				int index = lbModules.SelectedIndex;
				ctx.ModuleIndex = index;
				ctx.ReloadReleases();
			};

			lbReleases.SelectedIndexChanged += (object sender, System.EventArgs e) =>
			{
				int index = lbReleases.SelectedIndex;
				ctx.ReleaseIndex = index;
				//ctx.ReloadXXX();
			};

		}

		public void ShowRel()
		{
			ctx.frmRel.Show();	
		}

		public void ShowInst()
		{
			ctx.frmInst.Show();
		}

		private void btnRel_Click(object sender, EventArgs e)
		{
			ShowRel();
		}

		private void btnInst_Click(object sender, EventArgs e)
		{
			ShowInst();
		}

		private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			ctx.Dispose();
		}

		private void button8_Click(object sender, EventArgs e)
		{

		}

		// url of given release for currently selected module
		string GetReleaseUrl( string relName )
		{
			string releaseBaseUrl = ctx.dBase.GetReleaseModuleUrl( ctx.Module ); 
			return $"{releaseBaseUrl}/{relName}";
		}


		private void btnNewRel_Click(object sender, EventArgs e)
		{
			var f = new FrmNewRel();
			f.Module = ctx.Module;
			f.SourceReleaseName = ctx.Release;
			var res = f.ShowDialog();
			if( res == DialogResult.OK )
			{
				string releaseBaseUrl = ctx.dBase.GetReleaseModuleUrl( ctx.Module ); 
				string srcReleaseName = ctx.Release;
				string destReleaseName = f.CompleteName;
				if( ReleaseMaker.Copy(
					ctx.dBase.svnClient, 
					GetReleaseUrl(srcReleaseName),
					GetReleaseUrl(destReleaseName),
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
					GetReleaseUrl(relToDelete)
				) )
				{
					ctx.ScanRepo();
				}
				return;
			}
		}
	}
}
