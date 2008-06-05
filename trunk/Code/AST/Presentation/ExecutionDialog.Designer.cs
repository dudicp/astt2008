namespace AST.Presentation {
    partial class ExecutionDialog {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TPsListBox = new System.Windows.Forms.ListBox();
            this.ActionsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SingleActionsLabel = new System.Windows.Forms.Label();
            this.TSCsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.EndStationsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedEndStationsListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectEndStationButton = new System.Windows.Forms.Button();
            this.UnselectEndStationButton = new System.Windows.Forms.Button();
            this.MoveDownEndStationButton = new System.Windows.Forms.Button();
            this.MoveUpEndStationButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewEndStationButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(12, 19);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(96, 20);
            this.Title.TabIndex = 3;
            this.Title.Text = "Execution";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TPsListBox);
            this.groupBox1.Controls.Add(this.ActionsListBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SingleActionsLabel);
            this.groupBox1.Controls.Add(this.TSCsListBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 414);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // TPsListBox
            // 
            this.TPsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPsListBox.FormattingEnabled = true;
            this.TPsListBox.ItemHeight = 15;
            this.TPsListBox.Location = new System.Drawing.Point(9, 294);
            this.TPsListBox.Name = "TPsListBox";
            this.TPsListBox.Size = new System.Drawing.Size(142, 109);
            this.TPsListBox.TabIndex = 16;
            this.TPsListBox.SelectedIndexChanged += new System.EventHandler(this.TPsListBox_SelectedIndexChanged);
            // 
            // ActionsListBox
            // 
            this.ActionsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionsListBox.FormattingEnabled = true;
            this.ActionsListBox.ItemHeight = 15;
            this.ActionsListBox.Location = new System.Drawing.Point(9, 30);
            this.ActionsListBox.Name = "ActionsListBox";
            this.ActionsListBox.Size = new System.Drawing.Size(142, 109);
            this.ActionsListBox.TabIndex = 12;
            this.ActionsListBox.SelectedIndexChanged += new System.EventHandler(this.ActionsListBox_SelectedIndexChanged);
            this.ActionsListBox.DoubleClick += new System.EventHandler(this.ActionsListBox_OnDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Test Plans:";
            // 
            // SingleActionsLabel
            // 
            this.SingleActionsLabel.AutoSize = true;
            this.SingleActionsLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingleActionsLabel.Location = new System.Drawing.Point(6, 12);
            this.SingleActionsLabel.Name = "SingleActionsLabel";
            this.SingleActionsLabel.Size = new System.Drawing.Size(101, 15);
            this.SingleActionsLabel.TabIndex = 5;
            this.SingleActionsLabel.Text = "Single Actions:";
            // 
            // TSCsListBox
            // 
            this.TSCsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSCsListBox.FormattingEnabled = true;
            this.TSCsListBox.ItemHeight = 15;
            this.TSCsListBox.Location = new System.Drawing.Point(9, 162);
            this.TSCsListBox.Name = "TSCsListBox";
            this.TSCsListBox.Size = new System.Drawing.Size(142, 109);
            this.TSCsListBox.TabIndex = 14;
            this.TSCsListBox.SelectedIndexChanged += new System.EventHandler(this.TSCsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Test Scenarios:";
            // 
            // DescriptionText
            // 
            this.DescriptionText.Enabled = false;
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(249, 415);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(267, 45);
            this.DescriptionText.TabIndex = 12;
            this.DescriptionText.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(246, 397);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(72, 15);
            this.descriptionLabel.TabIndex = 11;
            this.descriptionLabel.Text = "Description:";
            // 
            // EndStationsListBox
            // 
            this.EndStationsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationsListBox.FormattingEnabled = true;
            this.EndStationsListBox.ItemHeight = 15;
            this.EndStationsListBox.Location = new System.Drawing.Point(9, 30);
            this.EndStationsListBox.Name = "EndStationsListBox";
            this.EndStationsListBox.Size = new System.Drawing.Size(142, 109);
            this.EndStationsListBox.TabIndex = 14;
            this.EndStationsListBox.SelectedIndexChanged += new System.EventHandler(this.EndStationsListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "All End-Stations:";
            // 
            // SelectedEndStationsListBox
            // 
            this.SelectedEndStationsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedEndStationsListBox.FormattingEnabled = true;
            this.SelectedEndStationsListBox.ItemHeight = 15;
            this.SelectedEndStationsListBox.Location = new System.Drawing.Point(9, 211);
            this.SelectedEndStationsListBox.Name = "SelectedEndStationsListBox";
            this.SelectedEndStationsListBox.Size = new System.Drawing.Size(142, 109);
            this.SelectedEndStationsListBox.TabIndex = 16;
            this.SelectedEndStationsListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedEndStationsListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Selected End-Stations:";
            // 
            // SelectEndStationButton
            // 
            this.SelectEndStationButton.Enabled = false;
            this.SelectEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectEndStationButton.Location = new System.Drawing.Point(83, 154);
            this.SelectEndStationButton.Name = "SelectEndStationButton";
            this.SelectEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.SelectEndStationButton.TabIndex = 22;
            this.SelectEndStationButton.Text = "↓";
            this.SelectEndStationButton.UseVisualStyleBackColor = true;
            this.SelectEndStationButton.Click += new System.EventHandler(this.SelectEndStationButton_Click);
            // 
            // UnselectEndStationButton
            // 
            this.UnselectEndStationButton.Enabled = false;
            this.UnselectEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnselectEndStationButton.Location = new System.Drawing.Point(42, 154);
            this.UnselectEndStationButton.Name = "UnselectEndStationButton";
            this.UnselectEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.UnselectEndStationButton.TabIndex = 21;
            this.UnselectEndStationButton.Text = "↑";
            this.UnselectEndStationButton.UseVisualStyleBackColor = true;
            this.UnselectEndStationButton.Click += new System.EventHandler(this.UnselectEndStationButton_Click);
            // 
            // MoveDownEndStationButton
            // 
            this.MoveDownEndStationButton.Enabled = false;
            this.MoveDownEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownEndStationButton.Location = new System.Drawing.Point(157, 266);
            this.MoveDownEndStationButton.Name = "MoveDownEndStationButton";
            this.MoveDownEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownEndStationButton.TabIndex = 24;
            this.MoveDownEndStationButton.Text = "↓";
            this.MoveDownEndStationButton.UseVisualStyleBackColor = true;
            this.MoveDownEndStationButton.Click += new System.EventHandler(this.MoveDownEndStationButton_Click);
            // 
            // MoveUpEndStationButton
            // 
            this.MoveUpEndStationButton.Enabled = false;
            this.MoveUpEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpEndStationButton.Location = new System.Drawing.Point(157, 237);
            this.MoveUpEndStationButton.Name = "MoveUpEndStationButton";
            this.MoveUpEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpEndStationButton.TabIndex = 23;
            this.MoveUpEndStationButton.Text = "↑";
            this.MoveUpEndStationButton.UseVisualStyleBackColor = true;
            this.MoveUpEndStationButton.Click += new System.EventHandler(this.MoveUpEndStationButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(157, 86);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(38, 23);
            this.EditButton.TabIndex = 27;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewEndStationButton
            // 
            this.NewEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewEndStationButton.Location = new System.Drawing.Point(157, 57);
            this.NewEndStationButton.Name = "NewEndStationButton";
            this.NewEndStationButton.Size = new System.Drawing.Size(38, 23);
            this.NewEndStationButton.TabIndex = 26;
            this.NewEndStationButton.Text = "New";
            this.NewEndStationButton.UseVisualStyleBackColor = true;
            this.NewEndStationButton.Click += new System.EventHandler(this.NewEndStationButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EditButton);
            this.groupBox2.Controls.Add(this.NewEndStationButton);
            this.groupBox2.Controls.Add(this.MoveDownEndStationButton);
            this.groupBox2.Controls.Add(this.MoveUpEndStationButton);
            this.groupBox2.Controls.Add(this.SelectEndStationButton);
            this.groupBox2.Controls.Add(this.UnselectEndStationButton);
            this.groupBox2.Controls.Add(this.SelectedEndStationsListBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.EndStationsListBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(581, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 332);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.ExecuteButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExecuteButton.Location = new System.Drawing.Point(738, 430);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(62, 30);
            this.ExecuteButton.TabIndex = 28;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = false;
            // 
            // ExecutionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 483);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DescriptionText);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Title);
            this.Name = "ExecutionDialog";
            this.Text = "ExecutionDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label SingleActionsLabel;
        private System.Windows.Forms.ListBox TPsListBox;
        private System.Windows.Forms.ListBox ActionsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox TSCsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ListBox EndStationsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox SelectedEndStationsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SelectEndStationButton;
        private System.Windows.Forms.Button UnselectEndStationButton;
        private System.Windows.Forms.Button MoveDownEndStationButton;
        private System.Windows.Forms.Button MoveUpEndStationButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button NewEndStationButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ExecuteButton;
    }
}