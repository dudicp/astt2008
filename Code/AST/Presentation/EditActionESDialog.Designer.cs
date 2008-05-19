namespace AST.Presentation {
    partial class EditActionESDialog {
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
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
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
            this.Title = new System.Windows.Forms.Label();
            this.EndStationsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(228, 253);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(71, 23);
            this.MyCancelButton.TabIndex = 19;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(150, 253);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(72, 23);
            this.okButton.TabIndex = 21;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
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
            this.EndStationsGroupBox.Location = new System.Drawing.Point(15, 53);
            this.EndStationsGroupBox.Name = "EndStationsGroupBox";
            this.EndStationsGroupBox.Size = new System.Drawing.Size(436, 174);
            this.EndStationsGroupBox.TabIndex = 20;
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
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(13, 14);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(162, 20);
            this.Title.TabIndex = 22;
            this.Title.Text = "Edit End-Stations";
            // 
            // EditActionESDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 286);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.EndStationsGroupBox);
            this.Name = "EditActionESDialog";
            this.Text = "Edit End-Stations";
            this.EndStationsGroupBox.ResumeLayout(false);
            this.EndStationsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox EndStationsGroupBox;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button NewEndStationButton;
        private System.Windows.Forms.Button ScheduleButton;
        private System.Windows.Forms.CheckBox ParallelCheckBox;
        private System.Windows.Forms.Button MoveDownEndStationButton;
        private System.Windows.Forms.Button MoveUpEndStationButton;
        private System.Windows.Forms.Button UnselectEndStationButton;
        private System.Windows.Forms.Button SelectEndStationButton;
        private System.Windows.Forms.ListBox SelectedEndStationsListBox;
        private System.Windows.Forms.Label SelectedEndStationLabel;
        private System.Windows.Forms.ListBox EndStationsListBox;
        private System.Windows.Forms.Label EndStationsLabel;
        private System.Windows.Forms.Label Title;

    }
}