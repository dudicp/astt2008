using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;

namespace AST.Management
{
    class ResultHandler : IResultHandler
    {

        private static ResultHandler m_instance = null;

        public Result CheckResult(Action action, EndStation endStation, DateTime startTime, DateTime endTime, string message)
        {
            String validityString, msg;
            bool status;
            
            validityString = action.GetValidityString(endStation.OSType).ToLower();
            msg = message.ToLower();
            status = msg.Contains(validityString);
            return new Result(action, endStation, startTime, endTime, status, message);
        }

        internal static IResultHandler GetInstance()
        {
            if (m_instance == null)
                m_instance = new ResultHandler();
            return m_instance;
        }
    }
}
