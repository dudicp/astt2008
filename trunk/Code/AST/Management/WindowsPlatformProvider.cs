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

        public String ExecuteCmd(IPAddress ip, String username, String password, String cmd, int timeout, int duration){

           String res = "";

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
           psi.CreateNoWindow = false;
           psi.UseShellExecute = false;
           psi.RedirectStandardOutput = true;
           p.StartInfo = psi;

           try {
               p.Start();
               if (duration == 0) {
                   //p.WaitForExit();
                   res = p.StandardOutput.ReadToEnd();
                   Debug.WriteLine("output:\n" + res);
                   p.Close();
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
           return res;
        }

        public String ExecuteScript(IPAddress ip, String username, String password, String filename, String arguments, int timeout, int duration)
        {
            String res = "";
            try {
                // 1. Transfer the script to the remote end-station
                this.GetAccess(ip, username, password);
                this.CopyScript(ip, filename);

                // 2. Executing the script remotely
                String command = "cscript.exe c:\\" + this.ResolveFilename(filename)+ " "+arguments;
                res = this.ExecuteCmd(ip, username, password, command, timeout, duration);
                // 3. Clean up
                this.DeleteScript(ip, filename);
                this.EndAccess(ip);
                
                return res;
            }catch(ManagementException e){
                throw e;
            }      
        }

    #region Execute Script Methods

        public void GetAccess(IPAddress ip, String username, String password){
            String account = "";
            if (username.Length != 0) account = "/user:" + username + " " + password;
            
            //net use \\X.X.X.X\C$ /user:administrator admin
            String command = "net";
            String args = " use \\\\" + ip.ToString() + "\\C$ " + account;
            Debug.WriteLine(command + args);

            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(command, args);
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            p.StartInfo = psi;
            try {
                if (!p.Start())
                    throw new ExecutionFailedException("Getting access to: "+ip.ToString()+ " Failed.");
                p.WaitForExit();
                if(p.ExitCode !=0) throw new ExecutionFailedException("Getting access to: "+ip.ToString()+ " exit with code: "+p.ExitCode);
                p.Close();
            }
            catch(ExecutionFailedException e){
                throw e;
            }
            catch (Exception e) {
                throw new ExecutionFailedException("Getting access to: " + ip.ToString() + " Failed.", e);
            }
        }

        public void EndAccess(IPAddress ip) {

            //net use \\X.X.X.X\C$ /dele
            String command = "net";
            String args = " use \\\\" + ip.ToString() + "\\C$ /dele";
            Debug.WriteLine(command + args);

            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(command, args);
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            p.StartInfo = psi;
            try {
                if (!p.Start()) throw new ExecutionFailedException("Deleting access to: " + ip.ToString() + " Failed.");
                p.WaitForExit();
                if (p.ExitCode != 0) throw new ExecutionFailedException("Deleting access to: " + ip.ToString() + " exit with code: " + p.ExitCode);
                p.Close();
            }
            catch (ExecutionFailedException e) {
                throw e;
            }
            catch (Exception e) {
                throw new ExecutionFailedException("Deleting access to: " + ip.ToString() + " Failed.", e);
            }
        }

        public void CopyScript(IPAddress ip, String filename) {
            //copy <filename> \\X.X.X.X\C$\<filename>
            String resolvedFilename = this.ResolveFilename(filename);
            try {
                File.Copy(filename, "\\\\" + ip.ToString() + "\\C$\\" + resolvedFilename, true);
            }catch(Exception e){
                throw new ExecutionFailedException("Copy script failed.", e);
            }
        }

        public void DeleteScript(IPAddress ip, String filename) {
            //del \\X.X.X.X\C$\<filename>
            String resolvedFilename = this.ResolveFilename(filename);
            try {
                File.Delete("\\\\" + ip.ToString() + "\\C$\\" + resolvedFilename);
            }
            catch (Exception e) {
                throw new ExecutionFailedException("Deleting script failed.", e);
            }
        }

        private String ResolveFilename(String fullPathFilename) {
            int index = fullPathFilename.LastIndexOf("\\");
            if (index >= 0) {
                return fullPathFilename.Substring(index + 1);
            }
            else return fullPathFilename;
        }

    #endregion

    }
}
