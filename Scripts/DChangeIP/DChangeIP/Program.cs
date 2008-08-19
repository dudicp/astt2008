using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace DChangeIP {

    class Program {

        public const int DCIP_OK = 0;
        public const int DCIP_FAIL = -1;
        public const int DCIP_DIR_NOT_FOUND = -2;
        public const int DCIP_FILE_NOT_FOUND = -3;
        public const int DCIP_UNAUTHORIZE_ACCESS = -4;


        static void Usage() {
            Console.WriteLine("\nUsage: DChangeIP.exe <computer_name> <shared_name> \n\t\t\t<username> <password> <end-station id>\n");
            Console.WriteLine(" <computer_name>\tThe name of the computer holds the shared folder\n\t\t\t(can be also IP address).");
            Console.WriteLine(" <shared_name>\t\tThe shared folder name on the computer name,\n\t\t\tthis is the path to write the new IP address.");
            Console.WriteLine(" <username>\t\tThe username for the computer_name.");
            Console.WriteLine(" <password>\t\tThe password for the computer_name.");
            Console.WriteLine(" <end-station id>\tThe ID of the end-station in the AST database.");
            Console.WriteLine("\n\n This command will release the current IP and renew it,\n if success it will write the new IP in \\\\<shared_folder>\\<end-station id> \n otherwise, it will return a non-positive error code.");
        }

        static int Main(string[] args) {

            if ((args.Length < 3)||(args.Length > 5)) {
                Usage();
                return DCIP_FAIL;
            }
            else if (args.Length == 4) {
                Console.WriteLine("you can't enter username without password.\n");
                return DCIP_FAIL;
            }

            String computerName = args[0];
            String shardFolderName = args[1];
            String endStationID = args[2];
            String username = "";
            String password = "";
            String account = "";

            //in-case we selected the optional username and password parameters.
            if (args.Length == 5) {
                username = args[2];
                password = args[3];
                endStationID = args[4];
                account = "/user:" + username + " " + password;
            }

            //Fixing the slash problem - removing the last slash
            if ((shardFolderName[shardFolderName.Length - 1] == '\\') ||
                (shardFolderName[shardFolderName.Length - 1] == '/')) {

                shardFolderName = shardFolderName.Substring(0,shardFolderName.Length - 1);
            }
           
            try {

                //1. First we try to get access to the shared folder.
                int errorCode = 0;

                String command = "net";
                String arguments = "use \\\\" + computerName + "\\" + shardFolderName + " " + account;

                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(command, arguments);
                psi.CreateNoWindow = false;
                psi.UseShellExecute = false;
                p.StartInfo = psi;

                try {
                    p.Start();
                    p.WaitForExit();
                    errorCode = p.ExitCode;
                    p.Close();
                }
                catch (Exception e) {
                    Console.WriteLine("Could not start process: " + e);
                    return DCIP_FAIL;
                }

                if (errorCode != 0) {
                    Console.WriteLine("Could not get access to the shared folder, error code: " + errorCode);
                    return DCIP_FAIL;
                }


                //2. Second we try to open a file in the shared folder.

                TextWriter tw = new StreamWriter("\\\\" + computerName + "\\" + shardFolderName +"\\"+ endStationID + ".txt", false);

                //3. Execute the 'ipconfig /release' shell command.
                errorCode = 0;

                command = "ipconfig";
                arguments = "/release";

                p = new Process();
                psi = new ProcessStartInfo(command, arguments);
                psi.CreateNoWindow = false;
                psi.UseShellExecute = false;
                p.StartInfo = psi;

                try {
                    p.Start();
                    p.WaitForExit();
                    errorCode = p.ExitCode;
                    p.Close();
                }
                catch (Exception e) {
                    Console.WriteLine("Could not start process: " + e);
                    tw.Close();
                    return DCIP_FAIL;
                }

                if (errorCode != 0) {
                    Console.WriteLine("Could not release the current IP, error code: "+errorCode);
                    tw.Close();
                    return DCIP_FAIL;
                }

                //4. Execute the 'ipconfig /renew' shell command.
                errorCode = 0;

                command = "ipconfig";
                arguments = "/renew";

                p = new Process();
                psi = new ProcessStartInfo(command, arguments);
                psi.CreateNoWindow = false;
                psi.UseShellExecute = false;
                p.StartInfo = psi;

                try {
                    p.Start();
                    p.WaitForExit();
                    errorCode = p.ExitCode;
                    p.Close();
                }
                catch (Exception e) {
                    Console.WriteLine("Could not start process: " + e);
                    tw.WriteLine(""+DCIP_FAIL+": Could not start process: " + e);
                    tw.Close();
                    return DCIP_FAIL;
                }

                if (errorCode != 0) {
                    Console.WriteLine("Could not renew IP, error code: " + errorCode);
                    tw.WriteLine("" + DCIP_FAIL + ": Could not renew IP, error code: " + errorCode);
                    tw.Close();
                    return DCIP_FAIL;
                }

                //5. Writing the new IP address to the file.
                IPHostEntry ip = Dns.GetHostEntry(Dns.GetHostName());

                IPAddress[] IPaddr = ip.AddressList;

                if (IPaddr.Length > 0)
                    tw.WriteLine(IPaddr[0].ToString());
                else {
                    Console.WriteLine("Couldn't find the new IP address.");
                    tw.WriteLine("" + DCIP_FAIL + ": Couldn't find the new IP address.");
                    tw.Close();
                    return DCIP_FAIL;
                }

                try {
                    tw.Close();
                }
                catch (Exception e) { tw.Close(); }


                //6. Closing the connection to the shared folder.
                errorCode = 0;

                command = "net";
                arguments = "use \\\\" + computerName + "\\" + shardFolderName + " /delete";

                p = new Process();
                psi = new ProcessStartInfo(command, arguments);
                psi.CreateNoWindow = false;
                psi.UseShellExecute = false;
                p.StartInfo = psi;

                try {
                    p.Start();
                    p.WaitForExit();
                    errorCode = p.ExitCode;
                    p.Close();
                }
                catch (Exception e) {
                    Console.WriteLine("Could not start process: " + e);
                    return DCIP_FAIL;
                }

                if (errorCode != 0) {
                    Console.WriteLine("Could not end the connection to the shared folder, error code: " + errorCode);
                    return DCIP_FAIL;
                }
            }

            // all this exceptions we will get before trying to change the IP address.
            catch (DirectoryNotFoundException e) {
                Console.WriteLine(e.Message);
                return DCIP_DIR_NOT_FOUND;
            }
            catch (UnauthorizedAccessException e) {
                Console.WriteLine(e.Message);
                return DCIP_UNAUTHORIZE_ACCESS;
            }
            catch (FileNotFoundException e) {
                Console.WriteLine(e.Message);
                return DCIP_FILE_NOT_FOUND;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return DCIP_FAIL;
            }

            return DCIP_OK;

        }
    }
}
