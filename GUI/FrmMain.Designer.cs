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
			this.btnRel = new System.Windows.Forms.Button();
			this.btnInst = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.listBox3 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
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
			this.SuspendLayout();
			// 
			// btnRel
			// 
			this.btnRel.Location = new System.Drawing.Point(1281, 57);
			this.btnRel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnRel.Name = "btnRel";
			this.btnRel.Size = new System.Drawing.Size(104, 45);
			this.btnRel.TabIndex = 0;
			this.btnRel.Text = "Releases";
			this.btnRel.UseVisualStyleBackColor = true;
			this.btnRel.Click += new System.EventHandler(this.btnRel_Click);
			// 
			// btnInst
			// 
			this.btnInst.Location = new System.Drawing.Point(1281, 117);
			this.btnInst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnInst.Name = "btnInst";
			this.btnInst.Size = new System.Drawing.Size(104, 45);
			this.btnInst.TabIndex = 1;
			this.btnInst.Text = "Installs";
			this.btnInst.UseVisualStyleBackColor = true;
			this.btnInst.Click += new System.EventHandler(this.btnInst_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Items.AddRange(new object[] {
            "IG",
            "TrackingSystem"});
			this.listBox1.Location = new System.Drawing.Point(19, 105);
			this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(180, 116);
			this.listBox1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 86);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "App Modules";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(241, 86);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Releases";
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.ItemHeight = 16;
			this.listBox2.Items.AddRange(new object[] {
            "Head",
            "Candidate/2.0.7",
            "Candidate/2.1.0",
            "Final/2.0.7"});
			this.listBox2.Location = new System.Drawing.Point(244, 105);
			this.listBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(180, 116);
			this.listBox2.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(465, 86);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "Installs";
			// 
			// listBox3
			// 
			this.listBox3.FormattingEnabled = true;
			this.listBox3.ItemHeight = 16;
			this.listBox3.Items.AddRange(new object[] {
            "CZ/Brno/MainEnv",
            "IL/Holon/BigIntegEnv1"});
			this.listBox3.Location = new System.Drawing.Point(469, 105);
			this.listBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new System.Drawing.Size(180, 116);
			this.listBox3.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(19, 229);
			this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(65, 29);
			this.button1.TabIndex = 8;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(97, 229);
			this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 29);
			this.button2.TabIndex = 9;
			this.button2.Text = "Edit";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(244, 229);
			this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 29);
			this.button3.TabIndex = 8;
			this.button3.Text = "Add";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(324, 229);
			this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(68, 29);
			this.button4.TabIndex = 9;
			this.button4.Text = "Edit";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(244, 284);
			this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(148, 32);
			this.button5.TabIndex = 8;
			this.button5.Text = "Pin to latest";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(244, 327);
			this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(148, 33);
			this.button6.TabIndex = 8;
			this.button6.Text = "Pin to revision";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(244, 370);
			this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(148, 31);
			this.button7.TabIndex = 10;
			this.button7.Text = "Make Final";
			this.button7.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(469, 283);
			this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(149, 33);
			this.button8.TabIndex = 8;
			this.button8.Text = "Pin to release";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(469, 229);
			this.button9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(71, 29);
			this.button9.TabIndex = 8;
			this.button9.Text = "Add";
			this.button9.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(554, 229);
			this.button10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(64, 29);
			this.button10.TabIndex = 9;
			this.button10.Text = "Edit";
			this.button10.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 19);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Repo";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(62, 19);
			this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(321, 22);
			this.textBox1.TabIndex = 11;
			this.textBox1.Text = "http://svndist.server.com/projects/abcd";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(395, 19);
			this.button11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(57, 23);
			this.button11.TabIndex = 8;
			this.button11.Text = "Scan";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(465, 323);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 17);
			this.label5.TabIndex = 3;
			this.label5.Text = "Local path";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(469, 341);
			this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(171, 22);
			this.textBox2.TabIndex = 11;
			this.textBox2.Text = "C:\\IG";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(469, 371);
			this.button12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(149, 31);
			this.button12.TabIndex = 8;
			this.button12.Text = "Checkout/Update";
			this.button12.UseVisualStyleBackColor = true;
			// 
			// listBox4
			// 
			this.listBox4.FormattingEnabled = true;
			this.listBox4.ItemHeight = 16;
			this.listBox4.Items.AddRange(new object[] {
            "Bin/All",
            "Config",
            "Data/World",
            "Data/Terrains/T1",
            "Data/Models/M1",
            "Data/Sounds",
            "Specs/Sim",
            "Specs/Station"});
			this.listBox4.Location = new System.Drawing.Point(19, 300);
			this.listBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.listBox4.Name = "listBox4";
			this.listBox4.Size = new System.Drawing.Size(180, 148);
			this.listBox4.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 281);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(126, 17);
			this.label6.TabIndex = 3;
			this.label6.Text = "Shared Resources";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1399, 554);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox4);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.btnInst);
			this.Controls.Add(this.btnRel);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FrmMain";
			this.Text = "Deployer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRel;
		private System.Windows.Forms.Button btnInst;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
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
	}
}

