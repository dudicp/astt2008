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

        public CreateAdditionalActionPanel(Action a){
            m_action = a;
            InitializeComponent();
            if (a != null) {
                Title.Text = "Edit Additional Action";
                SetActionAttributes();
            }
            else {
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
            List<Parameter> parameters = m_action.GetParameters();
            String[] names = new String[parameters.Count];
            for (int i = 0; i < names.Length; i++)
                names[i] = parameters[i].Name;
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
            m_action.RemoveParameter(m_action.GetParameters()[paramIndex]);
            SetActionParameters(paramIndex);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            if (browse.ShowDialog() == DialogResult.OK)
                ContentText.Text = browse.FileName;
        }

        private void EditParameterButton_Click(object sender, EventArgs e)
        {
            EditParametersDialog ed = new EditParametersDialog(m_action.GetParameters()[ParametersComboBox.SelectedIndex]);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                m_action.AddParameter(ed.GetParameter());
                SetActionParameters(ParametersComboBox.SelectedIndex);
            }
        }

        private void NewParameterButton_Click(object sender, EventArgs e){
            EditParametersDialog ed = new EditParametersDialog(null);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                m_action.AddParameter(ed.GetParameter());
                SetActionParameters(0);
            }
        }

        private void CommandLineRadio_CheckedChanged(object sender, EventArgs e){
            ContentLabel.Text = "Command Line:";
        }

        private void ScriptRadio_CheckedChanged(object sender, EventArgs e){
            ContentLabel.Text = "Script Filename:";
        }

        private void TestScriptRadio_CheckedChanged(object sender, EventArgs e){
            ContentLabel.Text = "Script Filename:";
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
            ASTManager.GetInstance().Save(this.m_action, AbstractAction.AbstractActionTypeEnum.ACTION);
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

