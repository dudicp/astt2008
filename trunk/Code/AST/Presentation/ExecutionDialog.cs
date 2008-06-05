using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AST.Domain;
using AST.Management;

namespace AST.Presentation {
    public partial class ExecutionDialog : Form {

        private Hashtable m_actionsInfo;
        private Hashtable m_TSCsInfo;
        private Hashtable m_TPsInfo;
        private List<EndStation> m_endStations;
        private AbstractAction m_activeAction;

        public ExecutionDialog() {
            m_activeAction = null;
            m_actionsInfo = new Hashtable();
            m_TSCsInfo = new Hashtable();
            m_TPsInfo = new Hashtable();
            InitializeComponent();
            SetAbstractActionsInfo();
        }

        private void SetAbstractActionsInfo() {
            this.ActionsListBox.Items.Clear();
            this.TSCsListBox.Items.Clear();
            this.TPsListBox.Items.Clear();

            this.m_actionsInfo = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.ACTION);
            this.m_TSCsInfo = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.TSC);
            this.m_TPsInfo = ASTManager.GetInstance().GetInfo(AbstractAction.AbstractActionTypeEnum.TP);

            //Setting Action List Box
            ICollection names = this.m_actionsInfo.Keys;
            foreach (String name in names)
                this.ActionsListBox.Items.Add(name);

            //Setting TSC List Box
            names = this.m_TSCsInfo.Keys;
            foreach (String name in names)
                this.TSCsListBox.Items.Add(name);

