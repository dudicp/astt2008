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

    public partial class MainForm : Form , ASTOutputListener{
        public MainForm(){
            this.MaximizeBox = false;
            
            InitializeComponent();
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.WelcomeScreen();
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);

            ASTManager.GetInstance().AddOutputListener(this);

            ASTManager.GetInstance().Init();

        }

        private void AboutMenuItem_Click(object sender, EventArgs e){
            AboutDialog ad = new AboutDialog();
            ad.ShowDialog();
        }

        private void NewAdditionalActionMenuItem_Click(object sender, EventArgs e){
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.CreateAdditionalActionPanel(null);
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }



        public void DisplayWelcomeScreen() {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.WelcomeScreen();
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

        public void DisplayErrorMessage(String message) {
            MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DisplayInfoMessage(String message) {
            MessageBox.Show(message, "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e) {
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            
            ASTManager.GetInstance().Exit();
        }

        private void ExitMenuItem_Click(object sender, FormClosedEventArgs e) {
            ASTManager.GetInstance().Exit();
        }

        private void ExecuteSingleActionMenuItem_Click(object sender, EventArgs e) {
            BrowseDialog bd = new BrowseDialog(AbstractAction.AbstractActionTypeEnum.ACTION);
            if (bd.ShowDialog() == DialogResult.OK) {
                String name = bd.GetAbstractActionName();
                if ((name == null) || (name.Length == 0)) {
                    MessageBox.Show("No Action Selected.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Action a = (Action)ASTManager.GetInstance().Load(name, AbstractAction.AbstractActionTypeEnum.ACTION);
                this.astPanel.Dispose();
                this.astPanel = new AST.Presentation.ExecutionPanel(a, AbstractAction.AbstractActionTypeEnum.ACTION);
                this.SuspendLayout();
                this.Controls.Add(this.astPanel);
                this.ResumeLayout(false);
            }
        }

        private void NewTestScenarioMenuItem_Click(object sender, EventArgs e) {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.CreateTSCPanel(null, AbstractAction.AbstractActionTypeEnum.TSC);
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

        private void NewTestPlanMenuItem_Click(object sender, EventArgs e) {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.CreateTSCPanel(null, AbstractAction.AbstractActionTypeEnum.TP);
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

        private void OpenAdditionalActionMenuItem_Click(object sender, EventArgs e) {
            OpenAbstractAction(AbstractAction.AbstractActionTypeEnum.ACTION);
        }

        private void OpenTestScenarioMenuItem_Click(object sender, EventArgs e) {
            OpenAbstractAction(AbstractAction.AbstractActionTypeEnum.TSC);
        }

        private void OpenTestPlanMenuItem_Click(object sender, EventArgs e) {
            OpenAbstractAction(AbstractAction.AbstractActionTypeEnum.TP);
        }

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


        private void DeleteAdditionalActionMenuItem_Click(object sender, EventArgs e) {
            DeleteAbstractAction(AbstractAction.AbstractActionTypeEnum.ACTION);
        }

        private void DeleteTestScenarioMenuItem_Click(object sender, EventArgs e) {
            DeleteAbstractAction(AbstractAction.AbstractActionTypeEnum.TSC);
        }

        private void DeleteTestPlanMenuItem_Click(object sender, EventArgs e) {
            DeleteAbstractAction(AbstractAction.AbstractActionTypeEnum.TP);
        }

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

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.astPanel.Dispose();
            this.astPanel = new AST.Presentation.OptionsPanel();
            this.SuspendLayout();
            this.Controls.Add(this.astPanel);
            this.ResumeLayout(false);
        }

    }
}