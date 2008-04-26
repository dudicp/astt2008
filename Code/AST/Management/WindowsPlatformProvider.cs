using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;

namespace AST.Management
{
    class WindowsPlatformProvider : IServiceProvider
    {
        private static WindowsPlatformProvider m_instance = null;
        
        private WindowsPlatformProvider()
        {
        }

        public static WindowsPlatformProvider GetInstance()
        {
            if (m_instance == null)
                m_instance = new WindowsPlatformProvider();
            return m_instance;
        }
        
        public void ExecuteCmd(IPAddress ip, String username, String password, String cmd)
        {
            String str = "D:\\Project\\PsTools\\psexec.exe" ;
            String args = " \\\\" + ip.ToString() + " -i "+ cmd;
            Console.WriteLine(str + args); 
            Process.Start(str, args);
        }

        public void ExecuteScript(IPAddress ip, String username, String password, String filename)
        {

        }


    }
}
