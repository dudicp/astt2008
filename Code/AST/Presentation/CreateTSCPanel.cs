using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Domain;
using AST.Management;
using System.Collections;

namespace AST.Presentation {
    public partial class CreateTSCPanel : AST.Presentation.ASTPanel {

        private AbstractAction m_abstractAction;
        private AbstractAction.AbstractActionTypeEnum m_type;
        private Hashtable m_actions;
        private List<AbstractAction> m_selectedActions;

        public CreateTSCPanel(AbstractAction a, AbstractAction.AbstractActionTypeEnum type) {
            m_abstractAction = a;
            m_type = type;

            InitializeComponent();

            SetAttributes();

            Init();
        }


        public void SetAttributes() {

            if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                TSCDetailsBox.Text = "TP Details";
                ActionsBox.Text = "TSC's";
                TSCNameLabel.Text = "Plan Name:";
                ActionNameLabel.Text = "TSC Name:";
                SelectedActionsLabel.Text = "Selected TSC's:";
            }
            else if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                TSCDetailsBox.Text = "TSC Details";
                ActionsBox.Text = "Actions";
                TSCNameLabel.Text = "Scenario Name:";
                ActionNameLabel.Text = "Action Name:";
                SelectedActionsLabel.Text = "Selected Actions:";
            }

