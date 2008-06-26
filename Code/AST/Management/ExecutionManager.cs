using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AST.Domain;
using System.Threading;

using System.Windows.Forms;
using System.Diagnostics;
using System.Net;

namespace AST.Management{

    class ExecutionManager{

        private Thread m_executionThread;
        private bool m_isRunning;
        private AbstractAction m_action;
        private AbstractAction.AbstractActionTypeEnum m_type;
        private int m_progress;
        private String m_reportName;
        private List<ExecutionManagerOutputListener> m_outputListeners;


        public ExecutionManager(int poolSize){
            m_outputListeners = new List<ExecutionManagerOutputListener>();
            m_isRunning = true;
            m_executionThread = new Thread(new ThreadStart(ExecuterThreadFunc));
            m_executionThread.Start();
            m_action = null;
            m_progress = 0;
        }

        public void Execute(AbstractAction action, AbstractAction.AbstractActionTypeEnum type, String reportName){
            m_action = action;
            m_reportName = reportName;
            m_type = type;
            m_progress = 0;
            System.Threading.Thread.Sleep(100);
            m_executionThread.Resume();      
        }

        public void Kill() {
            m_isRunning = false;
            System.Threading.Thread.Sleep(100);
            m_executionThread.Resume();
        }

 /*       private void ExecuterThreadFunc(){
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
                    Debug.WriteLine("Sleeping for " + action.Delay + " sec");
                    System.Threading.Thread.Sleep(action.Delay * 1000);
                }

                foreach (Object res in m_results)
                {
                    Debug.WriteLine(((Result)res).ToString());
                }

                m_results.Clear();
                
            }
        }*/

        private void ExecuterThreadFunc() {
            while (m_isRunning) {
                m_executionThread.Suspend();
                switch (m_type) {
                    case AbstractAction.AbstractActionTypeEnum.ACTION:
                        Execute((Action)m_action);
                        break;
                    case AbstractAction.AbstractActionTypeEnum.TSC:
                        Execute((TSC)m_action);
                        break;
                    case AbstractAction.AbstractActionTypeEnum.TP:
                        Execute((TP)m_action);
                        break;
                    default: break;
                }
                foreach (ExecutionManagerOutputListener o in m_outputListeners)
                    o.ExecutionFinish();
            }
        }


        private void Execute(Action action){
            foreach (ExecutionManagerOutputListener o in m_outputListeners)
                o.UpdateCurrrentAction(action.Name, m_action.GetActions().Count);

            Queue resultsQueue = Queue.Synchronized(new Queue());

            //In-case we are in Test Script, we need only to run on the local machine.
            if (action.ActionType == Action.ActionTypeEnum.TEST_SCRIPT) {
                action.ClearEndStations();
                action.AddEndStation(new EndStationSchedule(new EndStation(0,"LocalHost",IPAddress.Parse("127.0.0.1"),EndStation.OSTypeEnum.WINDOWS,"","",false)));
            }

            int length = action.GetEndStations().Count;
            ManualResetEvent[] doneEvents = new ManualResetEvent[length];

            for (int i = 0; i < length; i++) {
              doneEvents[i] = new ManualResetEvent(false);
              Executer executer = new Executer(action, i, doneEvents[i], resultsQueue);
              ThreadPool.QueueUserWorkItem(executer.ExecuterCallback, null);
            }

            WaitHandle.WaitAll(doneEvents);
            Debug.WriteLine("Sleeping for " + action.Delay + " sec");
            System.Threading.Thread.Sleep(action.Delay * 1000);

            foreach (Result res in resultsQueue) {
                Debug.WriteLine(((Result)res).ToString());
                
                //Update the report file
                ASTManager.GetInstance().Save(res, this.m_reportName);
            }

            //Update the screen
            m_progress++;
            double progress = ((double)m_progress) / ((double)(m_action.GetActions().Count));
            foreach (ExecutionManagerOutputListener o in m_outputListeners)
                o.UpdateProgress((int)(progress * 100), resultsQueue);
        }

        private void Execute(TSC tsc) {
            List<Action> actions = tsc.GetActions();
            foreach (Action a in actions)
                Execute(a);
        }

        private void Execute(TP tp) {
            List<TSC> TSCs = tp.GetTSCs();
            foreach (TSC tsc in TSCs)
                Execute(tsc);
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
