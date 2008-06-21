using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AST.Domain;
using System.Threading;

using System.Windows.Forms;
using System.Diagnostics;

namespace AST.Management
{
    class ExecutionManager
    {
        private Thread m_executionThread;
        private bool m_isRunning;
        private AbstractAction m_action;
        private List<Action> m_actions;
        private String m_reportName;
        private List<ExecutionManagerOutputListener> m_outputListeners;
        private Queue m_results;


        public ExecutionManager(int poolSize)
        {
            m_outputListeners = new List<ExecutionManagerOutputListener>();
            m_isRunning = true;
            m_executionThread = new Thread(new ThreadStart(ExecuterThreadFunc));
            m_executionThread.Start();
            m_action = null;
            
            m_results = Queue.Synchronized(new Queue());            

        }

        public Queue Results
        {
            get { return m_results; }
            set { m_results = value; }
        }

        public void Execute(AbstractAction action, String name)
        {
            m_action = action;
            m_reportName = name;
            System.Threading.Thread.Sleep(100);
            m_executionThread.Resume();      
        }

        private void ExecuterThreadFunc()
        {
            List<Action> actions;
            while (m_isRunning)
            {
                m_executionThread.Suspend();
                actions = m_action.GetActions();

                foreach (Action action in actions)
                {
                    int length = action.GetEndStations().ToArray().Length;
                    ManualResetEvent[] doneEvents = new ManualResetEvent[length];
                    for (int i = 0; i < length; i++)
                    {
                        doneEvents[i] = new ManualResetEvent(false);
                        Executer executer = new Executer(action, i, doneEvents[i], m_results);
                        ThreadPool.QueueUserWorkItem(executer.ExecuterCallback, null);
                    }

                    WaitHandle.WaitAll(doneEvents);
                    Debug.WriteLine("Sleeping for " + action.Timeout + " sec");
                    System.Threading.Thread.Sleep(action.Timeout * 1000);
                }

                foreach (Object res in m_results)
                {
                    Debug.WriteLine(((Result)res).ToString());
                }

                m_results.Clear();
                
            }
        }

        public void AddOutputListener(ExecutionManagerOutputListener o) {
            this.m_outputListeners.Add(o);
        }

        public void RemoveOutputListener(ExecutionManagerOutputListener o) {
            this.m_outputListeners.Remove(o);
        }

        public void RemoveAllOutputListeners() {
            this.m_outputListeners.Clear();
        }
    }
}
