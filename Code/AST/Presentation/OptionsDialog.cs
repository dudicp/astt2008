using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AST.Management;
using AST.Domain;


namespace AST.Presentation {
    public partial class OptionsDialog : Form {

        private List<EndStation> m_endStations;
        
        /// <summary>
        /// 
        /// </summary>
        public OptionsDialog() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitEndStations();
            InitConfiguration();
        }

        private void InitEndStations() {
            this.m_endStations = new List<EndStation>();
            this.EndStationsListBox.Items.Clear();

            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;

            //Filling the end-stations:
            foreach (EndStation es in endStations) {
                this.m_endStations.Add(es);
                this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            }
        }

        private void InitConfiguration() {
            this.DBConnectionText.Text = ConfigurationManager.GetDatabaseName();
            this.PSToolsPathText.Text = ConfigurationManager.GetPSToolsFullPath();
            this.MaxThreadPoolText.Value = ConfigurationManager.GetMaxThreadPoolSize();
            this.ReportsFullPathText.Text = ConfigurationManager.GetReportFullPath();
            if (ConfigurationManager.GetReportOption().Equals(ConfigurationManager.TXT_REPORT))
                this.TXTFormatRadioButton.Checked = true;
            else this.XMLFormatRadioButton.Checked = true;
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

        private void EditEndStationButton_Click(object sender, EventArgs e) {
            try {
                EndStationDialog esd = new EndStationDialog(this.m_endStations[this.EndStationsListBox.SelectedIndex]);
                if (esd.ShowDialog() == DialogResult.OK) {
                    EndStation es = esd.GetEndStation();
                    ASTManager.GetInstance().AddEndStation(es, false);
                    InitEndStations();

                    this.IPText.Text = es.IP.ToString();
                    this.UsernameText.Text = es.Username;
                    this.OSTypeText.Text = es.OSType.ToString();
                }
            }
            catch (Exception ex) { /*the message displayed and the end-station won't be added.*/ }
        }

        private void DeleteEndStationButton_Click(object sender, EventArgs e) {
            try {
                DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;

                int index = this.EndStationsListBox.SelectedIndex;
                ASTManager.GetInstance().RemoveEndStation(this.m_endStations[index]);
                this.m_endStations.RemoveAt(index);
                this.EndStationsListBox.Items.RemoveAt(index);
            }
            catch (Exception ex) { /*the message displayed and the end-station won't be added.*/ }
        }

        private void EndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.EditEndStationButton.Enabled = false;
            this.DeleteEndStationButton.Enabled = false;
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) return;

            this.EditEndStationButton.Enabled = true;
            this.DeleteEndStationButton.Enabled = true;

            this.IPText.Text = this.m_endStations[this.EndStationsListBox.SelectedIndex].IP.ToString();
            this.UsernameText.Text = this.m_endStations[this.EndStationsListBox.SelectedIndex].Username;
            this.OSTypeText.Text = this.m_endStations[this.EndStationsListBox.SelectedIndex].OSType.ToString();
            if (this.m_endStations[this.EndStationsListBox.SelectedIndex].IsDefault) this.IsDefaultLabel.Text = "Default End-Station";
            else this.IsDefaultLabel.Text = "";
        }

        private void BrowseButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            if (browse.ShowDialog() == DialogResult.OK)
                PSToolsPathText.Text = browse.SelectedPath;
        }

        private void ReportsBrowseButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            if (browse.ShowDialog() == DialogResult.OK)
                ReportsFullPathText.Text = browse.SelectedPath;
        }

        private void okButton_Click(object sender, EventArgs e) {
            String reportFormat = "";
            if(this.TXTFormatRadioButton.Checked) reportFormat = ConfigurationManager.TXT_REPORT;
            else reportFormat = ConfigurationManager.XML_REPORT;
            int res = ConfigurationManager.WriteConfiguration(this.DBConnectionText.Text, this.PSToolsPathText.Text, (int)this.MaxThreadPoolText.Value, this.ReportsFullPathText.Text, reportFormat);
            if (res == ConfigurationManager.SUCCESS) {
                MessageBox.Show("Configuration file updated successfully.", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else {
                String message;
                switch (res) {
                    case ConfigurationManager.ERROR_WRITING:
                        message = "Failed to write configuration file.";
                        break;
                    case ConfigurationManager.ERROR_INVALID_ARGUMENTS:
                        message = "Invalid arguments";
                        break;
                    default:
                        message = "Unexpected error occured while writing to file.";
                        break;
                }
                MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MyCancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

    }
}