using System;

namespace AST.Domain{

    public class Result{

        private Action m_action;
        private DateTime m_executionTime;
        private bool m_status;
        private String m_message;

        public Result(Action action,DateTime executionTime, bool status, String message)
        {
            m_action = action;
            m_executionTime = executionTime;
            m_status = status;
            m_message = message;
        }

        public Action GetAction()
        {
            return m_action;
        }

        public DateTime ExecutionTime
        {
            get { return m_executionTime; }
            set { m_executionTime = value; }
        }

        public bool Status
        {
            get { return m_status; }
            set { m_status = value; }
        }

        public String Message
        {
            get { return m_message; }
            set { m_message = value; }
        }
    }
}
