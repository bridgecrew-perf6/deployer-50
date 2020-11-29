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
	public partial class FrmInst : Form
	{
		public FrmInst()
		{
			InitializeComponent();
		}

		private void frmInst_FormClosing(object sender, FormClosingEventArgs e)
		{
			// no real closing, just hiding
			e.Cancel = true;
			this.Hide();

		}
	}
}
