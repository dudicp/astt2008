using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Domain;
using AST.Management;
using System.IO;
using AST.Database;

namespace AST.Presentation{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form , ASTOutputListener{
        /// <summary>
        /// 
        /// </summary>
        /// 

        private const String USER_MANUAL_FILE = "Documents\\UserManual.pdf";

        public MainForm(){
            this.MaximizeBox = false;

            ASTManager.GetInstance().AddOutputListener(this);

            ASTManager.GetInstance().Init();

            InitializeComponent();
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.ExecutionPanel();
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
            CreateAdditionalAction(null);      
        }


        /// <summary>
        /// 
        /// </summary>
        public void DisplayWelcomeScreen() {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.ExecutionPanel();
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
            CreateTSC(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTestPlanMenuItem_Click(object sender, EventArgs e) {
            CreateTP(null);
       
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
                try {
                    AbstractAction a = ASTManager.GetInstance().Load(name, type);
                    switch (type) {
                        case AbstractAction.AbstractActionTypeEnum.ACTION:
                            CreateAdditionalAction((Action)a);
                            break;
                        case AbstractAction.AbstractActionTypeEnum.TSC:
                            CreateTSC((TSC)a);
                            break;
                        case AbstractAction.AbstractActionTypeEnum.TP:
                            CreateTP((TP)a);
                            break;
                        default:
                            this.DisplayErrorMessage("Error: Wrong type selected.");
                            break;
                    }
                }
                catch (Exception ex) {
                    return;
                }
                this.SuspendLayout();
                this.Controls.Add(this.astPanel);
                this.ResumeLayout(false);
            }
        }

        private void CreateAdditionalAction(Action a){
            CreateAdditionalActionDialog d = new CreateAdditionalActionDialog(a);
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK) {
                this.astPanel.Dispose();
                this.astPanel = new AST.Presentation.ExecutionPanel();
                this.SuspendLayout();
                this.Controls.Add(this.astPanel);
                this.ResumeLayout(false);
            }
        }

        private void CreateTSC(TSC tsc) {
            CreateTSCDialog d = new CreateTSCDialog(tsc,AbstractAction.AbstractActionTypeEnum.TSC);
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK) {
                this.astPanel.Dispose();
                this.astPanel = new AST.Presentation.ExecutionPanel();
                this.SuspendLayout();
                this.Controls.Add(this.astPanel);
                this.ResumeLayout(false);
            }
        }

        private void CreateTP(TP tp) {
            CreateTSCDialog d = new CreateTSCDialog(tp, AbstractAction.AbstractActionTypeEnum.TP);
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK) {
                this.astPanel.Dispose();
                this.astPanel = new AST.Presentation.ExecutionPanel();
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

                this.astPanel.Dispose();
                this.astPanel = new AST.Presentation.ExecutionPanel();
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
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            OptionsDialog d = new OptionsDialog();
            d.ShowDialog();
            if(d.DialogResult == DialogResult.OK)
                ASTManager.GetInstance().Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteStripMenuItem_Click(object sender, EventArgs e) {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.ExecutionPanel();
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Method for displaying the user manuel.
        /// </summary>
        public void DisplayUserManuel() {
            if (!File.Exists(USER_MANUAL_FILE)) {
                this.DisplayErrorMessage("The file " + USER_MANUAL_FILE + " isn't found.");
                return;
            }
            System.Diagnostics.ProcessStartInfo procFormsBuilderStartInfo = new System.Diagnostics.ProcessStartInfo();
            procFormsBuilderStartInfo.FileName = USER_MANUAL_FILE;
            procFormsBuilderStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            System.Diagnostics.Process procFormsBuilder = new System.Diagnostics.Process();
            try {
                procFormsBuilder.StartInfo = procFormsBuilderStartInfo;
                procFormsBuilder.Start();
            }
            catch (Exception e) {
                this.DisplayErrorMessage("Unable to open the report file: " + USER_MANUAL_FILE);
            }
        }

        private void HelpMenuItem_Click(object sender, EventArgs e) {
            this.DisplayUserManuel();
        }
    }
}