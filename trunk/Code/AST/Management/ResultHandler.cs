using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;

namespace AST.Management
{
    /// <summary>
    /// 
    /// </summary>
    class ResultHandler : IResultHandler
    {
        /// <summary>
        /// 
        /// </summary>
        private static ResultHandler m_instance = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="endStation"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Result CheckResult(Action action, EndStation endStation, DateTime startTime, DateTime endTime, string message)
        {
            String validityString, msg;
            bool status;
            
            validityString = action.GetValidityString(endStation.OSType).ToLower();
            msg = message.ToLower();
            status = msg.Contains(validityString);
            return new Result(action, endStation, startTime, endTime, status, message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static IResultHandler GetInstance()
        {
            if (m_instance == null)
                m_instance = new ResultHandler();
            return m_instance;
        }
    }
}