            //Setting TP List Box
            names = this.m_TPsInfo.Keys;
            foreach (String name in names)
                this.TPsListBox.Items.Add(name);
        }

    #region SelectAbstractAction

        private void ActionsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.ActionsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_actionsInfo[this.ActionsListBox.SelectedItem];
                this.TPsListBox.ClearSelected();
                this.TSCsListBox.ClearSelected();
            }
        }

        private void TSCsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.TSCsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_TSCsInfo[this.TSCsListBox.SelectedItem];
                this.ActionsListBox.ClearSelected();
                this.TPsListBox.ClearSelected();
            }
        }

        private void TPsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.TPsListBox.SelectedItem != null) {
                this.DescriptionText.Text = (String)this.m_TPsInfo[this.TPsListBox.SelectedItem];
                this.ActionsListBox.ClearSelected();
                this.TSCsListBox.ClearSelected();
            }
        }

        private void ActionsListBox_OnDoubleClick(object sender, EventArgs e) {
            if (this.ActionsListBox.SelectedItem == null) return;
            m_activeAction = ASTManager.GetInstance().Load((String)this.ActionsListBox.SelectedItem, AbstractAction.AbstractActionTypeEnum.ACTION);

            //Add this action the Default End-Stations
            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;
            foreach (EndStation es in endStations) {
                if (es.IsDefault) m_activeAction.AddEndStation(new EndStationSchedule(es));
            }

            //Set End-Station List Boxes
            SetEndStations(m_activeAction);
        }

    #endregion

    #region EndStationsMethods

        private void SetEndStations(AbstractAction a) {
            this.m_endStations = new List<EndStation>();
            this.EndStationsListBox.Items.Clear();
            this.SelectedEndStationsListBox.Items.Clear();

            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;
            List<EndStation> selectedEndStations = new List<EndStation>();

            //Filling the selected end-stations list box:
            foreach (EndStationSchedule ess in a.GetEndStations()){
                this.SelectedEndStationsListBox.Items.Add(ess.EndStation.Name + "(" + ess.EndStation.ID + ")");
                selectedEndStations.Add(ess.EndStation);
            }

            //Filling the unselected end-stations:
            foreach (EndStation es in endStations) {
                if (!selectedEndStations.Contains(es)) {
                    this.m_endStations.Add(es);
                    this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
                }
            }
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

        private void EditButton_Click(object sender, EventArgs e) {
            EndStationDialog esd = new EndStationDialog(this.m_endStations[this.EndStationsListBox.SelectedIndex]);
            if (esd.ShowDialog() == DialogResult.OK) {
                this.m_endStations.Remove(this.m_endStations[this.EndStationsListBox.SelectedIndex]);
                this.EndStationsListBox.Items.RemoveAt(this.EndStationsListBox.SelectedIndex);
                EndStation es = esd.GetEndStation();
                ASTManager.GetInstance().AddEndStation(es, false);
                this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
                this.m_endStations.Add(es);
            }
        }

        private void SelectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) {
                this.SelectEndStationButton.Enabled = false;
                return;
            }
            EndStation es = this.m_endStations[this.EndStationsListBox.SelectedIndex];

            this.m_activeAction.AddEndStation(new EndStationSchedule(es));
            this.SelectedEndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            this.m_endStations.Remove(es);
            this.EndStationsListBox.Items.Remove(es.Name + "(" + es.ID + ")");
            if (EndStationsListBox.Items.Count == 0) {
                this.SelectEndStationButton.Enabled = false;
                this.EditButton.Enabled = false;
            }
        }

        private void UnselectEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count)) {
                this.UnselectEndStationButton.Enabled = false;
                return;
            }

            EndStationSchedule ess = this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex];
            EndStation es = ess.EndStation;

            this.EndStationsListBox.Items.Add(es.Name + "(" + es.ID + ")");
            this.m_endStations.Add(es);
            this.SelectedEndStationsListBox.Items.Remove(es.Name + "(" + es.ID + ")");
            this.m_activeAction.RemoveEndStation(ess);
            if (SelectedEndStationsListBox.Items.Count == 0)
                this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count))
                this.MoveUpEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_activeAction.GetEndStations().Count - 1)))
                this.MoveDownEndStationButton.Enabled = false;
        }

        private void EndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.SelectEndStationButton.Enabled = false;
            if ((this.EndStationsListBox.SelectedIndex < 0) || (this.EndStationsListBox.SelectedIndex >= this.m_endStations.Count)) return;
            this.SelectEndStationButton.Enabled = true;
            this.EditButton.Enabled = true;
            this.SelectedEndStationsListBox.ClearSelected();
        }

        private void SelectedEndStationsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            this.UnselectEndStationButton.Enabled = false;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count)) return;
            if (this.SelectedEndStationsListBox.SelectedIndex > 0) this.MoveUpEndStationButton.Enabled = true;
            else this.MoveUpEndStationButton.Enabled = false;
            if (this.SelectedEndStationsListBox.SelectedIndex < (this.m_activeAction.GetEndStations().Count - 1)) this.MoveDownEndStationButton.Enabled = true;
            else this.MoveDownEndStationButton.Enabled = false;
            this.UnselectEndStationButton.Enabled = true;
            this.EndStationsListBox.ClearSelected();
            this.EditButton.Enabled = false;
        }

        private void MoveUpEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count))
                return;
            String tmp = (String)this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex] = this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex - 1];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex - 1] = tmp;
            if ((this.SelectedEndStationsListBox.SelectedIndex <= 0) || (this.SelectedEndStationsListBox.SelectedIndex >= this.m_activeAction.GetEndStations().Count)) this.MoveUpEndStationButton.Enabled = false;

            EndStationSchedule ess = this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex-1];
            this.m_activeAction.GetEndStations().RemoveAt(this.SelectedEndStationsListBox.SelectedIndex-1);
            this.m_activeAction.GetEndStations().Insert(this.SelectedEndStationsListBox.SelectedIndex,this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex-1]);
            this.m_activeAction.GetEndStations().RemoveAt(this.SelectedEndStationsListBox.SelectedIndex);
            this.m_activeAction.GetEndStations().Insert(this.SelectedEndStationsListBox.SelectedIndex, ess);
            this.SelectedEndStationsListBox.SelectedIndex--;
        }

        private void MoveDownEndStationButton_Click(object sender, EventArgs e) {
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_activeAction.GetEndStations().Count - 1)))
                return;
            String tmp = (String)this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex] = this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex + 1];
            this.SelectedEndStationsListBox.Items[this.SelectedEndStationsListBox.SelectedIndex + 1] = tmp;
            

            EndStationSchedule ess = this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex];
            this.m_activeAction.GetEndStations().RemoveAt(this.SelectedEndStationsListBox.SelectedIndex);
            this.m_activeAction.GetEndStations().Insert(this.SelectedEndStationsListBox.SelectedIndex, this.m_activeAction.GetEndStations()[this.SelectedEndStationsListBox.SelectedIndex]);
            this.m_activeAction.GetEndStations().RemoveAt(this.SelectedEndStationsListBox.SelectedIndex+1);
            this.m_activeAction.GetEndStations().Insert(this.SelectedEndStationsListBox.SelectedIndex + 1,ess);
            this.SelectedEndStationsListBox.SelectedIndex++;
            if ((this.SelectedEndStationsListBox.SelectedIndex < 0) || (this.SelectedEndStationsListBox.SelectedIndex >= (this.m_activeAction.GetEndStations().Count - 1))) this.MoveDownEndStationButton.Enabled = false;
        }

    #endregion
    }
}