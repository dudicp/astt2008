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
    public partial class EditParametersDialog : Form
    {
        private Parameter m_param;

        public EditParametersDialog(Parameter param)
        {
            InitializeComponent();
            if (param != null)
            {
                m_param = param;
                Title.Text = "Edit Parameter";
                SetParameterAttributes();
            }
            else
            {
                m_param = new Parameter("", "", Parameter.ParameterTypeEnum.None, "");
                Title.Text = "Create Parameter";
                OptionCheckBox.Checked = false;
                InputCheckBox.Checked = false;
                ParameterContentBox.Enabled = false;
                InputBox.Enabled = false;
            }
        }

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
        }

        private void SetParameterContent(int OSTypeSelection)
        {
            EndStation.OSTypeEnum OSType = CreateAdditionalActionPanel.ConvertSelectionToOSType(OSTypeSelection);
            ContentText.Text = m_param.GetValue(OSType);
        }

        private void SetInputContetnt()
        {
            InputTextBox.Text = m_param.Input;
            ValidityText.Text = m_param.ValidityExp;
            if (ValidityText.Text.Length > 0) ValidityCheckBox.Checked = true;
            else ValidityCheckBox.Checked = false;
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

        private void SaveOSButton_Click(object sender, EventArgs e)
        {
            EndStation.OSTypeEnum OSType = CreateAdditionalActionPanel.ConvertSelectionToOSType(OScomboBox.SelectedIndex);
            m_param.AddValue(OSType, ContentText.Text);
        }

        private void RemoveOSButton_Click(object sender, EventArgs e)
        {
            EndStation.OSTypeEnum OSType = CreateAdditionalActionPanel.ConvertSelectionToOSType(OScomboBox.SelectedIndex);
            m_param.RemoveValue(OSType);
            SetParameterContent(OScomboBox.SelectedIndex);
        }

        private void OScomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetParameterContent(OScomboBox.SelectedIndex);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            m_param.Name = ParameterNameText.Text;
            m_param.Description = DescriptionText.Text;

            if ((InputCheckBox.Checked == true) && (OptionCheckBox.Checked == true))
                m_param.Type = Parameter.ParameterTypeEnum.Both;
            else if (InputCheckBox.Checked == true)
            {
                m_param.Type = Parameter.ParameterTypeEnum.Input;
                m_param.Input = InputTextBox.Text;
                m_param.ValidityExp = ValidityText.Text;
            }else if(OptionCheckBox.Checked == true)
                m_param.Type = Parameter.ParameterTypeEnum.Option;
            else m_param.Type = Parameter.ParameterTypeEnum.None;

            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}