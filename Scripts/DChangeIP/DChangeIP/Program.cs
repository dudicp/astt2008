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
            Console.WriteLine("\nUsage: DChangeIP <shared_folder> <end-station id>\n");
            Console.WriteLine(" <shared_folder>\tThe network path to write the new IP address.");
            Console.WriteLine(" <end-station id>\tThe ID of the end-station in the AST database.");
            Console.WriteLine("\n\n This command will release the current IP and renew it,\n if success it will write the new IP in \\\\<shared_folder>\\<end-station id> \n otherwise, it will return a non-positive error code.");
        }

        static int Main(string[] args) {

            if (args.Length < 2) {
                Usage();
                return DCIP_FAIL;
            }

            String shardFolderPath = args[0];
            String endStationID = args[1];

            //Fixing the slash problem
            if ((shardFolderPath[shardFolderPath.Length - 1] != '\\') &&
                (shardFolderPath[shardFolderPath.Length - 1] != '/')) {

                shardFolderPath = shardFolderPath + "\\";
            }
           
            try {

                //1. First we try to open the file in the shared folder.

                TextWriter tw = new StreamWriter(shardFolderPath + endStationID + ".txt", false);

                //2. Execute the 'ipconfig /release' shell command.
                int errorCode = 0;

                String command = "ipconfig";
                String arguments = "/release";

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
                    tw.Close();
                    return DCIP_FAIL;
                }

                if (errorCode != 0) {
                    Console.WriteLine("Could not release the current IP, error code: "+errorCode);
                    tw.Close();
                    return DCIP_FAIL;
                }

                //3. Execute the 'ipconfig /renew' shell command.
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

                //4. Writing the new IP address to the file.
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

                tw.Close();
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
