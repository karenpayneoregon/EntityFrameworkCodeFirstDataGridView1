namespace RestaurantDemo
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
            this.GetBreakfastOrderButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // GetBreakfastOrderButton
            // 
            this.GetBreakfastOrderButton.Location = new System.Drawing.Point(22, 191);
            this.GetBreakfastOrderButton.Name = "GetBreakfastOrderButton";
            this.GetBreakfastOrderButton.Size = new System.Drawing.Size(179, 23);
            this.GetBreakfastOrderButton.TabIndex = 0;
            this.GetBreakfastOrderButton.Text = "Get breakfast order";
            this.GetBreakfastOrderButton.UseVisualStyleBackColor = true;
            this.GetBreakfastOrderButton.Click += new System.EventHandler(this.GetBreakfastOrderButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(179, 173);
            this.listBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 217);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.GetBreakfastOrderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant breakfask";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetBreakfastOrderButton;
        private System.Windows.Forms.ListBox listBox1;
    }
}