            //New TSC / TP
            if (m_abstractAction == null) {
                // Test Plan
                if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                    this.m_abstractAction = new TP("", "", 0, "", DateTime.Now, 1);
                    Title.Text = "Create Test Plan";
                    
                }// Test Scenario
                else if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                    this.m_abstractAction = new TSC("", "", 0, "", DateTime.Now);
                    Title.Text = "Create Test Scenario";
                }
            }

            //Exist TSC / TP
            else {

                if (m_type == AbstractAction.AbstractActionTypeEnum.TP) Title.Text = "Edit Test Plan";
                else if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) Title.Text = "Edit Test Scenario";

                ActionNameText.Text = m_abstractAction.Name;
                ActionNameText.Enabled = false;
                CreatorNameText.Text = m_abstractAction.CreatorName;
                DescriptionText.Text = m_abstractAction.Description;
            }
        }

        private void Init() {

            this.ActionsListBox.Items.Clear();
            this.SelectedActionsListBox.Items.Clear();

            this.m_selectedActions = new List<AbstractAction>();

            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                this.m_actions = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.ACTION);
                List<Action> tmpList = ((TSC)this.m_abstractAction).GetActions();
                foreach (Action a in tmpList)
                    this.m_selectedActions.Add(a);
            }
            else if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                this.m_actions = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.TSC);
                List<TSC> tmpList = ((TP)this.m_abstractAction).GetTSCs();
                foreach (TSC a in tmpList)
                    this.m_selectedActions.Add(a);
            }

            //Filling the unselected abstract actions:
            ICollection names = this.m_actions.Keys;
            foreach (String name in names)
                this.ActionsListBox.Items.Add(name);

            //Filling the selected abstract actions:
            foreach (AbstractAction a in this.m_selectedActions)
                this.SelectedActionsListBox.Items.Add(a.Name);
        }

        private void ActionsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.ActionsListBox.SelectedItem != null) {
                this.ActionDescriptionText.Text = (String)this.m_actions[this.ActionsListBox.SelectedItem];
                this.SelectActionButton.Enabled = true;
            }
        }

        private void SelectedActionsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectActionButton.Enabled = false;
            this.SettingsButton.Enabled = false;
            if ((this.SelectedActionsListBox.SelectedIndex < 0) || (this.SelectedActionsListBox.SelectedIndex >= this.m_selectedActions.Count)) return;
            if (this.SelectedActionsListBox.SelectedIndex > 0) this.MoveUpActionButton.Enabled = true;
            else this.MoveUpActionButton.Enabled = false;
            if (this.SelectedActionsListBox.SelectedIndex < (this.m_selectedActions.Count - 1)) this.MoveDownActionButton.Enabled = true;
            else this.MoveDownActionButton.Enabled = false;
            this.UnselectActionButton.Enabled = true;

            this.ActionDescriptionText.Text = this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex].Description;
            this.SettingsButton.Enabled = true;
        }

        private void SelectActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if ((this.ActionsListBox.SelectedIndex < 0) || (this.ActionsListBox.SelectedIndex >= this.m_actions.Count)) {
                this.SelectActionButton.Enabled = false;
                return;
            }
            //T.D. loads fail??
            Action a = (Action)ASTManager.GetInstance().Load((String)this.ActionsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.ACTION);

            this.m_selectedActions.Add(a);
            this.SelectedActionsListBox.Items.Add(a.Name);
        }

        private void UnselectActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if ((this.SelectedActionsListBox.SelectedIndex < 0) || (this.SelectedActionsListBox.SelectedIndex >= this.m_selectedActions.Count)) {
                this.UnselectActionButton.Enabled = false;
                return;
            }

            AbstractAction a = this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex];

            this.SelectedActionsListBox.Items.Remove(a.Name);
            this.m_selectedActions.Remove(a);
            if (SelectedActionsListBox.Items.Count == 0)
                this.UnselectActionButton.Enabled = false;
            if ((this.SelectedActionsListBox.SelectedIndex <= 0) || (this.SelectedActionsListBox.SelectedIndex >= this.m_selectedActions.Count))
                this.MoveUpActionButton.Enabled = false;
            if ((this.SelectedActionsListBox.SelectedIndex < 0) || (this.SelectedActionsListBox.SelectedIndex >= (this.m_selectedActions.Count - 1)))
                this.MoveDownActionButton.Enabled = false;
        }

        private void MoveUpActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if ((this.SelectedActionsListBox.SelectedIndex <= 0) || (this.SelectedActionsListBox.SelectedIndex >= this.m_selectedActions.Count))
                return;

            //Changing the list box view order
            String tmp = (String)this.SelectedActionsListBox.Items[this.SelectedActionsListBox.SelectedIndex];
            this.SelectedActionsListBox.Items[this.SelectedActionsListBox.SelectedIndex] = this.SelectedActionsListBox.Items[this.SelectedActionsListBox.SelectedIndex - 1];
            this.SelectedActionsListBox.Items[this.SelectedActionsListBox.SelectedIndex - 1] = tmp;
            if ((this.SelectedActionsListBox.SelectedIndex <= 0) || (this.SelectedActionsListBox.SelectedIndex >= this.m_selectedActions.Count)) this.MoveUpActionButton.Enabled = false;

            //Changing the real container order
            AbstractAction atmp = this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex];
            this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex] = this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex - 1];
            this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex - 1] = atmp;
        }

        private void MoveDownActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if ((this.SelectedActionsListBox.SelectedIndex < 0) || (this.SelectedActionsListBox.SelectedIndex >= (this.m_selectedActions.Count - 1)))
                return;

            //Changing the list box view order
            String tmp = (String)this.SelectedActionsListBox.Items[this.SelectedActionsListBox.SelectedIndex];
            this.SelectedActionsListBox.Items[this.SelectedActionsListBox.SelectedIndex] = this.SelectedActionsListBox.Items[this.SelectedActionsListBox.SelectedIndex + 1];
            this.SelectedActionsListBox.Items[this.SelectedActionsListBox.SelectedIndex + 1] = tmp;
            if ((this.SelectedActionsListBox.SelectedIndex < 0) || (this.SelectedActionsListBox.SelectedIndex >= (this.m_selectedActions.Count - 1))) this.MoveDownActionButton.Enabled = false;

            //Changing the real container order
            AbstractAction atmp = this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex];
            this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex] = this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex + 1];
            this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex + 1] = atmp;
        }

        private void SettingsButton_Click(object sender, EventArgs e) {
            SettingsDialog sd;
            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                sd = new SettingsDialog((Action)this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex], AbstractAction.AbstractActionTypeEnum.ACTION);
            }
            else if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                sd = new SettingsDialog((TSC)this.m_selectedActions[this.SelectedActionsListBox.SelectedIndex], AbstractAction.AbstractActionTypeEnum.TSC);
            }
            else {
                //T.D. error??
                return;
            }

            if (sd.ShowDialog() == DialogResult.OK) { }
        }

        private void MyCancelButton_Click(object sender, EventArgs e) {
            //Return to the welcome screen
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            ASTManager.GetInstance().DisplayWelcomeScreen();
        }

        private void okButton_Click(object sender, EventArgs e) {
            //Save the Abstract Action
            if (!this.CheckForm()) return;
            this.m_abstractAction.Name = this.ActionNameText.Text;
            this.m_abstractAction.CreatorName = this.CreatorNameText.Text;
            this.m_abstractAction.Description = this.DescriptionText.Text;

            //Update the abstract action object with actions/tsc's
            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                foreach (Action a in this.m_selectedActions)
                    ((TSC)(this.m_abstractAction)).AddAction(a);
                ASTManager.GetInstance().Save(this.m_abstractAction, AbstractAction.AbstractActionTypeEnum.TSC);
            }
            else if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                foreach (TSC tsc in this.m_selectedActions)
                    ((TP)(this.m_abstractAction)).AddTSC(tsc);
                ASTManager.GetInstance().Save(this.m_abstractAction, AbstractAction.AbstractActionTypeEnum.TP);
            }

            ASTManager.GetInstance().DisplayWelcomeScreen();
        }

        private bool CheckForm() {
            bool res = true;
            String message = "The following attributes are invalid:\n";
            if (this.ActionNameText.Text.Length == 0) {
                message += "Action name\n";
                res = false;
            }
            if (this.CreatorNameText.Text.Length == 0) {
                message += "Creator name\n";
                res = false;
            }
            if (this.m_selectedActions.Count == 0) {
                if(m_type == AbstractAction.AbstractActionTypeEnum.TP) message += "No Selected Test Scenarios\n";
                else if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) message += "No Selected Actions\n";
                res = false;
            }

            // Checks the constrain that each TSC should have at least one test action
            if (this.m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                bool hasTest = false;
                foreach (Action a in this.m_selectedActions) {
                    if (a.ActionType == Action.ActionTypeEnum.TEST_SCRIPT) {
                        hasTest = true;
                        break;
                    }
                }
                if (!hasTest) {
                    message += "TSC Missing Test Action\n";
                    res = false;
                }
            }

            if (!res) MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return res;
        }

    }
}

