using System;

namespace AST.Domain{
    /// <summary>
    /// 
    /// </summary>
    public class Result{
        /// <summary>
        /// 
        /// </summary>
        private Action m_action;
        private EndStation m_endStation;
        private DateTime m_startTime;
        private DateTime m_endTime;
        private bool m_status;
        private String m_message;
        private int m_errorCode;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="endStation"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public Result(Action action, EndStation endStation, DateTime startTime, DateTime endTime, bool status, String message, int errorCode)
        {
            m_action = action;
            m_endStation = endStation;
            m_startTime = startTime;
            m_endTime = endTime;
            m_status = status;
            m_message = message;
            m_errorCode = errorCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Action GetAction(){
            return m_action;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EndStation GetEndStation() {
            return m_endStation;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime{
            get { return m_startTime; }
            set { m_startTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime {
            get { return m_endTime; }
            set { m_endTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Status{
            get { return m_status; }
            set { m_status = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Message{
            get { return m_message; }
            set { m_message = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ErrorCode {
            get { return m_errorCode; }
            set { m_errorCode = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String status = "Failed";
            if(m_status)
                status = "Success";

            String res = String.Format("\nAction: {0}\nEnd-Station: {1}\nStart: {2}\tEnd: {3}\nStatus: {4}\nResult: {5} ", m_action.Name, m_endStation, m_startTime, m_endTime, status, m_message);
            return res;
        }
    }
}
