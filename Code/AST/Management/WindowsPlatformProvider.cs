using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace AST.Management{

    class WindowsPlatformProvider : IServiceProvider{


        private const String EXECUTE_COMMAND = "\\psexec.exe";
        private const String KILL_COMMAND = "\\pskill.exe";
        private static WindowsPlatformProvider m_instance = null;
        
        private WindowsPlatformProvider(){}

        public static WindowsPlatformProvider GetInstance(){
            if (m_instance == null) 
                m_instance = new WindowsPlatformProvider();
            return m_instance;
        }

        public String ExecuteCmd(IPAddress ip, String username, String password, String cmd, int timeout, int duration) 
        {
           String res = "";
           String cmd2 = "c:\\pstools\\psexec.exe ";
           if (!File.Exists(cmd2))
               Console.Out.WriteLine("no such file" + cmd2);
           else
           {
                String PSToolsCommand = ConfigurationManager.GetPSToolsFullPath() + EXECUTE_COMMAND;
                if (!File.Exists(PSToolsCommand)) throw new FileNotExistException("The file: " + PSToolsCommand + " doesn't found.");

                String timeoutStr = "";
                if (username.Length != 0) username = " -u " + username;
                if (password.Length != 0) password = " -p " + password;
                if (timeout != 0) timeoutStr = " -n " + timeout;

                String args = " \\\\" + ip.ToString() + username + password + timeoutStr + " " + cmd;
                Debug.WriteLine(PSToolsCommand + args);

                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(PSToolsCommand, args);
                //psi.CreateNoWindow = false;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                p.StartInfo = psi;
     
                try {
                    p.Start();
                    if (duration == 0) {
                        //StreamReader myStreamReader = p.StandardOutput;
                        //String myString1 = myStreamReader.ReadToEnd();

                        p.WaitForExit();
                        res = p.StandardOutput.ReadToEnd();
                        Debug.WriteLine("Ping result:\n" + res);

                        //p.Close();
                    }
                    else {
                        if (!p.WaitForExit(duration * 1000)) p.Kill();
                    }

                }
                catch (ExecutionFailedException e) { throw e; }
                catch (FileNotExistException e) { throw e; }
                catch (Exception e) {
                    throw new ExecutionFailedException("Could not start process.", e);
                }

            }
            return res;
        }

 /*
        public String ExecuteCmd(IPAddress ip, String username, String password, String cmd)
        {
            String PSToolsPath = ConfigurationManager.GetPSToolsFullPath();
            String str = PSToolsPath + "\\psexec.exe" ;
            String args;
            if(username.Equals(""))
                args = " \\\\" + ip.ToString() +  " -i "+ cmd;
            else
                args = " \\\\" + ip.ToString() + " -u " + username + " -p " + password + " -i "+ cmd;
            Console.WriteLine(str + args); 
            Process.Start(str, args);
        }
*/
        public String ExecuteScript(IPAddress ip, String username, String password, String filename, int timeout, int duration)
        {
            String res = "";

            return res;
        }

    }
}
