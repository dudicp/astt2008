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
using AST.Database;

namespace AST.Presentation {
    /// <summary>
    /// 
    /// </summary>
    public partial class CreateTSCPanel : AST.Presentation.ASTPanel {

        private AbstractAction m_abstractAction;
        private AbstractAction.AbstractActionTypeEnum m_type;
        private Hashtable m_actions;
        private bool m_isNew;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="type"></param>
        public CreateTSCPanel(AbstractAction a, AbstractAction.AbstractActionTypeEnum type) {
            m_abstractAction = a;
            m_type = type;
            m_isNew = false;

            InitializeComponent();

            SetAttributes();

            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetAttributes() {

            if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                TSCDetailsBox.Text = "TP Details";
                ActionsBox.Text = "TSC's";
                TSCNameLabel.Text = "Plan Name:";
                ActionNameLabel.Text = "TSCs List:";
                SelectedActionsLabel.Text = "Selected TSC's:";
            }
            else if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                TSCDetailsBox.Text = "TSC Details";
                ActionsBox.Text = "Actions";
                TSCNameLabel.Text = "Scenario Name:";
                ActionNameLabel.Text = "Actions List:";
                SelectedActionsLabel.Text = "Selected Actions:";
            }

            //New TSC / TP
            if (m_abstractAction == null) {
                // Test Plan
                if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                    this.m_abstractAction = new TP("Root", "", "", DateTime.Now);
                    Title.Text = "Create Test Plan";
                    
                }// Test Scenario
                else if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                    this.m_abstractAction = new TSC("Root", "", "", DateTime.Now);
                    Title.Text = "Create Test Scenario";
                }

