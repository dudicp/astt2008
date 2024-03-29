namespace AST.Presentation {
    partial class CreateTSCDialog {
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
            this.SettingsButton = new System.Windows.Forms.Button();
            this.MoveDownActionButton = new System.Windows.Forms.Button();
            this.MoveUpActionButton = new System.Windows.Forms.Button();
            this.UnselectActionButton = new System.Windows.Forms.Button();
            this.SelectActionButton = new System.Windows.Forms.Button();
            this.ActionsBox = new System.Windows.Forms.GroupBox();
            this.ActionDescriptionText = new System.Windows.Forms.RichTextBox();
            this.SelectedTreeView = new System.Windows.Forms.TreeView();
            this.SelectedActionsLabel = new System.Windows.Forms.Label();
            this.ActionsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ActionNameLabel = new System.Windows.Forms.Label();
            this.ActionNameText = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.CreatorNameText = new System.Windows.Forms.TextBox();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.creatorNameLabel = new System.Windows.Forms.Label();
            this.TSCNameLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.TSCDetailsBox = new System.Windows.Forms.GroupBox();
            this.Title = new System.Windows.Forms.Label();
            this.ActionsBox.SuspendLayout();
            this.TSCDetailsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.Enabled = false;
            this.SettingsButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.Location = new System.Drawing.Point(246, 166);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(75, 23);
            this.SettingsButton.TabIndex = 9;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // MoveDownActionButton
            // 
            this.MoveDownActionButton.Enabled = false;
            this.MoveDownActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownActionButton.Location = new System.Drawing.Point(361, 87);
            this.MoveDownActionButton.Name = "MoveDownActionButton";
            this.MoveDownActionButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownActionButton.TabIndex = 8;
            this.MoveDownActionButton.Text = "↓";
            this.MoveDownActionButton.UseVisualStyleBackColor = true;
            this.MoveDownActionButton.Click += new System.EventHandler(this.MoveDownActionButton_Click);
            // 
            // MoveUpActionButton
            // 
            this.MoveUpActionButton.Enabled = false;
            this.MoveUpActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpActionButton.Location = new System.Drawing.Point(361, 58);
            this.MoveUpActionButton.Name = "MoveUpActionButton";
            this.MoveUpActionButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpActionButton.TabIndex = 7;
            this.MoveUpActionButton.Text = "↑";
            this.MoveUpActionButton.UseVisualStyleBackColor = true;
            this.MoveUpActionButton.Click += new System.EventHandler(this.MoveUpActionButton_Click);
            // 
            // UnselectActionButton
            // 
            this.UnselectActionButton.Enabled = false;
            this.UnselectActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnselectActionButton.Location = new System.Drawing.Point(160, 87);
            this.UnselectActionButton.Name = "UnselectActionButton";
            this.UnselectActionButton.Size = new System.Drawing.Size(36, 23);
            this.UnselectActionButton.TabIndex = 5;
            this.UnselectActionButton.Text = "←";
            this.UnselectActionButton.UseVisualStyleBackColor = true;
            this.UnselectActionButton.Click += new System.EventHandler(this.UnselectActionButton_Click);
            // 
            // SelectActionButton
            // 
            this.SelectActionButton.Enabled = false;
            this.SelectActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectActionButton.Location = new System.Drawing.Point(160, 58);
            this.SelectActionButton.Name = "SelectActionButton";
            this.SelectActionButton.Size = new System.Drawing.Size(35, 23);
            this.SelectActionButton.TabIndex = 4;
            this.SelectActionButton.Text = "→";
            this.SelectActionButton.UseVisualStyleBackColor = true;
            this.SelectActionButton.Click += new System.EventHandler(this.SelectActionButton_Click);
            // 
            // ActionsBox
            // 
            this.ActionsBox.Controls.Add(this.ActionDescriptionText);
            this.ActionsBox.Controls.Add(this.SelectedTreeView);
            this.ActionsBox.Controls.Add(this.SettingsButton);
            this.ActionsBox.Controls.Add(this.MoveDownActionButton);
            this.ActionsBox.Controls.Add(this.MoveUpActionButton);
            this.ActionsBox.Controls.Add(this.UnselectActionButton);
            this.ActionsBox.Controls.Add(this.SelectActionButton);
            this.ActionsBox.Controls.Add(this.SelectedActionsLabel);
            this.ActionsBox.Controls.Add(this.ActionsListBox);
            this.ActionsBox.Controls.Add(this.label1);
            this.ActionsBox.Controls.Add(this.ActionNameLabel);
            this.ActionsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionsBox.Location = new System.Drawing.Point(12, 224);
            this.ActionsBox.Name = "ActionsBox";
            this.ActionsBox.Size = new System.Drawing.Size(405, 256);
            this.ActionsBox.TabIndex = 26;
            this.ActionsBox.TabStop = false;
            this.ActionsBox.Text = "Actions";
            // 
            // ActionDescriptionText
            // 
            this.ActionDescriptionText.BackColor = System.Drawing.SystemColors.Control;
            this.ActionDescriptionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ActionDescriptionText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ActionDescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionDescriptionText.Location = new System.Drawing.Point(10, 203);
            this.ActionDescriptionText.Name = "ActionDescriptionText";
            this.ActionDescriptionText.ReadOnly = true;
            this.ActionDescriptionText.Size = new System.Drawing.Size(386, 46);
            this.ActionDescriptionText.TabIndex = 52;
            this.ActionDescriptionText.Text = "";
            // 
            // SelectedTreeView
            // 
            this.SelectedTreeView.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTreeView.Location = new System.Drawing.Point(219, 48);
            this.SelectedTreeView.Name = "SelectedTreeView";
            this.SelectedTreeView.Size = new System.Drawing.Size(128, 109);
            this.SelectedTreeView.TabIndex = 6;
            this.SelectedTreeView.DoubleClick += new System.EventHandler(this.SettingsButton_Click);
            this.SelectedTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SelectedTreeView_AfterSelect);
            // 
            // SelectedActionsLabel
            // 
            this.SelectedActionsLabel.AutoSize = true;
            this.SelectedActionsLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedActionsLabel.Location = new System.Drawing.Point(225, 25);
            this.SelectedActionsLabel.Name = "SelectedActionsLabel";
            this.SelectedActionsLabel.Size = new System.Drawing.Size(95, 15);
            this.SelectedActionsLabel.TabIndex = 12;
            this.SelectedActionsLabel.Text = "Selected Actions";
            // 
            // ActionsListBox
            // 
            this.ActionsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionsListBox.FormattingEnabled = true;
            this.ActionsListBox.ItemHeight = 15;
            this.ActionsListBox.Location = new System.Drawing.Point(10, 48);
            this.ActionsListBox.Name = "ActionsListBox";
            this.ActionsListBox.Size = new System.Drawing.Size(128, 109);
            this.ActionsListBox.Sorted = true;
            this.ActionsListBox.TabIndex = 3;
            this.ActionsListBox.SelectedIndexChanged += new System.EventHandler(this.ActionsListBox_SelectedIndexChanged);
            this.ActionsListBox.DoubleClick += new System.EventHandler(this.SelectActionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Description:";
            // 
            // ActionNameLabel
            // 
            this.ActionNameLabel.AutoSize = true;
            this.ActionNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionNameLabel.Location = new System.Drawing.Point(10, 25);
            this.ActionNameLabel.Name = "ActionNameLabel";
            this.ActionNameLabel.Size = new System.Drawing.Size(79, 15);
            this.ActionNameLabel.TabIndex = 0;
            this.ActionNameLabel.Text = "Action Name:";
            // 
            // ActionNameText
            // 
            this.ActionNameText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionNameText.Location = new System.Drawing.Point(113, 30);
            this.ActionNameText.Name = "ActionNameText";
            this.ActionNameText.Size = new System.Drawing.Size(136, 24);
            this.ActionNameText.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(6, 92);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(72, 15);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description:";
            // 
            // CreatorNameText
            // 
            this.CreatorNameText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatorNameText.Location = new System.Drawing.Point(113, 60);
            this.CreatorNameText.Name = "CreatorNameText";
            this.CreatorNameText.Size = new System.Drawing.Size(136, 24);
            this.CreatorNameText.TabIndex = 1;
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(213, 494);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 23;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // DescriptionText
            // 
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(6, 110);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(390, 45);
            this.DescriptionText.TabIndex = 2;
            this.DescriptionText.Text = "";
            // 
            // creatorNameLabel
            // 
            this.creatorNameLabel.AutoSize = true;
            this.creatorNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creatorNameLabel.Location = new System.Drawing.Point(6, 62);
            this.creatorNameLabel.Name = "creatorNameLabel";
            this.creatorNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.creatorNameLabel.Size = new System.Drawing.Size(85, 15);
            this.creatorNameLabel.TabIndex = 1;
            this.creatorNameLabel.Text = "Creator Name:";
            // 
            // TSCNameLabel
            // 
            this.TSCNameLabel.AutoSize = true;
            this.TSCNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSCNameLabel.Location = new System.Drawing.Point(6, 32);
            this.TSCNameLabel.Name = "TSCNameLabel";
            this.TSCNameLabel.Size = new System.Drawing.Size(90, 15);
            this.TSCNameLabel.TabIndex = 0;
            this.TSCNameLabel.Text = "Scenario Name:";
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(132, 494);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 22;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // TSCDetailsBox
            // 
            this.TSCDetailsBox.Controls.Add(this.DescriptionText);
            this.TSCDetailsBox.Controls.Add(this.CreatorNameText);
            this.TSCDetailsBox.Controls.Add(this.ActionNameText);
            this.TSCDetailsBox.Controls.Add(this.descriptionLabel);
            this.TSCDetailsBox.Controls.Add(this.creatorNameLabel);
            this.TSCDetailsBox.Controls.Add(this.TSCNameLabel);
            this.TSCDetailsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSCDetailsBox.Location = new System.Drawing.Point(12, 55);
            this.TSCDetailsBox.Name = "TSCDetailsBox";
            this.TSCDetailsBox.Size = new System.Drawing.Size(405, 163);
            this.TSCDetailsBox.TabIndex = 24;
            this.TSCDetailsBox.TabStop = false;
            this.TSCDetailsBox.Text = "TSC Details";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(10, 16);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(194, 20);
            this.Title.TabIndex = 25;
            this.Title.Text = "Create Test Scenario";
            // 
            // CreateTSCDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 532);
            this.Controls.Add(this.ActionsBox);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.TSCDetailsBox);
            this.Controls.Add(this.Title);
            this.Name = "CreateTSCDialog";
            this.Text = "CreateTSCDialog";
            this.ActionsBox.ResumeLayout(false);
            this.ActionsBox.PerformLayout();
            this.TSCDetailsBox.ResumeLayout(false);
            this.TSCDetailsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button MoveDownActionButton;
        private System.Windows.Forms.Button MoveUpActionButton;
        private System.Windows.Forms.Button UnselectActionButton;
        private System.Windows.Forms.Button SelectActionButton;
        private System.Windows.Forms.GroupBox ActionsBox;
        private System.Windows.Forms.TreeView SelectedTreeView;
        private System.Windows.Forms.Label SelectedActionsLabel;
        private System.Windows.Forms.ListBox ActionsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ActionNameLabel;
        private System.Windows.Forms.TextBox ActionNameText;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox CreatorNameText;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.Label creatorNameLabel;
        private System.Windows.Forms.Label TSCNameLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox TSCDetailsBox;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.RichTextBox ActionDescriptionText;
    }
}