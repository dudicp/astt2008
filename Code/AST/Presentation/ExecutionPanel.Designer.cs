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
            this.components = new System.ComponentModel.Container();
            this.DurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.InputLabel = new System.Windows.Forms.Label();
            this.DurationCheckBox = new System.Windows.Forms.CheckBox();
            this.MoveDownParameterButton = new System.Windows.Forms.Button();
            this.MoveUpParameterButton = new System.Windows.Forms.Button();
            this.SelectParameterButton = new System.Windows.Forms.Button();
            this.UnselectParameterButton = new System.Windows.Forms.Button();
            this.SelectedParametersListBox = new System.Windows.Forms.ListBox();
            this.SelectedParameterLabel = new System.Windows.Forms.Label();
            this.ParametersListBox = new System.Windows.Forms.ListBox();
            this.ParamtersLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.ReportNameTextBox = new System.Windows.Forms.TextBox();
            this.ReportNameCheckBox = new System.Windows.Forms.CheckBox();
            this.TreeViewLabel = new System.Windows.Forms.Label();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.TreeViewGroupBox = new System.Windows.Forms.GroupBox();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.MoveUpActionButton = new System.Windows.Forms.Button();
            this.MoveDownActionButton = new System.Windows.Forms.Button();
            this.DelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DelayCheckBox = new System.Windows.Forms.CheckBox();
            this.ParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.StopIfFailsCheckBox = new System.Windows.Forms.CheckBox();
            this.ValidityStringCheckBox = new System.Windows.Forms.CheckBox();
            this.ValidityStringTextBox = new System.Windows.Forms.TextBox();
            this.EndStationMenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewEndStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditEndStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEndStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndStationsListBox = new System.Windows.Forms.ListBox();
            this.TPsListBox = new System.Windows.Forms.ListBox();
            this.AbstractActionMenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewAbstractActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditAbstractActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAbstractActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActionsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SingleActionsLabel = new System.Windows.Forms.Label();
            this.TSCsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EndStationsGroupBox = new System.Windows.Forms.GroupBox();
            this.IsDefaultLabel = new System.Windows.Forms.Label();
            this.OSTypeText = new System.Windows.Forms.Label();
            this.UsernameText = new System.Windows.Forms.Label();
            this.IPText = new System.Windows.Forms.Label();
            this.OSTypeLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.MoveDownEndStationButton = new System.Windows.Forms.Button();
            this.MoveUpEndStationButton = new System.Windows.Forms.Button();
            this.SelectEndStationButton = new System.Windows.Forms.Button();
            this.UnselectEndStationButton = new System.Windows.Forms.Button();
            this.SelectedEndStationsListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EndStationLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Title = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumericUpDown)).BeginInit();
            this.TreeViewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).BeginInit();
            this.ParametersGroupBox.SuspendLayout();
            this.EndStationMenuItem.SuspendLayout();
            this.AbstractActionMenuItem.SuspendLayout();
            this.EndStationsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DurationNumericUpDown
            // 
            this.DurationNumericUpDown.Enabled = false;
            this.DurationNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DurationNumericUpDown.Location = new System.Drawing.Point(157, 365);
            this.DurationNumericUpDown.Name = "DurationNumericUpDown";
            this.DurationNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.DurationNumericUpDown.TabIndex = 18;
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
            this.InputLabel.Location = new System.Drawing.Point(7, 135);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(38, 15);
            this.InputLabel.TabIndex = 26;
            this.InputLabel.Text = "Input:";
            // 
            // DurationCheckBox
            // 
            this.DurationCheckBox.AutoSize = true;
            this.DurationCheckBox.Location = new System.Drawing.Point(6, 366);
            this.DurationCheckBox.Name = "DurationCheckBox";
            this.DurationCheckBox.Size = new System.Drawing.Size(126, 17);
            this.DurationCheckBox.TabIndex = 17;
            this.DurationCheckBox.Text = "Stop this action after:";
            this.DurationCheckBox.UseVisualStyleBackColor = true;
            this.DurationCheckBox.CheckedChanged += new System.EventHandler(this.DurationCheckBox_CheckedChanged);
            // 
            // MoveDownParameterButton
            // 
            this.MoveDownParameterButton.Enabled = false;
            this.MoveDownParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownParameterButton.Location = new System.Drawing.Point(157, 262);
            this.MoveDownParameterButton.Name = "MoveDownParameterButton";
            this.MoveDownParameterButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownParameterButton.TabIndex = 12;
            this.MoveDownParameterButton.Text = "↓";
            this.MoveDownParameterButton.UseVisualStyleBackColor = true;
            this.MoveDownParameterButton.Click += new System.EventHandler(this.MoveDownParameterButton_Click);
            // 
            // MoveUpParameterButton
            // 
            this.MoveUpParameterButton.Enabled = false;
            this.MoveUpParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpParameterButton.Location = new System.Drawing.Point(157, 234);
            this.MoveUpParameterButton.Name = "MoveUpParameterButton";
            this.MoveUpParameterButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpParameterButton.TabIndex = 11;
            this.MoveUpParameterButton.Text = "↑";
            this.MoveUpParameterButton.UseVisualStyleBackColor = true;
            this.MoveUpParameterButton.Click += new System.EventHandler(this.MoveUpParameterButton_Click);
            // 
            // SelectParameterButton
            // 
            this.SelectParameterButton.Enabled = false;
            this.SelectParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectParameterButton.Location = new System.Drawing.Point(79, 160);
            this.SelectParameterButton.Name = "SelectParameterButton";
            this.SelectParameterButton.Size = new System.Drawing.Size(35, 23);
            this.SelectParameterButton.TabIndex = 9;
            this.SelectParameterButton.Text = "↓";
            this.SelectParameterButton.UseVisualStyleBackColor = true;
            this.SelectParameterButton.Click += new System.EventHandler(this.SelectParameterButton_Click);
            // 
            // UnselectParameterButton
            // 
            this.UnselectParameterButton.Enabled = false;
            this.UnselectParameterButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnselectParameterButton.Location = new System.Drawing.Point(38, 160);
            this.UnselectParameterButton.Name = "UnselectParameterButton";
            this.UnselectParameterButton.Size = new System.Drawing.Size(35, 23);
            this.UnselectParameterButton.TabIndex = 8;
            this.UnselectParameterButton.Text = "↑";
            this.UnselectParameterButton.UseVisualStyleBackColor = true;
            this.UnselectParameterButton.Click += new System.EventHandler(this.UnselectParameterButton_Click);
            // 
            // SelectedParametersListBox
            // 
            this.SelectedParametersListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedParametersListBox.FormattingEnabled = true;
            this.SelectedParametersListBox.ItemHeight = 15;
            this.SelectedParametersListBox.Location = new System.Drawing.Point(9, 212);
            this.SelectedParametersListBox.Name = "SelectedParametersListBox";
            this.SelectedParametersListBox.Size = new System.Drawing.Size(142, 94);
            this.SelectedParametersListBox.TabIndex = 10;
            this.SelectedParametersListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedParametersListBox_SelectedIndexChanged);
            // 
            // SelectedParameterLabel
            // 
            this.SelectedParameterLabel.AutoSize = true;
            this.SelectedParameterLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedParameterLabel.Location = new System.Drawing.Point(6, 194);
            this.SelectedParameterLabel.Name = "SelectedParameterLabel";
            this.SelectedParameterLabel.Size = new System.Drawing.Size(138, 15);
            this.SelectedParameterLabel.TabIndex = 15;
            this.SelectedParameterLabel.Text = "Selected Parameters:";
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
            // InputTextBox
            // 
            this.InputTextBox.Enabled = false;
            this.InputTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(51, 133);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(100, 21);
            this.InputTextBox.TabIndex = 7;
            this.InputTextBox.Leave += new System.EventHandler(this.SetParameterValue);
            // 
            // ReportNameTextBox
            // 
            this.ReportNameTextBox.Enabled = false;
            this.ReportNameTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportNameTextBox.Location = new System.Drawing.Point(697, 412);
            this.ReportNameTextBox.Name = "ReportNameTextBox";
            this.ReportNameTextBox.Size = new System.Drawing.Size(98, 24);
            this.ReportNameTextBox.TabIndex = 27;
            // 
            // ReportNameCheckBox
            // 
            this.ReportNameCheckBox.AutoSize = true;
            this.ReportNameCheckBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportNameCheckBox.Location = new System.Drawing.Point(592, 414);
            this.ReportNameCheckBox.Name = "ReportNameCheckBox";
            this.ReportNameCheckBox.Size = new System.Drawing.Size(99, 19);
            this.ReportNameCheckBox.TabIndex = 26;
            this.ReportNameCheckBox.Text = "Report Name:";
            this.ReportNameCheckBox.UseVisualStyleBackColor = true;
            this.ReportNameCheckBox.CheckedChanged += new System.EventHandler(this.ReportNameCheckBox_CheckedChanged);
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
            // ExecuteButton
            // 
            this.ExecuteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ExecuteButton.Enabled = false;
            this.ExecuteButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExecuteButton.Location = new System.Drawing.Point(817, 451);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(62, 28);
            this.ExecuteButton.TabIndex = 28;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = false;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // TreeViewGroupBox
            // 
            this.TreeViewGroupBox.Controls.Add(this.TreeViewLabel);
            this.TreeViewGroupBox.Controls.Add(this.TreeView);
            this.TreeViewGroupBox.Controls.Add(this.MoveUpActionButton);
            this.TreeViewGroupBox.Controls.Add(this.MoveDownActionButton);
            this.TreeViewGroupBox.Enabled = false;
            this.TreeViewGroupBox.Location = new System.Drawing.Point(175, 67);
            this.TreeViewGroupBox.Name = "TreeViewGroupBox";
            this.TreeViewGroupBox.Size = new System.Drawing.Size(182, 320);
            this.TreeViewGroupBox.TabIndex = 46;
            this.TreeViewGroupBox.TabStop = false;
            // 
            // TreeView
            // 
            this.TreeView.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeView.Location = new System.Drawing.Point(9, 30);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(128, 276);
            this.TreeView.TabIndex = 3;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // MoveUpActionButton
            // 
            this.MoveUpActionButton.Enabled = false;
            this.MoveUpActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpActionButton.Location = new System.Drawing.Point(142, 136);
            this.MoveUpActionButton.Name = "MoveUpActionButton";
            this.MoveUpActionButton.Size = new System.Drawing.Size(35, 23);
            this.MoveUpActionButton.TabIndex = 4;
            this.MoveUpActionButton.Text = "↑";
            this.MoveUpActionButton.UseVisualStyleBackColor = true;
            this.MoveUpActionButton.Click += new System.EventHandler(this.MoveUpActionButton_Click);
            // 
            // MoveDownActionButton
            // 
            this.MoveDownActionButton.Enabled = false;
            this.MoveDownActionButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownActionButton.Location = new System.Drawing.Point(141, 165);
            this.MoveDownActionButton.Name = "MoveDownActionButton";
            this.MoveDownActionButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownActionButton.TabIndex = 5;
            this.MoveDownActionButton.Text = "↓";
            this.MoveDownActionButton.UseVisualStyleBackColor = true;
            this.MoveDownActionButton.Click += new System.EventHandler(this.MoveDownActionButton_Click);
            // 
            // DelayNumericUpDown
            // 
            this.DelayNumericUpDown.Enabled = false;
            this.DelayNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DelayNumericUpDown.Location = new System.Drawing.Point(157, 339);
            this.DelayNumericUpDown.Name = "DelayNumericUpDown";
            this.DelayNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.DelayNumericUpDown.TabIndex = 16;
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
            this.DelayCheckBox.Location = new System.Drawing.Point(6, 340);
            this.DelayCheckBox.Name = "DelayCheckBox";
            this.DelayCheckBox.Size = new System.Drawing.Size(129, 17);
            this.DelayCheckBox.TabIndex = 15;
            this.DelayCheckBox.Text = "Delay after execution:";
            this.DelayCheckBox.UseVisualStyleBackColor = true;
            this.DelayCheckBox.CheckedChanged += new System.EventHandler(this.DelayCheckBox_CheckedChanged);
            // 
            // ParametersGroupBox
            // 
            this.ParametersGroupBox.Controls.Add(this.StopIfFailsCheckBox);
            this.ParametersGroupBox.Controls.Add(this.ValidityStringCheckBox);
            this.ParametersGroupBox.Controls.Add(this.ValidityStringTextBox);
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
            this.ParametersGroupBox.Location = new System.Drawing.Point(366, 67);
            this.ParametersGroupBox.Name = "ParametersGroupBox";
            this.ParametersGroupBox.Size = new System.Drawing.Size(208, 414);
            this.ParametersGroupBox.TabIndex = 45;
            this.ParametersGroupBox.TabStop = false;
            // 
            // StopIfFailsCheckBox
            // 
            this.StopIfFailsCheckBox.AutoSize = true;
            this.StopIfFailsCheckBox.Location = new System.Drawing.Point(6, 392);
            this.StopIfFailsCheckBox.Name = "StopIfFailsCheckBox";
            this.StopIfFailsCheckBox.Size = new System.Drawing.Size(161, 17);
            this.StopIfFailsCheckBox.TabIndex = 19;
            this.StopIfFailsCheckBox.Text = "Stop execution if action fails.";
            this.StopIfFailsCheckBox.UseVisualStyleBackColor = true;
            this.StopIfFailsCheckBox.CheckedChanged += new System.EventHandler(this.StopIfFailsCheckBox_CheckedChanged);
            // 
            // ValidityStringCheckBox
            // 
            this.ValidityStringCheckBox.AutoSize = true;
            this.ValidityStringCheckBox.Location = new System.Drawing.Point(6, 314);
            this.ValidityStringCheckBox.Name = "ValidityStringCheckBox";
            this.ValidityStringCheckBox.Size = new System.Drawing.Size(92, 17);
            this.ValidityStringCheckBox.TabIndex = 13;
            this.ValidityStringCheckBox.Text = "Validity String:";
            this.ValidityStringCheckBox.UseVisualStyleBackColor = true;
            this.ValidityStringCheckBox.CheckedChanged += new System.EventHandler(this.ValidityStringCheckBox_CheckedChanged);
            // 
            // ValidityStringTextBox
            // 
            this.ValidityStringTextBox.Enabled = false;
            this.ValidityStringTextBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidityStringTextBox.Location = new System.Drawing.Point(100, 312);
            this.ValidityStringTextBox.Name = "ValidityStringTextBox";
            this.ValidityStringTextBox.Size = new System.Drawing.Size(100, 21);
            this.ValidityStringTextBox.TabIndex = 14;
            this.ValidityStringTextBox.Leave += new System.EventHandler(this.SetValidityString);
            // 
            // EndStationMenuItem
            // 
            this.EndStationMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewEndStationToolStripMenuItem,
            this.EditEndStationToolStripMenuItem,
            this.DeleteEndStationToolStripMenuItem});
            this.EndStationMenuItem.Name = "EndStationMenuItem";
            this.EndStationMenuItem.Size = new System.Drawing.Size(106, 70);
            // 
            // NewEndStationToolStripMenuItem
            // 
            this.NewEndStationToolStripMenuItem.Name = "NewEndStationToolStripMenuItem";
            this.NewEndStationToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.NewEndStationToolStripMenuItem.Text = "New";
            this.NewEndStationToolStripMenuItem.Click += new System.EventHandler(this.NewEndStationToolStripMenuItem_Click);
            // 
            // EditEndStationToolStripMenuItem
            // 
            this.EditEndStationToolStripMenuItem.Enabled = false;
            this.EditEndStationToolStripMenuItem.Name = "EditEndStationToolStripMenuItem";
            this.EditEndStationToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.EditEndStationToolStripMenuItem.Text = "Edit";
            this.EditEndStationToolStripMenuItem.Click += new System.EventHandler(this.EditEndStationToolStripMenuItem_Click);
            // 
            // DeleteEndStationToolStripMenuItem
            // 
            this.DeleteEndStationToolStripMenuItem.Enabled = false;
            this.DeleteEndStationToolStripMenuItem.Name = "DeleteEndStationToolStripMenuItem";
            this.DeleteEndStationToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.DeleteEndStationToolStripMenuItem.Text = "Delete";
            this.DeleteEndStationToolStripMenuItem.Click += new System.EventHandler(this.DeleteEndStationToolStripMenuItem_Click);
            // 
            // EndStationsListBox
            // 
            this.EndStationsListBox.ContextMenuStrip = this.EndStationMenuItem;
            this.EndStationsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationsListBox.FormattingEnabled = true;
            this.EndStationsListBox.ItemHeight = 15;
            this.EndStationsListBox.Location = new System.Drawing.Point(9, 30);
            this.EndStationsListBox.Name = "EndStationsListBox";
            this.EndStationsListBox.Size = new System.Drawing.Size(142, 109);
            this.EndStationsListBox.TabIndex = 14;
            this.EndStationsListBox.DoubleClick += new System.EventHandler(this.EditEndStationToolStripMenuItem_Click);
            this.EndStationsListBox.SelectedIndexChanged += new System.EventHandler(this.EndStationsListBox_SelectedIndexChanged);
            this.EndStationsListBox.MouseCaptureChanged += new System.EventHandler(this.EndStationsListBox_SelectedIndexChanged);
            // 
            // TPsListBox
            // 
            this.TPsListBox.ContextMenuStrip = this.AbstractActionMenuItem;
            this.TPsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPsListBox.FormattingEnabled = true;
            this.TPsListBox.ItemHeight = 15;
            this.TPsListBox.Location = new System.Drawing.Point(9, 294);
            this.TPsListBox.Name = "TPsListBox";
            this.TPsListBox.Size = new System.Drawing.Size(142, 109);
            this.TPsListBox.Sorted = true;
            this.TPsListBox.TabIndex = 2;
            this.TPsListBox.DoubleClick += new System.EventHandler(this.TPsListBoxOnDoubleClick);
            this.TPsListBox.SelectedIndexChanged += new System.EventHandler(this.TPsListBox_SelectedIndexChanged);
            this.TPsListBox.MouseCaptureChanged += new System.EventHandler(this.TPsListBox_SelectedIndexChanged);
            // 
            // AbstractActionMenuItem
            // 
            this.AbstractActionMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewAbstractActionToolStripMenuItem,
            this.EditAbstractActionToolStripMenuItem,
            this.DeleteAbstractActionToolStripMenuItem});
            this.AbstractActionMenuItem.Name = "AbstractActionMenuItem";
            this.AbstractActionMenuItem.Size = new System.Drawing.Size(106, 70);
            // 
            // NewAbstractActionToolStripMenuItem
            // 
            this.NewAbstractActionToolStripMenuItem.Name = "NewAbstractActionToolStripMenuItem";
            this.NewAbstractActionToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.NewAbstractActionToolStripMenuItem.Text = "New";
            this.NewAbstractActionToolStripMenuItem.Click += new System.EventHandler(this.NewAbstractActionToolStripMenuItem_Click);
            // 
            // EditAbstractActionToolStripMenuItem
            // 
            this.EditAbstractActionToolStripMenuItem.Enabled = false;
            this.EditAbstractActionToolStripMenuItem.Name = "EditAbstractActionToolStripMenuItem";
            this.EditAbstractActionToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.EditAbstractActionToolStripMenuItem.Text = "Edit";
            this.EditAbstractActionToolStripMenuItem.Click += new System.EventHandler(this.EditAbstractActionToolStripMenuItem_Click);
            // 
            // DeleteAbstractActionToolStripMenuItem
            // 
            this.DeleteAbstractActionToolStripMenuItem.Enabled = false;
            this.DeleteAbstractActionToolStripMenuItem.Name = "DeleteAbstractActionToolStripMenuItem";
            this.DeleteAbstractActionToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.DeleteAbstractActionToolStripMenuItem.Text = "Delete";
            this.DeleteAbstractActionToolStripMenuItem.Click += new System.EventHandler(this.DeleteAbstractActionToolStripMenuItem_Click);
            // 
            // ActionsListBox
            // 
            this.ActionsListBox.ContextMenuStrip = this.AbstractActionMenuItem;
            this.ActionsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionsListBox.FormattingEnabled = true;
            this.ActionsListBox.ItemHeight = 15;
            this.ActionsListBox.Location = new System.Drawing.Point(9, 30);
            this.ActionsListBox.Name = "ActionsListBox";
            this.ActionsListBox.Size = new System.Drawing.Size(142, 109);
            this.ActionsListBox.Sorted = true;
            this.ActionsListBox.TabIndex = 0;
            this.ActionsListBox.DoubleClick += new System.EventHandler(this.ActionsListBoxOnDoubleClick);
            this.ActionsListBox.SelectedIndexChanged += new System.EventHandler(this.ActionsListBox_SelectedIndexChanged);
            this.ActionsListBox.MouseCaptureChanged += new System.EventHandler(this.ActionsListBox_SelectedIndexChanged);
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
            this.TSCsListBox.ContextMenuStrip = this.AbstractActionMenuItem;
            this.TSCsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSCsListBox.FormattingEnabled = true;
            this.TSCsListBox.ItemHeight = 15;
            this.TSCsListBox.Location = new System.Drawing.Point(9, 162);
            this.TSCsListBox.Name = "TSCsListBox";
            this.TSCsListBox.Size = new System.Drawing.Size(142, 109);
            this.TSCsListBox.Sorted = true;
            this.TSCsListBox.TabIndex = 1;
            this.TSCsListBox.DoubleClick += new System.EventHandler(this.TSCsListBoxOnDoubleClick);
            this.TSCsListBox.SelectedIndexChanged += new System.EventHandler(this.TSCsListBox_SelectedIndexChanged);
            this.TSCsListBox.MouseCaptureChanged += new System.EventHandler(this.TSCsListBox_SelectedIndexChanged);
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
            // EndStationsGroupBox
            // 
            this.EndStationsGroupBox.Controls.Add(this.IsDefaultLabel);
            this.EndStationsGroupBox.Controls.Add(this.OSTypeText);
            this.EndStationsGroupBox.Controls.Add(this.UsernameText);
            this.EndStationsGroupBox.Controls.Add(this.IPText);
            this.EndStationsGroupBox.Controls.Add(this.OSTypeLabel);
            this.EndStationsGroupBox.Controls.Add(this.UsernameLabel);
            this.EndStationsGroupBox.Controls.Add(this.IPLabel);
            this.EndStationsGroupBox.Controls.Add(this.MoveDownEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.MoveUpEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.SelectEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.UnselectEndStationButton);
            this.EndStationsGroupBox.Controls.Add(this.SelectedEndStationsListBox);
            this.EndStationsGroupBox.Controls.Add(this.label4);
            this.EndStationsGroupBox.Controls.Add(this.EndStationsListBox);
            this.EndStationsGroupBox.Controls.Add(this.EndStationLabel);
            this.EndStationsGroupBox.Enabled = false;
            this.EndStationsGroupBox.Location = new System.Drawing.Point(583, 67);
            this.EndStationsGroupBox.Name = "EndStationsGroupBox";
            this.EndStationsGroupBox.Size = new System.Drawing.Size(296, 332);
            this.EndStationsGroupBox.TabIndex = 43;
            this.EndStationsGroupBox.TabStop = false;
            // 
            // IsDefaultLabel
            // 
            this.IsDefaultLabel.AutoSize = true;
            this.IsDefaultLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsDefaultLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.IsDefaultLabel.Location = new System.Drawing.Point(164, 110);
            this.IsDefaultLabel.Name = "IsDefaultLabel";
            this.IsDefaultLabel.Size = new System.Drawing.Size(0, 15);
            this.IsDefaultLabel.TabIndex = 44;
            // 
            // OSTypeText
            // 
            this.OSTypeText.AutoSize = true;
            this.OSTypeText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSTypeText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OSTypeText.Location = new System.Drawing.Point(220, 90);
            this.OSTypeText.Name = "OSTypeText";
            this.OSTypeText.Size = new System.Drawing.Size(37, 15);
            this.OSTypeText.TabIndex = 43;
            this.OSTypeText.Text = "          ";
            // 
            // UsernameText
            // 
            this.UsernameText.AutoSize = true;
            this.UsernameText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.UsernameText.Location = new System.Drawing.Point(231, 70);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(37, 15);
            this.UsernameText.TabIndex = 42;
            this.UsernameText.Text = "          ";
            // 
            // IPText
            // 
            this.IPText.AutoSize = true;
            this.IPText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.IPText.Location = new System.Drawing.Point(187, 50);
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(37, 15);
            this.IPText.TabIndex = 41;
            this.IPText.Text = "          ";
            // 
            // OSTypeLabel
            // 
            this.OSTypeLabel.AutoSize = true;
            this.OSTypeLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSTypeLabel.Location = new System.Drawing.Point(164, 90);
            this.OSTypeLabel.Name = "OSTypeLabel";
            this.OSTypeLabel.Size = new System.Drawing.Size(54, 15);
            this.OSTypeLabel.TabIndex = 40;
            this.OSTypeLabel.Text = "OS Type:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(164, 70);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(65, 15);
            this.UsernameLabel.TabIndex = 39;
            this.UsernameLabel.Text = "Username:";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.Location = new System.Drawing.Point(164, 50);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(19, 15);
            this.IPLabel.TabIndex = 38;
            this.IPLabel.Text = "IP:";
            // 
            // MoveDownEndStationButton
            // 
            this.MoveDownEndStationButton.Enabled = false;
            this.MoveDownEndStationButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownEndStationButton.Location = new System.Drawing.Point(157, 266);
            this.MoveDownEndStationButton.Name = "MoveDownEndStationButton";
            this.MoveDownEndStationButton.Size = new System.Drawing.Size(35, 23);
            this.MoveDownEndStationButton.TabIndex = 25;
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
            this.MoveUpEndStationButton.TabIndex = 24;
            this.MoveUpEndStationButton.Text = "↑";
            this.MoveUpEndStationButton.UseVisualStyleBackColor = true;
            this.MoveUpEndStationButton.Click += new System.EventHandler(this.MoveUpEndStationButton_Click);
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
            // SelectedEndStationsListBox
            // 
            this.SelectedEndStationsListBox.ContextMenuStrip = this.EndStationMenuItem;
            this.SelectedEndStationsListBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedEndStationsListBox.FormattingEnabled = true;
            this.SelectedEndStationsListBox.ItemHeight = 15;
            this.SelectedEndStationsListBox.Location = new System.Drawing.Point(9, 211);
            this.SelectedEndStationsListBox.Name = "SelectedEndStationsListBox";
            this.SelectedEndStationsListBox.Size = new System.Drawing.Size(142, 109);
            this.SelectedEndStationsListBox.TabIndex = 23;
            this.SelectedEndStationsListBox.DoubleClick += new System.EventHandler(this.EditEndStationToolStripMenuItem_Click);
            this.SelectedEndStationsListBox.SelectedIndexChanged += new System.EventHandler(this.SelectedEndStationsListBox_SelectedIndexChanged);
            this.SelectedEndStationsListBox.MouseCaptureChanged += new System.EventHandler(this.SelectedEndStationsListBox_SelectedIndexChanged);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TPsListBox);
            this.groupBox1.Controls.Add(this.ActionsListBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SingleActionsLabel);
            this.groupBox1.Controls.Add(this.TSCsListBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 414);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(14, 36);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(96, 20);
            this.Title.TabIndex = 38;
            this.Title.Text = "Execution";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(173, 390);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(84, 15);
            this.descriptionLabel.TabIndex = 40;
            this.descriptionLabel.Text = "Description:";
            // 
            // DescriptionText
            // 
            this.DescriptionText.BackColor = System.Drawing.SystemColors.Control;
            this.DescriptionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescriptionText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(176, 408);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ReadOnly = true;
            this.DescriptionText.Size = new System.Drawing.Size(179, 71);
            this.DescriptionText.TabIndex = 53;
            this.DescriptionText.Text = "";
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MessageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.MessageLabel.Location = new System.Drawing.Point(15, 490);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(73, 16);
            this.MessageLabel.TabIndex = 54;
            this.MessageLabel.Text = "             ";
            // 
            // ExecutionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.DescriptionText);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.TreeViewGroupBox);
            this.Controls.Add(this.ReportNameCheckBox);
            this.Controls.Add(this.ParametersGroupBox);
            this.Controls.Add(this.ReportNameTextBox);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.EndStationsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "ExecutionPanel";
            this.Size = new System.Drawing.Size(890, 515);
            ((System.ComponentModel.ISupportInitialize)(this.DurationNumericUpDown)).EndInit();
            this.TreeViewGroupBox.ResumeLayout(false);
            this.TreeViewGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).EndInit();
            this.ParametersGroupBox.ResumeLayout(false);
            this.ParametersGroupBox.PerformLayout();
            this.EndStationMenuItem.ResumeLayout(false);
            this.AbstractActionMenuItem.ResumeLayout(false);
            this.EndStationsGroupBox.ResumeLayout(false);
            this.EndStationsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown DurationNumericUpDown;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.CheckBox DurationCheckBox;
        private System.Windows.Forms.Button MoveDownParameterButton;
        private System.Windows.Forms.Button MoveUpParameterButton;
        private System.Windows.Forms.Button SelectParameterButton;
        private System.Windows.Forms.Button UnselectParameterButton;
        private System.Windows.Forms.ListBox SelectedParametersListBox;
        private System.Windows.Forms.Label SelectedParameterLabel;
        private System.Windows.Forms.ListBox ParametersListBox;
        private System.Windows.Forms.Label ParamtersLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox ReportNameTextBox;
        private System.Windows.Forms.CheckBox ReportNameCheckBox;
        private System.Windows.Forms.Label TreeViewLabel;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.GroupBox TreeViewGroupBox;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button MoveUpActionButton;
        private System.Windows.Forms.Button MoveDownActionButton;
        private System.Windows.Forms.NumericUpDown DelayNumericUpDown;
        private System.Windows.Forms.CheckBox DelayCheckBox;
        private System.Windows.Forms.GroupBox ParametersGroupBox;
        private System.Windows.Forms.ContextMenuStrip EndStationMenuItem;
        private System.Windows.Forms.ListBox EndStationsListBox;
        private System.Windows.Forms.ListBox TPsListBox;
        private System.Windows.Forms.ListBox ActionsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SingleActionsLabel;
        private System.Windows.Forms.ListBox TSCsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox EndStationsGroupBox;
        private System.Windows.Forms.Button MoveDownEndStationButton;
        private System.Windows.Forms.Button MoveUpEndStationButton;
        private System.Windows.Forms.Button SelectEndStationButton;
        private System.Windows.Forms.Button UnselectEndStationButton;
        private System.Windows.Forms.ListBox SelectedEndStationsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label EndStationLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ContextMenuStrip AbstractActionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewAbstractActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditAbstractActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteAbstractActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewEndStationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditEndStationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteEndStationToolStripMenuItem;
        private System.Windows.Forms.Label IsDefaultLabel;
        private System.Windows.Forms.Label OSTypeText;
        private System.Windows.Forms.Label UsernameText;
        private System.Windows.Forms.Label IPText;
        private System.Windows.Forms.Label OSTypeLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.TextBox ValidityStringTextBox;
        private System.Windows.Forms.CheckBox ValidityStringCheckBox;
        private System.Windows.Forms.CheckBox StopIfFailsCheckBox;
        private System.Windows.Forms.RichTextBox DescriptionText;
        private System.Windows.Forms.Label MessageLabel;
    }
}
