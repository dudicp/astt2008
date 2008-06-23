using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using AST.Presentation;
using AST.Management;
using System.Diagnostics;

using System.Runtime.InteropServices;

namespace AST{

    class ASTMain{

        // --------------------------------------------------------------------     
        [DllImport("user32.dll")]        
        public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);   
     
        [DllImport("user32.dll")]       
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [STAThread()]
        static void Main(string[] args){

            Console.Title = "TemporaryConsoleWindow";        
                
            // hide the console window                    
            setConsoleWindowVisibility(false, Console.Title);                   
            // open your form                    
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);                    
            Application.Run( new MainForm() );  
        }      

        public static void setConsoleWindowVisibility(bool visible, string title){
            IntPtr hWnd = FindWindow(null, title);
            if (hWnd != IntPtr.Zero){
                if (!visible)
                    //Hide the window                    
                    ShowWindow(hWnd, 0); // 0 = SW_HIDE                
                else
                    //Show window again                    
                    ShowWindow(hWnd, 1); //1 = SW_SHOWNORMA
             }
        }
    }
}
