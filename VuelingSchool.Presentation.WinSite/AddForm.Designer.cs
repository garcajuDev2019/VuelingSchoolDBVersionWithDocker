namespace VuelingSchool.Presentation.WinSite
{
	partial class AddForm
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
			this.txtId = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtSurname = new System.Windows.Forms.TextBox();
			this.txtBirthday = new System.Windows.Forms.TextBox();
			this.btSaveStudent = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtId
			// 
			this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtId.Location = new System.Drawing.Point(48, 25);
			this.txtId.Name = "txtId";
			this.txtId.Size = new System.Drawing.Size(234, 13);
			this.txtId.TabIndex = 0;
			// 
			// txtName
			// 
			this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtName.Location = new System.Drawing.Point(48, 64);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(234, 13);
			this.txtName.TabIndex = 1;
			// 
			// txtSurname
			// 
			this.txtSurname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSurname.Location = new System.Drawing.Point(48, 103);
			this.txtSurname.Name = "txtSurname";
			this.txtSurname.Size = new System.Drawing.Size(234, 13);
			this.txtSurname.TabIndex = 2;
			// 
			// txtBirthday
			// 
			this.txtBirthday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txtBirthday.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtBirthday.Location = new System.Drawing.Point(48, 142);
			this.txtBirthday.Name = "txtBirthday";
			this.txtBirthday.Size = new System.Drawing.Size(234, 13);
			this.txtBirthday.TabIndex = 3;
			// 
			// btSaveStudent
			// 
			this.btSaveStudent.Location = new System.Drawing.Point(106, 168);
			this.btSaveStudent.Name = "btSaveStudent";
			this.btSaveStudent.Size = new System.Drawing.Size(100, 26);
			this.btSaveStudent.TabIndex = 4;
			this.btSaveStudent.Text = "Save Changes";
			this.btSaveStudent.UseVisualStyleBackColor = true;
			this.btSaveStudent.Click += new System.EventHandler(this.btSaveStudent_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Student ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(45, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Surname";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(45, 126);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Birthday";
			// 
			// AddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(342, 204);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSaveStudent);
			this.Controls.Add(this.txtBirthday);
			this.Controls.Add(this.txtSurname);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.txtId);
			this.Name = "AddForm";
			this.Text = "AddForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtSurname;
		private System.Windows.Forms.TextBox txtBirthday;
		private System.Windows.Forms.Button btSaveStudent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}