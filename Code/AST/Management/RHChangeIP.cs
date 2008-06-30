using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
using System.Net;

namespace AST.Management {

    class RHChangeIP: IResultHandler {

        //The Parameter which holds the new IP address as input.
        private const String NEW_IP_PARAMETER = "NewIP";

        //only in-case where we change to the same IP as before,
        private const int SUCCESS_ERROR_CODE = 0;

        //in-case the IP address success the psexec return error code 64
        //cause it lost the connection to the old IP address
        //and all the output of the script is lost also.
        private const int PSEXEC_CONNECTION_FAILED = 64;

        private static RHChangeIP m_instance = null;

        public Result CheckResult(Action action, EndStation endStation, DateTime startTime, DateTime endTime, string message, int errorCode) {
            if ((endStation.OSType == EndStation.OSTypeEnum.WINDOWS) && 
                (errorCode != SUCCESS_ERROR_CODE) && 
                (errorCode != PSEXEC_CONNECTION_FAILED))

                return new Result(action, endStation, startTime, endTime, false, message, errorCode);

            IPAddress NewIP;
            String NewIPStr = "";
            List<Parameter> parameters = action.GetParameters();
            foreach (Parameter p in parameters) {
                if (p.Name == NEW_IP_PARAMETER) NewIPStr = p.Input;
            }

            try {
                NewIP = IPAddress.Parse(NewIPStr);
                message = "Change IPAddress to End-Station " + endStation.Name + "(" + endStation.ID + ")" + " from: " + endStation.IP.ToString() + " to: " + NewIPStr + " Success.";
                endStation.IP = NewIP;
                ASTManager.GetInstance().AddEndStation(endStation, false);
                return new Result(action, endStation, startTime, endTime, true, message, errorCode);
            }
            catch (Exception e) {
                message = "Change IPAddress to End-Station " + endStation.Name + "(" + endStation.ID + ")" + " from: " + endStation.IP.ToString() + " to: " + NewIPStr + " Success, but couldn't store in the local database.";
                return new Result(action, endStation, startTime, endTime, false, message, errorCode);
            }

        }

        internal static IResultHandler GetInstance() {
            if (m_instance == null)
                m_instance = new RHChangeIP();
            return m_instance;
        }
    }
}
