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
        /// <summary>
        /// 
        /// </summary>
        public AboutDialog()
        {
            InitializeComponent();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutDialog_Load(object sender, EventArgs e)
        {

        }
    }
}