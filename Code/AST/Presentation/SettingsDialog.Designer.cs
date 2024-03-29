namespace AST.Presentation {
    partial class SettingsDialog {
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.EditParametersTab = new System.Windows.Forms.TabPage();
            this.ActionDetailsBox = new System.Windows.Forms.GroupBox();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.MoveDownParameterButton = new System.Windows.Forms.Button();
            this.MoveUpParameterButton = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.UnselectParameterButton = new System.Windows.Forms.Button();
            this.SelectedParametersListBox = new System.Windows.Forms.ListBox();
            this.SelectParameterButton = new System.Windows.Forms.Button();
            this.SelectedParametersLabel = new System.Windows.Forms.Label();
            this.ParameterListBox = new System.Windows.Forms.ListBox();
            this.ParameterNameLabel = new System.Windows.Forms.Label();
            this.Title1 = new System.Windows.Forms.Label();
            this.EditEndStationTab = new System.Windows.Forms.TabPage();
            this.EndStationsGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewEndStationButton = new System.Windows.Forms.Button();
            this.MoveDownEndStationButton = new System.Windows.Forms.Button();
            this.MoveUpEndStationButton = new System.Windows.Forms.Button();
            this.UnselectEndStationButton = new System.Windows.Forms.Button();
            this.SelectEndStationButton = new System.Windows.Forms.Button();
            this.SelectedEndStationsListBox = new System.Windows.Forms.ListBox();
            this.SelectedEndStationLabel = new System.Windows.Forms.Label();
            this.EndStationsListBox = new System.Windows.Forms.ListBox();
            this.EndStationsLabel = new System.Windows.Forms.Label();
            this.Title2 = new System.Windows.Forms.Label();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.StopIfFailsCheckBox = new System.Windows.Forms.CheckBox();
            this.Title3 = new System.Windows.Forms.Label();
            this.DurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DurationCheckBox = new System.Windows.Forms.CheckBox();
            this.DelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DelayCheckBox = new System.Windows.Forms.CheckBox();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.EditParametersTab.SuspendLayout();
            this.ActionDetailsBox.SuspendLayout();
            this.EditEndStationTab.SuspendLayout();
            this.EndStationsGroupBox.SuspendLayout();
            this.MiscTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.EditParametersTab);
            this.tabControl.Controls.Add(this.EditEndStationTab);
            this.tabControl.Controls.Add(this.MiscTab);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(471, 322);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 1;
            // 
            // EditParametersTab
            // 
            this.EditParametersTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EditParametersTab.Controls.Add(this.ActionDetailsBox);
            this.EditParametersTab.Controls.Add(this.Title1);
            this.EditParametersTab.Location = new System.Drawing.Point(4, 22);
            this.EditParametersTab.Name = "EditParametersTab";
            this.EditParametersTab.Padding = new System.Windows.Forms.Padding(3);
            this.EditParametersTab.Size = new System.Drawing.Size(463, 296);
            this.EditParametersTab.TabIndex = 0;
            this.EditParametersTab.Text = "Edit Parameters";
            // 
            // ActionDetailsBox
            // 
            this.ActionDetailsBox.Controls.Add(this.DescriptionText);
            this.ActionDetailsBox.Controls.Add(this.MoveDownParameterButton);
            this.ActionDetailsBox.Controls.Add(this.MoveUpParameterButton);
            this.ActionDetailsBox.Controls.Add(this.InputLabel);
            this.ActionDetailsBox.Controls.Add(this.InputTextBox);
            this.ActionDetailsBox.Controls.Add(this.UnselectParameterButton);
            this.ActionDetailsBox.Controls.Add(this.SelectedParametersListBox);
            this.ActionDetailsBox.Controls.Add(this.SelectParameterButton);
            this.ActionDetailsBox.Controls.Add(this.SelectedParametersLabel);
            this.ActionDetailsBox.Controls.Add(this.ParameterListBox);
            this.ActionDetailsBox.Controls.Add(this.ParameterNameLabel);
            this.ActionDetailsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionDetailsBox.Location = new System.Drawing.Point(17, 52);
            this.ActionDetailsBox.Name = "ActionDetailsBox";
            this.ActionDetailsBox.Size = new System.Drawing.Size(435, 232);
            this.ActionDetailsBox.TabIndex = 20;
            this.ActionDetailsBox.TabStop = false;
            this.ActionDetailsBox.Text = "Action Details";
            // 
            // DescriptionText
            // 
            this.DescriptionText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DescriptionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescriptionText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(10, 148);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ReadOnly = true;
            this.DescriptionText.Size = new System.Drawing.Size(375, 46);
            this.DescriptionText.TabIndex = 53;
            this.DescriptionText.Text = "";
            // 
            // MoveDownParameterButton
            // 
            this.MoveDownParameterButton.Enabled = false;
            this.MoveDownParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownParameterButton.Location = new System.Drawing.Point(391, 87);
            this.MoveDownParameterButton.Name = "MoveDownParameterButton";
            this.MoveDownParameterButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownParameterButton.TabIndex = 7;
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
            this.MoveUpParameterButton.TabIndex = 6;
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
            this.InputTextBox.TabIndex = 2;
            this.InputTextBox.Leave += new System.EventHandler(this.SetParameterValue);
            // 
            // UnselectParameterButton
            // 
            this.UnselectParameterButton.Enabled = false;
            this.UnselectParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnselectParameterButton.Location = new System.Drawing.Point(177, 104);
            this.UnselectParameterButton.Name = "UnselectParameterButton";
            this.UnselectParameterButton.Size = new System.Drawing.Size(36, 23);
            this.UnselectParameterButton.TabIndex = 4;
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
            this.SelectedParametersListBox.DoubleClick += new System.EventHandler(this.UnselectParameterButton_Click);
            this.SelectedParametersListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedParametersListBox_SelectedIndexChanged);
            // 
            // SelectParameterButton
            // 
            this.SelectParameterButton.Enabled = false;
            this.SelectParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectParameterButton.Location = new System.Drawing.Point(177, 75);
            this.SelectParameterButton.Name = "SelectParameterButton";
            this.SelectParameterButton.Size = new System.Drawing.Size(35, 23);
            this.SelectParameterButton.TabIndex = 3;
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
            this.ParameterListBox.Sorted = true;
            this.ParameterListBox.TabIndex = 1;
            this.ParameterListBox.DoubleClick += new System.EventHandler(this.SelectParameterButton_Click);
            this.ParameterListBox.SelectedIndexChanged += new System.EventHandler(this.ParameterListBox_SelectedIndexChanged);
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
            // Title1
            // 
            this.Title1.AutoSize = true;
            this.Title1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title1.Location = new System.Drawing.Point(15, 13);
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(105, 20);
            this.Title1.TabIndex = 19;
            this.Title1.Text = "Edit Action";
            // 
            // EditEndStationTab
            // 
            this.EditEndStationTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EditEndStationTab.Controls.Add(this.EndStationsGroupBox);
            this.EditEndStationTab.Controls.Add(this.Title2);
            this.EditEndStationTab.Location = new System.Drawing.Point(4, 22);
            this.EditEndStationTab.Name = "EditEndStationTab";
            this.EditEndStationTab.Padding = new System.Windows.Forms.Padding(3);
            this.EditEndStationTab.Size = new System.Drawing.Size(463, 296);
            this.EditEndStationTab.TabIndex = 1;
            this.EditEndStationTab.Text = "Edit End-Stations";
            // 
            // EndStationsGroupBox
            // 
            this.EndStationsGroupBox.Controls.Add(this.DeleteButton);
            this.EndStationsGroupBox.Controls.Add(this.EditButton);
            this.EndStationsGroupBox.Controls.Add(this.NewEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.MoveDownEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.MoveUpEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.UnselectEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.SelectEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.SelectedEndStationsListBox);
            this.EndStationsGroupBox.Controls.Add(this.SelectedEndStationLabel);
            this.EndStationsGroupBox.Controls.Add(this.EndStationsListBox);
            this.EndStationsGroupBox.Controls.Add(this.EndStationsLabel);
            this.EndStationsGroupBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationsGroupBox.Location = new System.Drawing.Point(17, 52);
            this.EndStationsGroupBox.Name = "EndStationsGroupBox";
            this.EndStationsGroupBox.Size = new System.Drawing.Size(436, 174);
            this.EndStationsGroupBox.TabIndex = 27;
            this.EndStationsGroupBox.TabStop = false;
            this.EndStationsGroupBox.Text = "End-Stations";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(118, 137);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(48, 23);
            this.DeleteButton.TabIndex = 13;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(64, 137);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(48, 23);
            this.EditButton.TabIndex = 12;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewEndStationButton
            // 
            this.NewEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewEndStationButton.Location = new System.Drawing.Point(10, 137);
            this.NewEndStationButton.Name = "NewEndStationButton";
            this.NewEndStationButton.Size = new System.Drawing.Size(48, 23);
            this.NewEndStationButton.TabIndex = 11;
            this.NewEndStationButton.Text = "New";
            this.NewEndStationButton.UseVisualStyleBackColor = true;
            this.NewEndStationButton.Click += new System.EventHandler(this.NewEndStationButton_Click);
            // 
            // MoveDownEndStationButton
            // 
            this.MoveDownEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownEndStationButton.Location = new System.Drawing.Point(391, 87);
            this.MoveDownEndStationButton.Name = "MoveDownEndStationButton";
            this.MoveDownEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownEndStationButton.TabIndex = 18;
            this.MoveDownEndStationButton.Text = "↓";
            this.MoveDownEndStationButton.UseVisualStyleBackColor = true;
            this.MoveDownEndStationButton.Click += new System.EventHandler(this.MoveDownEndStationButton_Click);
            // 
            // MoveUpEndStationButton
            // 
            this.MoveUpEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpEndStationButton.Location = new System.Drawing.Point(391, 58);
            this.MoveUpEndStationButton.Name = "MoveUpEndStationButton";
            this.MoveUpEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpEndStationButton.TabIndex = 17;
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
            this.UnselectEndStationButton.TabIndex = 15;
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
            this.SelectEndStationButton.TabIndex = 14;
            this.SelectEndStationButton.Text = "→";
            this.SelectEndStationButton.UseVisualStyleBackColor = true;
            this.SelectEndStationButton.Click += new System.EventHandler(this.SelectEndStationButton_Click);
            // 
            // SelectedEndStationsListBox
            // 
            this.SelectedEndStationsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedEndStationsListBox.FormattingEnabled = true;
            this.SelectedEndStationsListBox.ItemHeight = 15;
            this.SelectedEndStationsListBox.Location = new System.Drawing.Point(226, 48);
            this.SelectedEndStationsListBox.Name = "SelectedEndStationsListBox";
            this.SelectedEndStationsListBox.Size = new System.Drawing.Size(156, 79);
            this.SelectedEndStationsListBox.TabIndex = 15;
            this.SelectedEndStationsListBox.DoubleClick += new System.EventHandler(this.UnselectEndStationButton_Click);
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
            this.EndStationsListBox.Size = new System.Drawing.Size(156, 79);
            this.EndStationsListBox.TabIndex = 10;
            this.EndStationsListBox.DoubleClick += new System.EventHandler(this.SelectEndStationButton_Click);
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
            // Title2
            // 
            this.Title2.AutoSize = true;
            this.Title2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title2.Location = new System.Drawing.Point(15, 13);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(162, 20);
            this.Title2.TabIndex = 26;
            this.Title2.Text = "Edit End-Stations";
            // 
            // MiscTab
            // 
            this.MiscTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MiscTab.Controls.Add(this.StopIfFailsCheckBox);
            this.MiscTab.Controls.Add(this.Title3);
            this.MiscTab.Controls.Add(this.DurationNumericUpDown);
            this.MiscTab.Controls.Add(this.DurationCheckBox);
            this.MiscTab.Controls.Add(this.DelayNumericUpDown);
            this.MiscTab.Controls.Add(this.DelayCheckBox);
            this.MiscTab.Location = new System.Drawing.Point(4, 22);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Padding = new System.Windows.Forms.Padding(3);
            this.MiscTab.Size = new System.Drawing.Size(463, 296);
            this.MiscTab.TabIndex = 2;
            this.MiscTab.Text = "Misc";
            // 
            // StopIfFailsCheckBox
            // 
            this.StopIfFailsCheckBox.AutoSize = true;
            this.StopIfFailsCheckBox.Location = new System.Drawing.Point(34, 183);
            this.StopIfFailsCheckBox.Name = "StopIfFailsCheckBox";
            this.StopIfFailsCheckBox.Size = new System.Drawing.Size(369, 17);
            this.StopIfFailsCheckBox.TabIndex = 26;
            this.StopIfFailsCheckBox.Text = "Stop the execution of the test scenario if the execution of the action fails.";
            this.StopIfFailsCheckBox.UseVisualStyleBackColor = true;
            // 
            // Title3
            // 
            this.Title3.AutoSize = true;
            this.Title3.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title3.Location = new System.Drawing.Point(15, 13);
            this.Title3.Name = "Title3";
            this.Title3.Size = new System.Drawing.Size(48, 20);
            this.Title3.TabIndex = 25;
            this.Title3.Text = "Misc";
            // 
            // DurationNumericUpDown
            // 
            this.DurationNumericUpDown.Enabled = false;
            this.DurationNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DurationNumericUpDown.Location = new System.Drawing.Point(308, 153);
            this.DurationNumericUpDown.Name = "DurationNumericUpDown";
            this.DurationNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.DurationNumericUpDown.TabIndex = 22;
            // 
            // DurationCheckBox
            // 
            this.DurationCheckBox.AutoSize = true;
            this.DurationCheckBox.Location = new System.Drawing.Point(34, 154);
            this.DurationCheckBox.Name = "DurationCheckBox";
            this.DurationCheckBox.Size = new System.Drawing.Size(268, 17);
            this.DurationCheckBox.TabIndex = 21;
            this.DurationCheckBox.Text = "Stop the execution if it takes longer than (Duration):";
            this.DurationCheckBox.UseVisualStyleBackColor = true;
            this.DurationCheckBox.CheckedChanged += new System.EventHandler(this.DurationCheckBox_CheckedChanged);
            // 
            // DelayNumericUpDown
            // 
            this.DelayNumericUpDown.Enabled = false;
            this.DelayNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DelayNumericUpDown.Location = new System.Drawing.Point(308, 124);
            this.DelayNumericUpDown.Name = "DelayNumericUpDown";
            this.DelayNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.DelayNumericUpDown.TabIndex = 20;
            // 
            // DelayCheckBox
            // 
            this.DelayCheckBox.AutoSize = true;
            this.DelayCheckBox.Location = new System.Drawing.Point(34, 125);
            this.DelayCheckBox.Name = "DelayCheckBox";
            this.DelayCheckBox.Size = new System.Drawing.Size(231, 17);
            this.DelayCheckBox.TabIndex = 19;
            this.DelayCheckBox.Text = "The time to wait after the execution (Delay):";
            this.DelayCheckBox.UseVisualStyleBackColor = true;
            this.DelayCheckBox.CheckedChanged += new System.EventHandler(this.DelayCheckBox_CheckedChanged);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(390, 328);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(71, 23);
            this.MyCancelButton.TabIndex = 9;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(312, 328);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(72, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 355);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl);
            this.Name = "SettingsDialog";
            this.Text = "Settings";
            this.tabControl.ResumeLayout(false);
            this.EditParametersTab.ResumeLayout(false);
            this.EditParametersTab.PerformLayout();
            this.ActionDetailsBox.ResumeLayout(false);
            this.ActionDetailsBox.PerformLayout();
            this.EditEndStationTab.ResumeLayout(false);
            this.EditEndStationTab.PerformLayout();
            this.EndStationsGroupBox.ResumeLayout(false);
            this.EndStationsGroupBox.PerformLayout();
            this.MiscTab.ResumeLayout(false);
            this.MiscTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage EditParametersTab;
        private System.Windows.Forms.Label Title1;
        private System.Windows.Forms.TabPage EditEndStationTab;
        private System.Windows.Forms.Label Title2;
        private System.Windows.Forms.TabPage MiscTab;
        private System.Windows.Forms.Label Title3;
        private System.Windows.Forms.NumericUpDown DurationNumericUpDown;
        private System.Windows.Forms.CheckBox DurationCheckBox;
        private System.Windows.Forms.NumericUpDown DelayNumericUpDown;
        private System.Windows.Forms.CheckBox DelayCheckBox;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox ActionDetailsBox;
        private System.Windows.Forms.Button MoveDownParameterButton;
        private System.Windows.Forms.Button MoveUpParameterButton;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Button UnselectParameterButton;
        private System.Windows.Forms.ListBox SelectedParametersListBox;
        private System.Windows.Forms.Button SelectParameterButton;
        private System.Windows.Forms.Label SelectedParametersLabel;
        private System.Windows.Forms.ListBox ParameterListBox;
        private System.Windows.Forms.Label ParameterNameLabel;
        private System.Windows.Forms.GroupBox EndStationsGroupBox;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button NewEndStationButton;
        private System.Windows.Forms.Button MoveDownEndStationButton;
        private System.Windows.Forms.Button MoveUpEndStationButton;
        private System.Windows.Forms.Button UnselectEndStationButton;
        private System.Windows.Forms.Button SelectEndStationButton;
        private System.Windows.Forms.ListBox SelectedEndStationsListBox;
        private System.Windows.Forms.Label SelectedEndStationLabel;
        private System.Windows.Forms.ListBox EndStationsListBox;
        private System.Windows.Forms.Label EndStationsLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.CheckBox StopIfFailsCheckBox;
    }
}