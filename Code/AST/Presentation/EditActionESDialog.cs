using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Domain;
using System.Collections;
using AST.Management;

namespace AST.Presentation {

    public partial class EditActionESDialog : Form {

        private AbstractAction m_action;
        private List<EndStation> m_endStations;
        private List<EndStation> m_selectedEndStations;

        public EditActionESDialog(AbstractAction a) {
            m_action = a;
            InitializeComponent();
            Init();
        }

        private void Init() {
            this.m_endStations = new List<EndStation>();
            this.m_selectedEndStations = new List<EndStation>();
            this.EndStationsListBox.Items.Clear();

            //Filling the selected end-stations:
            List<EndStationSchedule> endStationInAction = this.m_action.GetEndStations();
            foreach (EndStationSchedule ess in endStationInAction) {
                this.m_selectedEndStations.Add(ess.EndStation);
                this.SelectedEndStationsListBox.Items.Add(ess.EndStation.Name + "(" + ess.EndStation.ID + ")");
            }

            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;

            //Filling the unselected end-stations:
            foreach (EndStation es in endStations) {
                if (!this.m_selectedEndStations.Contains(es)) {
                    this.m_endStations.Add(es);
                    this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
                }
            }
        }

        private void SelectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) {
                this.SelectEndStationButton.Enabled = false;
                return;
            }
            EndStation es = this.m_endStations[this.EndStationsListBox.SelectedIndex];

            this.m_selectedEndStations.Add(es);
            this.SelectedEndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            this.m_endStations.Remove(es);
            this.EndStationsListBox.Items.Remove(es.Name + "(" + es.ID + ")");
            if (EndStationsListBox.Items.Count == 0) {
                this.SelectEndStationButton.Enabled = false;
                this.EditButton.Enabled = false;
            }
        }

        private void UnselectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count)) {
                this.UnselectEndStationButton.Enabled = false;
                return;
            }

            EndStation es = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex];
            this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            this.m_endStations.Add(es);
            this.SelectedEndStationsListBox.Items.Remove(es.Name + "(" + es.ID + ")");
            this.m_selectedEndStations.Remove(es);
            if (SelectedEndStationsListBox.Items.Count == 0)
                this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count))
                this.MoveUpEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_selectedEndStations.Count - 1)))
                this.MoveDownEndStationButton.Enabled = false;
        }

        private void MoveUpEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count))
                return;
            String tmp = (String)this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex] = this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex - 1];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex - 1] = tmp;
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count)) this.MoveUpEndStationButton.Enabled = false;

            EndStation estmp = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex];
            this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex] = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex - 1];
            this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex - 1] = estmp;
        }

        private void MoveDownEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_selectedEndStations.Count - 1)))
                return;
            String tmp = (String)this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex] = this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex + 1];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex + 1] = tmp;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_selectedEndStations.Count - 1))) this.MoveDownEndStationButton.Enabled = false;

            EndStation estmp = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex];
            this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex] = this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex + 1];
            this.m_selectedEndStations[this.SelectedEndStationsListBox.SelectedIndex + 1] = estmp;
        }

        private void EndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectEndStationButton.Enabled = false;
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) return;
            this.SelectEndStationButton.Enabled = true;
            this.EditButton.Enabled = true;
        }

        private void SelectedEndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_selectedEndStations.Count)) return;
            if (this.SelectedEndStationsListBox.SelectedIndex > 0) this.MoveUpEndStationButton.Enabled = true;
            else this.MoveUpEndStationButton.Enabled = false;
            if (this.SelectedEndStationsListBox.SelectedIndex < (this.m_selectedEndStations.Count - 1)) this.MoveDownEndStationButton.Enabled = true;
            else this.MoveDownEndStationButton.Enabled = false;
            this.UnselectEndStationButton.Enabled = true;
        }

        private void NewEndStationButton_Click(object sender, EventArgs e) {
            EndStationDialog esd = new EndStationDialog(null);
            if (esd.ShowDialog() == DialogResult.OK) {
                EndStation es = esd.GetEndStation();
                this.m_endStations.Add(es);
                ASTManager.GetInstance().AddEndStation(es);
                this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            }
        }

        private void EditButton_Click(object sender, EventArgs e) {
            EndStationDialog esd = new EndStationDialog(this.m_endStations[this.EndStationsListBox.SelectedIndex]);
            if (esd.ShowDialog() == DialogResult.OK) {
                EndStation es = esd.GetEndStation();
                ASTManager.GetInstance().AddEndStation(es);
                Init();
            }
        }

        private void okButton_Click(object sender, EventArgs e) {
            //Updating abstract action's end-stations

            this.m_action.ClearEndStations();

            for (int i = 0; i < this.m_selectedEndStations.Count; i++)
                this.m_action.AddEndStation(new EndStationSchedule(this.m_selectedEndStations[i]));

            this.DialogResult = DialogResult.OK;
        }

        private void MyCancelButton_Click(object sender, EventArgs e){
            //Return to the previuos screen
            DialogResult res = MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;

            this.DialogResult = DialogResult.Cancel;
        }


    }
}