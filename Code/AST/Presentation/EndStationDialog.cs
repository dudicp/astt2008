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
    public partial class EndStationDialog : Form {

        private EndStation m_es;

        public EndStationDialog(EndStation es) {
            this.m_es = es;
            InitializeComponent();
            if (es != null) {
                this.SetEndStationDetails();
            }else{
                int id = ASTManager.GetInstance().GetEndStations().Count;
                this.IDTextBox.Text = ""+id;
                this.m_es = new EndStation(id,"",new IPAddress(0x00000000) ,EndStation.OSTypeEnum.UNKNOWN,"","");
            }
        }

        private void SetEndStationDetails() {
            this.IDTextBox.Text = ""+this.m_es.ID;
            this.NameTextBox.Text = this.m_es.Name;
            this.IPTextBox.Text = this.m_es.IP.ToString();
            this.UsernameTextBox.Text = this.m_es.Username;
            this.PasswordTextBox.Text = this.m_es.Password;
        }

        public EndStation GetEndStation() {
            return this.m_es;
        }

        private void okButton_Click(object sender, EventArgs e) {
            //this.m_es.ID = this.IDTextBox.Text;

            if(!this.CheckForm()) return;

            this.m_es.Name = this.NameTextBox.Text;
            this.m_es.IP = IPAddress.Parse(this.IPTextBox.Text);
            this.m_es.Username = this.UsernameTextBox.Text;
            this.m_es.Password = this.PasswordTextBox.Text;
            
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
            if (!res) MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return res;
        }
    }
}