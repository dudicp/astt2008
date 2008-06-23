using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AST.Domain;

namespace AST.Management {
    public partial class ProgressDialog : Form, ExecutionManagerOutputListener{

        private List<EndStation> m_endStations;
        private int m_currentActionNo;

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(String text, Label label);
        delegate void SetValueCallback(int value, ProgressBar label, Queue resultsQueue);
        delegate void SetExecutionFinishCallback();


        public ProgressDialog() {
            InitializeComponent();
            m_endStations = new List<EndStation>();
            m_currentActionNo = 0;
            ASTManager.GetInstance().AddExecutionManagerOutputListener(this);

            this.Init();
        }

        private void Init() {
            this.ProgressBar.Value = 0;
            this.CurrentActionText.Text = "";
            this.ActionNoText.Text = "";

            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;

            //Filling the end-stations combo box:
            foreach (EndStation es in endStations) {
                this.m_endStations.Add(es);
                this.EndStationComboBox.Items.Add(es.Name + "(" + es.ID + ")");
            }
        }
    


        private void EndStationComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.EndStationComboBox.SelectedItem == null || this.EndStationComboBox.SelectedIndex >= m_endStations.Count) {
                return;
            }
            this.EndStationNameText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].Name+"("+m_endStations[this.EndStationComboBox.SelectedIndex].ID+")";
            this.IPText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].IP.ToString();
            this.UsernameText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].Username;
            this.OSTypeText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].OSType.ToString();
            this.MacText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].MAC;
        }

        private void MyCancelButton_Click(object sender, EventArgs e) {
        }

        private void OkButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        /////////////////////////////////////////////
        // ExecutionManagerOutputListener Methods
        ////////////////////////////////////////////

        public void UpdateProgress(int progress, Queue resultsQueue) {
            if ((progress < 0) || (progress > 100)) return;
            else SetValue(progress, this.ProgressBar, resultsQueue);
        }

        public void UpdateCurrrentAction(String currentActionName, int totalActions) {
            SetText(currentActionName, this.CurrentActionText);
            m_currentActionNo++;
            String text = "" + m_currentActionNo + "/" + totalActions;
            SetText(text, this.ActionNoText);
        }

        public void ExecutionFinish() {
            SetExecutionFinish();
        }


        // This method demonstrates a pattern for making thread-safe
        // calls on a Windows Forms control. 
        //
        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextCallback and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the TextBox control, the Text property is set directly. 
        private void SetText(String text, Label label) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (label.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, label });
            }
            else {
                label.Text = text;
            }
        }

        private void SetValue(int value, ProgressBar pb, Queue resultsQueue) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (pb.InvokeRequired) {
                SetValueCallback d = new SetValueCallback(SetValue);
                this.Invoke(d, new object[] { value, pb, resultsQueue });
            }
            else {
                pb.Value = value;
                this.UpdateResult(resultsQueue);
            }
        }

        private void SetExecutionFinish() {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (OkButton.InvokeRequired) {
                SetExecutionFinishCallback d = new SetExecutionFinishCallback(SetExecutionFinish);
                this.Invoke(d, new object[] {});
            }
            else {
                OkButton.Enabled = true;
            }
        }

        public void UpdateResult(Queue resultsQueue) {

            foreach (Result res in resultsQueue) {
                int rowNumber = this.ResultsGridView.Rows.Add();
                this.ResultsGridView.Rows[rowNumber].Cells[0].Value = res.GetAction().Name;
                this.ResultsGridView.Rows[rowNumber].Cells[1].Value = res.GetEndStation().Name + "(" + res.GetEndStation().ID + ")";
                if(res.Status)this.ResultsGridView.Rows[rowNumber].Cells[2].Value = "Success";
                else this.ResultsGridView.Rows[rowNumber].Cells[2].Value = "Failed";
            }

        }
    }
}