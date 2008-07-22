using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AST.Domain;
using AST.Management;
using AST.Database;

namespace AST.Presentation {
    /// <summary>
    /// 
    /// </summary>
    public partial class ExecutionDialog : Form {

        private Hashtable m_actionsInfo;
        private Hashtable m_TSCsInfo;
        private Hashtable m_TPsInfo;
        private List<EndStation> m_endStations;
        private List<Parameter> m_parameters;
        private AbstractAction m_activeAction;
        private AbstractAction m_rootAction;
        private AbstractAction.AbstractActionTypeEnum m_type;
        private String m_reportName;
        /// <summary>
        /// 
        /// </summary>
        public ExecutionDialog() {
            m_activeAction = null;
            m_rootAction = null;
            m_reportName = "";
            m_actionsInfo = new Hashtable();
            m_TSCsInfo = new Hashtable();
            m_TPsInfo = new Hashtable();
            InitializeComponent();            
            SetAbstractActionsInfo();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="type"></param>
        public ExecutionDialog(AbstractAction a, AbstractAction.AbstractActionTypeEnum type) {
            m_activeAction = a;
            m_rootAction = a;
            m_reportName = "";
            m_type = type;
            m_actionsInfo = new Hashtable();
            m_TSCsInfo = new Hashtable();
            m_TPsInfo = new Hashtable();
            InitializeComponent();
            SetAbstractActionsInfo();
            SelectAbstractAction();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AbstractAction GetAbstractAction() {
            return this.m_rootAction;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetReportName() {
            return this.m_reportName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AbstractAction.AbstractActionTypeEnum GetAbstractActionType() {
            return m_type;
        }

    #region Abstract Action Methods
        /// <summary>
        /// 
        /// </summary>
        private void SetAbstractActionsInfo() {
            this.ActionsListBox.Items.Clear();
            this.TSCsListBox.Items.Clear();
            this.TPsListBox.Items.Clear();

            this.m_actionsInfo = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.ACTION);
            this.m_TSCsInfo = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.TSC);
            this.m_TPsInfo = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.TP);

            //Setting Action List Box
            ICollection names = this.m_actionsInfo.Keys;
            foreach (String name in names)
                this.ActionsListBox.Items.Add(name);

            //Setting TSC List Box
            names = this.m_TSCsInfo.Keys;
            foreach (String name in names)
                this.TSCsListBox.Items.Add(name);

            //Setting TP List Box
            names = this.m_TPsInfo.Keys;
            foreach (String name in names)
                this.TPsListBox.Items.Add(name);
        }
        /// <summary>
        /// 
        /// </summary>
        private void SelectAbstractAction() {
            switch (m_type) {
                case AbstractAction.AbstractActionTypeEnum.ACTION:
                    this.ActionsListBox.SelectedItem = m_rootAction.Name;
                    this.ActionsListBox_OnDoubleClick(null, null);
                    break;
                case AbstractAction.AbstractActionTypeEnum.TSC:
                    this.TSCsListBox.SelectedItem = m_rootAction.Name;
                    this.TSCsListBox_OnDoubleClick(null, null);
                    this.TreeView.SelectedNode = this.TreeView.Nodes[0];
                    this.TreeView_OnDoubleClick(null, null);
                    break;
                default:
                    this.TPsListBox.SelectedItem = m_rootAction.Name;
                    this.TPsListBox_OnDoubleClick(null, null);
                    this.TreeView.SelectedNode = this.TreeView.Nodes[0];
                    this.TreeView_OnDoubleClick(null, null);
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.ActionsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_actionsInfo[this.ActionsListBox.SelectedItem];
                this.TPsListBox.ClearSelected();
                this.TSCsListBox.ClearSelected();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSCsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.TSCsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_TSCsInfo[this.TSCsListBox.SelectedItem];
                this.ActionsListBox.ClearSelected();
                this.TPsListBox.ClearSelected();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TPsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.TPsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_TPsInfo[this.TPsListBox.SelectedItem];
                this.ActionsListBox.ClearSelected();
                this.TSCsListBox.ClearSelected();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionsListBox_OnDoubleClick(object sender, EventArgs e) {
            if (this.ActionsListBox.SelectedItem == null) return;
            this.DescriptionText.Text = (String)this.m_actionsInfo[this.ActionsListBox.SelectedItem];
            this.TPsListBox.ClearSelected();
            this.TSCsListBox.ClearSelected();
            try {
                m_rootAction = ASTManager.GetInstance().Load((String)this.ActionsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.ACTION);
                m_activeAction = m_rootAction;

                //Add this action the Default End-Stations
                ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;
                foreach (EndStation es in endStations) {
                    if (es.IsDefault) m_activeAction.AddEndStation(new EndStationSchedule(es));
                }

                //Clears the TreeView
                this.TreeView.Nodes.Clear();

                //Set End-Station List Boxes
                this.SetEndStations(m_activeAction);

                //Clears the input text box
                this.InputTextBox.Clear();

                //Add this action the Default Parameters
                List<Parameter> parameters = ASTManager.GetInstance().GetParameters(m_activeAction.Name);
                foreach (Parameter p in parameters) {
                    if (p.IsDefault) ((Action)m_activeAction).AddParameter(p);
                }
            }
            catch (ConnectionFailedException ex) { throw new Exception(ex.Message); }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Set Parameters List Boxes
            this.SetParameters((Action)m_activeAction);

            //Enable The End-Station GroupBox
            this.EndStationsGroupBox.Enabled = true;

            //Enable The Parameters GroupBox
            this.ParametersGroupBox.Enabled = true;

            //Disable The TreeView GroupBox
            this.TreeViewGroupBox.Enabled = false;

            m_type = AbstractAction.AbstractActionTypeEnum.ACTION;

            //Enable the execute button
            this.ExecuteButton.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSCsListBox_OnDoubleClick(object sender, EventArgs e) {
            if (this.TSCsListBox.SelectedItem == null) return;
            try {
                m_rootAction = ASTManager.GetInstance().Load((String)this.TSCsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.TSC);
            }
            catch (ConnectionFailedException ex) { throw new Exception(ex.Message); }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Enable The End-Station GroupBox
            this.EndStationsGroupBox.Enabled = false;

            //Enable The Parameters GroupBox
            this.ParametersGroupBox.Enabled = false;

            //Clears the input text box
            this.InputTextBox.Clear();

            m_type = AbstractAction.AbstractActionTypeEnum.TSC;

            //Set TreeView GroupBox
            this.SetTreeView();

            //Disable The TreeView GroupBox
            this.TreeViewGroupBox.Enabled = true;

            //Enable the execute button
            this.ExecuteButton.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TPsListBox_OnDoubleClick(object sender, EventArgs e) {
            if (this.TPsListBox.SelectedItem == null) return;
            try {
                m_rootAction = ASTManager.GetInstance().Load((String)this.TPsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.TP);
            }
            catch (ConnectionFailedException ex) { throw new Exception(ex.Message); }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Enable The End-Station GroupBox
            this.EndStationsGroupBox.Enabled = false;

            //Enable The Parameters GroupBox
            this.ParametersGroupBox.Enabled = false;

            //Clears the input text box
            this.InputTextBox.Clear();

            m_type = AbstractAction.AbstractActionTypeEnum.TP;

            //Set TreeView GroupBox
            this.SetTreeView();

            //Disable The TreeView GroupBox
            this.TreeViewGroupBox.Enabled = true;

            //Enable the execute button
            this.ExecuteButton.Enabled = true;
        }

    #endregion

    #region TreeView Methods
        /// <summary>
        /// 
        /// </summary>
        private void SetTreeView() {
            this.TreeView.Nodes.Clear();
            this.TreeView.HideSelection = false;

            ASTNode node = new ASTNode(this.m_rootAction, m_type);
            this.TreeView.Nodes.Add(node);
            this.TreeView.Nodes[0].Expand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e) {

            if (this.TreeView.SelectedNode == null) return;

            this.DescriptionText.Text = ((ASTNode)(this.TreeView.SelectedNode)).Value.Description;

            if (TreeView.SelectedNode.Level != 1) {
                this.MoveUpActionButton.Enabled = false;
                this.MoveDownActionButton.Enabled = false;
                return;
            }

            if (this.TreeView.SelectedNode == null) return;
            if (TreeView.SelectedNode.Index > 0) this.MoveUpActionButton.Enabled = true;
            else this.MoveUpActionButton.Enabled = false;
            if ((TreeView.SelectedNode.Level == 1) && (TreeView.SelectedNode.Index < this.TreeView.SelectedNode.Parent.GetNodeCount(false) - 1)) this.MoveDownActionButton.Enabled = true;
            else this.MoveDownActionButton.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveUpActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if (this.TreeView.SelectedNode == null) return;

            //Changing the tree view order
            ASTNode upperNode = ((ASTNode)(this.TreeView.SelectedNode));
            int index = this.TreeView.SelectedNode.Index;
            ASTNode lowerNode = ((ASTNode)this.TreeView.SelectedNode.Parent.Nodes[index - 1]);

            if (this.TreeView.SelectedNode.Parent.Nodes.Count == 2) {
                //if there are only 2 children and we remove them the selected node will be changed to the parent node
                this.TreeView.SelectedNode.Parent.Nodes.RemoveAt(index);
                this.TreeView.SelectedNode.Parent.Nodes.RemoveAt(index - 1);
                this.TreeView.SelectedNode.Nodes.Insert(index - 1, lowerNode);
                this.TreeView.SelectedNode.Nodes.Insert(index - 1, upperNode);
            }
            else {
                this.TreeView.SelectedNode.Parent.Nodes.RemoveAt(index);
                this.TreeView.SelectedNode.Parent.Nodes.RemoveAt(index - 1);
                this.TreeView.SelectedNode.Parent.Nodes.Insert(index - 1, lowerNode);
                this.TreeView.SelectedNode.Parent.Nodes.Insert(index - 1, upperNode);
            }

            this.TreeView.SelectedNode = upperNode;
            if (this.TreeView.SelectedNode.Index == 0) this.MoveUpActionButton.Enabled = false;

            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                Action tmp = ((TSC)this.m_rootAction).GetActions()[index];
                ((TSC)this.m_rootAction).GetActions()[index] = ((TSC)this.m_rootAction).GetActions()[index - 1];
                ((TSC)this.m_rootAction).GetActions()[index - 1] = tmp;
            }
            if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                TSC tmp = ((TP)this.m_rootAction).GetTSCs()[index];
                ((TP)this.m_rootAction).GetTSCs()[index] = ((TP)this.m_rootAction).GetTSCs()[index - 1];
                ((TP)this.m_rootAction).GetTSCs()[index - 1] = tmp;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveDownActionButton_Click(object sender, EventArgs e) {
            //Checks index validity
            if (this.TreeView.SelectedNode == null) return;

            //Changing the tree view order
            ASTNode lowerNode = ((ASTNode)(this.TreeView.SelectedNode));
            int index = this.TreeView.SelectedNode.Index;
            ASTNode upperNode = ((ASTNode)this.TreeView.SelectedNode.Parent.Nodes[index + 1]);

            if (this.TreeView.SelectedNode.Parent.Nodes.Count == 2) {
                //if there are only 2 children and we remove them the selected node will be changed to the parent node
                this.TreeView.SelectedNode.Parent.Nodes.RemoveAt(index + 1);
                this.TreeView.SelectedNode.Parent.Nodes.RemoveAt(index);

                this.TreeView.SelectedNode.Nodes.Insert(index, lowerNode);
                this.TreeView.SelectedNode.Nodes.Insert(index, upperNode);
            }else{
                this.TreeView.SelectedNode.Parent.Nodes.RemoveAt(index + 1);
                this.TreeView.SelectedNode.Parent.Nodes.RemoveAt(index);

                this.TreeView.SelectedNode.Parent.Nodes.Insert(index, lowerNode);
                this.TreeView.SelectedNode.Parent.Nodes.Insert(index, upperNode);
            }
            this.TreeView.SelectedNode = lowerNode;

            if (m_type == AbstractAction.AbstractActionTypeEnum.TSC) {
                Action tmp = ((TSC)this.m_rootAction).GetActions()[index];
                ((TSC)this.m_rootAction).GetActions()[index] = ((TSC)this.m_rootAction).GetActions()[index + 1];
                ((TSC)this.m_rootAction).GetActions()[index + 1] = tmp;
            }
            if (m_type == AbstractAction.AbstractActionTypeEnum.TP) {
                TSC tmp = ((TP)this.m_rootAction).GetTSCs()[index];
                ((TP)this.m_rootAction).GetTSCs()[index] = ((TP)this.m_rootAction).GetTSCs()[index + 1];
                ((TP)this.m_rootAction).GetTSCs()[index + 1] = tmp;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_OnDoubleClick(object sender, EventArgs e) {

            if (this.TreeView.SelectedNode == null) return;

            m_activeAction = ((ASTNode)this.TreeView.SelectedNode).Value;
            AbstractAction.AbstractActionTypeEnum selectedType;
            if(m_type == AbstractAction.AbstractActionTypeEnum.TSC){
                if(this.TreeView.SelectedNode.Level == 0) selectedType = AbstractAction.AbstractActionTypeEnum.TSC;
                else selectedType = AbstractAction.AbstractActionTypeEnum.ACTION;
            }
            else{
                if(this.TreeView.SelectedNode.Level == 0) selectedType = AbstractAction.AbstractActionTypeEnum.TP;
                else if(this.TreeView.SelectedNode.Level == 1) selectedType = AbstractAction.AbstractActionTypeEnum.TSC;
                else selectedType = AbstractAction.AbstractActionTypeEnum.ACTION;
            }


            //Enable end-stations GroupBox
            this.EndStationsGroupBox.Enabled = true;
            this.SetEndStations(m_activeAction);

            //Enable Parameters Groupbox if the active action is of type Action
            if (selectedType == AbstractAction.AbstractActionTypeEnum.ACTION) {
                this.SetParameters((Action)m_activeAction);
                this.ParametersGroupBox.Enabled = true;
            }
            else this.ParametersGroupBox.Enabled = false;
        }

    #endregion

    #region End-Stations Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        private void SetEndStations(AbstractAction a) {
            this.m_endStations = new List<EndStation>();
            this.EndStationsListBox.Items.Clear();
            this.SelectedEndStationsListBox.Items.Clear();

            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;
            List<EndStation> selectedEndStations = new List<EndStation>();

            //Filling the selected end-stations list box:
            foreach (EndStationSchedule ess in a.GetEndStations()){
                this.SelectedEndStationsListBox.Items.Add(ess.EndStation.Name + "(" + ess.EndStation.ID + ")");
                selectedEndStations.Add(ess.EndStation);
            }

            //Filling the unselected end-stations:
            foreach (EndStation es in endStations) {
                if (!selectedEndStations.Contains(es)) {
                    this.m_endStations.Add(es);
                    this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewEndStationButton_Click(object sender, EventArgs e) {
            EndStationDialog esd = new EndStationDialog(null);
            if (esd.ShowDialog() == DialogResult.OK) {
                EndStation es = esd.GetEndStation();
                this.m_endStations.Add(es);
                ASTManager.GetInstance().AddEndStation(es, true);
                this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e) {

            //In case we are in the upper list box.
            if ((this.EndStationsListBox.SelectedIndex >= 0) && (this.EndStationsListBox.SelectedIndex < this.m_endStations.Count)) {
                EndStationDialog esd = new EndStationDialog(this.m_endStations[this.EndStationsListBox.SelectedIndex]);
                if (esd.ShowDialog() == DialogResult.OK) {
                    this.m_endStations.Remove(this.m_endStations[this.EndStationsListBox.SelectedIndex]);
                    this.EndStationsListBox.Items.RemoveAt(this.EndStationsListBox.SelectedIndex);
                    EndStation es = esd.GetEndStation();
                    ASTManager.GetInstance().AddEndStation(es, false);
                    this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
                    this.m_endStations.Add(es);
                }
            }

            // In case we are in the lower list box.
            if ((this.SelectedEndStationsListBox.SelectedIndex >= 0) && (this.SelectedEndStationsListBox.SelectedIndex < this.m_activeAction.GetEndStations().Count)) {
                EndStationDialog esd = new EndStationDialog(this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex].EndStation);
                if (esd.ShowDialog() == DialogResult.OK) {
                    this.m_activeAction.GetEndStations().Remove(this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex]);
                    this.SelectedEndStationsListBox.Items.RemoveAt(this.SelectedEndStationsListBox.SelectedIndex);
                    EndStation es = esd.GetEndStation();
                    ASTManager.GetInstance().AddEndStation(es, false);
                    this.SelectedEndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
                    this.m_activeAction.GetEndStations().Add(new EndStationSchedule(es));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) {
                this.SelectEndStationButton.Enabled = false;
                return;
            }
            this.EditButton.Enabled = false;
            EndStation es = this.m_endStations[this.EndStationsListBox.SelectedIndex];

            this.m_activeAction.AddEndStation(new EndStationSchedule(es));
            this.SelectedEndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            this.m_endStations.Remove(es);
            this.EndStationsListBox.Items.Remove(es.Name + "(" + es.ID + ")");
            if (EndStationsListBox.Items.Count == 0) {
                this.SelectEndStationButton.Enabled = false;
                this.EditButton.Enabled = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnselectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count)) {
                this.UnselectEndStationButton.Enabled = false;
                return;
            }
            this.EditButton.Enabled = false;
            EndStationSchedule ess = this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex];
            EndStation es = ess.EndStation;

            this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            this.m_endStations.Add(es);
            this.SelectedEndStationsListBox.Items.Remove(es.Name + "(" + es.ID + ")");
            this.m_activeAction.RemoveEndStation(ess);
            if (SelectedEndStationsListBox.Items.Count == 0)
                this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count))
                this.MoveUpEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_activeAction.GetEndStations().Count - 1)))
                this.MoveDownEndStationButton.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectEndStationButton.Enabled = false;
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) return;
            this.SelectEndStationButton.Enabled = true;
            this.EditButton.Enabled = true;
            this.SelectedEndStationsListBox.ClearSelected();

            this.SetUnselectedMenuItemDetails();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedEndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count)) return;
            if (this.SelectedEndStationsListBox.SelectedIndex > 0) this.MoveUpEndStationButton.Enabled = true;
            else this.MoveUpEndStationButton.Enabled = false;
            if (this.SelectedEndStationsListBox.SelectedIndex < (this.m_activeAction.GetEndStations().Count - 1)) this.MoveDownEndStationButton.Enabled = true;
            else this.MoveDownEndStationButton.Enabled = false;
            this.UnselectEndStationButton.Enabled = true;
            this.EndStationsListBox.ClearSelected();
            this.EditButton.Enabled = true;

