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
    public partial class SettingsDialog : Form {


        private AbstractAction m_action;
        private AbstractAction.AbstractActionTypeEnum m_type;
        private List<Parameter> m_parameters;
        private List<Parameter> m_selectedParameters;
        private List<EndStation> m_endStations;
        private List<EndStation> m_selectedEndStations;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="type"></param>
        public SettingsDialog(AbstractAction a, AbstractAction.AbstractActionTypeEnum type) {
            this.m_action = a;
            this.m_type = type;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (m_type != AbstractAction.AbstractActionTypeEnum.ACTION) {
                this.tabControl.Controls.Remove(this.EditParametersTab);
            }

            if (m_type != AbstractAction.AbstractActionTypeEnum.ACTION)
                this.tabControl.Controls.Remove(this.MiscTab);
            
            else {
                InitEditParametersTab();
                InitMiscTab();
            }
            
            if(m_type == AbstractAction.AbstractActionTypeEnum.ACTION && ((Action)a).ActionType == Action.ActionTypeEnum.TEST_SCRIPT)
                this.tabControl.Controls.Remove(this.EditEndStationTab);
            
            else InitEditEndStationTab();
        }

////////////////////////////////////////
//  Edit Parameters Tab
////////////////////////////////////////

        private void InitEditParametersTab() {

            this.Title1.Text = "Edit Parameters - " + this.m_action.Name;


            this.m_parameters = new List<Parameter>();
            this.m_selectedParameters = new List<Parameter>();

            //Filling the selected parameters:
            foreach (Parameter p in ((Action)this.m_action).GetParameters()){
                this.m_selectedParameters.Add(p);
                this.SelectedParametersListBox.Items.Add(p.Name);
            }

            List<Parameter> allParameters = null;

            try {
                allParameters = ASTManager.GetInstance().GetParameters(this.m_action.Name);
            }
            catch (ConnectionFailedException ex) { DialogResult = DialogResult.Cancel; }
            catch (Exception ex) { DialogResult = DialogResult.Cancel; }

            //Filling the unselected parameters:
            foreach (Parameter p in allParameters) {
                if (!this.m_selectedParameters.Contains(p)) {
                    this.m_parameters.Add(p);
                    this.ParameterListBox.Items.Add(p.Name);
                }
            }   
        }

        private void ParameterListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectParameterButton.Enabled = false;
            if ((this.ParameterListBox.SelectedIndex < 0) || (this.ParameterListBox.SelectedIndex >= this.m_parameters.Count)) return;
            this.SelectedParametersListBox.ClearSelected();
            this.SelectParameterButton.Enabled = true;
            this.DescriptionText.Text = this.m_parameters[this.ParameterListBox.SelectedIndex].Description;
            if (!(this.m_parameters[this.ParameterListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Input) &&
                !(this.m_parameters[this.ParameterListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Both))

                this.InputTextBox.Enabled = false;

            else this.InputTextBox.Enabled = true;

            this.InputTextBox.Text = this.m_parameters[this.ParameterListBox.SelectedIndex].Input;
        }

        private void SelectedParametersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count)) return;
            this.ParameterListBox.ClearSelected();
            if (this.SelectedParametersListBox.SelectedIndex > 0) this.MoveUpParameterButton.Enabled = true;
            else this.MoveUpParameterButton.Enabled = false;
            if (this.SelectedParametersListBox.SelectedIndex < (this.m_selectedParameters.Count - 1)) this.MoveDownParameterButton.Enabled = true;
            else this.MoveDownParameterButton.Enabled = false;
            this.UnselectParameterButton.Enabled = true;

            if (!(this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Input) &&
                !(this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Both))

                this.InputTextBox.Enabled = false;

            else this.InputTextBox.Enabled = true;

            this.InputTextBox.Text = this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex].Input;
            this.DescriptionText.Text = this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex].Description;
        }

        private void SelectParameterButton_Click(object sender, EventArgs e) {
            if ((this.ParameterListBox.SelectedIndex < 0) || (this.ParameterListBox.SelectedIndex >= this.m_parameters.Count)) {
                this.SelectParameterButton.Enabled = false;
                return;
            }
            Parameter p = this.m_parameters[this.ParameterListBox.SelectedIndex];
            p.Input = this.InputTextBox.Text;
            this.InputTextBox.Clear();

            this.m_selectedParameters.Add(p);
            this.SelectedParametersListBox.Items.Add(p.Name);
            this.m_parameters.Remove(p);
            this.ParameterListBox.Items.Remove(p.Name);
            if (ParameterListBox.Items.Count == 0)
                this.SelectParameterButton.Enabled = false;
        }

        private void UnselectParameterButton_Click(object sender, EventArgs e) {
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count)) {
                this.UnselectParameterButton.Enabled = false;
                return;
            }

            Parameter p = this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex];
            this.ParameterListBox.Items.Add(p.Name);
            this.m_parameters.Add(p);
            this.SelectedParametersListBox.Items.Remove(p.Name);
            this.m_selectedParameters.Remove(p);
            if (SelectedParametersListBox.Items.Count == 0)
                this.UnselectParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count))
                this.MoveUpParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (this.m_selectedParameters.Count - 1)))
                this.MoveDownParameterButton.Enabled = false;

            this.InputTextBox.Clear();
        }

        private void MoveUpParameterButton_Click(object sender, EventArgs e) {
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count))
                return;
            String tmp = (String)this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex] = this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex - 1];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex - 1] = tmp;
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count)) this.MoveUpParameterButton.Enabled = false;

            Parameter ptmp = this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex];
            this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex] = this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex - 1];
            this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex - 1] = ptmp;
        }

        private void MoveDownParameterButton_Click(object sender, EventArgs e) {
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (this.m_selectedParameters.Count - 1)))
                return;
            String tmp = (String)this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex] = this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex + 1];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex + 1] = tmp;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (this.m_selectedParameters.Count - 1))) this.MoveDownParameterButton.Enabled = false;

            Parameter ptmp = this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex];
            this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex] = this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex + 1];
            this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex + 1] = ptmp;
        }

