using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Domain;
using AST.Management;

namespace AST.Presentation {
    public partial class CreateAdditionalActionDialog : Form {

        private Action m_action;
        private List<Parameter> m_parameters;
        private List<Parameter> m_newParameters;
        private List<Parameter> m_changedParameters;
        private List<Parameter> m_removedParameters;
        private bool m_isNew;

/// <summary>
/// 
/// </summary>
/// <param name="a"></param>
        public CreateAdditionalActionDialog(Action a)
        {
            m_action = a;
            m_isNew = false;
            m_newParameters = new List<Parameter>();
            m_changedParameters = new List<Parameter>();
            m_removedParameters = new List<Parameter>();
            InitializeComponent();
            if (a != null)
            {
                this.m_action.CreationTime = DateTime.Now;
                this.m_parameters = ASTManager.GetInstance().GetParameters(this.m_action.Name);
                Title.Text = "Edit Additional Action";
                SetActionAttributes();
            }
            else
            {
                m_isNew = true;
                this.m_parameters = new List<Parameter>();
                this.m_action = new Action("", "", 0, "", DateTime.Now, 0, Action.ActionTypeEnum.COMMAND_LINE, 0);
                Title.Text = "Create Additional Action";
            }
        }
/// <summary>
/// 
/// </summary>
        private void SetActionAttributes()
        {
            SetActionDetails();
            OScomboBox.SelectedIndex = 0;
            SetActionContent(OScomboBox.SelectedIndex);
            SetActionParameters(0);
        }
/// <summary>
/// 
/// </summary>
        private void SetActionDetails()
        {
            ActionNameText.Text = m_action.Name;
            ActionNameText.Enabled = false;
            CreatorNameText.Text = m_action.CreatorName;
            switch (m_action.ActionType)
            {
                case Action.ActionTypeEnum.COMMAND_LINE:
                    {
                        CommandLineRadio.Checked = true;
                        ContentLabel.Text = "Command Line:";
                        break;
                    }
                case Action.ActionTypeEnum.SCRIPT:
                    {
                        ScriptRadio.Checked = true;
                        ContentLabel.Text = "Script Filename:";
                        break;
                    }
                case Action.ActionTypeEnum.TEST_SCRIPT:
                    {
                        TestScriptRadio.Checked = true;
                        ContentLabel.Text = "Script Filename:";
                        break;
                    }
            }
            DescriptionText.Text = m_action.Description;
        }
/// <summary>
/// 
/// </summary>
/// <param name="OSTypeSelection"></param>
        private void SetActionContent(int OSTypeSelection)
        {
            EndStation.OSTypeEnum OSType = ConvertSelectionToOSType(OSTypeSelection);
            ContentText.Text = m_action.GetContent(OSType);
            ValidityText.Text = m_action.GetValidityString(OSType);
            if (ValidityText.Text.Length > 0) ValidityCheckBox.Checked = true;
            else ValidityCheckBox.Checked = false;
            TimeoutText.Value = m_action.Timeout;
        }
/// <summary>
/// 
/// </summary>
/// <param name="selectedIndex"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OScomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActionContent(OScomboBox.SelectedIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveParameterButton_Click(object sender, EventArgs e)
        {
            if (this.ParametersComboBox.SelectedItem == null) return;
            int paramIndex = ParametersComboBox.SelectedIndex;
            this.m_removedParameters.Add(this.m_parameters[paramIndex]); //Added to the remove parameters
            this.m_parameters.Remove(this.m_parameters[paramIndex]); //Removed from screen
            SetActionParameters(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            if (browse.ShowDialog() == DialogResult.OK)
                ContentText.Text = browse.FileName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditParameterButton_Click(object sender, EventArgs e)
        {
            if (this.ParametersComboBox.SelectedItem == null) return;
            EditParametersDialog ed = new EditParametersDialog(this.m_parameters[ParametersComboBox.SelectedIndex]);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                this.m_parameters[ParametersComboBox.SelectedIndex] = ed.GetParameter();
                this.m_changedParameters.Add(ed.GetParameter());//Added to the changed parameters
                SetActionParameters(ParametersComboBox.SelectedIndex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewParameterButton_Click(object sender, EventArgs e)
        {
            EditParametersDialog ed = new EditParametersDialog(null);
            if (ed.ShowDialog() == DialogResult.OK)
            {
                this.m_parameters.Add(ed.GetParameter());
                this.m_newParameters.Add(ed.GetParameter());//Added to the changed parameters
                SetActionParameters(0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandLineRadio_CheckedChanged(object sender, EventArgs e)
        {
            ContentLabel.Text = "Command Line:";
            BrowseButton.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScriptRadio_CheckedChanged(object sender, EventArgs e)
        {
            ContentLabel.Text = "Script Filename:";
            BrowseButton.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestScriptRadio_CheckedChanged(object sender, EventArgs e)
        {
            ContentLabel.Text = "Script Filename:";
            BrowseButton.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            //Save the action
            if (!this.CheckForm()) return;
            this.m_action.Name = this.ActionNameText.Text;
            this.m_action.CreatorName = this.CreatorNameText.Text;

            if (this.CommandLineRadio.Checked) this.m_action.ActionType = Action.ActionTypeEnum.COMMAND_LINE;
            else if (this.ScriptRadio.Checked) this.m_action.ActionType = Action.ActionTypeEnum.SCRIPT;
            else if (this.TestScriptRadio.Checked) this.m_action.ActionType = Action.ActionTypeEnum.TEST_SCRIPT;

            this.m_action.Description = this.DescriptionText.Text;
            ASTManager.GetInstance().Save(this.m_action, AbstractAction.AbstractActionTypeEnum.ACTION, m_isNew);//Save Action Created/Modified

            foreach (Parameter p in this.m_newParameters)
                ASTManager.GetInstance().Save(p, this.m_action, true);//Save New Parameters Created

            foreach (Parameter p in this.m_changedParameters)
                ASTManager.GetInstance().Save(p, this.m_action, false);//Save Parameters Modified

            foreach (Parameter p in this.m_removedParameters)
                ASTManager.GetInstance().Delete(p, this.m_action);//Delete Parameters Removed

            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckForm()
        {
            bool res = true;
            String message = "The following attributes are invalid:\n";
            if (this.ActionNameText.Text.Length == 0)
            {
                message += "Action name\n";
                res = false;
            }
            if (this.CreatorNameText.Text.Length == 0)
            {
                message += "Creator name\n";
                res = false;
            }
            if (!res) MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckActionContent()
        {
            bool res = true;
            String message = "The following attributes are invalid:\n";
            if (this.OScomboBox.SelectedItem == null)
            {
                message += "OS Type\n";
                res = false;
            }
            if (this.ContentText.Text.Length == 0 && (this.ValidityCheckBox.Checked && this.ValidityText.Text.Length > 0))
            {
                message += "Command/script empty with non-empty validity string\n";
                res = false;
            }
            if (!res) MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return res;
        }

        private void SaveOSContent(object sender, EventArgs e) {
            EndStation.OSTypeEnum OSType = ConvertSelectionToOSType(OScomboBox.SelectedIndex);
            if (ContentText.Text.Length == 0) {
                m_action.AddContent(OSType, "");
                m_action.RemoveValidityString(OSType);
            }
            else m_action.AddContent(OSType, ContentText.Text);
        }

        private void SaveOSValidityString(object sender, EventArgs e) {
            //if (!this.CheckActionContent()) return;
            EndStation.OSTypeEnum OSType = ConvertSelectionToOSType(OScomboBox.SelectedIndex);
            if (ValidityText.Text.Length == 0 || !ValidityCheckBox.Checked) m_action.RemoveValidityString(OSType);
            else m_action.AddValidityString(OSType, ValidityText.Text);
        }

        private void TimeoutText_ValueChanged(object sender, EventArgs e) {
            m_action.Timeout = (int)TimeoutText.Value;
        }

        private void ValidityCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (this.ValidityCheckBox.Checked)
                this.ValidityText.Enabled = true;
            else {
                this.ValidityText.Enabled = false;
                EndStation.OSTypeEnum OSType = ConvertSelectionToOSType(OScomboBox.SelectedIndex);
                m_action.RemoveValidityString(OSType);

            }
        }

        
    }
}