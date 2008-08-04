namespace AST.Presentation
{
    partial class AboutDialog
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
            this.AboutText = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DevelopersLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LinkLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AboutText
            // 
            this.AboutText.AutoSize = true;
            this.AboutText.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutText.Location = new System.Drawing.Point(12, 45);
            this.AboutText.Name = "AboutText";
            this.AboutText.Size = new System.Drawing.Size(68, 16);
            this.AboutText.TabIndex = 3;
            this.AboutText.Text = "Version: ";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(58, 18);
            this.Title.TabIndex = 2;
            this.Title.Text = "About";
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(85, 188);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DevelopersLabel
            // 
            this.DevelopersLabel.AutoSize = true;
            this.DevelopersLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevelopersLabel.Location = new System.Drawing.Point(12, 88);
            this.DevelopersLabel.Name = "DevelopersLabel";
            this.DevelopersLabel.Size = new System.Drawing.Size(81, 15);
            this.DevelopersLabel.TabIndex = 5;
            this.DevelopersLabel.Text = "Developers:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "1.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 48);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dudi Patimer\r\nAdi Shachar\r\nYaniv Cohen";
            // 
            // LinkLabel
            // 
            this.LinkLabel.AutoSize = true;
            this.LinkLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LinkLabel.Location = new System.Drawing.Point(74, 154);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(97, 16);
            this.LinkLabel.TabIndex = 8;
            this.LinkLabel.Text = "AST Homepage";
            this.LinkLabel.MouseLeave += new System.EventHandler(this.LinkLabel_MouseLeave);
            this.LinkLabel.Click += new System.EventHandler(this.LinkLabel_Click);
            this.LinkLabel.MouseEnter += new System.EventHandler(this.LinkLabel_MouseEnter);
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(240, 223);
            this.Controls.Add(this.LinkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DevelopersLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AboutText);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.Name = "AboutDialog";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AboutText;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label DevelopersLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LinkLabel;
    }
}