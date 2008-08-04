using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using AST.Domain;
using AST.Management;


namespace AST.Presentation {
    /// <summary>
    /// 
    /// </summary>
    public partial class EndStationDialog : Form {

        private EndStation m_es;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="es"></param>
        public EndStationDialog(EndStation es) {
            this.m_es = es;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (es != null) {
                this.SetEndStationDetails();
            }else{
                this.Title.Text = "New End-Station";
                int id = ASTManager.GetInstance().GetUnusedEndStationIndex();
                this.IDTextBox.Text = ""+id;
                this.m_es = new EndStation(id,"",new IPAddress(0x00000000) ,EndStation.OSTypeEnum.WINDOWS,"","",false);
                this.SetOSType();
            }
        }

        private void SetEndStationDetails() {
            this.IDTextBox.Text = ""+this.m_es.ID;
            this.NameTextBox.Text = this.m_es.Name;
            this.IPTextBox.Text = this.m_es.IP.ToString();
            this.MACTextBox.Text = this.m_es.MAC;
            this.UsernameTextBox.Text = this.m_es.Username;
            this.PasswordTextBox.Text = this.m_es.Password;
            this.DefaultCheckBox.Checked = m_es.IsDefault;

            SetOSType();
        }

        private void SetOSType() {
            if (this.m_es.OSType == EndStation.OSTypeEnum.WINDOWS) this.OSComboBox.SelectedIndex = 0;
            else if (this.m_es.OSType == EndStation.OSTypeEnum.UNIX) this.OSComboBox.SelectedIndex = 1;
            else this.OSComboBox.SelectedIndex = 0;//for UNKNOWN Type
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EndStation GetEndStation() {
            return this.m_es;
        }

        private void okButton_Click(object sender, EventArgs e) {
            //this.m_es.ID = this.IDTextBox.Text;

            if(!this.CheckForm()) return;

            this.m_es.Name = this.NameTextBox.Text;
            this.m_es.IP = IPAddress.Parse(this.IPTextBox.Text);
            this.m_es.MAC = MACTextBox.Text;
            this.m_es.Username = this.UsernameTextBox.Text;
            this.m_es.Password = this.PasswordTextBox.Text;
            if (this.OSComboBox.SelectedItem.Equals("Windows"))
                this.m_es.OSType = EndStation.OSTypeEnum.WINDOWS;
            else if(this.OSComboBox.SelectedItem.Equals("Unix"))
                this.m_es.OSType = EndStation.OSTypeEnum.UNIX;
            this.m_es.IsDefault = this.DefaultCheckBox.Checked;
            DialogResult = DialogResult.OK;
        }

        private void MyCancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private bool CheckForm() {
            bool res = true;
            String message = "The following attributes are invalid:\n";
            IPAddress parsed;
            if (!IPAddress.TryParse(this.IPTextBox.Text, out parsed)) {
                message += "IP Address\n";
                res = false;
            }
            if (this.OSComboBox.SelectedItem == null) {
                message += "OS Type\n";
                res = false;
            }
            if (!res) MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return res;
        }
    }
}