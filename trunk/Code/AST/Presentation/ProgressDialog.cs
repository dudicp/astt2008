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

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(String text, Label label);
        delegate void SetValueCallback(int value, ProgressBar label);


        public ProgressDialog() {
            InitializeComponent();
            m_endStations = new List<EndStation>();
            ASTManager.GetInstance().AddExecutionManagerOutputListener(this);

            this.Init();
        }

        private void Init() {
            this.ProgressBar.Value = 0;
            this.CurrentActionText.Text = "";
            this.RoundText.Text = "";

            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;

            //Filling the end-stations combo box:
            foreach (EndStation es in endStations) {
                this.m_endStations.Add(es);
                this.EndStationComboBox.Items.Add(es.Name + "(" + es.ID + ")");
            }
        }
    


        private void EndStationComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.EndStationComboBox.SelectedIndex >= m_endStations.Count) {
                return;
            }
            this.EndStationNameText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].Name+"("+m_endStations[this.EndStationComboBox.SelectedIndex].ID+")";
            this.IPText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].IP.ToString();
            this.UsernameText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].Username;
            this.OSTypeText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].OSType.ToString();
            this.MacText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].MAC;
        }

        private void MyCancelButton_Click(object sender, EventArgs e) {
            UpdateResult();
            if (this.ProgressBar.Value <= 90) this.ProgressBar.Value = this.ProgressBar.Value + 10;
            UpdateProgress(this.ProgressBar.Value, "Action", 1, 1);
        }

        /////////////////////////////////////////////
        // ExecutionManagerOutputListener Methods
        ////////////////////////////////////////////

        public void UpdateProgress(int progress, String currentAction, int currentRound, int totalRounds) {
            /*SetText(currentAction, this.CurrentActionText);
            SetText("" + currentRound + "/" + totalRounds, this.RoundText);

            if ((progress < 0) || (progress > 100)) return;
            else SetValue(progress, this.ProgressBar);*/
        }

        public void UpdateResult() {

            int rowNumber = this.ResultsGridView.Rows.Add();
            this.ResultsGridView.Rows[rowNumber].Cells[0].Value = "Action " + rowNumber;
            this.ResultsGridView.Rows[rowNumber].Cells[1].Value = "Success";

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
                this.Invoke(d, new object[] { text });
            }
            else {
                label.Text = text;
            }
        }

        private void SetValue(int value, ProgressBar pb) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (pb.InvokeRequired) {
                SetValueCallback d = new SetValueCallback(SetValue);
                this.Invoke(d, new object[] { value });
            }
            else {
                pb.Value = value;
            }
        }

    }
}