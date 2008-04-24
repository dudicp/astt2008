namespace AST.Presentation {
    partial class EditActionDialog {
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
            this.ActionDetailsBox = new System.Windows.Forms.GroupBox();
            this.MoveDownParameterButton = new System.Windows.Forms.Button();
            this.MoveUpParameterButton = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.UnselectParameterButton = new System.Windows.Forms.Button();
            this.SelectedParametersListBox = new System.Windows.Forms.ListBox();
            this.SelectParameterButton = new System.Windows.Forms.Button();
            this.SelectedParametersLabel = new System.Windows.Forms.Label();
            this.ParameterListBox = new System.Windows.Forms.ListBox();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.ParameterNameLabel = new System.Windows.Forms.Label();
            this.EndStationsGroupBox = new System.Windows.Forms.GroupBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewEndStationButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.ParallelCheckBox = new System.Windows.Forms.CheckBox();
            this.MoveDownEndStationButton = new System.Windows.Forms.Button();
            this.MoveUpEndStationButton = new System.Windows.Forms.Button();
            this.UnselectEndStationButton = new System.Windows.Forms.Button();
            this.SelectEndStationButton = new System.Windows.Forms.Button();
            this.SelectedEndStationsListBox = new System.Windows.Forms.ListBox();
            this.SelectedEndStationLabel = new System.Windows.Forms.Label();
            this.EndStationsListBox = new System.Windows.Forms.ListBox();
            this.EndStationsLabel = new System.Windows.Forms.Label();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.ActionDetailsBox.SuspendLayout();
            this.EndStationsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(13, 14);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(105, 20);
            this.Title.TabIndex = 16;
            this.Title.Text = "Edit Action";
            // 
            // ActionDetailsBox
            // 
            this.ActionDetailsBox.Controls.Add(this.MoveDownParameterButton);
            this.ActionDetailsBox.Controls.Add(this.MoveUpParameterButton);
            this.ActionDetailsBox.Controls.Add(this.InputLabel);
            this.ActionDetailsBox.Controls.Add(this.InputTextBox);
            this.ActionDetailsBox.Controls.Add(this.UnselectParameterButton);
            this.ActionDetailsBox.Controls.Add(this.SelectedParametersListBox);
            this.ActionDetailsBox.Controls.Add(this.SelectParameterButton);
            this.ActionDetailsBox.Controls.Add(this.SelectedParametersLabel);
            this.ActionDetailsBox.Controls.Add(this.ParameterListBox);
            this.ActionDetailsBox.Controls.Add(this.DescriptionText);
            this.ActionDetailsBox.Controls.Add(this.descriptionLabel);
            this.ActionDetailsBox.Controls.Add(this.ParameterNameLabel);
            this.ActionDetailsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionDetailsBox.Location = new System.Drawing.Point(15, 53);
            this.ActionDetailsBox.Name = "ActionDetailsBox";
            this.ActionDetailsBox.Size = new System.Drawing.Size(435, 232);
            this.ActionDetailsBox.TabIndex = 17;
            this.ActionDetailsBox.TabStop = false;
            this.ActionDetailsBox.Text = "Action Details";
            // 
            // MoveDownParameterButton
            // 
            this.MoveDownParameterButton.Enabled = false;
            this.MoveDownParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownParameterButton.Location = new System.Drawing.Point(391, 87);
            this.MoveDownParameterButton.Name = "MoveDownParameterButton";
            this.MoveDownParameterButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownParameterButton.TabIndex = 20;
            this.MoveDownParameterButton.Text = "↓";
            this.MoveDownParameterButton.UseVisualStyleBackColor = true;
            this.MoveDownParameterButton.Click += new System.EventHandler(this.MoveDownParameterButton_Click);
            // 
            // MoveUpParameterButton
            // 
            this.MoveUpParameterButton.Enabled = false;
            this.MoveUpParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpParameterButton.Location = new System.Drawing.Point(391, 58);
            this.MoveUpParameterButton.Name = "MoveUpParameterButton";
            this.MoveUpParameterButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpParameterButton.TabIndex = 19;
            this.MoveUpParameterButton.Text = "↑";
            this.MoveUpParameterButton.UseVisualStyleBackColor = true;
            this.MoveUpParameterButton.Click += new System.EventHandler(this.MoveUpParameterButton_Click);
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLabel.Location = new System.Drawing.Point(145, 25);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(38, 15);
            this.InputLabel.TabIndex = 18;
            this.InputLabel.Text = "Input:";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Enabled = false;
            this.InputTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(147, 48);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(100, 21);
            this.InputTextBox.TabIndex = 17;
            // 
            // UnselectParameterButton
            // 
            this.UnselectParameterButton.Enabled = false;
            this.UnselectParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnselectParameterButton.Location = new System.Drawing.Point(177, 104);
            this.UnselectParameterButton.Name = "UnselectParameterButton";
            this.UnselectParameterButton.Size = new System.Drawing.Size(36, 23);
            this.UnselectParameterButton.TabIndex = 16;
            this.UnselectParameterButton.Text = "←";
            this.UnselectParameterButton.UseVisualStyleBackColor = true;
            this.UnselectParameterButton.Click += new System.EventHandler(this.UnselectParameterButton_Click);
            // 
            // SelectedParametersListBox
            // 
            this.SelectedParametersListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedParametersListBox.FormattingEnabled = true;
            this.SelectedParametersListBox.ItemHeight = 15;
            this.SelectedParametersListBox.Location = new System.Drawing.Point(257, 48);
            this.SelectedParametersListBox.Name = "SelectedParametersListBox";
            this.SelectedParametersListBox.Size = new System.Drawing.Size(128, 79);
            this.SelectedParametersListBox.TabIndex = 15;
            this.SelectedParametersListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedParametersListBox_SelectedIndexChanged);
            // 
            // SelectParameterButton
            // 
            this.SelectParameterButton.Enabled = false;
            this.SelectParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectParameterButton.Location = new System.Drawing.Point(177, 75);
            this.SelectParameterButton.Name = "SelectParameterButton";
            this.SelectParameterButton.Size = new System.Drawing.Size(35, 23);
            this.SelectParameterButton.TabIndex = 14;
            this.SelectParameterButton.Text = "→";
            this.SelectParameterButton.UseVisualStyleBackColor = true;
            this.SelectParameterButton.Click += new System.EventHandler(this.SelectParameterButton_Click);
            // 
            // SelectedParametersLabel
            // 
            this.SelectedParametersLabel.AutoSize = true;
            this.SelectedParametersLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedParametersLabel.Location = new System.Drawing.Point(254, 25);
            this.SelectedParametersLabel.Name = "SelectedParametersLabel";
            this.SelectedParametersLabel.Size = new System.Drawing.Size(118, 15);
            this.SelectedParametersLabel.TabIndex = 12;
            this.SelectedParametersLabel.Text = "Selected Parameters:";
            // 
            // ParameterListBox
            // 
            this.ParameterListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterListBox.FormattingEnabled = true;
            this.ParameterListBox.ItemHeight = 15;
            this.ParameterListBox.Location = new System.Drawing.Point(10, 48);
            this.ParameterListBox.Name = "ParameterListBox";
            this.ParameterListBox.Size = new System.Drawing.Size(128, 79);
            this.ParameterListBox.TabIndex = 11;
            this.ParameterListBox.SelectedIndexChanged += new System.EventHandler(this.ParameterListBox_SelectedIndexChanged);
            // 
            // DescriptionText
            // 
            this.DescriptionText.Enabled = false;
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(10, 174);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(376, 45);
            this.DescriptionText.TabIndex = 10;
            this.DescriptionText.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(6, 146);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(72, 15);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description:";
            // 
            // ParameterNameLabel
            // 
            this.ParameterNameLabel.AutoSize = true;
            this.ParameterNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterNameLabel.Location = new System.Drawing.Point(10, 25);
            this.ParameterNameLabel.Name = "ParameterNameLabel";
            this.ParameterNameLabel.Size = new System.Drawing.Size(99, 15);
            this.ParameterNameLabel.TabIndex = 0;
            this.ParameterNameLabel.Text = "Parameter Name:";
            // 
            // EndStationsGroupBox
            // 
            this.EndStationsGroupBox.Controls.Add(this.EditButton);
            this.EndStationsGroupBox.Controls.Add(this.NewEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.ScheduleButton);
            this.EndStationsGroupBox.Controls.Add(this.ParallelCheckBox);
            this.EndStationsGroupBox.Controls.Add(this.MoveDownEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.MoveUpEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.UnselectEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.SelectEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.SelectedEndStationsListBox);
            this.EndStationsGroupBox.Controls.Add(this.SelectedEndStationLabel);
            this.EndStationsGroupBox.Controls.Add(this.EndStationsListBox);
            this.EndStationsGroupBox.Controls.Add(this.EndStationsLabel);
            this.EndStationsGroupBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationsGroupBox.Location = new System.Drawing.Point(14, 286);
            this.EndStationsGroupBox.Name = "EndStationsGroupBox";
            this.EndStationsGroupBox.Size = new System.Drawing.Size(436, 174);
            this.EndStationsGroupBox.TabIndex = 18;
            this.EndStationsGroupBox.TabStop = false;
            this.EndStationsGroupBox.Text = "End-Stations";
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(80, 137);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(58, 23);
            this.EditButton.TabIndex = 25;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewEndStationButton
            // 
            this.NewEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewEndStationButton.Location = new System.Drawing.Point(10, 137);
            this.NewEndStationButton.Name = "NewEndStationButton";
            this.NewEndStationButton.Size = new System.Drawing.Size(58, 23);
            this.NewEndStationButton.TabIndex = 24;
            this.NewEndStationButton.Text = "New";
            this.NewEndStationButton.UseVisualStyleBackColor = true;
            this.NewEndStationButton.Click += new System.EventHandler(this.NewEndStationButton_Click);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Enabled = false;
            this.ScheduleButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScheduleButton.Location = new System.Drawing.Point(323, 138);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(75, 23);
            this.ScheduleButton.TabIndex = 23;
            this.ScheduleButton.Text = "Schedule";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            // 
            // ParallelCheckBox
            // 
            this.ParallelCheckBox.AutoSize = true;
            this.ParallelCheckBox.Location = new System.Drawing.Point(257, 142);
            this.ParallelCheckBox.Name = "ParallelCheckBox";
            this.ParallelCheckBox.Size = new System.Drawing.Size(60, 18);
            this.ParallelCheckBox.TabIndex = 22;
            this.ParallelCheckBox.Text = "Parallel";
            this.ParallelCheckBox.UseVisualStyleBackColor = true;
            // 
            // MoveDownEndStationButton
            // 
            this.MoveDownEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownEndStationButton.Location = new System.Drawing.Point(392, 88);
            this.MoveDownEndStationButton.Name = "MoveDownEndStationButton";
            this.MoveDownEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownEndStationButton.TabIndex = 21;
            this.MoveDownEndStationButton.Text = "↓";
            this.MoveDownEndStationButton.UseVisualStyleBackColor = true;
            this.MoveDownEndStationButton.Click += new System.EventHandler(this.MoveDownEndStationButton_Click);
            // 
            // MoveUpEndStationButton
            // 
            this.MoveUpEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpEndStationButton.Location = new System.Drawing.Point(392, 59);
            this.MoveUpEndStationButton.Name = "MoveUpEndStationButton";
            this.MoveUpEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpEndStationButton.TabIndex = 21;
            this.MoveUpEndStationButton.Text = "↑";
            this.MoveUpEndStationButton.UseVisualStyleBackColor = true;
            this.MoveUpEndStationButton.Click += new System.EventHandler(this.MoveUpEndStationButton_Click);
            // 
            // UnselectEndStationButton
            // 
            this.UnselectEndStationButton.Enabled = false;
            this.UnselectEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnselectEndStationButton.Location = new System.Drawing.Point(178, 88);
            this.UnselectEndStationButton.Name = "UnselectEndStationButton";
            this.UnselectEndStationButton.Size = new System.Drawing.Size(36, 23);
            this.UnselectEndStationButton.TabIndex = 21;
            this.UnselectEndStationButton.Text = "←";
            this.UnselectEndStationButton.UseVisualStyleBackColor = true;
            this.UnselectEndStationButton.Click += new System.EventHandler(this.UnselectEndStationButton_Click);
            // 
            // SelectEndStationButton
            // 
            this.SelectEndStationButton.Enabled = false;
            this.SelectEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectEndStationButton.Location = new System.Drawing.Point(178, 59);
            this.SelectEndStationButton.Name = "SelectEndStationButton";
            this.SelectEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.SelectEndStationButton.TabIndex = 21;
            this.SelectEndStationButton.Text = "→";
            this.SelectEndStationButton.UseVisualStyleBackColor = true;
            this.SelectEndStationButton.Click += new System.EventHandler(this.SelectEndStationButton_Click);
            // 
            // SelectedEndStationsListBox
            // 
            this.SelectedEndStationsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedEndStationsListBox.FormattingEnabled = true;
            this.SelectedEndStationsListBox.ItemHeight = 15;
            this.SelectedEndStationsListBox.Location = new System.Drawing.Point(257, 48);
            this.SelectedEndStationsListBox.Name = "SelectedEndStationsListBox";
            this.SelectedEndStationsListBox.Size = new System.Drawing.Size(128, 79);
            this.SelectedEndStationsListBox.TabIndex = 15;
            this.SelectedEndStationsListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedEndStationsListBox_SelectedIndexChanged);
            // 
            // SelectedEndStationLabel
            // 
            this.SelectedEndStationLabel.AutoSize = true;
            this.SelectedEndStationLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedEndStationLabel.Location = new System.Drawing.Point(254, 25);
            this.SelectedEndStationLabel.Name = "SelectedEndStationLabel";
            this.SelectedEndStationLabel.Size = new System.Drawing.Size(126, 15);
            this.SelectedEndStationLabel.TabIndex = 12;
            this.SelectedEndStationLabel.Text = "Selected End-Stations:";
            // 
            // EndStationsListBox
            // 
            this.EndStationsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationsListBox.FormattingEnabled = true;
            this.EndStationsListBox.ItemHeight = 15;
            this.EndStationsListBox.Location = new System.Drawing.Point(10, 48);
            this.EndStationsListBox.Name = "EndStationsListBox";
            this.EndStationsListBox.Size = new System.Drawing.Size(128, 79);
            this.EndStationsListBox.TabIndex = 11;
            this.EndStationsListBox.SelectedIndexChanged += new System.EventHandler(this.EndStationsListBox_SelectedIndexChanged);
            // 
            // EndStationsLabel
            // 
            this.EndStationsLabel.AutoSize = true;
            this.EndStationsLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationsLabel.Location = new System.Drawing.Point(10, 25);
            this.EndStationsLabel.Name = "EndStationsLabel";
            this.EndStationsLabel.Size = new System.Drawing.Size(107, 15);
            this.EndStationsLabel.TabIndex = 0;
            this.EndStationsLabel.Text = "End-Station Name:";
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(233, 489);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(71, 23);
            this.MyCancelButton.TabIndex = 17;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(155, 489);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(72, 23);
            this.okButton.TabIndex = 18;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // EditActionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 523);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.EndStationsGroupBox);
            this.Controls.Add(this.ActionDetailsBox);
            this.Controls.Add(this.Title);
            this.Name = "EditActionDialog";
            this.Text = "Edit Action";
            this.ActionDetailsBox.ResumeLayout(false);
            this.ActionDetailsBox.PerformLayout();
            this.EndStationsGroupBox.ResumeLayout(false);
            this.EndStationsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.GroupBox ActionDetailsBox;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label ParameterNameLabel;
        private System.Windows.Forms.ListBox ParameterListBox;
        private System.Windows.Forms.Button UnselectParameterButton;
        private System.Windows.Forms.ListBox SelectedParametersListBox;
        private System.Windows.Forms.Button SelectParameterButton;
        private System.Windows.Forms.Label SelectedParametersLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.GroupBox EndStationsGroupBox;
        private System.Windows.Forms.ListBox SelectedEndStationsListBox;
        private System.Windows.Forms.Label SelectedEndStationLabel;
        private System.Windows.Forms.ListBox EndStationsListBox;
        private System.Windows.Forms.Label EndStationsLabel;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button MoveDownParameterButton;
        private System.Windows.Forms.Button MoveUpParameterButton;
        private System.Windows.Forms.Button MoveDownEndStationButton;
        private System.Windows.Forms.Button MoveUpEndStationButton;
        private System.Windows.Forms.Button UnselectEndStationButton;
        private System.Windows.Forms.Button SelectEndStationButton;
        private System.Windows.Forms.Button ScheduleButton;
        private System.Windows.Forms.CheckBox ParallelCheckBox;
        private System.Windows.Forms.Button NewEndStationButton;
        private System.Windows.Forms.Button EditButton;
    }
}