                m_isNew = true;
            }

            //Exist TSC / TP
            else {

                this.m_abstractAction.CreationTime = DateTime.Now;

                if (m_type == AbstractAction.AbstractActionTypeEnum.TP) Title.Text = "Edit Test Plan";
                else if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) Title.Text = "Edit Test Scenario";

                ActionNameText.Text = m_abstractAction.Name;
                ActionNameText.Enabled = false;
                CreatorNameText.Text = m_abstractAction.CreatorName;
                DescriptionText.Text = m_abstractAction.Description;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void Init() {

            this.ActionsListBox.Items.Clear();
            this.SelectedTreeView.Nodes.Clear();
            this.SelectedTreeView.HideSelection = false;

            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) m_actions = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.ACTION);
            else m_actions = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.TSC);

            //Filling the unselected abstract actions:
            ICollection names = this.m_actions.Keys;
            foreach (String name in names)
                this.ActionsListBox.Items.Add(name);

            //Filling the selected tree view:
            ASTNode node = new ASTNode(m_abstractAction, m_type);
            this.SelectedTreeView.Nodes.Add(node);
            this.SelectedTreeView.Nodes[0].Expand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.ActionsListBox.SelectedItem != null) {
                this.ActionDescriptionText.Text = (String)this.m_actions[this.ActionsListBox.SelectedItem];
                this.SelectActionButton.Enabled = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedTreeView_AfterSelect(object sender, TreeViewEventArgs e) {

            if (this.SelectedTreeView.SelectedNode == null) return;

            this.ActionDescriptionText.Text = ((ASTNode)(this.SelectedTreeView.SelectedNode)).Value.Description;

            if (SelectedTreeView.SelectedNode.Level > 1) this.SettingsButton.Enabled = false;
            else this.SettingsButton.Enabled = true;

            if (SelectedTreeView.SelectedNode.Level != 1) { //Only if we aren't on TSC node in TP, or Action node in TSC
                this.MoveUpActionButton.Enabled = false;
                this.MoveDownActionButton.Enabled = false;
                this.SelectActionButton.Enabled = false;
                this.UnselectActionButton.Enabled = false;
                return;
            }
            
            this.UnselectActionButton.Enabled = true;
            if (SelectedTreeView.SelectedNode.Index > 0) this.MoveUpActionButton.Enabled = true;
            else this.MoveUpActionButton.Enabled = false;
            if (SelectedTreeView.SelectedNode.Index < this.SelectedTreeView.SelectedNode.Parent.Nodes.Count - 1) this.MoveDownActionButton.Enabled = true;
            else this.MoveDownActionButton.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if ((this.ActionsListBox.SelectedIndex < 0) || (this.ActionsListBox.SelectedIndex >= this.m_actions.Count)) {
                this.SelectActionButton.Enabled = false;
                return;
            }

            try {
                AbstractAction a;
                ASTNode node;
                if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                    a = (Action)ASTManager.GetInstance().Load((String)this.ActionsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.ACTION);
                    node = new ASTNode(a, AbstractAction.AbstractActionTypeEnum.ACTION); // TSC contains only actions.
                }
                else {
                    a = (TSC)ASTManager.GetInstance().Load((String)this.ActionsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.TSC);
                    node = new ASTNode(a, AbstractAction.AbstractActionTypeEnum.TSC); // TP contains only TSC's.
                }

                this.SelectedTreeView.Nodes[0].Nodes.Add(node);
                this.SettingsButton.Enabled = true;
            }
            catch (ConnectionFailedException ex) { throw new Exception(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnselectActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if (this.SelectedTreeView.SelectedNode == null) {
                this.UnselectActionButton.Enabled = false;
                return;
            }

            this.SelectedTreeView.Nodes[0].Nodes.Remove(this.SelectedTreeView.SelectedNode);

            if (SelectedTreeView.Nodes[0].Nodes.Count == 0) {
                this.UnselectActionButton.Enabled = false;
                this.SettingsButton.Enabled = false;
            }
            if(SelectedTreeView.SelectedNode.Index == 0)
                this.MoveUpActionButton.Enabled = false;
            if (SelectedTreeView.SelectedNode.Index == SelectedTreeView.Nodes[0].Nodes.Count - 1)
                this.MoveDownActionButton.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveUpActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if (this.SelectedTreeView.SelectedNode == null) return;

            //Changing the tree view order
            ASTNode upperNode = ((ASTNode)(this.SelectedTreeView.SelectedNode));
            int index = this.SelectedTreeView.SelectedNode.Index;
            ASTNode lowerNode = ((ASTNode)this.SelectedTreeView.SelectedNode.Parent.Nodes[index - 1]);

            if (this.SelectedTreeView.SelectedNode.Parent.Nodes.Count == 2) {
                //if there are only 2 children and we remove them the selected node will be changed to the parent node
                this.SelectedTreeView.SelectedNode.Parent.Nodes.RemoveAt(index);
                this.SelectedTreeView.SelectedNode.Parent.Nodes.RemoveAt(index - 1);
                this.SelectedTreeView.SelectedNode.Nodes.Insert(index - 1, lowerNode);
                this.SelectedTreeView.SelectedNode.Nodes.Insert(index - 1, upperNode);
            }
            else {
                this.SelectedTreeView.SelectedNode.Parent.Nodes.RemoveAt(index);
                this.SelectedTreeView.SelectedNode.Parent.Nodes.RemoveAt(index - 1);
                this.SelectedTreeView.SelectedNode.Parent.Nodes.Insert(index - 1, lowerNode);
                this.SelectedTreeView.SelectedNode.Parent.Nodes.Insert(index - 1, upperNode);
            }

            this.SelectedTreeView.SelectedNode = upperNode;
            if (this.SelectedTreeView.SelectedNode.Index == 0) this.MoveUpActionButton.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveDownActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if (this.SelectedTreeView.SelectedNode == null) return;

            //Changing the tree view order
            ASTNode lowerNode = ((ASTNode)(this.SelectedTreeView.SelectedNode));
            int index = this.SelectedTreeView.SelectedNode.Index;
            ASTNode upperNode = ((ASTNode)this.SelectedTreeView.SelectedNode.Parent.Nodes[index + 1]);

            if (this.SelectedTreeView.SelectedNode.Parent.Nodes.Count == 2) {
                //if there are only 2 children and we remove them the selected node will be changed to the parent node
                this.SelectedTreeView.SelectedNode.Parent.Nodes.RemoveAt(index + 1);
                this.SelectedTreeView.SelectedNode.Parent.Nodes.RemoveAt(index);

                this.SelectedTreeView.SelectedNode.Nodes.Insert(index, lowerNode);
                this.SelectedTreeView.SelectedNode.Nodes.Insert(index, upperNode);
            }
            else {
                this.SelectedTreeView.SelectedNode.Parent.Nodes.RemoveAt(index + 1);
                this.SelectedTreeView.SelectedNode.Parent.Nodes.RemoveAt(index);

                this.SelectedTreeView.SelectedNode.Parent.Nodes.Insert(index, lowerNode);
                this.SelectedTreeView.SelectedNode.Parent.Nodes.Insert(index, upperNode);
            }
            this.SelectedTreeView.SelectedNode = lowerNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsButton_Click(object sender, EventArgs e) {
            SettingsDialog sd;
            sd = new SettingsDialog(((ASTNode)(this.SelectedTreeView.SelectedNode)).Value, ((ASTNode)(this.SelectedTreeView.SelectedNode)).Type);

            if (sd.ShowDialog() == DialogResult.OK) { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyCancelButton_Click(object sender, EventArgs e) {
            //Return to the welcome screen
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            ASTManager.GetInstance().DisplayWelcomeScreen();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e) {
            //Save the Abstract Action
            if (!this.CheckForm()) return;
            this.m_abstractAction.Name = this.ActionNameText.Text;
            this.m_abstractAction.CreatorName = this.CreatorNameText.Text;
            this.m_abstractAction.Description = this.DescriptionText.Text;

            //Update the abstract action object with actions/tsc's
            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                ((TSC)this.m_abstractAction).ClearActions();
                foreach (TreeNode node in this.SelectedTreeView.Nodes[0].Nodes) {
                    Action a = ((Action)(((ASTNode)(node)).Value));
                    ((TSC)(this.m_abstractAction)).AddAction(a);
                }
                ASTManager.GetInstance().Save(this.m_abstractAction, AbstractAction.AbstractActionTypeEnum.TSC, m_isNew);
            }
            else if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                ((TP)this.m_abstractAction).ClearTSCs();
                foreach (TreeNode node in this.SelectedTreeView.Nodes[0].Nodes) {
                    TSC tsc = ((TSC)(((ASTNode)(node)).Value));
                    ((TP)(this.m_abstractAction)).AddTSC(tsc);
                }
                ASTManager.GetInstance().Save(this.m_abstractAction, AbstractAction.AbstractActionTypeEnum.TP, m_isNew);
            }

            ASTManager.GetInstance().DisplayWelcomeScreen();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
            if (this.SelectedTreeView.Nodes[0].Nodes.Count == 0) {
                if(m_type == AbstractAction.AbstractActionTypeEnum.TP) message += "No Selected Test Scenarios\n";
                else if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) message += "No Selected Actions\n";
                res = false;
            }

            // Checks the constrain that each TSC should have at least one test action
            if (this.m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                bool hasTest = false;
                foreach (TreeNode node in this.SelectedTreeView.Nodes[0].Nodes) {
                    Action a = ((Action)(((ASTNode)(node)).Value));
                    if (a.ActionType == Action.ActionTypeEnum.TEST_SCRIPT) {
                        hasTest = true;
                        break;
                    }
                }
                if (!hasTest) {
                    message += "TSC missing test action\n";
                    res = false;
                }
            }

            if (!res) MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return res;
        }

    }
}

