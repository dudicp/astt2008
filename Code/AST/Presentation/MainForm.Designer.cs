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
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecuteStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecuteSingleActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecuteTestScenarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecuteTestPlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ToolsStripMenuItem,
            this.HelpStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(442, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // FileStripMenuItem
            // 
            this.FileStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewStripMenuItem,
            this.FileOpenStripMenuItem,
            this.FileDeleteStripMenuItem,
            this.ExitMenuItem});
            this.FileStripMenuItem.Name = "FileStripMenuItem";
            this.FileStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.FileStripMenuItem.Text = "File";
            // 
            // FileNewStripMenuItem
            // 
            this.FileNewStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewAdditionalActionMenuItem,
            this.NewTestScenarioMenuItem,
            this.NewTestPlanMenuItem});
            this.FileNewStripMenuItem.Name = "FileNewStripMenuItem";
            this.FileNewStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.FileNewStripMenuItem.Text = "New";
            // 
            // NewAdditionalActionMenuItem
            // 
            this.NewAdditionalActionMenuItem.Name = "NewAdditionalActionMenuItem";
            this.NewAdditionalActionMenuItem.Size = new System.Drawing.Size(154, 22);
            this.NewAdditionalActionMenuItem.Text = "Additional Action";
            this.NewAdditionalActionMenuItem.Click += new System.EventHandler(this.NewAdditionalActionMenuItem_Click);
            // 
            // NewTestScenarioMenuItem
            // 
            this.NewTestScenarioMenuItem.Enabled = false;
            this.NewTestScenarioMenuItem.Name = "NewTestScenarioMenuItem";
            this.NewTestScenarioMenuItem.Size = new System.Drawing.Size(154, 22);
            this.NewTestScenarioMenuItem.Text = "Test Scenario";
            // 
            // NewTestPlanMenuItem
            // 
            this.NewTestPlanMenuItem.Enabled = false;
            this.NewTestPlanMenuItem.Name = "NewTestPlanMenuItem";
            this.NewTestPlanMenuItem.Size = new System.Drawing.Size(154, 22);
            this.NewTestPlanMenuItem.Text = "Test Plan";
            // 
            // FileOpenStripMenuItem
            // 
            this.FileOpenStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OPenAdditionalActionMenuItem,
            this.OpenTestScenarioMenuItem,
            this.OpenTestPlanMenuItem});
            this.FileOpenStripMenuItem.Name = "FileOpenStripMenuItem";
            this.FileOpenStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.FileOpenStripMenuItem.Text = "Open";
            // 
            // OPenAdditionalActionMenuItem
            // 
            this.OPenAdditionalActionMenuItem.Name = "OPenAdditionalActionMenuItem";
            this.OPenAdditionalActionMenuItem.Size = new System.Drawing.Size(154, 22);
            this.OPenAdditionalActionMenuItem.Text = "Additional Action";
            this.OPenAdditionalActionMenuItem.Click += new System.EventHandler(this.OpenAdditionalActionMenuItem_Click);
            // 
            // OpenTestScenarioMenuItem
            // 
            this.OpenTestScenarioMenuItem.Enabled = false;
            this.OpenTestScenarioMenuItem.Name = "OpenTestScenarioMenuItem";
            this.OpenTestScenarioMenuItem.Size = new System.Drawing.Size(154, 22);
            this.OpenTestScenarioMenuItem.Text = "Test Scenario";
            // 
            // OpenTestPlanMenuItem
            // 
            this.OpenTestPlanMenuItem.Enabled = false;
            this.OpenTestPlanMenuItem.Name = "OpenTestPlanMenuItem";
            this.OpenTestPlanMenuItem.Size = new System.Drawing.Size(154, 22);
            this.OpenTestPlanMenuItem.Text = "Test Plan";
            // 
            // FileDeleteStripMenuItem
            // 
            this.FileDeleteStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteAdditionalActionMenuItem,
            this.DeleteTestScenarioMenuItem,
            this.DeleteTestPlanMenuItem});
            this.FileDeleteStripMenuItem.Name = "FileDeleteStripMenuItem";
            this.FileDeleteStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.FileDeleteStripMenuItem.Text = "Delete";
            // 
            // DeleteAdditionalActionMenuItem
            // 
            this.DeleteAdditionalActionMenuItem.Name = "DeleteAdditionalActionMenuItem";
            this.DeleteAdditionalActionMenuItem.Size = new System.Drawing.Size(154, 22);
            this.DeleteAdditionalActionMenuItem.Text = "Additional Action";
            this.DeleteAdditionalActionMenuItem.Click += new System.EventHandler(this.DeleteAdditionalActionMenuItem_Click);
            // 
            // DeleteTestScenarioMenuItem
            // 
            this.DeleteTestScenarioMenuItem.Enabled = false;
            this.DeleteTestScenarioMenuItem.Name = "DeleteTestScenarioMenuItem";
            this.DeleteTestScenarioMenuItem.Size = new System.Drawing.Size(154, 22);
            this.DeleteTestScenarioMenuItem.Text = "Test Scenario";
            // 
            // DeleteTestPlanMenuItem
            // 
            this.DeleteTestPlanMenuItem.Enabled = false;
            this.DeleteTestPlanMenuItem.Name = "DeleteTestPlanMenuItem";
            this.DeleteTestPlanMenuItem.Size = new System.Drawing.Size(154, 22);
            this.DeleteTestPlanMenuItem.Text = "Test Plan";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // ToolsStripMenuItem
            // 
            this.ToolsStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExecuteStripMenuItem,
            this.ReportStripMenuItem});
            this.ToolsStripMenuItem.Name = "ToolsStripMenuItem";
            this.ToolsStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ToolsStripMenuItem.Text = "Tools";
            // 
            // ExecuteStripMenuItem
            // 
            this.ExecuteStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExecuteSingleActionMenuItem,
            this.ExecuteTestScenarioMenuItem,
            this.ExecuteTestPlanMenuItem});
            this.ExecuteStripMenuItem.Name = "ExecuteStripMenuItem";
            this.ExecuteStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ExecuteStripMenuItem.Text = "Execute";
            // 
            // ExecuteSingleActionMenuItem
            // 
            this.ExecuteSingleActionMenuItem.Name = "ExecuteSingleActionMenuItem";
            this.ExecuteSingleActionMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ExecuteSingleActionMenuItem.Text = "Single Action";
            this.ExecuteSingleActionMenuItem.Click += new System.EventHandler(this.ExecuteSingleActionMenuItem_Click);
            // 
            // ExecuteTestScenarioMenuItem
            // 
            this.ExecuteTestScenarioMenuItem.Enabled = false;
            this.ExecuteTestScenarioMenuItem.Name = "ExecuteTestScenarioMenuItem";
            this.ExecuteTestScenarioMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ExecuteTestScenarioMenuItem.Text = "Test Scenario";
            // 
            // ExecuteTestPlanMenuItem
            // 
            this.ExecuteTestPlanMenuItem.Enabled = false;
            this.ExecuteTestPlanMenuItem.Name = "ExecuteTestPlanMenuItem";
            this.ExecuteTestPlanMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ExecuteTestPlanMenuItem.Text = "Test Plan";
            // 
            // ReportStripMenuItem
            // 
            this.ReportStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerateReportMenuItem,
            this.DeleteReportMenuItem});
            this.ReportStripMenuItem.Enabled = false;
            this.ReportStripMenuItem.Name = "ReportStripMenuItem";
            this.ReportStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ReportStripMenuItem.Text = "Reports";
            // 
            // GenerateReportMenuItem
            // 
            this.GenerateReportMenuItem.Name = "GenerateReportMenuItem";
            this.GenerateReportMenuItem.Size = new System.Drawing.Size(155, 22);
            this.GenerateReportMenuItem.Text = "Generate Report";
            // 
            // DeleteReportMenuItem
            // 
            this.DeleteReportMenuItem.Name = "DeleteReportMenuItem";
            this.DeleteReportMenuItem.Size = new System.Drawing.Size(155, 22);
            this.DeleteReportMenuItem.Text = "Delete Report";
            // 
            // HelpStripMenuItem
            // 
            this.HelpStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem,
            this.HelpMenuItem});
            this.HelpStripMenuItem.Name = "HelpStripMenuItem";
            this.HelpStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.HelpStripMenuItem.Text = "Help";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(103, 22);
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Enabled = false;
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(103, 22);
            this.HelpMenuItem.Text = "Help";
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
            this.ClientSize = new System.Drawing.Size(442, 564);
            this.Controls.Add(this.astPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Automatic Software Testing Tool";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ASTPanel astPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem ExecuteStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExecuteSingleActionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExecuteTestScenarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExecuteTestPlanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GenerateReportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteReportMenuItem;
    }
}