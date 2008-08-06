using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace AST.Management {

    class RHDynamicChangeIP : IResultHandler {

        //The Parameter which holds the new IP address as input.
        private const String SHARED_FOLDER_PATH = "SharedFolderPath";


        //in-case the IP address success the psexec return error code 64
        //cause it lost the connection to the old IP address
        //and all the output of the script is lost also.
        private const int PSEXEC_CONNECTION_FAILED = 64;

        private static RHDynamicChangeIP m_instance = null;

        public Result CheckResult(Action action, EndStation endStation, DateTime startTime, DateTime endTime, string message, int errorCode) {
            if ((endStation.OSType == EndStation.OSTypeEnum.WINDOWS) &&
                (errorCode != PSEXEC_CONNECTION_FAILED))

                return new Result(action, endStation, startTime, endTime, false, message, errorCode);

            String sharedFolderPath = "";
            List<Parameter> parameters = action.GetParameters();
            foreach (Parameter p in parameters) {
                if (p.Name == SHARED_FOLDER_PATH) sharedFolderPath = p.Input;
            }

            //Fixing the slash problem
            if ((sharedFolderPath[sharedFolderPath.Length - 1] != '\\') &&
                (sharedFolderPath[sharedFolderPath.Length - 1] != '/')) {

                sharedFolderPath = sharedFolderPath + "\\";
            }

            try {
                TextReader tr = new StreamReader(sharedFolderPath + endStation.ID + ".txt");
                String res = tr.ReadLine();
                tr.Close();
                try {
                    File.Delete(sharedFolderPath + endStation.ID + ".txt");
                }
                catch (Exception e) {
                    Debug.WriteLine(e.Message);
                }

                //Checking for any errors
                if (res[0] == '-') {
                    return new Result(action, endStation, startTime, endTime, false, res, -1);
                }

                IPAddress NewIP = IPAddress.Parse(res);
                message = "Dynamic Change IPAddress to End-Station " + endStation.Name + "(" + endStation.ID + ")" + " from: " + endStation.IP.ToString() + " to: " + res + " Success.";
                endStation.IP = NewIP;
                ASTManager.GetInstance().AddEndStation(endStation, false);
                return new Result(action, endStation, startTime, endTime, true, message, 0);
            }
            catch (FormatException e) {
                message = "Change IPAddress to End-Station " + endStation.Name + "(" + endStation.ID + ")" + " Failed.";
                return new Result(action, endStation, startTime, endTime, false, message, errorCode);
            }
            catch (Exception e) {
                message = "Change IPAddress to End-Station " + endStation.Name + "(" + endStation.ID + ")" + " Success, but couldn't store in the local database.";
                return new Result(action, endStation, startTime, endTime, false, message, errorCode);
            }

        }

        internal static IResultHandler GetInstance() {
            if (m_instance == null)
                m_instance = new RHDynamicChangeIP();
            return m_instance;
        }
    }
}
