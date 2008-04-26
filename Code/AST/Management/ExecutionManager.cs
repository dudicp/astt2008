using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AST.Domain;
using System.Threading;

using System.Windows.Forms;

namespace AST.Management
{
    class ExecutionManager
    {
        private ICollection<Result> m_results;
        private Thread m_executionThread;
        private bool m_isRunning;
        private Action m_action;
        private String m_reportName;


        public ExecutionManager(int poolSize)
        {
            m_isRunning = true;
            m_executionThread = new Thread(new ThreadStart(ExecuterThreadFunc));
            m_executionThread.Start();
            m_action = null;

        }

        public ICollection<Result> Results
        {
            get { return m_results; }
            set { m_results = value; }
        }

        public void Execute(AbstractAction action, String name)
        {
            
            m_action = (Action)action;
            m_reportName = name;
            System.Threading.Thread.Sleep(100);
            m_executionThread.Resume();      
        }

        private void ExecuterThreadFunc()
        {
            while (m_isRunning)
            {
                m_executionThread.Suspend();

                int length = ((Action)m_action).GetEndStations().ToArray().Length;
                ManualResetEvent[] doneEvents = new ManualResetEvent[length];
                for (int i = 0; i < length; i++)
                {
                    doneEvents[i] = new ManualResetEvent(false);
                    Executer executer = new Executer(m_action,i, doneEvents[i]);
                    ThreadPool.QueueUserWorkItem(executer.ExecuterCallback, null);
                }

                WaitHandle.WaitAll(doneEvents);

            }
        }

            //int length = ((Action)action).GetEndStations().ToArray().Length;
            //ManualResetEvent[] doneEvents = new ManualResetEvent[length];
            //for (int i = 0; i < length; i++)
            //{
            //    doneEvents[i] = new ManualResetEvent(false);
            //    Executer executer = new Executer(action,i, doneEvents[i]);
            //    ThreadPool.QueueUserWorkItem(executer.ThreadPoolCallback);
 
    }
}
