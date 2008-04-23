using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
using System.Threading;

namespace AST.Management
{
    class Executer
    {
        private String m_cmd;
        private EndStation m_endstation;
        private Thread m_executionThread;

        public Executer()
        {
            m_executionThread = new Thread(new ThreadStart(ThreadFunc)); 
        }

        private void ThreadFunc()
        {
            
            IServiceProvider provider = WindowsPlatformProvider.GetInstance();
            provider.ExecuteCmd(null, "", "", "");
        }

        public void Execute(String cmd, EndStation endstation)
        {
           // m_executionThread.Resume();
            IServiceProvider provider = WindowsPlatformProvider.GetInstance();
            provider.ExecuteCmd(null, "", "", "");
        }

    }
}
