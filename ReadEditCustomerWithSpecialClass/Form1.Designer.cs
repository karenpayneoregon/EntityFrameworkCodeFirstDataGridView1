namespace ReadEditCustomerWithSpecialClass
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaveAllChangesButton = new System.Windows.Forms.Button();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactTitleColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StreetColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostalCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountyNameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EditContactColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveAllChangesButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 54);
            this.panel1.TabIndex = 0;
            // 
            // SaveAllChangesButton
            // 
            this.SaveAllChangesButton.Location = new System.Drawing.Point(12, 15);
            this.SaveAllChangesButton.Name = "SaveAllChangesButton";
            this.SaveAllChangesButton.Size = new System.Drawing.Size(154, 23);
            this.SaveAllChangesButton.TabIndex = 1;
            this.SaveAllChangesButton.Text = "Save all changes";
            this.SaveAllChangesButton.UseVisualStyleBackColor = true;
            this.SaveAllChangesButton.Click += new System.EventHandler(this.SaveAllChangesButton_Click);
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyNameColumn,
            this.FirstNameColumn,
            this.LastNameColumn,
            this.ContactTitleColumn,
            this.StreetColumn,
            this.CityColumn,
            this.PostalCodeColumn,
            this.CountyNameColumn,
            this.EditContactColumn});
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.Location = new System.Drawing.Point(0, 0);
            this.gridView.Name = "gridView";
            this.gridView.Size = new System.Drawing.Size(1074, 396);
            this.gridView.TabIndex = 1;
            this.gridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridView_CurrentCellDirtyStateChanged);
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.DataPropertyName = "CompanyName";
            this.CompanyNameColumn.HeaderText = "Company";
            this.CompanyNameColumn.Name = "CompanyNameColumn";
            this.CompanyNameColumn.ToolTipText = "Customer name";
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.DataPropertyName = "FirstName";
            this.FirstNameColumn.HeaderText = "First";
            this.FirstNameColumn.Name = "FirstNameColumn";
            this.FirstNameColumn.ReadOnly = true;
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.DataPropertyName = "LastName";
            this.LastNameColumn.HeaderText = "Last";
            this.LastNameColumn.Name = "LastNameColumn";
            this.LastNameColumn.ReadOnly = true;
            // 
            // ContactTitleColumn
            // 
            this.ContactTitleColumn.HeaderText = "Title";
            this.ContactTitleColumn.Name = "ContactTitleColumn";
            this.ContactTitleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ContactTitleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ContactTitleColumn.Width = 150;
            // 
            // StreetColumn
            // 
            this.StreetColumn.DataPropertyName = "Address";
            this.StreetColumn.HeaderText = "Street";
            this.StreetColumn.Name = "StreetColumn";
            // 
            // CityColumn
            // 
            this.CityColumn.DataPropertyName = "City";
            this.CityColumn.HeaderText = "City";
            this.CityColumn.Name = "CityColumn";
            // 
            // PostalCodeColumn
            // 
            this.PostalCodeColumn.DataPropertyName = "PostalCode";
            this.PostalCodeColumn.HeaderText = "Postal";
            this.PostalCodeColumn.Name = "PostalCodeColumn";
            // 
            // CountyNameColumn
            // 
            this.CountyNameColumn.HeaderText = "Country";
            this.CountyNameColumn.Name = "CountyNameColumn";
            this.CountyNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CountyNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EditContactColumn
            // 
            this.EditContactColumn.HeaderText = "";
            this.EditContactColumn.Name = "EditContactColumn";
            this.EditContactColumn.Text = "";
            this.EditContactColumn.ToolTipText = "Edit contact";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 450);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Button SaveAllChangesButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ContactTitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreetColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostalCodeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn CountyNameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn EditContactColumn;
    }
}

