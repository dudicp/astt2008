using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Domain;
using AST.Management;

namespace AST.Presentation{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form , ASTOutputListener{
        /// <summary>
        /// 
        /// </summary>
        public MainForm(){
            this.MaximizeBox = false;

            ASTManager.GetInstance().AddOutputListener(this);

            ASTManager.GetInstance().Init();

            InitializeComponent();
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.WelcomePanel();
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMenuItem_Click(object sender, EventArgs e){
            AboutDialog ad = new AboutDialog();
            ad.ShowDialog();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewAdditionalActionMenuItem_Click(object sender, EventArgs e){
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.CreateAdditionalActionPanel(null);
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DisplayWelcomeScreen() {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.WelcomePanel();
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void DisplayErrorMessage(String message) {
            MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void DisplayInfoMessage(String message) {
            MessageBox.Show(message, "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, EventArgs e) {
            ASTManager.GetInstance().Exit();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, FormClosedEventArgs e) {
            ASTManager.GetInstance().Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTestScenarioMenuItem_Click(object sender, EventArgs e) {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.CreateTSCPanel(null, AbstractAction.AbstractActionTypeEnum.TSC);
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTestPlanMenuItem_Click(object sender, EventArgs e) {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.CreateTSCPanel(null, AbstractAction.AbstractActionTypeEnum.TP);
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAdditionalActionMenuItem_Click(object sender, EventArgs e) {
            OpenAbstractAction(AbstractAction.AbstractActionTypeEnum.ACTION);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenTestScenarioMenuItem_Click(object sender, EventArgs e) {
            OpenAbstractAction(AbstractAction.AbstractActionTypeEnum.TSC);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenTestPlanMenuItem_Click(object sender, EventArgs e) {
            OpenAbstractAction(AbstractAction.AbstractActionTypeEnum.TP);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        private void OpenAbstractAction(AbstractAction.AbstractActionTypeEnum type) {
            //browsing for the action
            BrowseDialog bd = new BrowseDialog(type);
            if (bd.ShowDialog() == DialogResult.OK) {
                String name = bd.GetAbstractActionName();
                if ((name == null) || (name.Length == 0)) {
                    MessageBox.Show("No Item Selected.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AbstractAction a = ASTManager.GetInstance().Load(name, type);
                this.astPanel.Dispose();

                switch (type) {
                    case AbstractAction.AbstractActionTypeEnum.ACTION:
                        this.astPanel = new AST.Presentation.CreateAdditionalActionPanel((Action)a);
                        break;
                    case AbstractAction.AbstractActionTypeEnum.TSC:
                        this.astPanel = new AST.Presentation.CreateTSCPanel(a, type);
                        break;
                    case AbstractAction.AbstractActionTypeEnum.TP:
                        this.astPanel = new AST.Presentation.CreateTSCPanel(a,type);
                        break;
                    default:
                        this.DisplayErrorMessage("Error: Wrong type selected.");
                        break;
                }
                
                this.SuspendLayout();
                this.Controls.Add(this.astPanel);
                this.ResumeLayout(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAdditionalActionMenuItem_Click(object sender, EventArgs e) {
            DeleteAbstractAction(AbstractAction.AbstractActionTypeEnum.ACTION);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteTestScenarioMenuItem_Click(object sender, EventArgs e) {
            DeleteAbstractAction(AbstractAction.AbstractActionTypeEnum.TSC);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteTestPlanMenuItem_Click(object sender, EventArgs e) {
            DeleteAbstractAction(AbstractAction.AbstractActionTypeEnum.TP);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        private void DeleteAbstractAction(AbstractAction.AbstractActionTypeEnum type) {
            BrowseDialog bd = new BrowseDialog(type);
            if (bd.ShowDialog() == DialogResult.OK) {
                //Delete Action
                String name = bd.GetAbstractActionName();
                if ((name == null) || (name.Length == 0)) {
                    MessageBox.Show("No Item Selected.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;

                ASTManager.GetInstance().DeleteAbstractAction(name, type);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.OptionsPanel();
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteStripMenuItem_Click(object sender, EventArgs e) {
            ExecutionDialog ed = new ExecutionDialog();
            if (ed.ShowDialog() == DialogResult.OK) {
                ProgressDialog pd = new ProgressDialog(ed.GetReportName());

                AbstractAction a = ed.GetAbstractAction();
                AbstractAction.AbstractActionTypeEnum type = ed.GetAbstractActionType();
                String reportName = ed.GetReportName();

                ASTManager.GetInstance().Execute(a, type, reportName);

                pd.ShowDialog();
            }
        }

    }
}