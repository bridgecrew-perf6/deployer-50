using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
			lbReleases.DataSource = ctx.CurrentModuleReleases;
			lbInstalls.DataSource = ctx.Installs;

			// releases are shown for currently selected module
			lbModules.SelectedIndexChanged += (object sender, System.EventArgs e) =>
			{
				int index = lbModules.SelectedIndex;
				ctx.CurrentModule = ( index < 0 ) ? String.Empty : ctx.Modules[index];
				ctx.ReloadReleases();
			};

			lbReleases.SelectedIndexChanged += (object sender, System.EventArgs e) =>
			{
				int index = lbReleases.SelectedIndex;
				ctx.CurrentRelease = ( index < 0 ) ? String.Empty : ctx.CurrentModuleReleases[index];
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
	}
}
