using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
using System.Net;

namespace AST.Management {
    /// <summary>
    /// 
    /// </summary>
    class SetIPRH : IResultHandler {
        /// <summary>
        /// 
        /// </summary>
        private static SetIPRH m_instance = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="endStation"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Result CheckResult(Action action, EndStation endStation, DateTime startTime, DateTime endTime, string message) {
            List<Parameter> parameters = action.GetParameters();
            String NewIPStr = "";
            foreach (Parameter p in parameters) {
                if (p.Name == "NewIP") NewIPStr = p.Input;
            }

            IPAddress NewIP;
            try{
                NewIP = IPAddress.Parse(NewIPStr);
                message = "Set IPAddress to End-Station " + endStation.Name + "(" + endStation.ID + ")" + " from: " + endStation.IP.ToString() + " to: " + NewIPStr + " Success.";
                endStation.IP = NewIP;
                ASTManager.GetInstance().AddEndStation(endStation, false);
                return new Result(action, endStation, startTime, endTime, true, message);
            }
            catch(Exception e) {
                message = "Set IPAddress to End-Station " + endStation.Name + "(" + endStation.ID + ")" + " from: " + endStation.IP.ToString() + " to: " + NewIPStr + " Failed.";
                return new Result(action, endStation, startTime, endTime, false, message);
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static IResultHandler GetInstance() {
            if (m_instance == null)
                m_instance = new SetIPRH();
            return m_instance;
        }
    }
}
