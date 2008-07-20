namespace AST.Management {
    partial class ProgressDialog {
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
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.ResultsGridView = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidityString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndStationComboBox = new System.Windows.Forms.ComboBox();
            this.EndStationLabel = new System.Windows.Forms.Label();
            this.EndStationDetailsBox = new System.Windows.Forms.GroupBox();
            this.EndStationNameText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EndStationNameLabel = new System.Windows.Forms.Label();
            this.MacText = new System.Windows.Forms.Label();
            this.MacLabel = new System.Windows.Forms.Label();
            this.OSTypeText = new System.Windows.Forms.Label();
            this.UsernameText = new System.Windows.Forms.Label();
            this.IPText = new System.Windows.Forms.Label();
            this.OSTypeLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.CurrentActionLabel = new System.Windows.Forms.Label();
            this.ActionNoLabel = new System.Windows.Forms.Label();
            this.ActionNoText = new System.Windows.Forms.Label();
            this.CurrentActionText = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ViewReportLabel = new System.Windows.Forms.Label();
            this.MessageText = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGridView)).BeginInit();
            this.EndStationDetailsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(13, 288);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(613, 23);
            this.ProgressBar.TabIndex = 0;
            this.ProgressBar.Value = 70;
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(313, 322);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(71, 23);
            this.MyCancelButton.TabIndex = 20;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // ResultsGridView
            // 
            this.ResultsGridView.AllowUserToAddRows = false;
            this.ResultsGridView.AllowUserToDeleteRows = false;
            this.ResultsGridView.AllowUserToResizeRows = false;
            this.ResultsGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.ResultsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.EndStation,
            this.Status,
            this.ValidityString});
            this.ResultsGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ResultsGridView.Location = new System.Drawing.Point(10, 47);
            this.ResultsGridView.MultiSelect = false;
            this.ResultsGridView.Name = "ResultsGridView";
            this.ResultsGridView.ReadOnly = true;
            this.ResultsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultsGridView.Size = new System.Drawing.Size(418, 106);
            this.ResultsGridView.TabIndex = 21;
            this.ResultsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultsGridView_CellContentClick);
            // 
            // Action
            // 
            this.Action.Frozen = true;
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // EndStation
            // 
            this.EndStation.Frozen = true;
            this.EndStation.HeaderText = "End-Station";
            this.EndStation.Name = "EndStation";
            this.EndStation.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.Frozen = true;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 70;
            // 
            // ValidityString
            // 
            this.ValidityString.Frozen = true;
            this.ValidityString.HeaderText = "Validity String";
            this.ValidityString.Name = "ValidityString";
            this.ValidityString.ReadOnly = true;
            // 
            // EndStationComboBox
            // 
            this.EndStationComboBox.FormattingEnabled = true;
            this.EndStationComboBox.Location = new System.Drawing.Point(521, 46);
            this.EndStationComboBox.Name = "EndStationComboBox";
            this.EndStationComboBox.Size = new System.Drawing.Size(105, 21);
            this.EndStationComboBox.TabIndex = 22;
            this.EndStationComboBox.SelectedIndexChanged += new System.EventHandler(this.EndStationComboBox_SelectedIndexChanged);
            // 
            // EndStationLabel
            // 
            this.EndStationLabel.AutoSize = true;
            this.EndStationLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationLabel.Location = new System.Drawing.Point(436, 48);
            this.EndStationLabel.Name = "EndStationLabel";
            this.EndStationLabel.Size = new System.Drawing.Size(79, 15);
            this.EndStationLabel.TabIndex = 23;
            this.EndStationLabel.Text = "End-Stations:";
            // 
            // EndStationDetailsBox
            // 
            this.EndStationDetailsBox.Controls.Add(this.EndStationNameText);
            this.EndStationDetailsBox.Controls.Add(this.label3);
            this.EndStationDetailsBox.Controls.Add(this.EndStationNameLabel);
            this.EndStationDetailsBox.Controls.Add(this.MacText);
            this.EndStationDetailsBox.Controls.Add(this.MacLabel);
            this.EndStationDetailsBox.Controls.Add(this.OSTypeText);
            this.EndStationDetailsBox.Controls.Add(this.UsernameText);
            this.EndStationDetailsBox.Controls.Add(this.IPText);
            this.EndStationDetailsBox.Controls.Add(this.OSTypeLabel);
            this.EndStationDetailsBox.Controls.Add(this.UsernameLabel);
            this.EndStationDetailsBox.Controls.Add(this.IPLabel);
            this.EndStationDetailsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationDetailsBox.Location = new System.Drawing.Point(439, 73);
            this.EndStationDetailsBox.Name = "EndStationDetailsBox";
            this.EndStationDetailsBox.Size = new System.Drawing.Size(187, 127);
            this.EndStationDetailsBox.TabIndex = 24;
            this.EndStationDetailsBox.TabStop = false;
            this.EndStationDetailsBox.Text = "End-Station Details";
            // 
            // EndStationNameText
            // 
            this.EndStationNameText.AutoSize = true;
            this.EndStationNameText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationNameText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.EndStationNameText.Location = new System.Drawing.Point(79, 19);
            this.EndStationNameText.Name = "EndStationNameText";
            this.EndStationNameText.Size = new System.Drawing.Size(0, 15);
            this.EndStationNameText.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(36, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 46;
            // 
            // EndStationNameLabel
            // 
            this.EndStationNameLabel.AutoSize = true;
            this.EndStationNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationNameLabel.Location = new System.Drawing.Point(11, 19);
            this.EndStationNameLabel.Name = "EndStationNameLabel";
            this.EndStationNameLabel.Size = new System.Drawing.Size(63, 15);
            this.EndStationNameLabel.TabIndex = 45;
            this.EndStationNameLabel.Text = "Name (ID):";
            // 
            // MacText
            // 
            this.MacText.AutoSize = true;
            this.MacText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MacText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MacText.Location = new System.Drawing.Point(54, 100);
            this.MacText.Name = "MacText";
            this.MacText.Size = new System.Drawing.Size(0, 15);
            this.MacText.TabIndex = 44;
            // 
            // MacLabel
            // 
            this.MacLabel.AutoSize = true;
            this.MacLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MacLabel.Location = new System.Drawing.Point(11, 100);
            this.MacLabel.Name = "MacLabel";
            this.MacLabel.Size = new System.Drawing.Size(35, 15);
            this.MacLabel.TabIndex = 43;
            this.MacLabel.Text = "MAC:";
            // 
            // OSTypeText
            // 
            this.OSTypeText.AutoSize = true;
            this.OSTypeText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSTypeText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OSTypeText.Location = new System.Drawing.Point(71, 80);
            this.OSTypeText.Name = "OSTypeText";
            this.OSTypeText.Size = new System.Drawing.Size(0, 15);
            this.OSTypeText.TabIndex = 42;
            // 
            // UsernameText
            // 
            this.UsernameText.AutoSize = true;
            this.UsernameText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.UsernameText.Location = new System.Drawing.Point(82, 60);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(0, 15);
            this.UsernameText.TabIndex = 41;
            // 
            // IPText
            // 
            this.IPText.AutoSize = true;
            this.IPText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.IPText.Location = new System.Drawing.Point(36, 40);
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(0, 15);
            this.IPText.TabIndex = 40;
            // 
            // OSTypeLabel
            // 
            this.OSTypeLabel.AutoSize = true;
            this.OSTypeLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSTypeLabel.Location = new System.Drawing.Point(11, 80);
            this.OSTypeLabel.Name = "OSTypeLabel";
            this.OSTypeLabel.Size = new System.Drawing.Size(54, 15);
            this.OSTypeLabel.TabIndex = 39;
            this.OSTypeLabel.Text = "OS Type:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(11, 60);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(65, 15);
            this.UsernameLabel.TabIndex = 38;
            this.UsernameLabel.Text = "Username:";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.Location = new System.Drawing.Point(11, 40);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(19, 15);
            this.IPLabel.TabIndex = 37;
            this.IPLabel.Text = "IP:";
            // 
            // CurrentActionLabel
            // 
            this.CurrentActionLabel.AutoSize = true;
            this.CurrentActionLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentActionLabel.Location = new System.Drawing.Point(10, 258);
            this.CurrentActionLabel.Name = "CurrentActionLabel";
            this.CurrentActionLabel.Size = new System.Drawing.Size(105, 15);
            this.CurrentActionLabel.TabIndex = 39;
            this.CurrentActionLabel.Text = "Current Action:";
            // 
            // ActionNoLabel
            // 
            this.ActionNoLabel.AutoSize = true;
            this.ActionNoLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionNoLabel.Location = new System.Drawing.Point(307, 258);
            this.ActionNoLabel.Name = "ActionNoLabel";
            this.ActionNoLabel.Size = new System.Drawing.Size(77, 15);
            this.ActionNoLabel.TabIndex = 40;
            this.ActionNoLabel.Text = "Action No.:";
            // 
            // ActionNoText
            // 
            this.ActionNoText.AutoSize = true;
            this.ActionNoText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionNoText.Location = new System.Drawing.Point(387, 258);
            this.ActionNoText.Name = "ActionNoText";
            this.ActionNoText.Size = new System.Drawing.Size(34, 15);
            this.ActionNoText.TabIndex = 41;
            this.ActionNoText.Text = "         ";
            // 
            // CurrentActionText
            // 
            this.CurrentActionText.AutoSize = true;
            this.CurrentActionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentActionText.Location = new System.Drawing.Point(121, 258);
            this.CurrentActionText.Name = "CurrentActionText";
            this.CurrentActionText.Size = new System.Drawing.Size(37, 15);
            this.CurrentActionText.TabIndex = 42;
            this.CurrentActionText.Text = "          ";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(179, 20);
            this.Title.TabIndex = 43;
            this.Title.Text = "Execution Progress";
            // 
            // OkButton
            // 
            this.OkButton.Enabled = false;
            this.OkButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(236, 322);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(71, 23);
            this.OkButton.TabIndex = 44;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(13, 173);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(64, 15);
            this.MessageLabel.TabIndex = 46;
            this.MessageLabel.Text = "Message:";
            // 
            // ViewReportLabel
            // 
            this.ViewReportLabel.AutoSize = true;
            this.ViewReportLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewReportLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ViewReportLabel.Location = new System.Drawing.Point(405, 327);
            this.ViewReportLabel.Name = "ViewReportLabel";
            this.ViewReportLabel.Size = new System.Drawing.Size(76, 13);
            this.ViewReportLabel.TabIndex = 48;
            this.ViewReportLabel.Text = "View Report";
            this.ViewReportLabel.Click += new System.EventHandler(this.ViewReportLabel_Click);
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(91, 173);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(334, 66);
            this.MessageText.TabIndex = 49;
            this.MessageText.Text = "";
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 358);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.ViewReportLabel);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.CurrentActionText);
            this.Controls.Add(this.ActionNoText);
            this.Controls.Add(this.ActionNoLabel);
            this.Controls.Add(this.CurrentActionLabel);
            this.Controls.Add(this.EndStationDetailsBox);
            this.Controls.Add(this.EndStationLabel);
            this.Controls.Add(this.EndStationComboBox);
            this.Controls.Add(this.ResultsGridView);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.ProgressBar);
            this.Name = "ProgressDialog";
            this.Text = "Execution Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGridView)).EndInit();
            this.EndStationDetailsBox.ResumeLayout(false);
            this.EndStationDetailsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.DataGridView ResultsGridView;
        private System.Windows.Forms.ComboBox EndStationComboBox;
        private System.Windows.Forms.Label EndStationLabel;
        private System.Windows.Forms.GroupBox EndStationDetailsBox;
        private System.Windows.Forms.Label OSTypeText;
        private System.Windows.Forms.Label UsernameText;
        private System.Windows.Forms.Label IPText;
        private System.Windows.Forms.Label OSTypeLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label EndStationNameLabel;
        private System.Windows.Forms.Label MacText;
        private System.Windows.Forms.Label MacLabel;
        private System.Windows.Forms.Label CurrentActionLabel;
        private System.Windows.Forms.Label ActionNoLabel;
        private System.Windows.Forms.Label ActionNoText;
        private System.Windows.Forms.Label CurrentActionText;
        private System.Windows.Forms.Label EndStationNameText;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidityString;
        private System.Windows.Forms.Label ViewReportLabel;
        private System.Windows.Forms.RichTextBox MessageText;
    }
}