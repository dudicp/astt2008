namespace AST.Presentation {
    partial class CreateAdditionalActionDialog {
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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.TimeoutText = new System.Windows.Forms.NumericUpDown();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.ValidityCheckBox = new System.Windows.Forms.CheckBox();
            this.ValidityText = new System.Windows.Forms.TextBox();
            this.ContentText = new System.Windows.Forms.TextBox();
            this.RemoveParameterButton = new System.Windows.Forms.Button();
            this.parameterNameLabel = new System.Windows.Forms.Label();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.ParametersBox = new System.Windows.Forms.GroupBox();
            this.NewParameterButton = new System.Windows.Forms.Button();
            this.EditParameterButton = new System.Windows.Forms.Button();
            this.ParametersComboBox = new System.Windows.Forms.ComboBox();
            this.ContentLabel = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.TestScriptRadio = new System.Windows.Forms.RadioButton();
            this.ScriptRadio = new System.Windows.Forms.RadioButton();
            this.CommandLineRadio = new System.Windows.Forms.RadioButton();
            this.CreatorNameText = new System.Windows.Forms.TextBox();
            this.ActionNameText = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.actionTypeLabel = new System.Windows.Forms.Label();
            this.actionContentBox = new System.Windows.Forms.GroupBox();
            this.OSTypeLabel = new System.Windows.Forms.Label();
            this.OScomboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.actionDetailsBox = new System.Windows.Forms.GroupBox();
            this.StopIfFailsCheckBox = new System.Windows.Forms.CheckBox();
            this.BatchFileRadio = new System.Windows.Forms.RadioButton();
            this.creatorNameLabel = new System.Windows.Forms.Label();
            this.actionNameLabel = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutText)).BeginInit();
            this.ParametersBox.SuspendLayout();
            this.actionContentBox.SuspendLayout();
            this.actionDetailsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Enabled = false;
            this.BrowseButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.Location = new System.Drawing.Point(303, 61);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(95, 23);
            this.BrowseButton.TabIndex = 10;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // TimeoutText
            // 
            this.TimeoutText.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeoutText.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TimeoutText.Location = new System.Drawing.Point(358, 90);
            this.TimeoutText.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.TimeoutText.Name = "TimeoutText";
            this.TimeoutText.Size = new System.Drawing.Size(40, 21);
            this.TimeoutText.TabIndex = 13;
            this.TimeoutText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TimeoutText.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TimeoutText.ValueChanged += new System.EventHandler(this.TimeoutText_ValueChanged);
            // 
            // TimeoutLabel
            // 
            this.TimeoutLabel.AutoSize = true;
            this.TimeoutLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeoutLabel.Location = new System.Drawing.Point(300, 93);
            this.TimeoutLabel.Name = "TimeoutLabel";
            this.TimeoutLabel.Size = new System.Drawing.Size(55, 15);
            this.TimeoutLabel.TabIndex = 16;
            this.TimeoutLabel.Text = "Timeout:";
            // 
            // ValidityCheckBox
            // 
            this.ValidityCheckBox.AutoSize = true;
            this.ValidityCheckBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidityCheckBox.Location = new System.Drawing.Point(6, 92);
            this.ValidityCheckBox.Name = "ValidityCheckBox";
            this.ValidityCheckBox.Size = new System.Drawing.Size(103, 19);
            this.ValidityCheckBox.TabIndex = 11;
            this.ValidityCheckBox.Text = "Validity String:";
            this.ValidityCheckBox.UseVisualStyleBackColor = true;
            this.ValidityCheckBox.CheckedChanged += new System.EventHandler(this.ValidityCheckBox_CheckedChanged);
            // 
            // ValidityText
            // 
            this.ValidityText.Enabled = false;
            this.ValidityText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidityText.Location = new System.Drawing.Point(113, 90);
            this.ValidityText.Name = "ValidityText";
            this.ValidityText.Size = new System.Drawing.Size(181, 24);
            this.ValidityText.TabIndex = 12;
            this.ValidityText.Leave += new System.EventHandler(this.SaveOSValidityString);
            // 
            // ContentText
            // 
            this.ContentText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentText.Location = new System.Drawing.Point(113, 60);
            this.ContentText.Name = "ContentText";
            this.ContentText.Size = new System.Drawing.Size(181, 24);
            this.ContentText.TabIndex = 9;
            this.ContentText.Leave += new System.EventHandler(this.SaveOSContent);
            // 
            // RemoveParameterButton
            // 
            this.RemoveParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveParameterButton.Location = new System.Drawing.Point(228, 25);
            this.RemoveParameterButton.Name = "RemoveParameterButton";
            this.RemoveParameterButton.Size = new System.Drawing.Size(63, 23);
            this.RemoveParameterButton.TabIndex = 15;
            this.RemoveParameterButton.Text = "Remove";
            this.RemoveParameterButton.UseVisualStyleBackColor = true;
            this.RemoveParameterButton.Click += new System.EventHandler(this.RemoveParameterButton_Click);
            // 
            // parameterNameLabel
            // 
            this.parameterNameLabel.AutoSize = true;
            this.parameterNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameterNameLabel.Location = new System.Drawing.Point(6, 28);
            this.parameterNameLabel.Name = "parameterNameLabel";
            this.parameterNameLabel.Size = new System.Drawing.Size(99, 15);
            this.parameterNameLabel.TabIndex = 19;
            this.parameterNameLabel.Text = "Parameter Name:";
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(215, 503);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 19;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // ParametersBox
            // 
            this.ParametersBox.Controls.Add(this.RemoveParameterButton);
            this.ParametersBox.Controls.Add(this.NewParameterButton);
            this.ParametersBox.Controls.Add(this.EditParameterButton);
            this.ParametersBox.Controls.Add(this.parameterNameLabel);
            this.ParametersBox.Controls.Add(this.ParametersComboBox);
            this.ParametersBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersBox.Location = new System.Drawing.Point(12, 429);
            this.ParametersBox.Name = "ParametersBox";
            this.ParametersBox.Size = new System.Drawing.Size(405, 59);
            this.ParametersBox.TabIndex = 23;
            this.ParametersBox.TabStop = false;
            this.ParametersBox.Text = "Parameters";
            // 
            // NewParameterButton
            // 
            this.NewParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewParameterButton.Location = new System.Drawing.Point(346, 25);
            this.NewParameterButton.Name = "NewParameterButton";
            this.NewParameterButton.Size = new System.Drawing.Size(53, 23);
            this.NewParameterButton.TabIndex = 17;
            this.NewParameterButton.Text = "New";
            this.NewParameterButton.UseVisualStyleBackColor = true;
            this.NewParameterButton.Click += new System.EventHandler(this.NewParameterButton_Click);
            // 
            // EditParameterButton
            // 
            this.EditParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditParameterButton.Location = new System.Drawing.Point(292, 25);
            this.EditParameterButton.Name = "EditParameterButton";
            this.EditParameterButton.Size = new System.Drawing.Size(53, 23);
            this.EditParameterButton.TabIndex = 16;
            this.EditParameterButton.Text = "Edit";
            this.EditParameterButton.UseVisualStyleBackColor = true;
            this.EditParameterButton.Click += new System.EventHandler(this.EditParameterButton_Click);
            // 
            // ParametersComboBox
            // 
            this.ParametersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParametersComboBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersComboBox.FormattingEnabled = true;
            this.ParametersComboBox.Location = new System.Drawing.Point(113, 25);
            this.ParametersComboBox.Name = "ParametersComboBox";
            this.ParametersComboBox.Size = new System.Drawing.Size(112, 23);
            this.ParametersComboBox.Sorted = true;
            this.ParametersComboBox.TabIndex = 14;
            // 
            // ContentLabel
            // 
            this.ContentLabel.AutoSize = true;
            this.ContentLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentLabel.Location = new System.Drawing.Point(6, 62);
            this.ContentLabel.Name = "ContentLabel";
            this.ContentLabel.Size = new System.Drawing.Size(92, 15);
            this.ContentLabel.TabIndex = 12;
            this.ContentLabel.Text = "Command Line:";
            // 
            // DescriptionText
            // 
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(9, 157);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(390, 45);
            this.DescriptionText.TabIndex = 6;
            this.DescriptionText.Text = "";
            // 
            // TestScriptRadio
            // 
            this.TestScriptRadio.AutoSize = true;
            this.TestScriptRadio.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestScriptRadio.Location = new System.Drawing.Point(225, 114);
            this.TestScriptRadio.Name = "TestScriptRadio";
            this.TestScriptRadio.Size = new System.Drawing.Size(76, 18);
            this.TestScriptRadio.TabIndex = 5;
            this.TestScriptRadio.TabStop = true;
            this.TestScriptRadio.Text = "Test Script";
            this.TestScriptRadio.UseVisualStyleBackColor = true;
            this.TestScriptRadio.CheckedChanged += new System.EventHandler(this.TestScriptRadio_CheckedChanged);
            // 
            // ScriptRadio
            // 
            this.ScriptRadio.AutoSize = true;
            this.ScriptRadio.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptRadio.Location = new System.Drawing.Point(113, 114);
            this.ScriptRadio.Name = "ScriptRadio";
            this.ScriptRadio.Size = new System.Drawing.Size(53, 18);
            this.ScriptRadio.TabIndex = 3;
            this.ScriptRadio.TabStop = true;
            this.ScriptRadio.Text = "Script";
            this.ScriptRadio.UseVisualStyleBackColor = true;
            this.ScriptRadio.CheckedChanged += new System.EventHandler(this.ScriptRadio_CheckedChanged);
            // 
            // CommandLineRadio
            // 
            this.CommandLineRadio.AutoSize = true;
            this.CommandLineRadio.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommandLineRadio.Location = new System.Drawing.Point(113, 90);
            this.CommandLineRadio.Name = "CommandLineRadio";
            this.CommandLineRadio.Size = new System.Drawing.Size(94, 18);
            this.CommandLineRadio.TabIndex = 2;
            this.CommandLineRadio.TabStop = true;
            this.CommandLineRadio.Text = "Command Line";
            this.CommandLineRadio.UseVisualStyleBackColor = true;
            this.CommandLineRadio.CheckedChanged += new System.EventHandler(this.CommandLineRadio_CheckedChanged);
            // 
            // CreatorNameText
            // 
            this.CreatorNameText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatorNameText.Location = new System.Drawing.Point(113, 60);
            this.CreatorNameText.Name = "CreatorNameText";
            this.CreatorNameText.Size = new System.Drawing.Size(136, 24);
            this.CreatorNameText.TabIndex = 1;
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
            this.descriptionLabel.Location = new System.Drawing.Point(6, 139);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(72, 15);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description:";
            // 
            // actionTypeLabel
            // 
            this.actionTypeLabel.AutoSize = true;
            this.actionTypeLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionTypeLabel.Location = new System.Drawing.Point(6, 92);
            this.actionTypeLabel.Name = "actionTypeLabel";
            this.actionTypeLabel.Size = new System.Drawing.Size(74, 15);
            this.actionTypeLabel.TabIndex = 2;
            this.actionTypeLabel.Text = "Action Type:";
            // 
            // actionContentBox
            // 
            this.actionContentBox.Controls.Add(this.BrowseButton);
            this.actionContentBox.Controls.Add(this.TimeoutText);
            this.actionContentBox.Controls.Add(this.TimeoutLabel);
            this.actionContentBox.Controls.Add(this.ValidityCheckBox);
            this.actionContentBox.Controls.Add(this.ValidityText);
            this.actionContentBox.Controls.Add(this.ContentText);
            this.actionContentBox.Controls.Add(this.ContentLabel);
            this.actionContentBox.Controls.Add(this.OSTypeLabel);
            this.actionContentBox.Controls.Add(this.OScomboBox);
            this.actionContentBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionContentBox.Location = new System.Drawing.Point(12, 297);
            this.actionContentBox.Name = "actionContentBox";
            this.actionContentBox.Size = new System.Drawing.Size(405, 126);
            this.actionContentBox.TabIndex = 22;
            this.actionContentBox.TabStop = false;
            this.actionContentBox.Text = "Action Content";
            // 
            // OSTypeLabel
            // 
            this.OSTypeLabel.AutoSize = true;
            this.OSTypeLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSTypeLabel.Location = new System.Drawing.Point(6, 32);
            this.OSTypeLabel.Name = "OSTypeLabel";
            this.OSTypeLabel.Size = new System.Drawing.Size(54, 15);
            this.OSTypeLabel.TabIndex = 11;
            this.OSTypeLabel.Text = "OS Type:";
            // 
            // OScomboBox
            // 
            this.OScomboBox.AllowDrop = true;
            this.OScomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OScomboBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OScomboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OScomboBox.FormattingEnabled = true;
            this.OScomboBox.Items.AddRange(new object[] {
            "Windows",
            "Unix"});
            this.OScomboBox.Location = new System.Drawing.Point(113, 30);
            this.OScomboBox.Name = "OScomboBox";
            this.OScomboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OScomboBox.Size = new System.Drawing.Size(136, 23);
            this.OScomboBox.TabIndex = 8;
            this.OScomboBox.SelectedIndexChanged += new System.EventHandler(this.OScomboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(134, 503);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 18;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // actionDetailsBox
            // 
            this.actionDetailsBox.Controls.Add(this.StopIfFailsCheckBox);
            this.actionDetailsBox.Controls.Add(this.BatchFileRadio);
            this.actionDetailsBox.Controls.Add(this.DescriptionText);
            this.actionDetailsBox.Controls.Add(this.TestScriptRadio);
            this.actionDetailsBox.Controls.Add(this.ScriptRadio);
            this.actionDetailsBox.Controls.Add(this.CommandLineRadio);
            this.actionDetailsBox.Controls.Add(this.CreatorNameText);
            this.actionDetailsBox.Controls.Add(this.ActionNameText);
            this.actionDetailsBox.Controls.Add(this.descriptionLabel);
            this.actionDetailsBox.Controls.Add(this.actionTypeLabel);
            this.actionDetailsBox.Controls.Add(this.creatorNameLabel);
            this.actionDetailsBox.Controls.Add(this.actionNameLabel);
            this.actionDetailsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionDetailsBox.Location = new System.Drawing.Point(12, 52);
            this.actionDetailsBox.Name = "actionDetailsBox";
            this.actionDetailsBox.Size = new System.Drawing.Size(405, 239);
            this.actionDetailsBox.TabIndex = 20;
            this.actionDetailsBox.TabStop = false;
            this.actionDetailsBox.Text = "Action Details";
            // 
            // StopIfFailsCheckBox
            // 
            this.StopIfFailsCheckBox.AutoSize = true;
            this.StopIfFailsCheckBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopIfFailsCheckBox.Location = new System.Drawing.Point(6, 212);
            this.StopIfFailsCheckBox.Name = "StopIfFailsCheckBox";
            this.StopIfFailsCheckBox.Size = new System.Drawing.Size(200, 19);
            this.StopIfFailsCheckBox.TabIndex = 7;
            this.StopIfFailsCheckBox.Text = "Stop execution if the action fails.";
            this.StopIfFailsCheckBox.UseVisualStyleBackColor = true;
            // 
            // BatchFileRadio
            // 
            this.BatchFileRadio.AutoSize = true;
            this.BatchFileRadio.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchFileRadio.Location = new System.Drawing.Point(225, 90);
            this.BatchFileRadio.Name = "BatchFileRadio";
            this.BatchFileRadio.Size = new System.Drawing.Size(69, 18);
            this.BatchFileRadio.TabIndex = 4;
            this.BatchFileRadio.TabStop = true;
            this.BatchFileRadio.Text = "Batch File";
            this.BatchFileRadio.UseVisualStyleBackColor = true;
            this.BatchFileRadio.CheckedChanged += new System.EventHandler(this.BatchFileRadio_CheckedChanged);
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
            // actionNameLabel
            // 
            this.actionNameLabel.AutoSize = true;
            this.actionNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionNameLabel.Location = new System.Drawing.Point(6, 32);
            this.actionNameLabel.Name = "actionNameLabel";
            this.actionNameLabel.Size = new System.Drawing.Size(79, 15);
            this.actionNameLabel.TabIndex = 0;
            this.actionNameLabel.Text = "Action Name:";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(10, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(227, 20);
            this.Title.TabIndex = 21;
            this.Title.Text = "Create Additional Action";
            // 
            // CreateAdditionalActionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 537);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.ParametersBox);
            this.Controls.Add(this.actionContentBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.actionDetailsBox);
            this.Controls.Add(this.Title);
            this.Name = "CreateAdditionalActionDialog";
            this.Text = "CreateAdditionalActionDialog";
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutText)).EndInit();
            this.ParametersBox.ResumeLayout(false);
            this.ParametersBox.PerformLayout();
            this.actionContentBox.ResumeLayout(false);
            this.actionContentBox.PerformLayout();
            this.actionDetailsBox.ResumeLayout(false);
            this.actionDetailsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.NumericUpDown TimeoutText;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.CheckBox ValidityCheckBox;
        private System.Windows.Forms.TextBox ValidityText;
        private System.Windows.Forms.TextBox ContentText;
        private System.Windows.Forms.Button RemoveParameterButton;
        private System.Windows.Forms.Label parameterNameLabel;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.GroupBox ParametersBox;
        private System.Windows.Forms.Button NewParameterButton;
        private System.Windows.Forms.Button EditParameterButton;
        private System.Windows.Forms.Label ContentLabel;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.RadioButton TestScriptRadio;
        private System.Windows.Forms.RadioButton ScriptRadio;
        private System.Windows.Forms.RadioButton CommandLineRadio;
        private System.Windows.Forms.TextBox CreatorNameText;
        private System.Windows.Forms.TextBox ActionNameText;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label actionTypeLabel;
        private System.Windows.Forms.GroupBox actionContentBox;
        private System.Windows.Forms.Label OSTypeLabel;
        private System.Windows.Forms.ComboBox OScomboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox actionDetailsBox;
        private System.Windows.Forms.Label creatorNameLabel;
        private System.Windows.Forms.Label actionNameLabel;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.RadioButton BatchFileRadio;
        private System.Windows.Forms.CheckBox StopIfFailsCheckBox;
        private System.Windows.Forms.ComboBox ParametersComboBox;
    }
}