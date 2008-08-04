namespace AST.Presentation
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewAdditionalActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTestScenarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTestPlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OPenAdditionalActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTestScenarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTestPlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileDeleteStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAdditionalActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTestScenarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTestPlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.astPanel = new AST.Presentation.ASTPanel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileStripMenuItem,
            this.HelpStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(892, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // FileStripMenuItem
            // 
            this.FileStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewStripMenuItem,
            this.FileOpenStripMenuItem,
            this.FileDeleteStripMenuItem,
            this.settingsToolStripMenuItem1,
            this.ExitMenuItem});
            this.FileStripMenuItem.Name = "FileStripMenuItem";
            this.FileStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileStripMenuItem.Text = "File";
            // 
            // FileNewStripMenuItem
            // 
            this.FileNewStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewAdditionalActionMenuItem,
            this.NewTestScenarioMenuItem,
            this.NewTestPlanMenuItem});
            this.FileNewStripMenuItem.Name = "FileNewStripMenuItem";
            this.FileNewStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.FileNewStripMenuItem.Text = "New";
            // 
            // NewAdditionalActionMenuItem
            // 
            this.NewAdditionalActionMenuItem.Name = "NewAdditionalActionMenuItem";
            this.NewAdditionalActionMenuItem.Size = new System.Drawing.Size(167, 22);
            this.NewAdditionalActionMenuItem.Text = "Additional Action";
            this.NewAdditionalActionMenuItem.Click += new System.EventHandler(this.NewAdditionalActionMenuItem_Click);
            // 
            // NewTestScenarioMenuItem
            // 
            this.NewTestScenarioMenuItem.Name = "NewTestScenarioMenuItem";
            this.NewTestScenarioMenuItem.Size = new System.Drawing.Size(167, 22);
            this.NewTestScenarioMenuItem.Text = "Test Scenario";
            this.NewTestScenarioMenuItem.Click += new System.EventHandler(this.NewTestScenarioMenuItem_Click);
            // 
            // NewTestPlanMenuItem
            // 
            this.NewTestPlanMenuItem.Name = "NewTestPlanMenuItem";
            this.NewTestPlanMenuItem.Size = new System.Drawing.Size(167, 22);
            this.NewTestPlanMenuItem.Text = "Test Plan";
            this.NewTestPlanMenuItem.Click += new System.EventHandler(this.NewTestPlanMenuItem_Click);
            // 
            // FileOpenStripMenuItem
            // 
            this.FileOpenStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OPenAdditionalActionMenuItem,
            this.OpenTestScenarioMenuItem,
            this.OpenTestPlanMenuItem});
            this.FileOpenStripMenuItem.Name = "FileOpenStripMenuItem";
            this.FileOpenStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.FileOpenStripMenuItem.Text = "Open";
            // 
            // OPenAdditionalActionMenuItem
            // 
            this.OPenAdditionalActionMenuItem.Name = "OPenAdditionalActionMenuItem";
            this.OPenAdditionalActionMenuItem.Size = new System.Drawing.Size(167, 22);
            this.OPenAdditionalActionMenuItem.Text = "Additional Action";
            this.OPenAdditionalActionMenuItem.Click += new System.EventHandler(this.OpenAdditionalActionMenuItem_Click);
            // 
            // OpenTestScenarioMenuItem
            // 
            this.OpenTestScenarioMenuItem.Name = "OpenTestScenarioMenuItem";
            this.OpenTestScenarioMenuItem.Size = new System.Drawing.Size(167, 22);
            this.OpenTestScenarioMenuItem.Text = "Test Scenario";
            this.OpenTestScenarioMenuItem.Click += new System.EventHandler(this.OpenTestScenarioMenuItem_Click);
            // 
            // OpenTestPlanMenuItem
            // 
            this.OpenTestPlanMenuItem.Name = "OpenTestPlanMenuItem";
            this.OpenTestPlanMenuItem.Size = new System.Drawing.Size(167, 22);
            this.OpenTestPlanMenuItem.Text = "Test Plan";
            this.OpenTestPlanMenuItem.Click += new System.EventHandler(this.OpenTestPlanMenuItem_Click);
            // 
            // FileDeleteStripMenuItem
            // 
            this.FileDeleteStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteAdditionalActionMenuItem,
            this.DeleteTestScenarioMenuItem,
            this.DeleteTestPlanMenuItem});
            this.FileDeleteStripMenuItem.Name = "FileDeleteStripMenuItem";
            this.FileDeleteStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.FileDeleteStripMenuItem.Text = "Delete";
            // 
            // DeleteAdditionalActionMenuItem
            // 
            this.DeleteAdditionalActionMenuItem.Name = "DeleteAdditionalActionMenuItem";
            this.DeleteAdditionalActionMenuItem.Size = new System.Drawing.Size(167, 22);
            this.DeleteAdditionalActionMenuItem.Text = "Additional Action";
            this.DeleteAdditionalActionMenuItem.Click += new System.EventHandler(this.DeleteAdditionalActionMenuItem_Click);
            // 
            // DeleteTestScenarioMenuItem
            // 
            this.DeleteTestScenarioMenuItem.Name = "DeleteTestScenarioMenuItem";
            this.DeleteTestScenarioMenuItem.Size = new System.Drawing.Size(167, 22);
            this.DeleteTestScenarioMenuItem.Text = "Test Scenario";
            this.DeleteTestScenarioMenuItem.Click += new System.EventHandler(this.DeleteTestScenarioMenuItem_Click);
            // 
            // DeleteTestPlanMenuItem
            // 
            this.DeleteTestPlanMenuItem.Name = "DeleteTestPlanMenuItem";
            this.DeleteTestPlanMenuItem.Size = new System.Drawing.Size(167, 22);
            this.DeleteTestPlanMenuItem.Text = "Test Plan";
            this.DeleteTestPlanMenuItem.Click += new System.EventHandler(this.DeleteTestPlanMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(116, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // HelpStripMenuItem
            // 
            this.HelpStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem,
            this.HelpMenuItem});
            this.HelpStripMenuItem.Name = "HelpStripMenuItem";
            this.HelpStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpStripMenuItem.Text = "Help";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(107, 22);
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(107, 22);
            this.HelpMenuItem.Text = "Help";
            this.HelpMenuItem.Click += new System.EventHandler(this.HelpMenuItem_Click);
            // 
            // astPanel
            // 
            this.astPanel.Location = new System.Drawing.Point(0, 29);
            this.astPanel.Name = "astPanel";
            this.astPanel.Size = new System.Drawing.Size(433, 336);
            this.astPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 514);
            this.Controls.Add(this.astPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Automatic Software Testing Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExitMenuItem_Click);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ASTPanel astPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileNewStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewAdditionalActionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewTestScenarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewTestPlanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileOpenStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OPenAdditionalActionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenTestScenarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenTestPlanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileDeleteStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteAdditionalActionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTestScenarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTestPlanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
    }
}