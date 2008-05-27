namespace AST.Management {
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
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.AbortButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ParameterNameLabel = new System.Windows.Forms.Label();
            this.ParameterDetailsBox = new System.Windows.Forms.GroupBox();
            this.OSTypeText = new System.Windows.Forms.Label();
            this.UsernameText = new System.Windows.Forms.Label();
            this.IPText = new System.Windows.Forms.Label();
            this.OSTypeLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.EndStationsTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ParameterDetailsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(13, 243);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(445, 23);
            this.ProgressBar.TabIndex = 0;
            this.ProgressBar.Value = 70;
            // 
            // AbortButton
            // 
            this.AbortButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbortButton.Location = new System.Drawing.Point(198, 281);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(71, 23);
            this.AbortButton.TabIndex = 20;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(13, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(240, 117);
            this.dataGridView1.TabIndex = 21;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(349, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(105, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // ParameterNameLabel
            // 
            this.ParameterNameLabel.AutoSize = true;
            this.ParameterNameLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterNameLabel.Location = new System.Drawing.Point(264, 13);
            this.ParameterNameLabel.Name = "ParameterNameLabel";
            this.ParameterNameLabel.Size = new System.Drawing.Size(79, 15);
            this.ParameterNameLabel.TabIndex = 23;
            this.ParameterNameLabel.Text = "End-Stations:";
            // 
            // ParameterDetailsBox
            // 
            this.ParameterDetailsBox.Controls.Add(this.label9);
            this.ParameterDetailsBox.Controls.Add(this.label3);
            this.ParameterDetailsBox.Controls.Add(this.label4);
            this.ParameterDetailsBox.Controls.Add(this.label1);
            this.ParameterDetailsBox.Controls.Add(this.label2);
            this.ParameterDetailsBox.Controls.Add(this.OSTypeText);
            this.ParameterDetailsBox.Controls.Add(this.UsernameText);
            this.ParameterDetailsBox.Controls.Add(this.IPText);
            this.ParameterDetailsBox.Controls.Add(this.OSTypeLabel);
            this.ParameterDetailsBox.Controls.Add(this.UsernameLabel);
            this.ParameterDetailsBox.Controls.Add(this.IPLabel);
            this.ParameterDetailsBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterDetailsBox.Location = new System.Drawing.Point(267, 38);
            this.ParameterDetailsBox.Name = "ParameterDetailsBox";
            this.ParameterDetailsBox.Size = new System.Drawing.Size(187, 127);
            this.ParameterDetailsBox.TabIndex = 24;
            this.ParameterDetailsBox.TabStop = false;
            this.ParameterDetailsBox.Text = "End-Station Details";
            // 
            // OSTypeText
            // 
            this.OSTypeText.AutoSize = true;
            this.OSTypeText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSTypeText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OSTypeText.Location = new System.Drawing.Point(71, 80);
            this.OSTypeText.Name = "OSTypeText";
            this.OSTypeText.Size = new System.Drawing.Size(59, 15);
            this.OSTypeText.TabIndex = 42;
            this.OSTypeText.Text = "WINDOWS";
            // 
            // UsernameText
            // 
            this.UsernameText.AutoSize = true;
            this.UsernameText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.UsernameText.Location = new System.Drawing.Point(82, 60);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(29, 15);
            this.UsernameText.TabIndex = 41;
            this.UsernameText.Text = "Kyle";
            // 
            // IPText
            // 
            this.IPText.AutoSize = true;
            this.IPText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.IPText.Location = new System.Drawing.Point(36, 40);
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(72, 15);
            this.IPText.TabIndex = 40;
            this.IPText.Text = "192.168.2.3";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(54, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 44;
            this.label1.Text = "02-00-54-55-4E-01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "MAC:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "Name (ID):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "Current Action:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(360, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = "Round:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(417, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "1/1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(121, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 42;
            this.label8.Text = "Action 4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(79, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 47;
            this.label9.Text = "End-Station (1)";
            // 
            // EndStationsTitle
            // 
            this.EndStationsTitle.AutoSize = true;
            this.EndStationsTitle.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndStationsTitle.Location = new System.Drawing.Point(12, 9);
            this.EndStationsTitle.Name = "EndStationsTitle";
            this.EndStationsTitle.Size = new System.Drawing.Size(179, 20);
            this.EndStationsTitle.TabIndex = 43;
            this.EndStationsTitle.Text = "Execution Progress";
            // 
            // ExecutionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 312);
            this.Controls.Add(this.EndStationsTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ParameterDetailsBox);
            this.Controls.Add(this.ParameterNameLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.ProgressBar);
            this.Name = "ExecutionDialog";
            this.Text = "Execution Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ParameterDetailsBox.ResumeLayout(false);
            this.ParameterDetailsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label ParameterNameLabel;
        private System.Windows.Forms.GroupBox ParameterDetailsBox;
        private System.Windows.Forms.Label OSTypeText;
        private System.Windows.Forms.Label UsernameText;
        private System.Windows.Forms.Label IPText;
        private System.Windows.Forms.Label OSTypeLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label EndStationsTitle;
    }
}