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
	public partial class FrmNewRel : Form
	{
		/// <summary>
		/// What module	we are creatimg the release for	(input)
		/// </summary>
		public string Module = String.Empty;

		/// <summary>
		/// Full name of the source release we are copying from (input)
		/// </summary>
		public string SourceReleaseName = String.Empty;
	
		/// <summary>
		/// The full resulting name (output)
		/// </summary>
		public string CompleteName = String.Empty;

		/// <summary>
		/// Pin-style of the externals to shared resources (output)
		/// </summary>
		public Exter.EPinType PinType = Exter.EPinType.Invalid;

		public FrmNewRel()
		{
			InitializeComponent();

			var releaseTypes = new List<string>( RepoScanner.ModuleStoppers );
			cbType.DataSource = releaseTypes;
			cbType.SelectedValueChanged += (object sender, EventArgs e) => { UpdateResult(); };
			txtName.TextChanged += (object sender, EventArgs e) => { UpdateResult(); };
		}

		private void FrmNewRel_Load(object sender, EventArgs e)
		{
			txtDerivedFrom.Text = SourceReleaseName;
			UpdateResult();
		}

		void UpdateResult()
		{
			
			var relType = cbType.Text;
			var relName = txtName.Text;

			CompleteName =  relType + "/" + relName;
			PinType = ReleaseTypeToPinType( relType );

			txtComplateName.Text = CompleteName;
		}

		Exter.EPinType ReleaseTypeToPinType( string relType )
		{
			switch( relType.ToLower() )
			{
				case "head": return Exter.EPinType.Head;
				case "integration": return Exter.EPinType.Peg;
				case "candidate": return Exter.EPinType.Branch;
				case "final": return Exter.EPinType.Tag;
			}
			return Exter.EPinType.Invalid;
		}

	}
}
