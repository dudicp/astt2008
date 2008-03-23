namespace AST.Presentation {
    partial class ExecutionPanel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Title = new System.Windows.Forms.Label();
            this.executionDetailsBox = new System.Windows.Forms.GroupBox();
            this.DelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DelayCheckBox = new System.Windows.Forms.CheckBox();
            this.NumberOfTimesLabel = new System.Windows.Forms.Label();
            this.TimesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EditActionButton = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.TreeViewLabel = new System.Windows.Forms.Label();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.ReportNameCheckBox = new System.Windows.Forms.CheckBox();
            this.ReportNameTextBox = new System.Windows.Forms.TextBox();
            this.executionDetailsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(16, 45);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(202, 20);
            this.Title.TabIndex = 2;
            this.Title.Text = "Execute Single Action";
            // 
            // executionDetailsBox
            // 
            this.executionDetailsBox.Controls.Add(this.DelayNumericUpDown);
            this.executionDetailsBox.Controls.Add(this.DelayCheckBox);
            this.executionDetailsBox.Controls.Add(this.NumberOfTimesLabel);
            this.executionDetailsBox.Controls.Add(this.TimesNumericUpDown);
            this.executionDetailsBox.Controls.Add(this.EditActionButton);
            this.executionDetailsBox.Controls.Add(this.treeView);
            this.executionDetailsBox.Controls.Add(this.DescriptionText);
            this.executionDetailsBox.Controls.Add(this.descriptionLabel);
            this.executionDetailsBox.Controls.Add(this.TreeViewLabel);
            this.executionDetailsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executionDetailsBox.Location = new System.Drawing.Point(18, 84);
            this.executionDetailsBox.Name = "executionDetailsBox";
            this.executionDetailsBox.Size = new System.Drawing.Size(405, 371);
            this.executionDetailsBox.TabIndex = 3;
            this.executionDetailsBox.TabStop = false;
            this.executionDetailsBox.Text = "Execution Details";
            // 
            // DelayNumericUpDown
            // 
            this.DelayNumericUpDown.Location = new System.Drawing.Point(325, 137);
            this.DelayNumericUpDown.Name = "DelayNumericUpDown";
            this.DelayNumericUpDown.Size = new System.Drawing.Size(43, 21);
            this.DelayNumericUpDown.TabIndex = 18;
            this.DelayNumericUpDown.ValueChanged += new System.EventHandler(this.DelayNumericUpDown_ValueChanged);
            // 
            // DelayCheckBox
            // 
            this.DelayCheckBox.AutoSize = true;
            this.DelayCheckBox.Location = new System.Drawing.Point(268, 138);
            this.DelayCheckBox.Name = "DelayCheckBox";
            this.DelayCheckBox.Size = new System.Drawing.Size(51, 18);
            this.DelayCheckBox.TabIndex = 17;
            this.DelayCheckBox.Text = "Delay";
            this.DelayCheckBox.UseVisualStyleBackColor = true;
            this.DelayCheckBox.CheckedChanged += new System.EventHandler(this.DelayCheckBox_CheckedChanged);
            // 
            // NumberOfTimesLabel
            // 
            this.NumberOfTimesLabel.AutoSize = true;
            this.NumberOfTimesLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfTimesLabel.Location = new System.Drawing.Point(85, 239);
            this.NumberOfTimesLabel.Name = "NumberOfTimesLabel";
            this.NumberOfTimesLabel.Size = new System.Drawing.Size(91, 14);
            this.NumberOfTimesLabel.TabIndex = 16;
            this.NumberOfTimesLabel.Text = "Number of Times:";
            // 
            // TimesNumericUpDown
            // 
            this.TimesNumericUpDown.Location = new System.Drawing.Point(209, 237);
            this.TimesNumericUpDown.Name = "TimesNumericUpDown";
            this.TimesNumericUpDown.Size = new System.Drawing.Size(40, 21);
            this.TimesNumericUpDown.TabIndex = 15;
            // 
            // EditActionButton
            // 
            this.EditActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditActionButton.Location = new System.Drawing.Point(280, 95);
            this.EditActionButton.Name = "EditActionButton";
            this.EditActionButton.Size = new System.Drawing.Size(76, 25);
            this.EditActionButton.TabIndex = 12;
            this.EditActionButton.Text = "Edit Action";
            this.EditActionButton.UseVisualStyleBackColor = true;
            this.EditActionButton.Click += new System.EventHandler(this.EditActionButton_Click);
            // 
            // treeView
            // 
            this.treeView.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(82, 56);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(167, 148);
            this.treeView.TabIndex = 11;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // DescriptionText
            // 
            this.DescriptionText.Enabled = false;
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(6, 300);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(390, 64);
            this.DescriptionText.TabIndex = 10;
            this.DescriptionText.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(6, 277);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(72, 15);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description:";
            // 
            // TreeViewLabel
            // 
            this.TreeViewLabel.AutoSize = true;
            this.TreeViewLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeViewLabel.Location = new System.Drawing.Point(79, 38);
            this.TreeViewLabel.Name = "TreeViewLabel";
            this.TreeViewLabel.Size = new System.Drawing.Size(61, 15);
            this.TreeViewLabel.TabIndex = 0;
            this.TreeViewLabel.Text = "Tree View:";
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteButton.Location = new System.Drawing.Point(140, 522);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(75, 23);
            this.ExecuteButton.TabIndex = 4;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(221, 522);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 5;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // ReportNameCheckBox
            // 
            this.ReportNameCheckBox.AutoSize = true;
            this.ReportNameCheckBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportNameCheckBox.Location = new System.Drawing.Point(99, 475);
            this.ReportNameCheckBox.Name = "ReportNameCheckBox";
            this.ReportNameCheckBox.Size = new System.Drawing.Size(99, 19);
            this.ReportNameCheckBox.TabIndex = 6;
            this.ReportNameCheckBox.Text = "Report Name:";
            this.ReportNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReportNameTextBox
            // 
            this.ReportNameTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportNameTextBox.Location = new System.Drawing.Point(204, 473);
            this.ReportNameTextBox.Name = "ReportNameTextBox";
            this.ReportNameTextBox.Size = new System.Drawing.Size(136, 24);
            this.ReportNameTextBox.TabIndex = 7;
            // 
            // ExecutionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ReportNameTextBox);
            this.Controls.Add(this.ReportNameCheckBox);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.executionDetailsBox);
            this.Controls.Add(this.Title);
            this.Name = "ExecutionPanel";
            this.Size = new System.Drawing.Size(434, 559);
            this.executionDetailsBox.ResumeLayout(false);
            this.executionDetailsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.GroupBox executionDetailsBox;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.Label TreeViewLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button EditActionButton;
        private System.Windows.Forms.NumericUpDown TimesNumericUpDown;
        private System.Windows.Forms.Label NumberOfTimesLabel;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.CheckBox ReportNameCheckBox;
        private System.Windows.Forms.TextBox ReportNameTextBox;
        private System.Windows.Forms.NumericUpDown DelayNumericUpDown;
        private System.Windows.Forms.CheckBox DelayCheckBox;
    }
}
