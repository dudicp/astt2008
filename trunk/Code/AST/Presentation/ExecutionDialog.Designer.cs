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
            this.EndStationLabel = new System.Windows.Forms.Label();
            this.SelectedEndStationsListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectEndStationButton = new System.Windows.Forms.Button();
            this.UnselectEndStationButton = new System.Windows.Forms.Button();
            this.MoveDownEndStationButton = new System.Windows.Forms.Button();
            this.MoveUpEndStationButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewEndStationButton = new System.Windows.Forms.Button();
            this.EndStationsGroupBox = new System.Windows.Forms.GroupBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.ParamtersLabel = new System.Windows.Forms.Label();
            this.ParametersListBox = new System.Windows.Forms.ListBox();
            this.SelectedParameterLabel = new System.Windows.Forms.Label();
            this.SelectedParametersListBox = new System.Windows.Forms.ListBox();
            this.UnselectParameterButton = new System.Windows.Forms.Button();
            this.SelectParameterButton = new System.Windows.Forms.Button();
            this.MoveUpParameterButton = new System.Windows.Forms.Button();
            this.MoveDownParameterButton = new System.Windows.Forms.Button();
            this.ParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.DurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InputLabel = new System.Windows.Forms.Label();
            this.DurationCheckBox = new System.Windows.Forms.CheckBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.DelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DelayCheckBox = new System.Windows.Forms.CheckBox();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.MoveDownActionButton = new System.Windows.Forms.Button();
            this.MoveUpActionButton = new System.Windows.Forms.Button();
            this.TreeViewGroupBox = new System.Windows.Forms.GroupBox();
            this.TreeViewLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ReportNameTextBox = new System.Windows.Forms.TextBox();
            this.ReportNameCheckBox = new System.Windows.Forms.CheckBox();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.EndStationsGroupBox.SuspendLayout();
            this.ParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).BeginInit();
            this.TreeViewGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(12, 23);
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
            this.TPsListBox.Sorted = true;
            this.TPsListBox.TabIndex = 16;
            this.TPsListBox.SelectedIndexChanged += new System.EventHandler(this.TPsListBox_SelectedIndexChanged);
            this.TPsListBox.DoubleClick += new System.EventHandler(this.TPsListBox_OnDoubleClick);
            // 
            // ActionsListBox
            // 
            this.ActionsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionsListBox.FormattingEnabled = true;
            this.ActionsListBox.ItemHeight = 15;
            this.ActionsListBox.Location = new System.Drawing.Point(9, 30);
            this.ActionsListBox.Name = "ActionsListBox";
            this.ActionsListBox.Size = new System.Drawing.Size(142, 109);
            this.ActionsListBox.Sorted = true;
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
            this.TSCsListBox.Sorted = true;
            this.TSCsListBox.TabIndex = 14;
            this.TSCsListBox.SelectedIndexChanged += new System.EventHandler(this.TSCsListBox_SelectedIndexChanged);
            this.TSCsListBox.DoubleClick += new System.EventHandler(this.TSCsListBox_OnDoubleClick);
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
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(174, 410);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(179, 50);
            this.DescriptionText.TabIndex = 12;
            this.DescriptionText.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(171, 392);
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
            // EndStationLabel
            // 
            this.EndStationLabel.AutoSize = true;
            this.EndStationLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationLabel.Location = new System.Drawing.Point(6, 12);
            this.EndStationLabel.Name = "EndStationLabel";
            this.EndStationLabel.Size = new System.Drawing.Size(92, 15);
            this.EndStationLabel.TabIndex = 13;
            this.EndStationLabel.Text = "End-Stations:";
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
            // EndStationsGroupBox
            // 
            this.EndStationsGroupBox.Controls.Add(this.EditButton);
            this.EndStationsGroupBox.Controls.Add(this.NewEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.MoveDownEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.MoveUpEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.SelectEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.UnselectEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.SelectedEndStationsListBox);
            this.EndStationsGroupBox.Controls.Add(this.label4);
            this.EndStationsGroupBox.Controls.Add(this.EndStationsListBox);
            this.EndStationsGroupBox.Controls.Add(this.EndStationLabel);
            this.EndStationsGroupBox.Enabled = false;
            this.EndStationsGroupBox.Location = new System.Drawing.Point(581, 57);
            this.EndStationsGroupBox.Name = "EndStationsGroupBox";
            this.EndStationsGroupBox.Size = new System.Drawing.Size(208, 332);
            this.EndStationsGroupBox.TabIndex = 28;
            this.EndStationsGroupBox.TabStop = false;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.ExecuteButton.Enabled = false;
            this.ExecuteButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExecuteButton.Location = new System.Drawing.Point(722, 443);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(62, 28);
            this.ExecuteButton.TabIndex = 28;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = false;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // ParamtersLabel
            // 
            this.ParamtersLabel.AutoSize = true;
            this.ParamtersLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParamtersLabel.Location = new System.Drawing.Point(6, 12);
            this.ParamtersLabel.Name = "ParamtersLabel";
            this.ParamtersLabel.Size = new System.Drawing.Size(82, 15);
            this.ParamtersLabel.TabIndex = 13;
            this.ParamtersLabel.Text = "Parameters:";
            // 
            // ParametersListBox
            // 
            this.ParametersListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersListBox.FormattingEnabled = true;
            this.ParametersListBox.ItemHeight = 15;
            this.ParametersListBox.Location = new System.Drawing.Point(9, 30);
            this.ParametersListBox.Name = "ParametersListBox";
            this.ParametersListBox.Size = new System.Drawing.Size(142, 94);
            this.ParametersListBox.TabIndex = 14;
            this.ParametersListBox.SelectedIndexChanged += new System.EventHandler(this.ParametersListBox_SelectedIndexChanged);
            // 
            // SelectedParameterLabel
            // 
            this.SelectedParameterLabel.AutoSize = true;
            this.SelectedParameterLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedParameterLabel.Location = new System.Drawing.Point(6, 208);
            this.SelectedParameterLabel.Name = "SelectedParameterLabel";
            this.SelectedParameterLabel.Size = new System.Drawing.Size(138, 15);
            this.SelectedParameterLabel.TabIndex = 15;
            this.SelectedParameterLabel.Text = "Selected Parameters:";
            // 
            // SelectedParametersListBox
            // 
            this.SelectedParametersListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedParametersListBox.FormattingEnabled = true;
            this.SelectedParametersListBox.ItemHeight = 15;
            this.SelectedParametersListBox.Location = new System.Drawing.Point(9, 226);
            this.SelectedParametersListBox.Name = "SelectedParametersListBox";
            this.SelectedParametersListBox.Size = new System.Drawing.Size(142, 94);
            this.SelectedParametersListBox.TabIndex = 16;
            this.SelectedParametersListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedParametersListBox_SelectedIndexChanged);
            // 
            // UnselectParameterButton
            // 
            this.UnselectParameterButton.Enabled = false;
            this.UnselectParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnselectParameterButton.Location = new System.Drawing.Point(38, 174);
            this.UnselectParameterButton.Name = "UnselectParameterButton";
            this.UnselectParameterButton.Size = new System.Drawing.Size(35, 23);
            this.UnselectParameterButton.TabIndex = 21;
            this.UnselectParameterButton.Text = "↑";
            this.UnselectParameterButton.UseVisualStyleBackColor = true;
            this.UnselectParameterButton.Click += new System.EventHandler(this.UnselectParameterButton_Click);
            // 
            // SelectParameterButton
            // 
            this.SelectParameterButton.Enabled = false;
            this.SelectParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectParameterButton.Location = new System.Drawing.Point(79, 174);
            this.SelectParameterButton.Name = "SelectParameterButton";
            this.SelectParameterButton.Size = new System.Drawing.Size(35, 23);
            this.SelectParameterButton.TabIndex = 22;
            this.SelectParameterButton.Text = "↓";
            this.SelectParameterButton.UseVisualStyleBackColor = true;
            this.SelectParameterButton.Click += new System.EventHandler(this.SelectParameterButton_Click);
            // 
            // MoveUpParameterButton
            // 
            this.MoveUpParameterButton.Enabled = false;
            this.MoveUpParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpParameterButton.Location = new System.Drawing.Point(157, 248);
            this.MoveUpParameterButton.Name = "MoveUpParameterButton";
            this.MoveUpParameterButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpParameterButton.TabIndex = 23;
            this.MoveUpParameterButton.Text = "↑";
            this.MoveUpParameterButton.UseVisualStyleBackColor = true;
            this.MoveUpParameterButton.Click += new System.EventHandler(this.MoveUpParameterButton_Click);
            // 
            // MoveDownParameterButton
            // 
            this.MoveDownParameterButton.Enabled = false;
            this.MoveDownParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownParameterButton.Location = new System.Drawing.Point(157, 276);
            this.MoveDownParameterButton.Name = "MoveDownParameterButton";
            this.MoveDownParameterButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownParameterButton.TabIndex = 24;
            this.MoveDownParameterButton.Text = "↓";
            this.MoveDownParameterButton.UseVisualStyleBackColor = true;
            this.MoveDownParameterButton.Click += new System.EventHandler(this.MoveDownParameterButton_Click);
            // 
            // ParametersGroupBox
            // 
            this.ParametersGroupBox.Controls.Add(this.DurationNumericUpDown);
            this.ParametersGroupBox.Controls.Add(this.InputLabel);
            this.ParametersGroupBox.Controls.Add(this.DurationCheckBox);
            this.ParametersGroupBox.Controls.Add(this.InputTextBox);
            this.ParametersGroupBox.Controls.Add(this.DelayNumericUpDown);
            this.ParametersGroupBox.Controls.Add(this.MoveDownParameterButton);
            this.ParametersGroupBox.Controls.Add(this.DelayCheckBox);
            this.ParametersGroupBox.Controls.Add(this.MoveUpParameterButton);
            this.ParametersGroupBox.Controls.Add(this.SelectParameterButton);
            this.ParametersGroupBox.Controls.Add(this.UnselectParameterButton);
            this.ParametersGroupBox.Controls.Add(this.SelectedParametersListBox);
            this.ParametersGroupBox.Controls.Add(this.SelectedParameterLabel);
            this.ParametersGroupBox.Controls.Add(this.ParametersListBox);
            this.ParametersGroupBox.Controls.Add(this.ParamtersLabel);
            this.ParametersGroupBox.Enabled = false;
            this.ParametersGroupBox.Location = new System.Drawing.Point(364, 57);
            this.ParametersGroupBox.Name = "ParametersGroupBox";
            this.ParametersGroupBox.Size = new System.Drawing.Size(208, 414);
            this.ParametersGroupBox.TabIndex = 29;
            this.ParametersGroupBox.TabStop = false;
            // 
            // DurationNumericUpDown
            // 
            this.DurationNumericUpDown.Enabled = false;
            this.DurationNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DurationNumericUpDown.Location = new System.Drawing.Point(157, 381);
            this.DurationNumericUpDown.Name = "DurationNumericUpDown";
            this.DurationNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.DurationNumericUpDown.TabIndex = 38;
            this.DurationNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DurationNumericUpDown.ValueChanged += new System.EventHandler(this.DurationNumericUpDown_ValueChanged);
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLabel.Location = new System.Drawing.Point(7, 141);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(38, 15);
            this.InputLabel.TabIndex = 26;
            this.InputLabel.Text = "Input:";
            // 
            // DurationCheckBox
            // 
            this.DurationCheckBox.AutoSize = true;
            this.DurationCheckBox.Location = new System.Drawing.Point(6, 382);
            this.DurationCheckBox.Name = "DurationCheckBox";
            this.DurationCheckBox.Size = new System.Drawing.Size(126, 17);
            this.DurationCheckBox.TabIndex = 37;
            this.DurationCheckBox.Text = "Stop this action after:";
            this.DurationCheckBox.UseVisualStyleBackColor = true;
            this.DurationCheckBox.CheckedChanged += new System.EventHandler(this.DurationCheckBox_CheckedChanged);
            // 
            // InputTextBox
            // 
            this.InputTextBox.Enabled = false;
            this.InputTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(51, 139);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(100, 21);
            this.InputTextBox.TabIndex = 25;
            // 
            // DelayNumericUpDown
            // 
            this.DelayNumericUpDown.Enabled = false;
            this.DelayNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DelayNumericUpDown.Location = new System.Drawing.Point(157, 352);
            this.DelayNumericUpDown.Name = "DelayNumericUpDown";
            this.DelayNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.DelayNumericUpDown.TabIndex = 36;
            this.DelayNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DelayNumericUpDown.ValueChanged += new System.EventHandler(this.DelayNumericUpDown_ValueChanged);
            // 
            // DelayCheckBox
            // 
            this.DelayCheckBox.AutoSize = true;
            this.DelayCheckBox.Location = new System.Drawing.Point(6, 355);
            this.DelayCheckBox.Name = "DelayCheckBox";
            this.DelayCheckBox.Size = new System.Drawing.Size(129, 17);
            this.DelayCheckBox.TabIndex = 35;
            this.DelayCheckBox.Text = "Delay after execution:";
            this.DelayCheckBox.UseVisualStyleBackColor = true;
            this.DelayCheckBox.CheckedChanged += new System.EventHandler(this.DelayCheckBox_CheckedChanged);
            // 
            // TreeView
            // 
            this.TreeView.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeView.Location = new System.Drawing.Point(9, 30);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(128, 290);
            this.TreeView.TabIndex = 33;
            this.TreeView.DoubleClick += new System.EventHandler(this.TreeView_OnDoubleClick);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // MoveDownActionButton
            // 
            this.MoveDownActionButton.Enabled = false;
            this.MoveDownActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownActionButton.Location = new System.Drawing.Point(141, 165);
            this.MoveDownActionButton.Name = "MoveDownActionButton";
            this.MoveDownActionButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownActionButton.TabIndex = 32;
            this.MoveDownActionButton.Text = "↓";
            this.MoveDownActionButton.UseVisualStyleBackColor = true;
            this.MoveDownActionButton.Click += new System.EventHandler(this.MoveDownActionButton_Click);
            // 
            // MoveUpActionButton
            // 
            this.MoveUpActionButton.Enabled = false;
            this.MoveUpActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpActionButton.Location = new System.Drawing.Point(142, 136);
            this.MoveUpActionButton.Name = "MoveUpActionButton";
            this.MoveUpActionButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpActionButton.TabIndex = 31;
            this.MoveUpActionButton.Text = "↑";
            this.MoveUpActionButton.UseVisualStyleBackColor = true;
            this.MoveUpActionButton.Click += new System.EventHandler(this.MoveUpActionButton_Click);
            // 
            // TreeViewGroupBox
            // 
            this.TreeViewGroupBox.Controls.Add(this.TreeViewLabel);
            this.TreeViewGroupBox.Controls.Add(this.TreeView);
            this.TreeViewGroupBox.Controls.Add(this.MoveUpActionButton);
            this.TreeViewGroupBox.Controls.Add(this.MoveDownActionButton);
            this.TreeViewGroupBox.Enabled = false;
            this.TreeViewGroupBox.Location = new System.Drawing.Point(173, 57);
            this.TreeViewGroupBox.Name = "TreeViewGroupBox";
            this.TreeViewGroupBox.Size = new System.Drawing.Size(182, 332);
            this.TreeViewGroupBox.TabIndex = 34;
            this.TreeViewGroupBox.TabStop = false;
            // 
            // TreeViewLabel
            // 
            this.TreeViewLabel.AutoSize = true;
            this.TreeViewLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeViewLabel.Location = new System.Drawing.Point(6, 12);
            this.TreeViewLabel.Name = "TreeViewLabel";
            this.TreeViewLabel.Size = new System.Drawing.Size(71, 15);
            this.TreeViewLabel.TabIndex = 27;
            this.TreeViewLabel.Text = "Tree View:";
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(607, 446);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(50, 23);
            this.SaveButton.TabIndex = 28;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // ReportNameTextBox
            // 
            this.ReportNameTextBox.Enabled = false;
            this.ReportNameTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportNameTextBox.Location = new System.Drawing.Point(686, 402);
            this.ReportNameTextBox.Name = "ReportNameTextBox";
            this.ReportNameTextBox.Size = new System.Drawing.Size(98, 24);
            this.ReportNameTextBox.TabIndex = 36;
            // 
            // ReportNameCheckBox
            // 
            this.ReportNameCheckBox.AutoSize = true;
            this.ReportNameCheckBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportNameCheckBox.Location = new System.Drawing.Point(581, 404);
            this.ReportNameCheckBox.Name = "ReportNameCheckBox";
            this.ReportNameCheckBox.Size = new System.Drawing.Size(99, 19);
            this.ReportNameCheckBox.TabIndex = 35;
            this.ReportNameCheckBox.Text = "Report Name:";
            this.ReportNameCheckBox.UseVisualStyleBackColor = true;
            this.ReportNameCheckBox.CheckedChanged += new System.EventHandler(this.ReportNameCheckBox_CheckedChanged);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(663, 446);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(53, 23);
            this.MyCancelButton.TabIndex = 37;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // ExecutionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 483);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.ReportNameTextBox);
            this.Controls.Add(this.ReportNameCheckBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TreeViewGroupBox);
            this.Controls.Add(this.ParametersGroupBox);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.EndStationsGroupBox);
            this.Controls.Add(this.DescriptionText);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Title);
            this.Name = "ExecutionDialog";
            this.Text = "ExecutionDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.EndStationsGroupBox.ResumeLayout(false);
            this.EndStationsGroupBox.PerformLayout();
            this.ParametersGroupBox.ResumeLayout(false);
            this.ParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).EndInit();
            this.TreeViewGroupBox.ResumeLayout(false);
            this.TreeViewGroupBox.PerformLayout();
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
        private System.Windows.Forms.Label EndStationLabel;
        private System.Windows.Forms.ListBox SelectedEndStationsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SelectEndStationButton;
        private System.Windows.Forms.Button UnselectEndStationButton;
        private System.Windows.Forms.Button MoveDownEndStationButton;
        private System.Windows.Forms.Button MoveUpEndStationButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button NewEndStationButton;
        private System.Windows.Forms.GroupBox EndStationsGroupBox;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Label ParamtersLabel;
        private System.Windows.Forms.ListBox ParametersListBox;
        private System.Windows.Forms.Label SelectedParameterLabel;
        private System.Windows.Forms.ListBox SelectedParametersListBox;
        private System.Windows.Forms.Button UnselectParameterButton;
        private System.Windows.Forms.Button SelectParameterButton;
        private System.Windows.Forms.Button MoveUpParameterButton;
        private System.Windows.Forms.Button MoveDownParameterButton;
        private System.Windows.Forms.GroupBox ParametersGroupBox;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button MoveDownActionButton;
        private System.Windows.Forms.Button MoveUpActionButton;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.GroupBox TreeViewGroupBox;
        private System.Windows.Forms.Label TreeViewLabel;
        private System.Windows.Forms.NumericUpDown DurationNumericUpDown;
        private System.Windows.Forms.CheckBox DurationCheckBox;
        private System.Windows.Forms.NumericUpDown DelayNumericUpDown;
        private System.Windows.Forms.CheckBox DelayCheckBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox ReportNameTextBox;
        private System.Windows.Forms.CheckBox ReportNameCheckBox;
        private System.Windows.Forms.Button MyCancelButton;
    }
}