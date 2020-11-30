namespace Deployer
{
	partial class FrmNewRel
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
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDerivedFrom = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtComplateName = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(218, 120);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(283, 29);
			this.txtName.TabIndex = 0;
			this.txtName.Text = "0.0.0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type";
			// 
			// cbType
			// 
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.FormattingEnabled = true;
			this.cbType.Items.AddRange(new object[] {
            "head",
            "integration",
            "candidate",
            "final"});
			this.cbType.Location = new System.Drawing.Point(24, 120);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(167, 32);
			this.cbType.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(218, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 25);
			this.label2.TabIndex = 3;
			this.label2.Text = "Name";
			// 
			// txtDerivedFrom
			// 
			this.txtDerivedFrom.Location = new System.Drawing.Point(29, 39);
			this.txtDerivedFrom.Name = "txtDerivedFrom";
			this.txtDerivedFrom.ReadOnly = true;
			this.txtDerivedFrom.Size = new System.Drawing.Size(477, 29);
			this.txtDerivedFrom.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(127, 25);
			this.label3.TabIndex = 5;
			this.label3.Text = "Derived from ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 184);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 25);
			this.label4.TabIndex = 6;
			this.label4.Text = "Full Name";
			// 
			// txtComplateName
			// 
			this.txtComplateName.Location = new System.Drawing.Point(29, 212);
			this.txtComplateName.Name = "txtComplateName";
			this.txtComplateName.ReadOnly = true;
			this.txtComplateName.Size = new System.Drawing.Size(477, 29);
			this.txtComplateName.TabIndex = 7;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(223, 271);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(132, 56);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(380, 271);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(121, 56);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FrmNewRel
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(542, 348);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtComplateName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDerivedFrom);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtName);
			this.Name = "FrmNewRel";
			this.Text = "New Release";
			this.Load += new System.EventHandler(this.FrmNewRel_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDerivedFrom;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtComplateName;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}