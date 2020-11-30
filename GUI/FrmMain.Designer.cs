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
			this.btnRel = new System.Windows.Forms.Button();
			this.btnInst = new System.Windows.Forms.Button();
			this.lbModules = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbReleases = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lbInstalls = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btnNewRel = new System.Windows.Forms.Button();
			this.btnRelRemove = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button11 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button12 = new System.Windows.Forms.Button();
			this.listBox4 = new System.Windows.Forms.ListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button14 = new System.Windows.Forms.Button();
			this.bsModules = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.bsModules)).BeginInit();
			this.SuspendLayout();
			// 
			// btnRel
			// 
			this.btnRel.Location = new System.Drawing.Point(1761, 86);
			this.btnRel.Name = "btnRel";
			this.btnRel.Size = new System.Drawing.Size(143, 68);
			this.btnRel.TabIndex = 0;
			this.btnRel.Text = "Releases";
			this.btnRel.UseVisualStyleBackColor = true;
			this.btnRel.Click += new System.EventHandler(this.btnRel_Click);
			// 
			// btnInst
			// 
			this.btnInst.Location = new System.Drawing.Point(1761, 176);
			this.btnInst.Name = "btnInst";
			this.btnInst.Size = new System.Drawing.Size(143, 68);
			this.btnInst.TabIndex = 1;
			this.btnInst.Text = "Installs";
			this.btnInst.UseVisualStyleBackColor = true;
			this.btnInst.Click += new System.EventHandler(this.btnInst_Click);
			// 
			// lbModules
			// 
			this.lbModules.FormattingEnabled = true;
			this.lbModules.ItemHeight = 24;
			this.lbModules.Location = new System.Drawing.Point(26, 158);
			this.lbModules.Name = "lbModules";
			this.lbModules.Size = new System.Drawing.Size(246, 172);
			this.lbModules.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 129);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 25);
			this.label1.TabIndex = 3;
			this.label1.Text = "App Modules";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(331, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 25);
			this.label2.TabIndex = 5;
			this.label2.Text = "Releases";
			// 
			// lbReleases
			// 
			this.lbReleases.FormattingEnabled = true;
			this.lbReleases.ItemHeight = 24;
			this.lbReleases.Items.AddRange(new object[] {
            "Head",
            "Candidate/2.0.7",
            "Candidate/2.1.0",
            "Final/2.0.7"});
			this.lbReleases.Location = new System.Drawing.Point(336, 158);
			this.lbReleases.Name = "lbReleases";
			this.lbReleases.Size = new System.Drawing.Size(246, 172);
			this.lbReleases.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(639, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 25);
			this.label3.TabIndex = 7;
			this.label3.Text = "Installs";
			// 
			// lbInstalls
			// 
			this.lbInstalls.FormattingEnabled = true;
			this.lbInstalls.ItemHeight = 24;
			this.lbInstalls.Items.AddRange(new object[] {
            "CZ/Brno/MainEnv",
            "IL/Holon/BigIntegEnv1"});
			this.lbInstalls.Location = new System.Drawing.Point(645, 158);
			this.lbInstalls.Name = "lbInstalls";
			this.lbInstalls.Size = new System.Drawing.Size(246, 172);
			this.lbInstalls.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(26, 344);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(89, 44);
			this.button1.TabIndex = 8;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(133, 344);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(95, 44);
			this.button2.TabIndex = 9;
			this.button2.Text = "Edit";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// btnNewRel
			// 
			this.btnNewRel.Location = new System.Drawing.Point(336, 344);
			this.btnNewRel.Name = "btnNewRel";
			this.btnNewRel.Size = new System.Drawing.Size(110, 44);
			this.btnNewRel.TabIndex = 8;
			this.btnNewRel.Text = "Add";
			this.btnNewRel.UseVisualStyleBackColor = true;
			this.btnNewRel.Click += new System.EventHandler(this.btnNewRel_Click);
			// 
			// btnRelRemove
			// 
			this.btnRelRemove.Location = new System.Drawing.Point(468, 344);
			this.btnRelRemove.Name = "btnRelRemove";
			this.btnRelRemove.Size = new System.Drawing.Size(114, 44);
			this.btnRelRemove.TabIndex = 9;
			this.btnRelRemove.Text = "Remove";
			this.btnRelRemove.UseVisualStyleBackColor = true;
			this.btnRelRemove.Click += new System.EventHandler(this.btnRelRemove_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(336, 426);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(204, 48);
			this.button5.TabIndex = 8;
			this.button5.Text = "Pin to latest";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(336, 490);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(204, 50);
			this.button6.TabIndex = 8;
			this.button6.Text = "Pin to revision";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(336, 555);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(204, 46);
			this.button7.TabIndex = 10;
			this.button7.Text = "Make Final";
			this.button7.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(645, 424);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(205, 50);
			this.button8.TabIndex = 8;
			this.button8.Text = "Pin to release";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(645, 344);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(98, 44);
			this.button9.TabIndex = 8;
			this.button9.Text = "Add";
			this.button9.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(762, 344);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(88, 44);
			this.button10.TabIndex = 9;
			this.button10.Text = "Edit";
			this.button10.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 25);
			this.label4.TabIndex = 3;
			this.label4.Text = "Repo";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(85, 28);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(440, 29);
			this.textBox1.TabIndex = 11;
			this.textBox1.Text = "http://svndist.server.com/projects/abcd";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(543, 28);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(78, 46);
			this.button11.TabIndex = 8;
			this.button11.Text = "Scan";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(639, 484);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(102, 25);
			this.label5.TabIndex = 3;
			this.label5.Text = "Local path";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(645, 512);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(234, 29);
			this.textBox2.TabIndex = 11;
			this.textBox2.Text = "C:\\IG";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(645, 556);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(205, 46);
			this.button12.TabIndex = 8;
			this.button12.Text = "Checkout/Update";
			this.button12.UseVisualStyleBackColor = true;
			// 
			// listBox4
			// 
			this.listBox4.FormattingEnabled = true;
			this.listBox4.ItemHeight = 24;
			this.listBox4.Items.AddRange(new object[] {
            "Bin/All",
            "Config",
            "Data/World",
            "Data/Terrains/T1",
            "Data/Models/M1",
            "Data/Sounds",
            "Specs/Sim",
            "Specs/Station"});
			this.listBox4.Location = new System.Drawing.Point(26, 450);
			this.listBox4.Name = "listBox4";
			this.listBox4.Size = new System.Drawing.Size(246, 220);
			this.listBox4.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(21, 422);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(174, 25);
			this.label6.TabIndex = 3;
			this.label6.Text = "Shared Resources";
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(1761, 262);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(143, 68);
			this.button14.TabIndex = 13;
			this.button14.Text = "New Release";
			this.button14.UseVisualStyleBackColor = true;
			// 
			// bsModules
			// 
			this.bsModules.DataSource = typeof(Deployer.Context);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 831);
			this.Controls.Add(this.button14);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.btnRelRemove);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.btnNewRel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbInstalls);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbReleases);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox4);
			this.Controls.Add(this.lbModules);
			this.Controls.Add(this.btnInst);
			this.Controls.Add(this.btnRel);
			this.Name = "FrmMain";
			this.Text = "Deployer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.bsModules)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRel;
		private System.Windows.Forms.Button btnInst;
		private System.Windows.Forms.ListBox lbModules;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbReleases;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lbInstalls;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnNewRel;
		private System.Windows.Forms.Button btnRelRemove;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.ListBox listBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.BindingSource bsModules;
		private System.Windows.Forms.Button button14;
	}
}

