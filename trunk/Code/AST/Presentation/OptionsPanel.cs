using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Management;
using AST.Domain;
using System.Collections;

namespace AST.Presentation {
    public partial class OptionsPanel : AST.Presentation.ASTPanel {

        private List<EndStation> m_endStations;

        public OptionsPanel() {
            InitializeComponent();
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
        }

        private void NewEndStationButton_Click(object sender, EventArgs e) {
            EndStationDialog esd = new EndStationDialog(null);
            if (esd.ShowDialog() == DialogResult.OK) {
                EndStation es = esd.GetEndStation();
                this.m_endStations.Add(es);
                ASTManager.GetInstance().AddEndStation(es, true);
                this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            }
        }

        private void EditEndStationButton_Click(object sender, EventArgs e) {
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

        private void DeleteEndStationButton_Click(object sender, EventArgs e) {
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            ASTManager.GetInstance().RemoveEndStation(this.m_endStations[this.EndStationsListBox.SelectedIndex]);
            this.m_endStations.RemoveAt(this.EndStationsListBox.SelectedIndex);
            this.EndStationsListBox.Items.RemoveAt(this.EndStationsListBox.SelectedIndex);
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

        private void okButton_Click(object sender, EventArgs e) {
            int res = ConfigurationManager.WriteConfiguration(this.DBConnectionText.Text, this.PSToolsPathText.Text, (int)this.MaxThreadPoolText.Value);
            if (res == ConfigurationManager.SUCCESS) {
                MessageBox.Show("Configuration file updated successfully.", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ASTManager.GetInstance().Init();
                ASTManager.GetInstance().DisplayWelcomeScreen();
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
            //Return to the welcome screen
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            ASTManager.GetInstance().DisplayWelcomeScreen();
        }

    }
}