            this.SetSelectedMenuItemDetails();
        }
        /// <summary>
        /// 
        /// </summary>
        private void SetSelectedMenuItemDetails() {
            this.IPMenuItem.Text = "IP:  " + this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex].EndStation.IP;
            this.UsernameMenuItem.Text = "Username:  " + this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex].EndStation.Username;
            this.OSTypeMenuItem.Text = "OS Type:  " + this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex].EndStation.OSType;
        }
        /// <summary>
        /// 
        /// </summary>
        private void SetUnselectedMenuItemDetails() {
            this.IPMenuItem.Text = "IP:  " + this.m_endStations[this.EndStationsListBox.SelectedIndex].IP;
            this.UsernameMenuItem.Text = "Username:  " + this.m_endStations[this.EndStationsListBox.SelectedIndex].Username;
            this.OSTypeMenuItem.Text = "OS Type:  " + this.m_endStations[this.EndStationsListBox.SelectedIndex].OSType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveUpEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count))
                return;
            String tmp = (String)this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex] = this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex - 1];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex - 1] = tmp;
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count)) this.MoveUpEndStationButton.Enabled = false;

            EndStationSchedule ess = this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex-1];
            this.m_activeAction.GetEndStations().RemoveAt(this.SelectedEndStationsListBox.SelectedIndex-1);
            this.m_activeAction.GetEndStations().Insert(this.SelectedEndStationsListBox.SelectedIndex,this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex-1]);
            this.m_activeAction.GetEndStations().RemoveAt(this.SelectedEndStationsListBox.SelectedIndex);
            this.m_activeAction.GetEndStations().Insert(this.SelectedEndStationsListBox.SelectedIndex, ess);
            this.SelectedEndStationsListBox.SelectedIndex--;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveDownEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_activeAction.GetEndStations().Count - 1)))
                return;
            String tmp = (String)this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex] = this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex + 1];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex + 1] = tmp;
            

            EndStationSchedule ess = this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex];
            this.m_activeAction.GetEndStations().RemoveAt(this.SelectedEndStationsListBox.SelectedIndex);
            this.m_activeAction.GetEndStations().Insert(this.SelectedEndStationsListBox.SelectedIndex, this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex]);
            this.m_activeAction.GetEndStations().RemoveAt(this.SelectedEndStationsListBox.SelectedIndex+1);
            this.m_activeAction.GetEndStations().Insert(this.SelectedEndStationsListBox.SelectedIndex + 1,ess);
            this.SelectedEndStationsListBox.SelectedIndex++;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_activeAction.GetEndStations().Count - 1))) this.MoveDownEndStationButton.Enabled = false;
        }

    #endregion

    #region Parameters Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        private void SetParameters(Action a) {

            this.SelectedParametersListBox.Items.Clear();
            this.ParametersListBox.Items.Clear();
            this.m_parameters = new List<Parameter>();

            //Filling the selected parameters:
            foreach (Parameter p in a.GetParameters()) {
                this.SelectedParametersListBox.Items.Add(p.Name);
            }

            List<Parameter> allParameters = ASTManager.GetInstance().GetParameters(a.Name);

            //Filling the unselected parameters:
            foreach (Parameter p in allParameters) {
                if (!a.GetParameters().Contains(p)) {
                    this.m_parameters.Add(p);
                    this.ParametersListBox.Items.Add(p.Name);
                }
            }

            if (a.Delay == 0) {
                this.DelayNumericUpDown.Value = 10;
                this.DelayCheckBox.Checked = false;
            }
            else {
                this.DelayNumericUpDown.Value = Decimal.Parse(a.Delay.ToString());
                this.DelayCheckBox.Checked = true;
            }

            if (a.Duration == 0) {
                this.DurationNumericUpDown.Value = 10;
                this.DurationCheckBox.Checked = false;
            }
            else {
                this.DurationNumericUpDown.Value = Decimal.Parse(a.Duration.ToString());
                this.DurationCheckBox.Checked = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParametersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectParameterButton.Enabled = false;
            if ((this.ParametersListBox.SelectedIndex < 0) || (this.ParametersListBox.SelectedIndex >= this.m_parameters.Count)) return;
            this.SelectParameterButton.Enabled = true;
            this.DescriptionText.Text = this.m_parameters[this.ParametersListBox.SelectedIndex].Description;
            if (!(this.m_parameters[this.ParametersListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Input) &&
                !(this.m_parameters[this.ParametersListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Both))

                this.InputTextBox.Enabled = false;

            else this.InputTextBox.Enabled = true;

            this.InputTextBox.Text = this.m_parameters[this.ParametersListBox.SelectedIndex].Input;
            this.SelectedParametersListBox.ClearSelected();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedParametersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= ((Action)this.m_activeAction).GetParameters().Count)) return;
            if (this.SelectedParametersListBox.SelectedIndex > 0) this.MoveUpParameterButton.Enabled = true;
            else this.MoveUpParameterButton.Enabled = false;
            if (this.SelectedParametersListBox.SelectedIndex < (((Action)this.m_activeAction).GetParameters().Count - 1)) this.MoveDownParameterButton.Enabled = true;
            else this.MoveDownParameterButton.Enabled = false;
            this.UnselectParameterButton.Enabled = true;

            if (!(((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Input) &&
                !(((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Both))

                this.InputTextBox.Enabled = false;

            else this.InputTextBox.Enabled = true;

            this.InputTextBox.Text = ((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex].Input;
            this.DescriptionText.Text = ((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex].Description;
            this.ParametersListBox.ClearSelected();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnselectParameterButton_Click(object sender, EventArgs e) {
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= ((Action)this.m_activeAction).GetParameters().Count)) {
                this.UnselectParameterButton.Enabled = false;
                return;
            }

            Parameter p = ((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex];
            this.ParametersListBox.Items.Add(p.Name);
            this.m_parameters.Add(p);
            this.SelectedParametersListBox.Items.Remove(p.Name);
            ((Action)this.m_activeAction).RemoveParameter(p);
            if (SelectedParametersListBox.Items.Count == 0)
                this.UnselectParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= ((Action)this.m_activeAction).GetParameters().Count))
                this.MoveUpParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (((Action)this.m_activeAction).GetParameters().Count - 1)))
                this.MoveDownParameterButton.Enabled = false;

            this.InputTextBox.Clear();
        }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void SetParameterValue(object sender, EventArgs e) {
            
            // In case we are in the upper list box.
            System.Diagnostics.Debug.WriteLine("Up   Selected Index = " + this.ParametersListBox.SelectedIndex);
            System.Diagnostics.Debug.WriteLine("Down Selected Index = " + this.SelectedParametersListBox.SelectedIndex);
            if ((this.ParametersListBox.SelectedIndex >= 0) && (this.ParametersListBox.SelectedIndex < this.m_parameters.Count)) {
                this.m_parameters[this.ParametersListBox.SelectedIndex].Input = this.InputTextBox.Text;
            }

            // In case we are in the lower list box.
            else if ((this.SelectedParametersListBox.SelectedIndex >= 0) && (this.SelectedParametersListBox.SelectedIndex < ((Action)this.m_activeAction).GetParameters().Count)) {
                ((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex].Input = this.InputTextBox.Text;
            }
        }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void SelectParameterButton_Click(object sender, EventArgs e) {
            if ((this.ParametersListBox.SelectedIndex < 0) || (this.ParametersListBox.SelectedIndex >= this.m_parameters.Count)) {
                this.SelectParameterButton.Enabled = false;
                return;
            }
            Parameter p = this.m_parameters[this.ParametersListBox.SelectedIndex];
            p.Input = this.InputTextBox.Text;
            this.InputTextBox.Clear();

            ((Action)this.m_activeAction).AddParameter(p);
            this.SelectedParametersListBox.Items.Add(p.Name);
            this.m_parameters.Remove(p);
            this.ParametersListBox.Items.Remove(p.Name);
            if (ParametersListBox.Items.Count == 0)
                this.SelectParameterButton.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveUpParameterButton_Click(object sender, EventArgs e) {
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= ((Action)this.m_activeAction).GetParameters().Count))
                return;
            String tmp = (String)this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex] = this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex - 1];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex - 1] = tmp;
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= ((Action)this.m_activeAction).GetParameters().Count)) this.MoveUpParameterButton.Enabled = false;

            Parameter p = ((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex - 1];
            ((Action)this.m_activeAction).GetParameters().RemoveAt(this.SelectedParametersListBox.SelectedIndex - 1);
            ((Action)this.m_activeAction).GetParameters().Insert(this.SelectedParametersListBox.SelectedIndex, ((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex - 1]);
            ((Action)this.m_activeAction).GetParameters().RemoveAt(this.SelectedParametersListBox.SelectedIndex);
            ((Action)this.m_activeAction).GetParameters().Insert(this.SelectedParametersListBox.SelectedIndex, p);
            this.SelectedParametersListBox.SelectedIndex--;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveDownParameterButton_Click(object sender, EventArgs e) {
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (((Action)this.m_activeAction).GetParameters().Count - 1)))
                return;
            String tmp = (String)this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex] = this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex + 1];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex + 1] = tmp;


            Parameter p = ((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex];
            ((Action)this.m_activeAction).GetParameters().RemoveAt(this.SelectedParametersListBox.SelectedIndex);
            ((Action)this.m_activeAction).GetParameters().Insert(this.SelectedParametersListBox.SelectedIndex, ((Action)this.m_activeAction).GetParameters()[this.SelectedParametersListBox.SelectedIndex]);
            ((Action)this.m_activeAction).GetParameters().RemoveAt(this.SelectedParametersListBox.SelectedIndex + 1);
            ((Action)this.m_activeAction).GetParameters().Insert(this.SelectedParametersListBox.SelectedIndex + 1, p);
            this.SelectedParametersListBox.SelectedIndex++;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (((Action)this.m_activeAction).GetParameters().Count - 1))) this.MoveDownParameterButton.Enabled = false;
        }

    #endregion

    #region Misc Methods
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void DelayCheckBox_CheckedChanged(object sender, EventArgs e) {
            this.DelayNumericUpDown.Enabled = this.DelayCheckBox.Checked;
            if (!this.DelayCheckBox.Checked) ((Action)m_activeAction).Delay = 0;
            else ((Action)m_activeAction).Delay = (int)this.DelayNumericUpDown.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DurationCheckBox_CheckedChanged(object sender, EventArgs e) {
            this.DurationNumericUpDown.Enabled = this.DurationCheckBox.Checked;
            if (!this.DurationCheckBox.Checked) ((Action)m_activeAction).Duration = 0;
            else ((Action)m_activeAction).Duration = (int)this.DurationNumericUpDown.Value;
        }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void DelayNumericUpDown_ValueChanged(object sender, EventArgs e) {
            ((Action)m_activeAction).Delay = (int)this.DelayNumericUpDown.Value;
        }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void DurationNumericUpDown_ValueChanged(object sender, EventArgs e) {
            ((Action)m_activeAction).Duration = (int)this.DurationNumericUpDown.Value;
        }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void ReportNameCheckBox_CheckedChanged(object sender, EventArgs e) {
            this.ReportNameTextBox.Enabled = this.ReportNameCheckBox.Checked;
        }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void ExecuteButton_Click(object sender, EventArgs e) {

            //Getting report name
            if ((this.ReportNameCheckBox.Checked) && (this.ReportNameTextBox.Text.Length > 0)) m_reportName = this.ReportNameTextBox.Text;
            else if (this.ReportNameCheckBox.Checked) {
                MessageBox.Show("Invalid Report Name.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else m_reportName = this.GenerateTmpReportName();

            //Check End-Stations Selection
            bool check = false;
            String err = "The following actions has no end-station:\n\n";
            List<Action> allActions = m_rootAction.GetActions();            
            foreach (Action a in allActions)
            {
                if ((a.ActionType != Action.ActionTypeEnum.TEST_SCRIPT) && (a.GetEndStations().Count == 0)){
                    check = true;
                    err += a.Name + ".\n";
                }
            }
            if (check) {
                MessageBox.Show(err, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
        }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void MyCancelButton_Click(object sender, EventArgs e) {
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            DialogResult = DialogResult.Cancel;
        }

    #endregion     
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private String GenerateTmpReportName() {
            String reportName = this.m_rootAction.Name + " " + DateTime.Now.ToString();
            reportName = reportName.Replace(":", "-");
            reportName = reportName.Replace("\\", "-");
            reportName = reportName.Replace("/", "-");
            return reportName;
        }
        
    }
}