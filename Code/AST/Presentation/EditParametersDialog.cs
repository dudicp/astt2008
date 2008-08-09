using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Domain;

namespace AST.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EditParametersDialog : Form
    {
        private Parameter m_param;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public EditParametersDialog(Parameter param)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            if (param != null)
            {
                m_param = param;
                Title.Text = "Edit Parameter";
                SetParameterAttributes();
            }
            else
            {
                m_param = new Parameter("", "", Parameter.ParameterTypeEnum.None, "",false);
                Title.Text = "Create Parameter";
                OptionCheckBox.Checked = false;
                InputCheckBox.Checked = false;
                ParameterContentBox.Enabled = false;
                InputBox.Enabled = false;
                OScomboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Parameter GetParameter(){
            return m_param;
        }

        private void SetParameterAttributes()
        {
            SetParameterDetails();
            OScomboBox.SelectedIndex = 0;
            SetParameterContent(OScomboBox.SelectedIndex);
            SetInputContetnt();
        }

        private void SetParameterDetails()
        {
            ParameterNameText.Text = m_param.Name;
            ParameterNameText.Enabled = false;
            switch (m_param.Type)
            {
                case Parameter.ParameterTypeEnum.Option:
                    {
                        OptionCheckBox.Checked = true;
                        InputCheckBox.Checked = false;
                        ParameterContentBox.Enabled = true;
                        InputBox.Enabled = false;
                        break;
                    }
                case Parameter.ParameterTypeEnum.Input:
                    {
                        OptionCheckBox.Checked = false;
                        InputCheckBox.Checked = true;
                        ParameterContentBox.Enabled = false;
                        InputBox.Enabled = true;
                        break;
                    }
                case Parameter.ParameterTypeEnum.Both:
                    {
                        OptionCheckBox.Checked = true;
                        InputCheckBox.Checked = true;
                        ParameterContentBox.Enabled = true;
                        InputBox.Enabled = true;
                        break;
                    }
                default:
                    {
                        OptionCheckBox.Checked = false;
                        InputCheckBox.Checked = false;
                        ParameterContentBox.Enabled = false;
                        InputBox.Enabled = false;
                        break;
                    }
            }
            DescriptionText.Text = m_param.Description;
            DefaultCheckBox.Checked = m_param.IsDefault;
        }

        private void SetParameterContent(int OSTypeSelection)
        {
            EndStation.OSTypeEnum OSType = CreateAdditionalActionDialog.ConvertSelectionToOSType(OSTypeSelection);
            ContentText.Text = m_param.GetValue(OSType);
        }

        private void SetInputContetnt()
        {
            InputTextBox.Text = m_param.Input;
        }

        private void InputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InputCheckBox.Checked == true)
                InputBox.Enabled = true;
            else InputBox.Enabled = false;
        }

        private void OptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OptionCheckBox.Checked == true)
                ParameterContentBox.Enabled = true;
            else ParameterContentBox.Enabled = false;
        }

        private void OScomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetParameterContent(OScomboBox.SelectedIndex);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            m_param.Name = ParameterNameText.Text;
            m_param.Description = DescriptionText.Text;

            if ((InputCheckBox.Checked == true) && (OptionCheckBox.Checked == true)) {
                if (InputTextBox.Text.Length != 0) {
                    m_param.Type = Parameter.ParameterTypeEnum.Both;
                    m_param.Input = InputTextBox.Text;
                }
                else {
                    m_param.Type = Parameter.ParameterTypeEnum.Both;
                    m_param.Input = "";
                }
            }
            else if (InputCheckBox.Checked == true) {
                m_param.Type = Parameter.ParameterTypeEnum.Input;
                m_param.Input = InputTextBox.Text;
                m_param.ValidityExp = "";
            }
            else if (OptionCheckBox.Checked == true) {
                m_param.Type = Parameter.ParameterTypeEnum.Option;
                m_param.Input = "";
            }
            else {
                m_param.Type = Parameter.ParameterTypeEnum.None;
                m_param.Input = "";
            }
            m_param.IsDefault = DefaultCheckBox.Checked;

            if (m_param.Name != null && m_param.Name.Length != 0) ;
            else if ((m_param.Name == null || m_param.Name.Length == 0) && m_param.Input != null && m_param.Input.Length != 0) m_param.Name = m_param.Input;
            else if ((m_param.Name == null || m_param.Name.Length == 0) && ((String)m_param.GetAllValues()[EndStation.OSTypeEnum.WINDOWS]) != null && ((String)m_param.GetAllValues()[EndStation.OSTypeEnum.WINDOWS]).Length != 0) m_param.Name = (String)m_param.GetAllValues()[EndStation.OSTypeEnum.WINDOWS];
            else {
                MessageBox.Show("Parameter name is missing.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SaveOSValue(object sender, EventArgs e) {
            EndStation.OSTypeEnum OSType = CreateAdditionalActionDialog.ConvertSelectionToOSType(OScomboBox.SelectedIndex);
            if (ContentText.Text.Length == 0) {
                m_param.RemoveValue(OSType);
            }
            else m_param.AddValue(OSType, ContentText.Text);
        }
    }
}