namespace DataExtractor
{
    partial class UserInterface
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
            this.uxFileSelectLabel = new System.Windows.Forms.Label();
            this.uxFileDisplay = new System.Windows.Forms.TextBox();
            this.uxFileSelectButton = new System.Windows.Forms.Button();
            this.uxOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.uxHeaderSelectLabel = new System.Windows.Forms.Label();
            this.uxHeaderSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxDataSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // uxFileSelectLabel
            // 
            this.uxFileSelectLabel.AutoSize = true;
            this.uxFileSelectLabel.Location = new System.Drawing.Point(21, 9);
            this.uxFileSelectLabel.Name = "uxFileSelectLabel";
            this.uxFileSelectLabel.Size = new System.Drawing.Size(59, 13);
            this.uxFileSelectLabel.TabIndex = 0;
            this.uxFileSelectLabel.Text = "Select File:";
            // 
            // uxFileDisplay
            // 
            this.uxFileDisplay.Location = new System.Drawing.Point(86, 6);
            this.uxFileDisplay.Name = "uxFileDisplay";
            this.uxFileDisplay.ReadOnly = true;
            this.uxFileDisplay.Size = new System.Drawing.Size(246, 20);
            this.uxFileDisplay.TabIndex = 1;
            // 
            // uxFileSelectButton
            // 
            this.uxFileSelectButton.Location = new System.Drawing.Point(338, 5);
            this.uxFileSelectButton.Name = "uxFileSelectButton";
            this.uxFileSelectButton.Size = new System.Drawing.Size(43, 23);
            this.uxFileSelectButton.TabIndex = 2;
            this.uxFileSelectButton.Text = "...";
            this.uxFileSelectButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uxFileSelectButton.UseVisualStyleBackColor = true;
            this.uxFileSelectButton.Click += new System.EventHandler(this.uxFileSelectButton_Click);
            // 
            // uxOpenFile
            // 
            this.uxOpenFile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            // 
            // uxHeaderSelectLabel
            // 
            this.uxHeaderSelectLabel.AutoSize = true;
            this.uxHeaderSelectLabel.Location = new System.Drawing.Point(2, 40);
            this.uxHeaderSelectLabel.Name = "uxHeaderSelectLabel";
            this.uxHeaderSelectLabel.Size = new System.Drawing.Size(78, 13);
            this.uxHeaderSelectLabel.TabIndex = 3;
            this.uxHeaderSelectLabel.Text = "Select Header:";
            // 
            // uxHeaderSelect
            // 
            this.uxHeaderSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxHeaderSelect.FormattingEnabled = true;
            this.uxHeaderSelect.Location = new System.Drawing.Point(86, 37);
            this.uxHeaderSelect.Name = "uxHeaderSelect";
            this.uxHeaderSelect.Size = new System.Drawing.Size(295, 21);
            this.uxHeaderSelect.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Data:";
            // 
            // uxDataSelect
            // 
            this.uxDataSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxDataSelect.FormattingEnabled = true;
            this.uxDataSelect.Location = new System.Drawing.Point(86, 64);
            this.uxDataSelect.Name = "uxDataSelect";
            this.uxDataSelect.Size = new System.Drawing.Size(295, 21);
            this.uxDataSelect.TabIndex = 6;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 91);
            this.Controls.Add(this.uxDataSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxHeaderSelect);
            this.Controls.Add(this.uxHeaderSelectLabel);
            this.Controls.Add(this.uxFileSelectButton);
            this.Controls.Add(this.uxFileDisplay);
            this.Controls.Add(this.uxFileSelectLabel);
            this.Name = "UserInterface";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxFileSelectLabel;
        private System.Windows.Forms.TextBox uxFileDisplay;
        private System.Windows.Forms.Button uxFileSelectButton;
        private System.Windows.Forms.OpenFileDialog uxOpenFile;
        private System.Windows.Forms.Label uxHeaderSelectLabel;
        private System.Windows.Forms.ComboBox uxHeaderSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox uxDataSelect;
    }
}

