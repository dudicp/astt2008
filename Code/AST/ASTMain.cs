using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using AST.Presentation;
using AST.Management;
using System.Diagnostics;

namespace AST{

    class ASTMain{
        // --------------------------------------------------------------------
        [STAThread]
        static void Main(){
            //Creating the ASTManager and initiliaze it.
            ASTManager.GetInstance().Init("Server=YANIV\\SQLEXPRESS;Database=ASTDB;Integrated Security=True;");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        // --------------------------------------------------------------------
    }
}