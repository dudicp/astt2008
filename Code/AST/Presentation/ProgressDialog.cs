using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AST.Domain;

namespace AST.Management
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProgressDialog : Form, ExecutionManagerOutputListener
    {

        private const int CP_NOCLOSE_BUTTON = 0x200;
        private List<EndStation> m_endStations;
        private int m_currentActionNo;
        private String m_reportFilename;
        private Color m_defaultColor;
        private List<Result> m_allResults;
        private bool m_stopExecute;

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.

        delegate void SetTextCallback(String text, Label label);
        delegate void SetValueCallback(int value, ProgressBar label, Queue resultsQueue);
        delegate void SetExecutionFinishCallback();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportFilename"></param>
        public ProgressDialog(String reportFilename)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            m_endStations = new List<EndStation>();
            m_allResults = new List<Result>();
            m_stopExecute = false;
            m_currentActionNo = 0;
            m_reportFilename = reportFilename;
            ViewReportLabel.Text = "";
            m_defaultColor = ViewReportLabel.ForeColor;
            ASTManager.GetInstance().AddExecutionManagerOutputListener(this);

            this.Init();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            this.ProgressBar.Value = 0;
            this.CurrentActionText.Text = "";
            this.ActionNoText.Text = "";

            ICollection endStations = ASTManager.GetInstance().GetEndStations().Values;

            //Filling the end-stations combo box:
            foreach (EndStation es in endStations)
            {
                this.m_endStations.Add(es);
                //this.EndStationComboBox.Items.Add(es.Name + "(" + es.ID + ")");
                this.EndStationComboBox.Items.Add(es.Name);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.EndStationComboBox.SelectedItem == null || this.EndStationComboBox.SelectedIndex >= m_endStations.Count)
            {
                return;
            }
            //this.EndStationNameText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].Name + "(" + m_endStations[this.EndStationComboBox.SelectedIndex].ID + ")";
            this.EndStationNameText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].Name;
            this.IPText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].IP.ToString();
            this.UsernameText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].Username;
            this.OSTypeText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].OSType.ToString();
            this.MacText.Text = m_endStations[this.EndStationComboBox.SelectedIndex].MAC;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            m_stopExecute = true;
            ASTManager.GetInstance().StopExecution();
            MyCancelButton.Enabled = false;
            CloseButton.Enabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            if (MyCancelButton.Enabled) {
                m_stopExecute = true;
                ASTManager.GetInstance().StopExecution();
                MyCancelButton.Enabled = false;
                CloseButton.Enabled = false;
            }
            CloseButton.Enabled = false;
            DialogResult = DialogResult.OK;
        }

        /////////////////////////////////////////////
        // ExecutionManagerOutputListener Methods
        ////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="resultsQueue"></param>
        public void UpdateProgress(int progress, Queue resultsQueue)
        {
            if ((progress < 0) || (progress > 100)) return;
            else SetValue(progress, this.ProgressBar, resultsQueue);
            if (m_stopExecute) {
                ExecutionFinish();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentActionName"></param>
        /// <param name="totalActions"></param>
        public void UpdateCurrrentAction(String currentActionName, int totalActions)
        {
            SetText(currentActionName, this.CurrentActionText);
            m_currentActionNo++;
            String text = "" + m_currentActionNo + "/" + totalActions;
            SetText(text, this.ActionNoText);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ExecutionFinish()
        {
            SetExecutionFinish();
        }

        public void DisplayMessage(String message) {
            SetText(message, this.MessageLabel);
        }



        /// <summary>
        ///  This method demonstrates a pattern for making thread-safe
        ///  calls on a Windows Forms control. 
        /// 
        ///  If the calling thread is different from the thread that
        ///  created the TextBox control, this method creates a
        ///  SetTextCallback and calls itself asynchronously using the
        ///  Invoke method.
        /// 
        ///  If the calling thread is the same as the thread that created
        ///  the TextBox control, the Text property is set directly.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="label"></param>
        private void SetText(String text, Label label)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, label });
            }
            else
            {
                label.Text = text;
            }
        }
        /// <summary>
        /// InvokeRequired required compares the thread ID of the
        /// calling thread to the thread ID of the creating thread.
        /// If these threads are different, it returns true.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pb"></param>
        /// <param name="resultsQueue"></param>
        private void SetValue(int value, ProgressBar pb, Queue resultsQueue)
        {
            if (pb.InvokeRequired)
            {
                SetValueCallback d = new SetValueCallback(SetValue);
                this.Invoke(d, new object[] { value, pb, resultsQueue });
            }
            else
            {
                pb.Value = value;
                this.UpdateResult(resultsQueue);
            }
        }

        /// <summary>
        /// InvokeRequired required compares the thread ID of the
        /// calling thread to the thread ID of the creating thread.
        /// If these threads are different, it returns true.
        /// </summary>
        private void SetExecutionFinish()
        {
            if (OkButton.InvokeRequired)
            {
                SetExecutionFinishCallback d = new SetExecutionFinishCallback(SetExecutionFinish);
                this.Invoke(d, new object[] { });
            }
            else
            {
                MyCancelButton.Enabled = false;
                CloseButton.Enabled = false;
                OkButton.Enabled = true;
                ViewReportLabel.Text = "View Report";
                ViewReportLabel.Enabled = true;
                InProgressImage.Enabled = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultsQueue"></param>
        public void UpdateResult(Queue resultsQueue)
        {

            foreach (Result res in resultsQueue)
            {
                this.m_allResults.Add(res);
                int rowNumber = this.ResultsGridView.Rows.Add();
                this.ResultsGridView.Rows[rowNumber].Cells[0].Value = res.GetAction().Name;
                //this.ResultsGridView.Rows[rowNumber].Cells[1].Value = res.GetEndStation().Name + "(" + res.GetEndStation().ID + ")";
                this.ResultsGridView.Rows[rowNumber].Cells[1].Value = res.GetEndStation().Name;
                if (res.Status) this.ResultsGridView.Rows[rowNumber].Cells[2].Value = "Success";
                else this.ResultsGridView.Rows[rowNumber].Cells[2].Value = "Fail";
                this.ResultsGridView.Rows[rowNumber].Cells[3].Value = res.GetAction().GetValidityString(AST.Domain.EndStation.OSTypeEnum.WINDOWS);
                this.MessageText.Text = res.Message;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewReportLabel_Click(object sender, EventArgs e)
        {
            ASTManager.GetInstance().ShowReport(m_reportFilename);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewReport_MouseEnter(object sender, EventArgs e)
        {
            this.ViewReportLabel.ForeColor = Color.LightSteelBlue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewReport_MouseLeave(object sender, EventArgs e)
        {
            this.ViewReportLabel.ForeColor = m_defaultColor;
        }

        private void ResultsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            this.MessageText.Text = this.m_allResults[this.ResultsGridView.SelectedCells[0].RowIndex].Message;
        }

    }
}