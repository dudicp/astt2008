using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace AST.Management{
    /// <summary>
    /// 
    /// </summary>
    class WindowsPlatformProvider : IServiceProvider{


        private const String EXECUTE_COMMAND = "\\psexec.exe";
        private const String KILL_COMMAND = "\\pskill.exe";
        private const String SCRIPT_FILENAME = "ASTScript.vbs";
        private const int CONNECTION_TIMEOUT1 = 1460;
        private const int CONNECTION_TIMEOUT2 = 1722;
        private const int NOT_REACHABLE = 1006;
        private static WindowsPlatformProvider m_instance = null;
        /// <summary>
        /// 
        /// </summary>
        private WindowsPlatformProvider(){}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static WindowsPlatformProvider GetInstance(){
            if (m_instance == null) 
                m_instance = new WindowsPlatformProvider();
            return m_instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cmd"></param>
        /// <param name="timeout"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public String ExecuteCmd(IPAddress ip, String username, String password, String cmd, int timeout, int duration, out int errorCode){

           String res = "";
           errorCode = 0;

           String PSToolsCommand = ConfigurationManager.GetPSToolsFullPath() + EXECUTE_COMMAND;
           if (!File.Exists(PSToolsCommand)) throw new FileNotExistException("The file " + PSToolsCommand + " isn't found.");

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
                   p.WaitForExit();
                   res = p.StandardOutput.ReadToEnd();
                   errorCode = p.ExitCode;
                   if ((errorCode == CONNECTION_TIMEOUT1) || (errorCode == CONNECTION_TIMEOUT2))
                       throw new ExecutionFailedException("Timeout accessing "+ip.ToString());
                   if (errorCode == NOT_REACHABLE)
                       throw new ExecutionFailedException("Couldn't access: " + ip.ToString() + "\nThe network path was not found.");
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
               throw new ExecutionFailedException("Unknown error occured during the execution.", e);
           }
           return res;
        }


        public String ExecuteBatch(IPAddress ip, String username, String password, String filename, int timeout, int duration, out int errorCode) {
            if (!File.Exists(filename)) throw new FileNotExistException("The batch file " + filename + " isn't found.");

            String res = "";
            try {
                String command = " -c "+filename;
                res = this.ExecuteCmd(ip, username, password, command, timeout, duration, out errorCode);
                return res;
            }
            catch (ManagementException e) {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="filename"></param>
        /// <param name="arguments"></param>
        /// <param name="timeout"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public String ExecuteScript(IPAddress ip, String username, String password, String filename, String arguments, int timeout, int duration, out int errorCode)
        {
            String res = "";
            try {
                // 1. Transfer the script to the remote end-station
                //this.GetAccess(ip, username, password);
                //this.CopyScript(ip, filename);

                // 2. Executing the script remotely
                //String command = "cscript.exe c:\\" + this.ResolveFilename(filename)+ " "+arguments;
                String command = "cscript.exe c:\\" + SCRIPT_FILENAME + " " + arguments;
                res = this.ExecuteCmd(ip, username, password, command, timeout, duration, out errorCode);
                // 3. Clean up
                //this.DeleteScript(ip, filename);
                //this.EndAccess(ip);
                
                return res;
            }catch(ManagementException e){
                throw e;
            }      
        }

    #region Execute Script Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="filename"></param>
        public void CopyScript(IPAddress ip, String filename, String username, String password) {
            //copy <filename> \\X.X.X.X\C$\<filename>
            if (!File.Exists(filename)) throw new FileNotExistException("The script file " + filename + " isn't found.");
            try {
                this.GetAccess(ip, username, password);
                File.Copy(filename, "\\\\" + ip.ToString() + "\\C$\\" + SCRIPT_FILENAME, true);
                this.EndAccess(ip);
            }
            catch (FileNotExistException e) {
                throw e; 
            }catch (ManagementException e) {
                throw e;
            }catch(Exception e){
                throw new ExecutionFailedException("Unknown error occured during copying the script file "+ filename +".", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="filename"></param>
        public void DeleteScript(IPAddress ip, String filename) {
            //del \\X.X.X.X\C$\<filename>
            //String resolvedFilename = this.ResolveFilename(filename);
            try {
                File.Delete("\\\\" + ip.ToString() + "\\C$\\" + SCRIPT_FILENAME);
                this.EndAccess(ip);
            }
            catch (ManagementException e) {
                throw e;
            }catch (Exception e) {
                throw new ExecutionFailedException("Deleting script failed.", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullPathFilename"></param>
        /// <returns></returns>
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
