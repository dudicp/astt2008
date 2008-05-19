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
        
        public EditActionDialog(Action a) {
            this.m_action = a;
            InitializeComponent();
            Init();
        }

        private void Init() {

            this.m_parameters = new List<Parameter>();
            this.m_selectedParameters = this.m_action.GetParameters();
            List<Parameter> allParameters = ASTManager.GetInstance().GetParameters(this.m_action.Name);

            //Filling the unselected parameters:
            foreach (Parameter p in allParameters) {
                if (!this.m_selectedParameters.Contains(p)) {
                    this.m_parameters.Add(p);
                    this.ParameterListBox.Items.Add(p.Name);
                }
            }
            //Filling the selected parameters:
            foreach (Parameter p in this.m_selectedParameters)
                this.SelectedParametersListBox.Items.Add(p.Name);
        }

        private void ParameterListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectParameterButton.Enabled = false;
            if ((this.ParameterListBox.SelectedIndex < 0) || (this.ParameterListBox.SelectedIndex >= this.m_parameters.Count)) return;
            this.SelectParameterButton.Enabled = true;
            this.DescriptionText.Text = this.m_parameters[this.ParameterListBox.SelectedIndex].Description;
            if (!(this.m_parameters[this.ParameterListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Input) &&
                !(this.m_parameters[this.ParameterListBox.SelectedIndex].Type == Parameter.ParameterTypeEnum.Both))

                this.InputTextBox.Enabled = false;

            else this.InputTextBox.Enabled = true;
            
            this.InputTextBox.Clear();
        }

        private void SelectedParametersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectParameterButton.Enabled = false;
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= this.m_selectedParameters.Count)) return;
            if (this.SelectedParametersListBox.SelectedIndex > 0) this.MoveUpParameterButton.Enabled = true;
            else this.MoveUpParameterButton.Enabled = false;
            if (this.SelectedParametersListBox.SelectedIndex < (this.m_selectedParameters.Count-1)) this.MoveDownParameterButton.Enabled = true;
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
            if ((this.SelectedParametersListBox.SelectedIndex < 0) || (this.SelectedParametersListBox.SelectedIndex >= (this.m_selectedParameters.Count-1)))
                this.MoveDownParameterButton.Enabled = false;

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

        private void MyCancelButton_Click(object sender, EventArgs e) {
            //Return to Execution Screen
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e) {
            //Updating action's parameters

            this.m_action.ClearParameters();

            for (int i = 0; i < this.m_selectedParameters.Count; i++)
                this.m_action.AddParameter(this.m_selectedParameters[i]);

            this.DialogResult = DialogResult.OK;
        }
    }
}
