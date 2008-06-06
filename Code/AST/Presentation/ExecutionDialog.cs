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

namespace AST.Presentation {
    public partial class ExecutionDialog : Form {

        private Hashtable m_actionsInfo;
        private Hashtable m_TSCsInfo;
        private Hashtable m_TPsInfo;
        private List<EndStation> m_endStations;
        private List<Parameter> m_parameters;
        private AbstractAction m_activeAction;
        private AbstractAction.AbstractActionTypeEnum m_type;

        public ExecutionDialog() {
            m_activeAction = null;
            m_actionsInfo = new Hashtable();
            m_TSCsInfo = new Hashtable();
            m_TPsInfo = new Hashtable();
            InitializeComponent();
            SetAbstractActionsInfo();
        }

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

    #region Select Abstract Action

        private void ActionsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.ActionsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_actionsInfo[this.ActionsListBox.SelectedItem];
                this.TPsListBox.ClearSelected();
                this.TSCsListBox.ClearSelected();
            }
        }

        private void TSCsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.TSCsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_TSCsInfo[this.TSCsListBox.SelectedItem];
                this.ActionsListBox.ClearSelected();
                this.TPsListBox.ClearSelected();
            }
        }

        private void TPsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.TPsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_TPsInfo[this.TPsListBox.SelectedItem];
                this.ActionsListBox.ClearSelected();
                this.TSCsListBox.ClearSelected();
            }
        }

        private void ActionsListBox_OnDoubleClick(object sender, EventArgs e) {
            if (this.ActionsListBox.SelectedItem == null) return;
            m_activeAction = ASTManager.GetInstance().Load((String)this.ActionsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.ACTION);

            //Add this action the Default End-Stations
            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;
            foreach (EndStation es in endStations) {
                if (es.IsDefault) m_activeAction.AddEndStation(new EndStationSchedule(es));
            }

            //Set End-Station List Boxes
            this.SetEndStations(m_activeAction);

            //Add this action the Default Parameters
            List<Parameter> parameters = ASTManager.GetInstance().GetParameters(m_activeAction.Name);
            foreach (Parameter p in parameters) {
                if (p.IsDefault) ((Action)m_activeAction).AddParameter(p);
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
        }

        private void TSCsListBox_OnDoubleClick(object sender, EventArgs e) {
            if (this.TSCsListBox.SelectedItem == null) return;
            m_activeAction = ASTManager.GetInstance().Load((String)this.TSCsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.TSC);

            //Set End-Station List Boxes
            this.SetEndStations(m_activeAction);

            //Enable The End-Station GroupBox
            this.EndStationsGroupBox.Enabled = true;

            //Enable The Parameters GroupBox
            this.ParametersGroupBox.Enabled = false;

            m_type = AbstractAction.AbstractActionTypeEnum.TSC;

            //Set TreeView GroupBox
            this.SetTreeView();

            //Disable The TreeView GroupBox
            this.TreeViewGroupBox.Enabled = true;
        }

        private void TPsListBox_OnDoubleClick(object sender, EventArgs e) {
            if (this.TPsListBox.SelectedItem == null) return;
            m_activeAction = ASTManager.GetInstance().Load((String)this.TPsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.TP);

            //Set End-Station List Boxes
            this.SetEndStations(m_activeAction);

            //Enable The End-Station GroupBox
            this.EndStationsGroupBox.Enabled = true;

            //Enable The Parameters GroupBox
            this.ParametersGroupBox.Enabled = false;

            m_type = AbstractAction.AbstractActionTypeEnum.TP;

            //Set TreeView GroupBox
            this.SetTreeView();

            //Disable The TreeView GroupBox
            this.TreeViewGroupBox.Enabled = true;
        }

    #endregion

    #region TreeView Methods

        private void SetTreeView() {
            this.TreeView.Nodes.Clear();

            ASTNode node = new ASTNode(this.m_activeAction, m_type);
            this.TreeView.Nodes.Add(node);
        }

    #endregion

        #region End-Stations Methods

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

        private void NewEndStationButton_Click(object sender, EventArgs e) {
            EndStationDialog esd = new EndStationDialog(null);
            if (esd.ShowDialog() == DialogResult.OK) {
                EndStation es = esd.GetEndStation();
                this.m_endStations.Add(es);
                ASTManager.GetInstance().AddEndStation(es, true);
                this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            }
        }

        private void EditButton_Click(object sender, EventArgs e) {
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

        private void SelectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) {
                this.SelectEndStationButton.Enabled = false;
                return;
            }
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

        private void UnselectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count)) {
                this.UnselectEndStationButton.Enabled = false;
                return;
            }

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

        private void EndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectEndStationButton.Enabled = false;
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) return;
            this.SelectEndStationButton.Enabled = true;
            this.EditButton.Enabled = true;
            this.SelectedEndStationsListBox.ClearSelected();
        }

        private void SelectedEndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count)) return;
            if (this.SelectedEndStationsListBox.SelectedIndex > 0) this.MoveUpEndStationButton.Enabled = true;
            else this.MoveUpEndStationButton.Enabled = false;
            if (this.SelectedEndStationsListBox.SelectedIndex < (this.m_activeAction.GetEndStations().Count - 1)) this.MoveDownEndStationButton.Enabled = true;
            else this.MoveDownEndStationButton.Enabled = false;
            this.UnselectEndStationButton.Enabled = true;
            this.EndStationsListBox.ClearSelected();
            this.EditButton.Enabled = false;
        }

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
        }

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

        private void DelayCheckBox_CheckedChanged(object sender, EventArgs e) {
            this.DelayNumericUpDown.Enabled = this.DelayCheckBox.Checked;
            if (!this.DelayCheckBox.Checked) ((Action)m_activeAction).Delay = 0;
        }

        private void DurationCheckBox_CheckedChanged(object sender, EventArgs e) {
            this.DurationNumericUpDown.Enabled = this.DurationCheckBox.Checked;
            if (!this.DurationCheckBox.Checked) ((Action)m_activeAction).Duration = 0;
        }

        private void DelayNumericUpDown_ValueChanged(object sender, EventArgs e) {
            ((Action)m_activeAction).Delay = (int)this.DelayNumericUpDown.Value;
        }

        private void DurationNumericUpDown_ValueChanged(object sender, EventArgs e) {
            ((Action)m_activeAction).Duration = (int)this.DurationNumericUpDown.Value;
        }

    #endregion

    }
}