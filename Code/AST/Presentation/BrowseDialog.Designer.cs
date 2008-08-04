namespace AST.Presentation
{
    partial class BrowseDialog
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.DescriptionText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(16, 39);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(238, 68);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.DoubleClick += new System.EventHandler(this.okButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MessageLabel.Location = new System.Drawing.Point(3, 9);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(265, 16);
            this.MessageLabel.TabIndex = 13;
            this.MessageLabel.Text = "Please select the wanted action from the list:";
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(55, 201);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(136, 201);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 3;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // DescriptionText
            // 
            this.DescriptionText.BackColor = System.Drawing.SystemColors.Control;
            this.DescriptionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescriptionText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DescriptionText.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(16, 126);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ReadOnly = true;
            this.DescriptionText.Size = new System.Drawing.Size(238, 57);
            this.DescriptionText.TabIndex = 1;
            this.DescriptionText.Text = "";
            // 
            // BrowseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 236);
            this.Controls.Add(this.DescriptionText);
            this.Controls.Add(this.MyCancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.listBox);
            this.Name = "BrowseDialog";
            this.Text = "Browse Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.RichTextBox DescriptionText;
    }
}