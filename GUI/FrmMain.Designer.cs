namespace Deployer
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lbModules = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbReleases = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lbInstalls = new System.Windows.Forms.ListBox();
			this.btnNewRel = new System.Windows.Forms.Button();
			this.btnRelRemove = new System.Windows.Forms.Button();
			this.btnPinInstallToRelease = new System.Windows.Forms.Button();
			this.btnAddInstall = new System.Windows.Forms.Button();
			this.btnRemoveInstall = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtRepoUrl = new System.Windows.Forms.TextBox();
			this.btnScanRepo = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLocalPath = new System.Windows.Forms.TextBox();
			this.btnCheckout = new System.Windows.Forms.Button();
			this.lbExternals = new System.Windows.Forms.ListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnEditExternals = new System.Windows.Forms.Button();
			this.btnEditModule = new System.Windows.Forms.Button();
			this.btnAddModule = new System.Windows.Forms.Button();
			this.cmdBrowseRepo = new System.Windows.Forms.Button();
			this.bsModules = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.bsModules)).BeginInit();
			this.SuspendLayout();
			// 
			// lbModules
			// 
			this.lbModules.FormattingEnabled = true;
			this.lbModules.HorizontalScrollbar = true;
			this.lbModules.ItemHeight = 24;
			this.lbModules.Location = new System.Drawing.Point(24, 117);
			this.lbModules.Name = "lbModules";
			this.lbModules.Size = new System.Drawing.Size(246, 172);
			this.lbModules.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "App Modules";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(306, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Releases";
			// 
			// lbReleases
			// 
			this.lbReleases.FormattingEnabled = true;
			this.lbReleases.HorizontalScrollbar = true;
			this.lbReleases.ItemHeight = 24;
			this.lbReleases.Items.AddRange(new object[] {
            "Head",
            "Candidate/2.0.7",
            "Candidate/2.1.0",
            "Final/2.0.7"});
			this.lbReleases.Location = new System.Drawing.Point(311, 117);
			this.lbReleases.Name = "lbReleases";
			this.lbReleases.Size = new System.Drawing.Size(426, 172);
			this.lbReleases.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(800, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "Installs";
			// 
			// lbInstalls
			// 
			this.lbInstalls.FormattingEnabled = true;
			this.lbInstalls.HorizontalScrollbar = true;
			this.lbInstalls.ItemHeight = 24;
			this.lbInstalls.Items.AddRange(new object[] {
            "CZ/Prague/MainEnv",
            "GE/Munich/BigIntegEnv1"});
			this.lbInstalls.Location = new System.Drawing.Point(806, 117);
			this.lbInstalls.Name = "lbInstalls";
			this.lbInstalls.Size = new System.Drawing.Size(246, 172);
			this.lbInstalls.TabIndex = 6;
			// 
			// btnNewRel
			// 
			this.btnNewRel.Location = new System.Drawing.Point(311, 303);
			this.btnNewRel.Name = "btnNewRel";
			this.btnNewRel.Size = new System.Drawing.Size(110, 44);
			this.btnNewRel.TabIndex = 8;
			this.btnNewRel.Text = "Add";
			this.btnNewRel.UseVisualStyleBackColor = true;
			this.btnNewRel.Click += new System.EventHandler(this.btnNewRel_Click);
			// 
			// btnRelRemove
			// 
			this.btnRelRemove.Location = new System.Drawing.Point(443, 303);
			this.btnRelRemove.Name = "btnRelRemove";
			this.btnRelRemove.Size = new System.Drawing.Size(114, 44);
			this.btnRelRemove.TabIndex = 9;
			this.btnRelRemove.Text = "Remove";
			this.btnRelRemove.UseVisualStyleBackColor = true;
			this.btnRelRemove.Click += new System.EventHandler(this.btnRelRemove_Click);
			// 
			// btnPinInstallToRelease
			// 
			this.btnPinInstallToRelease.Location = new System.Drawing.Point(1074, 117);
			this.btnPinInstallToRelease.Name = "btnPinInstallToRelease";
			this.btnPinInstallToRelease.Size = new System.Drawing.Size(117, 50);
			this.btnPinInstallToRelease.TabIndex = 8;
			this.btnPinInstallToRelease.Text = "Pin to release";
			this.btnPinInstallToRelease.UseVisualStyleBackColor = true;
			this.btnPinInstallToRelease.Click += new System.EventHandler(this.button8_Click);
			// 
			// btnAddInstall
			// 
			this.btnAddInstall.Location = new System.Drawing.Point(806, 303);
			this.btnAddInstall.Name = "btnAddInstall";
			this.btnAddInstall.Size = new System.Drawing.Size(98, 44);
			this.btnAddInstall.TabIndex = 8;
			this.btnAddInstall.Text = "Add";
			this.btnAddInstall.UseVisualStyleBackColor = true;
			// 
			// btnRemoveInstall
			// 
			this.btnRemoveInstall.Location = new System.Drawing.Point(923, 303);
			this.btnRemoveInstall.Name = "btnRemoveInstall";
			this.btnRemoveInstall.Size = new System.Drawing.Size(129, 44);
			this.btnRemoveInstall.TabIndex = 9;
			this.btnRemoveInstall.Text = "Remove";
			this.btnRemoveInstall.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Repo";
			// 
			// txtRepoUrl
			// 
			this.txtRepoUrl.Location = new System.Drawing.Point(85, 28);
			this.txtRepoUrl.Name = "txtRepoUrl";
			this.txtRepoUrl.Size = new System.Drawing.Size(840, 22);
			this.txtRepoUrl.TabIndex = 11;
			this.txtRepoUrl.Text = "http://svndist.server.com/projects/abcd";
			// 
			// btnScanRepo
			// 
			this.btnScanRepo.Location = new System.Drawing.Point(952, 28);
			this.btnScanRepo.Name = "btnScanRepo";
			this.btnScanRepo.Size = new System.Drawing.Size(100, 46);
			this.btnScanRepo.TabIndex = 8;
			this.btnScanRepo.Text = "Scan";
			this.btnScanRepo.UseVisualStyleBackColor = true;
			this.btnScanRepo.Click += new System.EventHandler(this.btnScanRepo_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(800, 390);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 17);
			this.label5.TabIndex = 3;
			this.label5.Text = "Local path";
			// 
			// txtLocalPath
			// 
			this.txtLocalPath.Location = new System.Drawing.Point(806, 418);
			this.txtLocalPath.Name = "txtLocalPath";
			this.txtLocalPath.Size = new System.Drawing.Size(234, 22);
			this.txtLocalPath.TabIndex = 11;
			this.txtLocalPath.Text = "C:\\IG";
			// 
			// btnCheckout
			// 
			this.btnCheckout.Enabled = false;
			this.btnCheckout.Location = new System.Drawing.Point(806, 462);
			this.btnCheckout.Name = "btnCheckout";
			this.btnCheckout.Size = new System.Drawing.Size(205, 46);
			this.btnCheckout.TabIndex = 8;
			this.btnCheckout.Text = "Checkout/Update";
			this.btnCheckout.UseVisualStyleBackColor = true;
			// 
			// lbExternals
			// 
			this.lbExternals.FormattingEnabled = true;
			this.lbExternals.HorizontalScrollbar = true;
			this.lbExternals.ItemHeight = 24;
			this.lbExternals.Items.AddRange(new object[] {
            "Bin/All",
            "Config",
            "Data/World",
            "Data/Terrains/T1",
            "Data/Models/M1",
            "Data/Sounds",
            "Specs/Sim",
            "Specs/Station"});
			this.lbExternals.Location = new System.Drawing.Point(24, 409);
			this.lbExternals.Name = "lbExternals";
			this.lbExternals.Size = new System.Drawing.Size(713, 220);
			this.lbExternals.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(19, 381);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(126, 17);
			this.label6.TabIndex = 3;
			this.label6.Text = "Shared Resources";
			// 
			// btnEditExternals
			// 
			this.btnEditExternals.Location = new System.Drawing.Point(230, 363);
			this.btnEditExternals.Name = "btnEditExternals";
			this.btnEditExternals.Size = new System.Drawing.Size(76, 40);
			this.btnEditExternals.TabIndex = 14;
			this.btnEditExternals.Text = "Edit";
			this.btnEditExternals.UseVisualStyleBackColor = true;
			this.btnEditExternals.Click += new System.EventHandler(this.btnEditExternals_Click);
			// 
			// btnEditModule
			// 
			this.btnEditModule.Enabled = false;
			this.btnEditModule.Location = new System.Drawing.Point(131, 303);
			this.btnEditModule.Name = "btnEditModule";
			this.btnEditModule.Size = new System.Drawing.Size(95, 44);
			this.btnEditModule.TabIndex = 9;
			this.btnEditModule.Text = "Edit";
			this.btnEditModule.UseVisualStyleBackColor = true;
			// 
			// btnAddModule
			// 
			this.btnAddModule.Enabled = false;
			this.btnAddModule.Location = new System.Drawing.Point(24, 303);
			this.btnAddModule.Name = "btnAddModule";
			this.btnAddModule.Size = new System.Drawing.Size(89, 44);
			this.btnAddModule.TabIndex = 8;
			this.btnAddModule.Text = "Add";
			this.btnAddModule.UseVisualStyleBackColor = true;
			// 
			// cmdBrowseRepo
			// 
			this.cmdBrowseRepo.Location = new System.Drawing.Point(1076, 28);
			this.cmdBrowseRepo.Name = "cmdBrowseRepo";
			this.cmdBrowseRepo.Size = new System.Drawing.Size(115, 46);
			this.cmdBrowseRepo.TabIndex = 15;
			this.cmdBrowseRepo.Text = "Browse";
			this.cmdBrowseRepo.UseVisualStyleBackColor = true;
			this.cmdBrowseRepo.Click += new System.EventHandler(this.cmdBrowseRepo_Click);
			// 
			// bsModules
			// 
			this.bsModules.DataSource = typeof(Deployer.Context);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1230, 664);
			this.Controls.Add(this.cmdBrowseRepo);
			this.Controls.Add(this.btnEditExternals);
			this.Controls.Add(this.txtLocalPath);
			this.Controls.Add(this.txtRepoUrl);
			this.Controls.Add(this.btnRemoveInstall);
			this.Controls.Add(this.btnRelRemove);
			this.Controls.Add(this.btnEditModule);
			this.Controls.Add(this.btnPinInstallToRelease);
			this.Controls.Add(this.btnCheckout);
			this.Controls.Add(this.btnAddInstall);
			this.Controls.Add(this.btnScanRepo);
			this.Controls.Add(this.btnNewRel);
			this.Controls.Add(this.btnAddModule);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbInstalls);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbReleases);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbExternals);
			this.Controls.Add(this.lbModules);
			this.Name = "FrmMain";
			this.Text = "Deployer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
			this.Load += new System.EventHandler(this.FrmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.bsModules)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListBox lbModules;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbReleases;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lbInstalls;
		private System.Windows.Forms.Button btnNewRel;
		private System.Windows.Forms.Button btnRelRemove;
		private System.Windows.Forms.Button btnPinInstallToRelease;
		private System.Windows.Forms.Button btnAddInstall;
		private System.Windows.Forms.Button btnRemoveInstall;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRepoUrl;
		private System.Windows.Forms.Button btnScanRepo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLocalPath;
		private System.Windows.Forms.Button btnCheckout;
		private System.Windows.Forms.ListBox lbExternals;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.BindingSource bsModules;
		private System.Windows.Forms.Button btnEditExternals;
		private System.Windows.Forms.Button btnEditModule;
		private System.Windows.Forms.Button btnAddModule;
		private System.Windows.Forms.Button cmdBrowseRepo;
	}
}

