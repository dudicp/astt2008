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

namespace AST.Presentation
{
    public partial class WelcomePanel : AST.Presentation.ASTPanel{

        private List<RecentEntry> m_recent;
        private const int RECENT_NUMBER = 5;
        private Color m_defaultColor;

        public WelcomePanel(){
            m_recent = new List<RecentEntry>();
            InitializeComponent();
            SetRecent();
            m_defaultColor = Recent1.ForeColor;
        }

        private void SetRecent() {
            m_recent = ASTManager.GetInstance().GetRecent(RECENT_NUMBER);

            Recent1.Text = "";
            Recent2.Text = "";
            Recent3.Text = "";
            Recent4.Text = "";
            Recent5.Text = "";
            this.Recent1.Enabled = false;
            this.Recent2.Enabled = false;
            this.Recent3.Enabled = false;
            this.Recent4.Enabled = false;
            this.Recent5.Enabled = false;

            if (m_recent.Count > 0) {
                Recent1.Text = SetText(m_recent[0]);
                this.Recent1.Enabled = true;
            }
            if (m_recent.Count > 1) {
                Recent2.Text = SetText(m_recent[1]);
                this.Recent2.Enabled = true;
            }
            if (m_recent.Count > 2) {
                Recent3.Text = SetText(m_recent[2]);
                this.Recent3.Enabled = true;
            }
            if (m_recent.Count > 3) {
                Recent4.Text = SetText(m_recent[3]);
                this.Recent4.Enabled = true;
            }
            if (m_recent.Count > 4) {
                Recent5.Text = SetText(m_recent[4]);
                this.Recent5.Enabled = true;
            }
        }

        private String SetText(RecentEntry re) {
            String res = re.Name;
            if (res.Length > 17) res = res.Substring(0, 16);
            return res;
        }

    #region On Recent Click

        private void Recent1_DoubleClick(object sender, EventArgs e) {
            OnDoubleClick(0);
        }

        private void Recent2_DoubleClick(object sender, EventArgs e) {
            OnDoubleClick(1);
        }

        private void Recent3_DoubleClick(object sender, EventArgs e) {
            OnDoubleClick(2);
        }

        private void Recent4_DoubleClick(object sender, EventArgs e) {
            OnDoubleClick(3);
        }

        private void Recent5_DoubleClick(object sender, EventArgs e) {
            OnDoubleClick(4);
        }

        private void OnDoubleClick(int index) {
            if (m_recent.Count > index) {
                AbstractAction action = ASTManager.GetInstance().Load(m_recent[index].Name, m_recent[index].Type);
                ExecutionDialog ed = new ExecutionDialog(action, m_recent[index].Type);
                if (ed.ShowDialog() == DialogResult.OK) {
                    ProgressDialog pd = new ProgressDialog(ed.GetReportName());

                    AbstractAction a = ed.GetAbstractAction();
                    AbstractAction.AbstractActionTypeEnum type = ed.GetAbstractActionType();
                    String reportName = ed.GetReportName();                    

                    ASTManager.GetInstance().Execute(a, type, reportName);

                    pd.ShowDialog();
                }
            }
        }

    #endregion

    #region On Mouse Enter/Leave

        private void Recent1_MouseEnter(object sender, EventArgs e) {
            this.Recent1.ForeColor = Color.LightSteelBlue;
            if (m_recent.Count > 0)
                this.DescriptionText.Text = m_recent[0].Description;
        }

        private void Recent2_MouseEnter(object sender, EventArgs e) {
            this.Recent2.ForeColor = Color.LightSteelBlue;
            if (m_recent.Count > 1)
                this.DescriptionText.Text = m_recent[1].Description;
        }

        private void Recent3_MouseEnter(object sender, EventArgs e) {
            this.Recent3.ForeColor = Color.LightSteelBlue;
            if (m_recent.Count > 2)
                this.DescriptionText.Text = m_recent[2].Description;
        }

        private void Recent4_MouseEnter(object sender, EventArgs e) {
            this.Recent4.ForeColor = Color.LightSteelBlue;
            if (m_recent.Count > 3)
                this.DescriptionText.Text = m_recent[3].Description;
        }

        private void Recent5_MouseEnter(object sender, EventArgs e) {
            this.Recent5.ForeColor = Color.LightSteelBlue;
            if (m_recent.Count > 4)
                this.DescriptionText.Text = m_recent[4].Description;
        }

        private void Recent1_MouseLeave(object sender, EventArgs e) {
            this.Recent1.ForeColor = m_defaultColor;
            this.DescriptionText.Text = "";
        }

        private void Recent2_MouseLeave(object sender, EventArgs e) {
            this.Recent2.ForeColor = m_defaultColor;
            this.DescriptionText.Text = "";
        }

        private void Recent3_MouseLeave(object sender, EventArgs e) {
            this.Recent3.ForeColor = m_defaultColor;
            this.DescriptionText.Text = "";
        }

        private void Recent4_MouseLeave(object sender, EventArgs e) {
            this.Recent4.ForeColor = m_defaultColor;
            this.DescriptionText.Text = "";
        }

        private void Recent5_MouseLeave(object sender, EventArgs e) {
            this.Recent5.ForeColor = m_defaultColor;
            this.DescriptionText.Text = "";
        }

    #endregion
    }
}

