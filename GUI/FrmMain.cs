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
