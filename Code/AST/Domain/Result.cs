using System;

namespace AST.Domain{

    public class Result{

        private Action m_action;
        private EndStation m_endStation;
        private DateTime m_startTime;
        private DateTime m_endTime;
        private bool m_status;
        private String m_message;

        public Result(Action action, EndStation endStation, DateTime startTime, DateTime endTime, bool status, String message)
        {
            m_action = action;
            m_endStation = endStation;
            m_startTime = startTime;
            m_endTime = endTime;
            m_status = status;
            m_message = message;
        }

        public Action GetAction(){
            return m_action;
        }

   /*     public DateTime ExecutionTime{
            get { return m_executionTime; }
            set { m_executionTime = value; }
        }
*/
        public bool Status{
            get { return m_status; }
            set { m_status = value; }
        }

        public String Message{
            get { return m_message; }
            set { m_message = value; }
        }

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
