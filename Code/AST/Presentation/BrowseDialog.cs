using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AST.Management;
using AST.Domain;
using System.Diagnostics;

namespace AST.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BrowseDialog : Form
    {

        private AbstractAction.AbstractActionTypeEnum m_selectedType;
        private String m_abstractActionName;
        private Hashtable m_info;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedType"></param>
        public BrowseDialog(AbstractAction.AbstractActionTypeEnum selectedType) {
            this.MaximizeBox = false;
            m_selectedType = selectedType;
            m_info = new Hashtable();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SetListBoxNames();
        }

        private void SetListBoxNames() {
            try {
                this.listBox.Items.Clear();
                if (m_selectedType == AbstractAction.AbstractActionTypeEnum.ACTION) this.m_info = ASTManager.GetInstance().GetAdditionalActionsInfo();
                else this.m_info = ASTManager.GetInstance().GetInfo(m_selectedType);

                ICollection names = this.m_info.Keys;
                foreach (String name in names)
                    this.listBox.Items.Add(name);
            }
            catch (Exception e) {
                DialogResult = DialogResult.Cancel;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetAbstractActionName(){
            return m_abstractActionName;
        }

        private void MyCancelButton_Click(object sender, EventArgs e){
            DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e){
            m_abstractActionName = (String)listBox.SelectedItem;
            if (m_abstractActionName == null)
            {
                MessageBox.Show("No item selected.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e) {
           if(this.listBox.SelectedItem!=null)
                this.DescriptionText.Text = (String)this.m_info[this.listBox.SelectedItem];
        }
    }
}