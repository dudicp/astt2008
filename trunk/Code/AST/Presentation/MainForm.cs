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

        private void OpenAdditionalActionMenuItem_Click(object sender, EventArgs e){
            //browsing for the action
            BrowseDialog bd = new BrowseDialog(AbstractAction.AbstractActionTypeEnum.ACTION);
            if (bd.ShowDialog() == DialogResult.OK) {
                String name = bd.GetAbstractActionName();
                if ((name == null) || (name.Length == 0)) {
                    MessageBox.Show("No Action Selected.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Action a = (Action)ASTManager.GetInstance().Load(name, AbstractAction.AbstractActionTypeEnum.ACTION);
                this.astPanel.Dispose();
                this.astPanel = new AST.Presentation.CreateAdditionalActionPanel(a);
                this.SuspendLayout();
                this.Controls.Add(this.astPanel);
                this.ResumeLayout(false);
            }
        }

        private void DeleteAdditionalActionMenuItem_Click(object sender, EventArgs e){
            BrowseDialog bd = new BrowseDialog(AbstractAction.AbstractActionTypeEnum.ACTION);
            if (bd.ShowDialog() == DialogResult.OK)
            {
                //Delete Action
                String name = bd.GetAbstractActionName();
                if ((name == null) || (name.Length == 0)) {
                    MessageBox.Show("No Action Selected.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;

                ASTManager.GetInstance().DeleteAbstractAction(name, AbstractAction.AbstractActionTypeEnum.ACTION);
            }
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

    }
}