using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Management;
using AST.Domain;

namespace AST.Presentation {
    public partial class ExecutionPanel : AST.Presentation.ASTPanel {

        private AbstractAction m_abstractAction;
        private AbstractAction.AbstractActionTypeEnum m_type;

        public ExecutionPanel(AbstractAction a, AbstractAction.AbstractActionTypeEnum type) {
            this.m_abstractAction = a;
            this.m_type = type;
            InitializeComponent();
            SetExecutionDetails(type);
        }

        private void SetExecutionDetails(AbstractAction.AbstractActionTypeEnum type) {
            switch (type) {
                case AbstractAction.AbstractActionTypeEnum.ACTION: {
                    this.SetSingleActionDetails();
                    break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TSC: {
                    this.SetTSCDetails();
                    break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TP: {
                    this.SetTPDetails();
                    break;
                    }
            }
        }

        private void SetSingleActionDetails() {
            this.Title.Text = "Execute Single Action";
            this.TimesNumericUpDown.Enabled = false;
            this.SettingsButton.Enabled = false;
            System.Windows.Forms.TreeNode actionNode = new System.Windows.Forms.TreeNode(this.m_abstractAction.Name);
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { actionNode });
        }

        private void SetTSCDetails() {
            this.Title.Text = "Execute Test Scenario";
            this.TimesNumericUpDown.Enabled = false;
            this.SettingsButton.Enabled = false;
        }

        private void SetTPDetails() {
            this.Title.Text = "Execute Test Plan";
            this.SettingsButton.Enabled = false;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e) {
            //Only for Action type by Hight and m_abstractAction type
            this.SettingsButton.Enabled = true;
            this.DescriptionText.Text = this.m_abstractAction.Description;
        }

        private void EditActionButton_Click(object sender, EventArgs e) {
            //this.EditActionButton.Enabled = false;
            SettingsDialog ea = new SettingsDialog((Action)this.m_abstractAction, AbstractAction.AbstractActionTypeEnum.ACTION);
            if (ea.ShowDialog() == DialogResult.OK) {}
        }

        private void ExecuteButton_Click(object sender, EventArgs e) {

            String reportName;
            if ((this.ReportNameCheckBox.Checked) && (this.ReportNameTextBox.Text.Length > 0)) reportName = this.ReportNameTextBox.Text;
            else if (this.ReportNameCheckBox.Checked) {
                MessageBox.Show("Invalid Report Name.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else reportName = this.m_abstractAction.Name + " " + DateTime.Now.ToString();

            //int maxTime = this.m_abstractAction.CalculateMaxTime();
            int maxTime = 10;
            DialogResult res = MessageBox.Show("Execution max time is: " + maxTime + " seconds", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ExecutionDialog ed = new ExecutionDialog();

            ASTManager.GetInstance().Execute(this.m_abstractAction, reportName);
            
            // Open ExecutionDialog
            ed.ShowDialog();

            ASTManager.GetInstance().DisplayWelcomeScreen();
        }

        private void MyCancelButton_Click(object sender, EventArgs e) {
            //Return to the welcome screen
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            ASTManager.GetInstance().DisplayWelcomeScreen();
        }
    }
}