////////////////////////////////////////
//  Edit End-Stations Tab
////////////////////////////////////////

        private void InitEditEndStationTab() {

            this.Title2.Text = "Edit End-Stations - " + this.m_action.Name;

            this.m_endStations = new List<EndStation>();
            this.m_selectedEndStations = new List<EndStation>();
            this.EndStationsListBox.Items.Clear();

            //Filling the selected end-stations:
            List<EndStationSchedule> endStationInAction = this.m_action.GetEndStations();
            foreach (EndStationSchedule ess in endStationInAction) {
                this.m_selectedEndStations.Add(ess.EndStation);
                this.SelectedEndStationsListBox.Items.Add(ess.EndStation.Name + "(" + ess.EndStation.ID + ")");
            }

            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;

            //Filling the unselected end-stations:
            foreach (EndStation es in endStations) {
                if (!this.m_selectedEndStations.Contains(es)) {
                    this.m_endStations.Add(es);
                    this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
                }
            }
        }

        private void SelectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) {
                this.SelectEndStationButton.Enabled = false;
                return;
            }
            EndStation es = this.m_endStations[this.EndStationsListBox.SelectedIndex];

            this.m_selectedEndStations.Add(es);
            this.SelectedEndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            this.m_endStations.Remove(es);
            this.EndStationsListBox.Items.Remove(es.Name + "(" + es.ID + ")");
            this.SelectEndStationButton.Enabled = false;
            this.EditButton.Enabled = false;
            this.DeleteButton.Enabled = false;

        }

        private void UnselectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count)) {
                this.UnselectEndStationButton.Enabled = false;
                return;
            }

            EndStation es = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex];
            this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            this.m_endStations.Add(es);
            this.SelectedEndStationsListBox.Items.Remove(es.Name + "(" + es.ID + ")");
            this.m_selectedEndStations.Remove(es);
            if (SelectedEndStationsListBox.Items.Count == 0)
                this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count))
                this.MoveUpEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_selectedEndStations.Count - 1)))
                this.MoveDownEndStationButton.Enabled = false;
        }

        private void MoveUpEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count))
                return;
            String tmp = (String)this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex] = this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex - 1];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex - 1] = tmp;
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count)) this.MoveUpEndStationButton.Enabled = false;

            EndStation estmp = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex];
            this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex] = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex - 1];
            this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex - 1] = estmp;
        }

        private void MoveDownEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_selectedEndStations.Count - 1)))
                return;
            String tmp = (String)this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex] = this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex + 1];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex + 1] = tmp;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_selectedEndStations.Count - 1))) this.MoveDownEndStationButton.Enabled = false;

            EndStation estmp = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex];
            this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex] = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex + 1];
            this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex + 1] = estmp;
        }

        private void EndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectEndStationButton.Enabled = false;
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) return;
            this.SelectedEndStationsListBox.ClearSelected();
            this.SelectEndStationButton.Enabled = true;
            this.EditButton.Enabled = true;
            this.DeleteButton.Enabled = true;
        }

        private void SelectedEndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count)) return;
            this.EndStationsListBox.ClearSelected();
            if (this.SelectedEndStationsListBox.SelectedIndex > 0) this.MoveUpEndStationButton.Enabled = true;
            else this.MoveUpEndStationButton.Enabled = false;
            if (this.SelectedEndStationsListBox.SelectedIndex < (this.m_selectedEndStations.Count - 1)) this.MoveDownEndStationButton.Enabled = true;
            else this.MoveDownEndStationButton.Enabled = false;
            this.UnselectEndStationButton.Enabled = true;
        }

        private void NewEndStationButton_Click(object sender, EventArgs e) {
            try {
                EndStationDialog esd = new EndStationDialog(null);
                if (esd.ShowDialog() == DialogResult.OK) {
                    EndStation es = esd.GetEndStation();
                    ASTManager.GetInstance().AddEndStation(es, true);
                    this.m_endStations.Add(es);
                    this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
                }
            }
            catch (Exception ex) { /*the message displayed and the end-station won't be added.*/ }
        }

        private void EditButton_Click(object sender, EventArgs e) {
            try {
                EndStationDialog esd = null;
                if (this.EndStationsListBox.SelectedItem != null) esd = new EndStationDialog(this.m_endStations[this.EndStationsListBox.SelectedIndex]);
                else if (this.SelectedEndStationsListBox.SelectedItem != null) esd = new EndStationDialog(this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex]);
                else return;
                if (esd.ShowDialog() == DialogResult.OK) {
                    EndStation es = esd.GetEndStation();
                    ASTManager.GetInstance().AddEndStation(es, false);
                    InitEditEndStationTab();
                    this.EditButton.Enabled = false;
                    this.DeleteButton.Enabled = false;
                }
            }
            catch (Exception ex) { /*the message displayed and the end-station won't be added.*/ }
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            try {            
                EndStation es = null;
                if (this.EndStationsListBox.SelectedItem != null) es = m_endStations[this.EndStationsListBox.SelectedIndex];
                else if (this.SelectedEndStationsListBox.SelectedItem != null) es = m_endStations[this.SelectedEndStationsListBox.SelectedIndex];
                else return;

                DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;

                ASTManager.GetInstance().RemoveEndStation(es);
                this.EndStationsListBox.Items.RemoveAt(this.EndStationsListBox.SelectedIndex);
                InitEditEndStationTab();
                this.EditButton.Enabled = false;
                this.DeleteButton.Enabled = false;
            }
            catch (Exception ex) { /*the message displayed and the end-station won't be added.*/ }
        }

        private void okButton_Click(object sender, EventArgs e) {
            //1. Updating abstract action's end-stations

            if ((m_type != AbstractAction.AbstractActionTypeEnum.ACTION)||((m_type == AbstractAction.AbstractActionTypeEnum.ACTION && ((Action)this.m_action).ActionType != Action.ActionTypeEnum.TEST_SCRIPT))) {
                this.m_action.ClearEndStations();
                for (int i = 0; i < this.m_selectedEndStations.Count; i++)
                    this.m_action.AddEndStation(new EndStationSchedule(this.m_selectedEndStations[i]));
            }

            if (m_type == AbstractAction.AbstractActionTypeEnum.ACTION && ((Action)this.m_action).ActionType != Action.ActionTypeEnum.BATCH_FILE) {

                //2. Updating action's parameters
                ((Action)this.m_action).ClearParameters();

                for (int i = 0; i < this.m_selectedParameters.Count; i++)
                    ((Action)this.m_action).AddParameter(this.m_selectedParameters[i]);

            }

            if (m_type == AbstractAction.AbstractActionTypeEnum.ACTION){
                //3. Update Misc
                if (this.DelayCheckBox.Checked)
                    ((Action)this.m_action).Delay = (int)this.DelayNumericUpDown.Value;
                else ((Action)this.m_action).Delay = 0;

                if (this.DurationCheckBox.Checked)
                    ((Action)this.m_action).Duration = (int)this.DurationNumericUpDown.Value;
                else ((Action)this.m_action).Duration = 0;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void MyCancelButton_Click(object sender, EventArgs e) {

            this.DialogResult = DialogResult.Cancel;
        }

////////////////////////////////////////
//  Edit Misc Tab
////////////////////////////////////////

        private void InitMiscTab() {

            this.Title3.Text = "Misc - " + this.m_action.Name;

            if (m_type == AbstractAction.AbstractActionTypeEnum.ACTION && ((Action)m_action).ActionType == Action.ActionTypeEnum.TEST_SCRIPT)
                this.DurationCheckBox.Enabled = false;
            else this.DurationCheckBox.Enabled = true;

            if (((Action)this.m_action).Delay != 0) {
                this.DelayCheckBox.Checked = true;
                this.DelayNumericUpDown.Value = ((Action)this.m_action).Delay;
            }

            if (((Action)(this.m_action)).Duration != 0) {
                this.DurationCheckBox.Checked = true;
                this.DurationNumericUpDown.Value = ((Action)(this.m_action)).Duration;
            }
        }

        private void DelayCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (this.DelayCheckBox.Checked) this.DelayNumericUpDown.Enabled = true;
            else {
                this.DelayNumericUpDown.Enabled = false;
                //((Action)m_action).Delay = 0;
            }
        }

        private void DurationCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (this.DurationCheckBox.Checked) this.DurationNumericUpDown.Enabled = true;
            else {
                this.DurationNumericUpDown.Enabled = false;
                //((Action)m_action).Duration = 0;
            }
        }

        private void SetParameterValue(object sender, EventArgs e) {

            // In case we are in the upper list box.
            if (this.ParameterListBox.SelectedItem != null) {
                this.m_parameters[this.ParameterListBox.SelectedIndex].Input = this.InputTextBox.Text;
            }

            // In case we are in the lower list box.
            else if (this.SelectedParametersListBox.SelectedItem != null) {
                this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex].Input = this.InputTextBox.Text;
            }
        }
    }
}