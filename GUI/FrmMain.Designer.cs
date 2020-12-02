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
			this.label4 = new System.Windows.Forms.Label();
			this.txtRepoUrl = new System.Windows.Forms.TextBox();
			this.btnScanRepo = new System.Windows.Forms.Button();
			this.btnCheckout = new System.Windows.Forms.Button();
			this.lbReleaseExternals = new System.Windows.Forms.ListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnEditReleaseExternals = new System.Windows.Forms.Button();
			this.btnEditModule = new System.Windows.Forms.Button();
			this.btnAddModule = new System.Windows.Forms.Button();
			this.cmdBrowseRepo = new System.Windows.Forms.Button();
			this.lbInstallExternals = new System.Windows.Forms.ListBox();
			this.btnEditInstallExternals = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
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
			this.lbInstalls.Size = new System.Drawing.Size(385, 172);
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
			this.btnPinInstallToRelease.Location = new System.Drawing.Point(806, 300);
			this.btnPinInstallToRelease.Name = "btnPinInstallToRelease";
			this.btnPinInstallToRelease.Size = new System.Drawing.Size(141, 50);
			this.btnPinInstallToRelease.TabIndex = 8;
			this.btnPinInstallToRelease.Text = "Pin to release";
			this.btnPinInstallToRelease.UseVisualStyleBackColor = true;
			this.btnPinInstallToRelease.Click += new System.EventHandler(this.btnPinInstallToRelease_Click);
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
			// btnCheckout
			// 
			this.btnCheckout.Location = new System.Drawing.Point(1050, 300);
			this.btnCheckout.Name = "btnCheckout";
			this.btnCheckout.Size = new System.Drawing.Size(141, 46);
			this.btnCheckout.TabIndex = 8;
			this.btnCheckout.Text = "Checkout";
			this.btnCheckout.UseVisualStyleBackColor = true;
			this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
			// 
			// lbReleaseExternals
			// 
			this.lbReleaseExternals.FormattingEnabled = true;
			this.lbReleaseExternals.HorizontalScrollbar = true;
			this.lbReleaseExternals.ItemHeight = 24;
			this.lbReleaseExternals.Items.AddRange(new object[] {
            "Bin/All",
            "Config",
            "Data/World",
            "Data/Terrains/T1",
            "Data/Models/M1",
            "Data/Sounds",
            "Specs/Sim",
            "Specs/Station"});
			this.lbReleaseExternals.Location = new System.Drawing.Point(24, 409);
			this.lbReleaseExternals.Name = "lbReleaseExternals";
			this.lbReleaseExternals.Size = new System.Drawing.Size(713, 220);
			this.lbReleaseExternals.TabIndex = 2;
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
			// btnEditReleaseExternals
			// 
			this.btnEditReleaseExternals.Location = new System.Drawing.Point(230, 363);
			this.btnEditReleaseExternals.Name = "btnEditReleaseExternals";
			this.btnEditReleaseExternals.Size = new System.Drawing.Size(76, 40);
			this.btnEditReleaseExternals.TabIndex = 14;
			this.btnEditReleaseExternals.Text = "Edit";
			this.btnEditReleaseExternals.UseVisualStyleBackColor = true;
			this.btnEditReleaseExternals.Click += new System.EventHandler(this.btnEditReleaseExternals_Click);
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
			// lbInstallExternals
			// 
			this.lbInstallExternals.FormattingEnabled = true;
			this.lbInstallExternals.HorizontalScrollbar = true;
			this.lbInstallExternals.ItemHeight = 24;
			this.lbInstallExternals.Items.AddRange(new object[] {
            "Bin/All",
            "Config",
            "Data/World",
            "Data/Terrains/T1",
            "Data/Models/M1",
            "Data/Sounds",
            "Specs/Sim",
            "Specs/Station"});
			this.lbInstallExternals.Location = new System.Drawing.Point(806, 409);
			this.lbInstallExternals.Name = "lbInstallExternals";
			this.lbInstallExternals.Size = new System.Drawing.Size(394, 220);
			this.lbInstallExternals.TabIndex = 16;
			// 
			// btnEditInstallExternals
			// 
			this.btnEditInstallExternals.Location = new System.Drawing.Point(1005, 363);
			this.btnEditInstallExternals.Name = "btnEditInstallExternals";
			this.btnEditInstallExternals.Size = new System.Drawing.Size(76, 40);
			this.btnEditInstallExternals.TabIndex = 18;
			this.btnEditInstallExternals.Text = "Edit";
			this.btnEditInstallExternals.UseVisualStyleBackColor = true;
			this.btnEditInstallExternals.Click += new System.EventHandler(this.btnEditInstallExternals_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(799, 381);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 17);
			this.label5.TabIndex = 17;
			this.label5.Text = "App Modules Linked";
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
			this.Controls.Add(this.btnEditInstallExternals);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbInstallExternals);
			this.Controls.Add(this.cmdBrowseRepo);
			this.Controls.Add(this.btnEditReleaseExternals);
			this.Controls.Add(this.txtRepoUrl);
			this.Controls.Add(this.btnRelRemove);
			this.Controls.Add(this.btnEditModule);
			this.Controls.Add(this.btnPinInstallToRelease);
			this.Controls.Add(this.btnCheckout);
			this.Controls.Add(this.btnScanRepo);
			this.Controls.Add(this.btnNewRel);
			this.Controls.Add(this.btnAddModule);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbInstalls);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbReleases);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbReleaseExternals);
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRepoUrl;
		private System.Windows.Forms.Button btnScanRepo;
		private System.Windows.Forms.Button btnCheckout;
		private System.Windows.Forms.ListBox lbReleaseExternals;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.BindingSource bsModules;
		private System.Windows.Forms.Button btnEditReleaseExternals;
		private System.Windows.Forms.Button btnEditModule;
		private System.Windows.Forms.Button btnAddModule;
		private System.Windows.Forms.Button cmdBrowseRepo;
		private System.Windows.Forms.ListBox lbInstallExternals;
		private System.Windows.Forms.Button btnEditInstallExternals;
		private System.Windows.Forms.Label label5;
	}
}

