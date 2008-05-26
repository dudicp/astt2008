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
            if (m_instance == null) m_instance = new WindowsPlatformProvider();
            return m_instance;
        }
        
        public void ExecuteCmd(IPAddress ip, String username, String password, String cmd, int timeout, int duration){

            String PSToolsCommand = ConfigurationManager.GetPSToolsFullPath() + EXECUTE_COMMAND;
            if (!File.Exists(PSToolsCommand)) throw new FileNotExistException("The file: "+PSToolsCommand+" doesn't found.");

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
            String res;
            try {
                p.Start();
                if (duration == 0) {
                    StreamReader myStreamReader = p.StandardOutput;                  
                    String myString1 = myStreamReader.ReadToEnd();

                    //res = p.StandardOutput.ReadToEnd();
                    //p.WaitForExit();
                    p.Close();
                }
                else {
                    if (!p.WaitForExit(duration * 1000)) p.Kill();
                }

                if (p.ExitCode != 0) throw new ExecutionFailedException("Proccess terminated with error code: " + p.ExitCode);

                Process pi = new Process();
                pi.StartInfo.FileName = "cmd.exe";
                pi.StartInfo.Arguments = "/c dir *.*";
                pi.StartInfo.UseShellExecute = false;
                pi.StartInfo.RedirectStandardOutput = true;
                pi.Start();

                string output = pi.StandardOutput.ReadToEnd();

            }catch (ExecutionFailedException e) { throw e; }
            catch (Exception e) {
                throw new ExecutionFailedException("Could not start process.", e);
            }
            

            /*if (duration != 0) {
                System.Threading.Thread.Sleep(duration*1000);
                String PsKillCommand = ConfigurationManager.GetPSToolsFullPath() + KILL_COMMAND;
                args = " \\\\" + ip.ToString() + username + password + " " + p.Id;
                Process.Start(PsKillCommand, args);
            }*/

        public void ExecuteCmd(IPAddress ip, String username, String password, String cmd)
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

        public void ExecuteScript(IPAddress ip, String username, String password, String filename, int timeout, int duration)
        {

        }


    }
}
