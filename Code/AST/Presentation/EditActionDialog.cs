using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Domain;
using AST.Management;

namespace AST.Presentation {
    
    public partial class EditActionDialog : Form {

        private Action m_action;
        private List<Parameter> m_parameters;
        private List<Parameter> m_selectedParameters;
        private List<EndStation> m_endStations;
        private List<EndStation> m_selectedEndStations;
        
        public EditActionDialog(Action a) {
            this.m_action = a;
            InitializeComponent();
            Init();
        }

        private void Init() {
            this.SetActionDetails();
            this.SetEndStationsDetails();
        }

        private void SetActionDetails(){
            this.m_parameters = ASTManager.GetInstance().GetParameters(this.m_action.Name);
            this.m_selectedParameters = new List<Parameter>();
            foreach (Parameter p in this.m_parameters)
                this.ParameterListBox.Items.Add(p.Name);
        }

        private void SetEndStationsDetails() {
            Hashtable endStations = ASTManager.GetInstance().GetEndStations();
            this.m_endStations = new List<EndStation>();
            this.m_selectedEndStations = new List<EndStation>();
            ICollection names = endStations.Keys;
            foreach (String name in names) {
                this.m_endStations.Add((EndStation)endStations[name]);
                this.EndStationsListBox.Items.Add(name);
            }
        }

        private void ParameterListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectParameterButton.Enabled = false;
            if ((this.ParameterListBox.SelectedIndex < 0) || (this.ParameterListBox.SelectedIndex >= this.m_parameters.Count)) return;
            this.SelectParameterButton.Enabled = true;
            this.DescriptionText.Text = this.m_parameters[this.ParameterListBox.SelectedIndex].Description;
            if (!(this.m_parameters[this.ParameterListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Input) &&
                !(this.m_parameters[this.ParameterListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Both))

                this.InputTextBox.Enabled = false;
        }

        private void SelectedParametersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count)) return;
            if (this.SelectedParametersListBox.SelectedIndex > 0) this.MoveUpParameterButton.Enabled = true;
            else this.MoveUpParameterButton.Enabled = false;
            if (this.SelectedParametersListBox.SelectedIndex < (this.m_selectedParameters.Count-1)) this.MoveDownParameterButton.Enabled = true;
            else this.MoveDownParameterButton.Enabled = false;
            this.UnselectParameterButton.Enabled = true;
            this.DescriptionText.Text = this.m_selectedParameters[this.SelectedParametersListBox.SelectedIndex].Description;
        }

        private void SelectParameterButton_Click(object sender, EventArgs e) {
            if ((this.ParameterListBox.SelectedIndex < 0) || (this.ParameterListBox.SelectedIndex >= this.m_parameters.Count)) {
                this.SelectParameterButton.Enabled = false;
                return;
            }
            Parameter p = this.m_parameters[this.ParameterListBox.SelectedIndex];
            p.Input = this.InputTextBox.Text;
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
                this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count))
                this.MoveUpParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (this.m_selectedParameters.Count-1)))
                this.MoveDownParameterButton.Enabled = false;

        }

        private void NewEndStationButton_Click(object sender, EventArgs e) {
            EndStationDialog esd = new EndStationDialog(null);
            if (esd.ShowDialog() == DialogResult.OK) {
                EndStation es = esd.GetEndStation();
                this.m_endStations.Add(es);
                ASTManager.GetInstance().AddEndStation(es);
                this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            }
        }

        private void MoveUpParameterButton_Click(object sender, EventArgs e) {
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count))
                return;
            String tmp = (String)this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex] = this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex - 1];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex - 1] = tmp;
            if ((this.SelectedParametersListBox.SelectedIndex <= 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count)) this.MoveUpParameterButton.Enabled = false;
        }

        private void MoveDownParameterButton_Click(object sender, EventArgs e) {
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (this.m_selectedParameters.Count-1)))
                return;
            String tmp = (String)this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex] = this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex + 1];
            this.SelectedParametersListBox.Items[this.SelectedParametersListBox.SelectedIndex + 1] = tmp;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (this.m_selectedParameters.Count-1))) this.MoveDownParameterButton.Enabled = false;
        }

        private void MyCancelButton_Click(object sender, EventArgs e) {
            //Return to Execution Screen
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e) {
            //Return to Execution Screen
            this.DialogResult = DialogResult.OK;
        }

    }
}
