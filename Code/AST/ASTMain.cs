using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using AST.Presentation;
using AST.Management;

namespace AST{

    class ASTMain{
        // --------------------------------------------------------------------
        [STAThread]
        static void Main(){
            //Creating the ASTManager and initiliaze it.
            ASTManager.GetInstance().Init(new IPAddress(0x2414188f),1000);
            Application.Run(new MainForm());
        }
        // --------------------------------------------------------------------
    }
}
