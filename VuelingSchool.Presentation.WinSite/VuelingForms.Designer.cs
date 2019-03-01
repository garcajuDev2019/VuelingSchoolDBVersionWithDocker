namespace VuelingSchool.Presentation.WinSite
{
	partial class VuelingForms
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
			this.btSave = new System.Windows.Forms.Button();
			this.btRefreshDataSet = new System.Windows.Forms.Button();
			this.studentDataGrid = new System.Windows.Forms.DataGridView();
			this.cbStates = new System.Windows.Forms.ComboBox();
			this.btAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.studentDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(158, 415);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(119, 23);
			this.btSave.TabIndex = 4;
			this.btSave.Text = "Save Changes";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btRefreshDataSet
			// 
			this.btRefreshDataSet.Location = new System.Drawing.Point(33, 415);
			this.btRefreshDataSet.Name = "btRefreshDataSet";
			this.btRefreshDataSet.Size = new System.Drawing.Size(119, 23);
			this.btRefreshDataSet.TabIndex = 5;
			this.btRefreshDataSet.Text = "Refresh Data";
			this.btRefreshDataSet.UseVisualStyleBackColor = true;
			this.btRefreshDataSet.Click += new System.EventHandler(this.btSave_Click);
			// 
			// studentDataGrid
			// 
			this.studentDataGrid.BackgroundColor = System.Drawing.Color.White;
			this.studentDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.studentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.studentDataGrid.Location = new System.Drawing.Point(12, 23);
			this.studentDataGrid.Name = "studentDataGrid";
			this.studentDataGrid.Size = new System.Drawing.Size(511, 386);
			this.studentDataGrid.TabIndex = 7;
			// 
			// cbStates
			// 
			this.cbStates.FormattingEnabled = true;
			this.cbStates.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
			this.cbStates.Location = new System.Drawing.Point(529, 23);
			this.cbStates.Name = "cbStates";
			this.cbStates.Size = new System.Drawing.Size(259, 21);
			this.cbStates.TabIndex = 8;
			// 
			// btAdd
			// 
			this.btAdd.Location = new System.Drawing.Point(283, 415);
			this.btAdd.Name = "btAdd";
			this.btAdd.Size = new System.Drawing.Size(112, 23);
			this.btAdd.TabIndex = 13;
			this.btAdd.Text = "Add";
			this.btAdd.UseVisualStyleBackColor = true;
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click_1);
			// 
			// VuelingForms
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btAdd);
			this.Controls.Add(this.cbStates);
			this.Controls.Add(this.studentDataGrid);
			this.Controls.Add(this.btRefreshDataSet);
			this.Controls.Add(this.btSave);
			this.Name = "VuelingForms";
			this.Text = "VuelingForms";
			((System.ComponentModel.ISupportInitialize)(this.studentDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btRefreshDataSet;
		private System.Windows.Forms.DataGridView studentDataGrid;
		private System.Windows.Forms.ComboBox cbStates;
		private System.Windows.Forms.Button btAdd;
	}
}