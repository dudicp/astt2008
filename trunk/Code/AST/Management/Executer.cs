using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
using System.Threading;

namespace AST.Management
{
    class Executer
    {
        private Action m_action;
        private EndStation m_endstation;
        private Thread m_executionThread;
        private bool m_isRunning;

        public Executer(Action a, EndStation es)
        {
            m_action = a;
            m_endstation = es;
            m_isRunning = true;
            m_executionThread = new Thread(new ThreadStart(ThreadFunc));
            m_executionThread.Start();
        }

        private void ThreadFunc()
        {
            while (m_isRunning) {

                m_executionThread.Suspend();
                
                IServiceProvider provider = WindowsPlatformProvider.GetInstance();

                String command = m_action.GenerateCommand(m_endstation.OSType);

                provider.ExecuteCmd(m_endstation.IP, m_endstation.Username, m_endstation.Password, command);

            }
        }

        public void Execute()
        {
           m_executionThread.Resume();
        }

    }
}
