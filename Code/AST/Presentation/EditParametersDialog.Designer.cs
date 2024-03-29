namespace AST.Presentation
{
    partial class EditParametersDialog
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
            this.ParameterContentBox = new System.Windows.Forms.GroupBox();
            this.ContentText = new System.Windows.Forms.TextBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.OSTypeLabel = new System.Windows.Forms.Label();
            this.OScomboBox = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.ParameterNameText = new System.Windows.Forms.TextBox();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.ParameterDetailsBox = new System.Windows.Forms.GroupBox();
            this.DefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.InputCheckBox = new System.Windows.Forms.CheckBox();
            this.OptionCheckBox = new System.Windows.Forms.CheckBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.ParameterTypeLabel = new System.Windows.Forms.Label();
            this.ParameterNameLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.InputLabel = new System.Windows.Forms.Label();
            this.InputBox = new System.Windows.Forms.GroupBox();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.ParameterContentBox.SuspendLayout();
            this.ParameterDetailsBox.SuspendLayout();
            this.InputBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParameterContentBox
            // 
            this.ParameterContentBox.Controls.Add(this.ContentText);
            this.ParameterContentBox.Controls.Add(this.ValueLabel);
            this.ParameterContentBox.Controls.Add(this.OSTypeLabel);
            this.ParameterContentBox.Controls.Add(this.OScomboBox);
            this.ParameterContentBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterContentBox.Location = new System.Drawing.Point(15, 251);
            this.ParameterContentBox.Name = "ParameterContentBox";
            this.ParameterContentBox.Size = new System.Drawing.Size(260, 86);
            this.ParameterContentBox.TabIndex = 17;
            this.ParameterContentBox.TabStop = false;
            this.ParameterContentBox.Text = "Parameter Content";
            // 
            // ContentText
            // 
            this.ContentText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentText.Location = new System.Drawing.Point(113, 52);
            this.ContentText.Name = "ContentText";
            this.ContentText.Size = new System.Drawing.Size(136, 24);
            this.ContentText.TabIndex = 6;
            this.ContentText.Leave += new System.EventHandler(this.SaveOSValue);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValueLabel.Location = new System.Drawing.Point(6, 54);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(39, 15);
            this.ValueLabel.TabIndex = 12;
            this.ValueLabel.Text = "Value:";
            // 
            // OSTypeLabel
            // 
            this.OSTypeLabel.AutoSize = true;
            this.OSTypeLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSTypeLabel.Location = new System.Drawing.Point(6, 24);
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
            this.OScomboBox.Location = new System.Drawing.Point(113, 22);
            this.OScomboBox.Name = "OScomboBox";
            this.OScomboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OScomboBox.Size = new System.Drawing.Size(136, 23);
            this.OScomboBox.TabIndex = 5;
            this.OScomboBox.SelectedIndexChanged += new System.EventHandler(this.OScomboBox_SelectedIndexChanged);
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(68, 412);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 12;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(13, 14);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(165, 20);
            this.Title.TabIndex = 15;
            this.Title.Text = "Create Parameter";
            // 
            // ParameterNameText
            // 
            this.ParameterNameText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterNameText.Location = new System.Drawing.Point(113, 25);
            this.ParameterNameText.Name = "ParameterNameText";
            this.ParameterNameText.Size = new System.Drawing.Size(136, 24);
            this.ParameterNameText.TabIndex = 0;
            // 
            // DescriptionText
            // 
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(9, 109);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(240, 45);
            this.DescriptionText.TabIndex = 3;
            this.DescriptionText.Text = "";
            // 
            // ParameterDetailsBox
            // 
            this.ParameterDetailsBox.Controls.Add(this.DefaultCheckBox);
            this.ParameterDetailsBox.Controls.Add(this.InputCheckBox);
            this.ParameterDetailsBox.Controls.Add(this.OptionCheckBox);
            this.ParameterDetailsBox.Controls.Add(this.DescriptionText);
            this.ParameterDetailsBox.Controls.Add(this.ParameterNameText);
            this.ParameterDetailsBox.Controls.Add(this.descriptionLabel);
            this.ParameterDetailsBox.Controls.Add(this.ParameterTypeLabel);
            this.ParameterDetailsBox.Controls.Add(this.ParameterNameLabel);
            this.ParameterDetailsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterDetailsBox.Location = new System.Drawing.Point(15, 53);
            this.ParameterDetailsBox.Name = "ParameterDetailsBox";
            this.ParameterDetailsBox.Size = new System.Drawing.Size(260, 192);
            this.ParameterDetailsBox.TabIndex = 14;
            this.ParameterDetailsBox.TabStop = false;
            this.ParameterDetailsBox.Text = "Parameter Details";
            // 
            // DefaultCheckBox
            // 
            this.DefaultCheckBox.AutoSize = true;
            this.DefaultCheckBox.Location = new System.Drawing.Point(9, 165);
            this.DefaultCheckBox.Name = "DefaultCheckBox";
            this.DefaultCheckBox.Size = new System.Drawing.Size(59, 18);
            this.DefaultCheckBox.TabIndex = 4;
            this.DefaultCheckBox.Text = "Default";
            this.DefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // InputCheckBox
            // 
            this.InputCheckBox.AutoSize = true;
            this.InputCheckBox.Location = new System.Drawing.Point(193, 62);
            this.InputCheckBox.Name = "InputCheckBox";
            this.InputCheckBox.Size = new System.Drawing.Size(51, 18);
            this.InputCheckBox.TabIndex = 2;
            this.InputCheckBox.Text = "Input";
            this.InputCheckBox.UseVisualStyleBackColor = true;
            this.InputCheckBox.CheckedChanged += new System.EventHandler(this.InputCheckBox_CheckedChanged);
            // 
            // OptionCheckBox
            // 
            this.OptionCheckBox.AutoSize = true;
            this.OptionCheckBox.Location = new System.Drawing.Point(113, 62);
            this.OptionCheckBox.Name = "OptionCheckBox";
            this.OptionCheckBox.Size = new System.Drawing.Size(58, 18);
            this.OptionCheckBox.TabIndex = 1;
            this.OptionCheckBox.Text = "Option";
            this.OptionCheckBox.UseVisualStyleBackColor = true;
            this.OptionCheckBox.CheckedChanged += new System.EventHandler(this.OptionCheckBox_CheckedChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(6, 91);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(72, 15);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description:";
            // 
            // ParameterTypeLabel
            // 
            this.ParameterTypeLabel.AutoSize = true;
            this.ParameterTypeLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterTypeLabel.Location = new System.Drawing.Point(6, 63);
            this.ParameterTypeLabel.Name = "ParameterTypeLabel";
            this.ParameterTypeLabel.Size = new System.Drawing.Size(94, 15);
            this.ParameterTypeLabel.TabIndex = 2;
            this.ParameterTypeLabel.Text = "Parameter Type:";
            // 
            // ParameterNameLabel
            // 
            this.ParameterNameLabel.AutoSize = true;
            this.ParameterNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterNameLabel.Location = new System.Drawing.Point(6, 27);
            this.ParameterNameLabel.Name = "ParameterNameLabel";
            this.ParameterNameLabel.Size = new System.Drawing.Size(99, 15);
            this.ParameterNameLabel.TabIndex = 0;
            this.ParameterNameLabel.Text = "Parameter Name:";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(117, 20);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(136, 24);
            this.InputTextBox.TabIndex = 9;
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLabel.Location = new System.Drawing.Point(10, 23);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(38, 15);
            this.InputLabel.TabIndex = 21;
            this.InputLabel.Text = "Input:";
            // 
            // InputBox
            // 
            this.InputBox.Controls.Add(this.InputLabel);
            this.InputBox.Controls.Add(this.InputTextBox);
            this.InputBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox.Location = new System.Drawing.Point(17, 343);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(260, 57);
            this.InputBox.TabIndex = 22;
            this.InputBox.TabStop = false;
            this.InputBox.Text = "Input";
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(149, 412);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 13;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditParametersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 445);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.ParameterContentBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.ParameterDetailsBox);
            this.Controls.Add(this.InputBox);
            this.Name = "EditParametersDialog";
            this.Text = "Edit Parameter";
            this.ParameterContentBox.ResumeLayout(false);
            this.ParameterContentBox.PerformLayout();
            this.ParameterDetailsBox.ResumeLayout(false);
            this.ParameterDetailsBox.PerformLayout();
            this.InputBox.ResumeLayout(false);
            this.InputBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ParameterContentBox;
        private System.Windows.Forms.TextBox ContentText;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label OSTypeLabel;
        private System.Windows.Forms.ComboBox OScomboBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox ParameterNameText;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.GroupBox ParameterDetailsBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label ParameterNameLabel;
        private System.Windows.Forms.CheckBox InputCheckBox;
        private System.Windows.Forms.CheckBox OptionCheckBox;
        private System.Windows.Forms.Label ParameterTypeLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.GroupBox InputBox;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.CheckBox DefaultCheckBox;

    }
}