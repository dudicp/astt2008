using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AST.Management {
    public partial class ExecutionDialog : Form, ExecutionManagerOutputListener{
        public ExecutionDialog() {
            InitializeComponent();
            ASTManager.GetInstance().AddExecutionManagerOutputListener(this);
        }

        public void UpdateProgress(int progress, String currentAction, int roundNumber) { 
            this.ProgressBar.Value = progress;
        }
    }
}