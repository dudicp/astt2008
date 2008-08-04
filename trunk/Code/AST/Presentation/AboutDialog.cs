using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AST.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AboutDialog : Form
    {

        private Color m_defaultColor;

        /// <summary>
        /// 
        /// </summary>
        public AboutDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            m_defaultColor = LinkLabel.ForeColor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        private void LinkLabel_Click(object sender, EventArgs e) {

            System.Diagnostics.ProcessStartInfo procFormsBuilderStartInfo = new System.Diagnostics.ProcessStartInfo();
            procFormsBuilderStartInfo.FileName = "http://www.cs.bgu.ac.il/~adishach";
            procFormsBuilderStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            System.Diagnostics.Process procFormsBuilder = new System.Diagnostics.Process();
            procFormsBuilder.StartInfo = procFormsBuilderStartInfo;
            procFormsBuilder.Start();
        }

        private void LinkLabel_MouseEnter(object sender, EventArgs e) {
            this.LinkLabel.ForeColor = Color.LightSteelBlue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel_MouseLeave(object sender, EventArgs e) {
            this.LinkLabel.ForeColor = m_defaultColor;
        }
    }
}