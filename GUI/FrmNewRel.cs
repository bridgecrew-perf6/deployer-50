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
		public Repo.ReleaseMaker.EPinType PinType = Repo.ReleaseMaker.EPinType.Invalid;

		public FrmNewRel()
		{
			InitializeComponent();

			var releaseTypes = new List<string>( Repo.ModuleScanner.Stoppers );
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

		Repo.ReleaseMaker.EPinType ReleaseTypeToPinType( string relType )
		{
			switch( relType.ToLower() )
			{
				case "head": return Repo.ReleaseMaker.EPinType.Head;
				case "integration": return Repo.ReleaseMaker.EPinType.Peg;
				case "candidate": return Repo.ReleaseMaker.EPinType.Branch;
				case "final": return Repo.ReleaseMaker.EPinType.Tag;
			}
			return Repo.ReleaseMaker.EPinType.Invalid;
		}

	}
}
