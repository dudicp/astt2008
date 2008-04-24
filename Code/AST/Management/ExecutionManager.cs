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
        private Executer m_executer;

        public ExecutionManager(int poolSize)
        {
            m_isRunning = true;
            m_executionThread = new Thread(new ThreadStart(MyThreadFunc));
            m_executionThread.Start();
        }

        public ICollection<Result> Results
        {
            get { return m_results; }
            set { m_results = value; }
        }

        public void Execute(AbstractAction action, String name)
        {
            m_executer = new Executer((Action)action, ((Action)action).GetEndStations()[0].EndStation);
            System.Threading.Thread.Sleep(100);
            m_executionThread.Resume();      
        }

        private void MyThreadFunc()
        {
            while (m_isRunning)
            {
                m_executionThread.Suspend();

                //Console.WriteLine("Thread func");
                m_executer.Execute();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
