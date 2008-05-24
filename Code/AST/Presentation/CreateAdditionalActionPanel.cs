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

    public partial class CreateAdditionalActionPanel : AST.Presentation.ASTPanel{

        private Action m_action;
        private List<Parameter> m_parameters;
        private List<Parameter> m_changedParameters;
        private List<Parameter> m_removedParameters;

        public CreateAdditionalActionPanel(Action a){
            m_action = a;
            m_changedParameters = new List<Parameter>();
            m_removedParameters = new List<Parameter>();
            InitializeComponent();
            if (a != null) {
                this.m_parameters = ASTManager.GetInstance().GetParameters(this.m_action.Name);
                Title.Text = "Edit Additional Action";
                SetActionAttributes();
            }
            else {
                this.m_parameters = new List<Parameter>();
                this.m_action = new Action("", "", 0, "", DateTime.Now, 0, Action.ActionTypeEnum.COMMAND_LINE, 0);
                Title.Text = "Create Additional Action";
            }
        }

        private void SetActionAttributes(){
            SetActionDetails();
            OScomboBox.SelectedIndex = 0;
            SetActionContent(OScomboBox.SelectedIndex);
            SetActionParameters(0);
        }

        private void SetActionDetails(){
            ActionNameText.Text = m_action.Name;
            ActionNameText.Enabled = false;
            CreatorNameText.Text = m_action.CreatorName;
            switch (m_action.ActionType){
                case Action.ActionTypeEnum.COMMAND_LINE:{
                        CommandLineRadio.Checked = true;
                        ContentLabel.Text = "Command Line:";
                        break;
                    }
                case Action.ActionTypeEnum.SCRIPT:{
                        ScriptRadio.Checked = true;
                        ContentLabel.Text = "Script Filename:";
                        break;
                    }
                case Action.ActionTypeEnum.TEST_SCRIPT:{
                        TestScriptRadio.Checked = true;
                        ContentLabel.Text = "Script Filename:";
                        break;
                    }
            }
            DescriptionText.Text = m_action.Description;
        }

        private void SetActionContent(int OSTypeSelection){
            EndStation.OSTypeEnum OSType = ConvertSelectionToOSType(OSTypeSelection);
            ContentText.Text = m_action.GetContent(OSType);
            ValidityText.Text = m_action.GetValidityString(OSType);
            if (ValidityText.Text.Length > 0) ValidityCheckBox.Checked = true;
            else ValidityCheckBox.Checked = false;
            TimeoutText.Value = m_action.Timeout;
        }

        private void SetActionParameters(int selectedIndex)
        {
            String[] names = new String[this.m_parameters.Count];
            for (int i = 0; i < names.Length; i++)
                names[i] = this.m_parameters[i].Name;
            ParametersComboBox.Items.Clear();
            ParametersComboBox.Items.AddRange(names);
            if (names.Length != 0)
            {
                ParametersComboBox.Enabled = true;
                RemoveParameterButton.Enabled = true;
                EditParameterButton.Enabled = true;
                ParametersComboBox.SelectedIndex = selectedIndex;
            }
            else
            {
                ParametersComboBox.Enabled = false;
                RemoveParameterButton.Enabled = false;
                EditParameterButton.Enabled = false;
            }
        }
        public static EndStation.OSTypeEnum ConvertSelectionToOSType(int selection)
        {
            switch (selection)
            {
                case 0: // Windows
                    {
                        return EndStation.OSTypeEnum.WINDOWS;
                    }
                case 1: // Unix
                    {
                        return EndStation.OSTypeEnum.UNIX;
                    }
                default:
                    {
                        return EndStation.OSTypeEnum.UNKNOWN;
                    }
            }
        }

        private void OScomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActionContent(OScomboBox.SelectedIndex);
        }

        private void SaveOSButton_Click(object sender, EventArgs e)
        {
            EndStation.OSTypeEnum OSType = ConvertSelectionToOSType(OScomboBox.SelectedIndex);
            m_action.AddContent(OSType,ContentText.Text);
            m_action.Timeout = (int)TimeoutText.Value;
            if (ValidityCheckBox.Checked) m_action.AddValidityString(OSType, ValidityText.Text);
        }

        private void RemoveOSButton_Click(object sender, EventArgs e)
        {
            EndStation.OSTypeEnum OSType = ConvertSelectionToOSType(OScomboBox.SelectedIndex);
            m_action.RemoveContent(OSType);
            m_action.RemoveValidityString(OSType);
            SetActionContent(OScomboBox.SelectedIndex);
        }

        private void RemoveParameterButton_Click(object sender, EventArgs e)
        {
            int paramIndex = ParametersComboBox.SelectedIndex;
            this.m_removedParameters.Add(this.m_parameters[paramIndex]); //Added to the remove parameters
            this.m_parameters.Remove(this.m_parameters[paramIndex]); //Removed from screen
            SetActionParameters(0);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            if (browse.ShowDialog() == DialogResult.OK)
                ContentText.Text = browse.FileName;
        }

        private void EditParameterButton_Click(object sender, EventArgs e)
        {
            EditParametersDialog ed = new EditParametersDialog(this.m_parameters[ParametersComboBox.SelectedIndex]);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                this.m_parameters[ParametersComboBox.SelectedIndex] = ed.GetParameter();
                this.m_changedParameters.Add(ed.GetParameter());//Added to the changed parameters
                SetActionParameters(ParametersComboBox.SelectedIndex);
            }
        }

        private void NewParameterButton_Click(object sender, EventArgs e){
            EditParametersDialog ed = new EditParametersDialog(null);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                this.m_parameters.Add(ed.GetParameter());
                this.m_changedParameters.Add(ed.GetParameter());//Added to the changed parameters
                SetActionParameters(0);
            }
        }

        private void CommandLineRadio_CheckedChanged(object sender, EventArgs e){
            ContentLabel.Text = "Command Line:";
            BrowseButton.Enabled = false;
        }

        private void ScriptRadio_CheckedChanged(object sender, EventArgs e){
            ContentLabel.Text = "Script Filename:";
            BrowseButton.Enabled = true;
        }

        private void TestScriptRadio_CheckedChanged(object sender, EventArgs e){
            ContentLabel.Text = "Script Filename:";
            BrowseButton.Enabled = true;
        }

        private void okButton_Click(object sender, EventArgs e){
            //Save the action
            if (!this.CheckForm()) return;
            this.m_action.Name = this.ActionNameText.Text;
            this.m_action.CreatorName = this.CreatorNameText.Text;
            
            if (this.CommandLineRadio.Checked) this.m_action.ActionType = Action.ActionTypeEnum.COMMAND_LINE;
            else if (this.ScriptRadio.Checked) this.m_action.ActionType = Action.ActionTypeEnum.SCRIPT;
            else if (this.TestScriptRadio.Checked) this.m_action.ActionType = Action.ActionTypeEnum.TEST_SCRIPT;

            this.m_action.Description = this.DescriptionText.Text;
            ASTManager.GetInstance().Save(this.m_action, AbstractAction.AbstractActionTypeEnum.ACTION);//Save Action Created/Modified

            foreach (Parameter p in this.m_changedParameters)
                ASTManager.GetInstance().Save(p,this.m_action);//Save Parameters Created/Modified

            foreach (Parameter p in this.m_removedParameters)
                ASTManager.GetInstance().Delete(p, this.m_action);//Delete Parameters Removed

            ASTManager.GetInstance().DisplayWelcomeScreen();
        }

        private void MyCancelButton_Click(object sender, EventArgs e){
            //Return to the welcome screen
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            
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
            if (!res) MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return res;
        }
    }
}
