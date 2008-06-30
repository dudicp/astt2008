using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AST.Domain;
using System.Threading;

using System.Windows.Forms;
using System.Diagnostics;
using System.Net;

namespace AST.Management
{

    /// <summary>
    /// responsible for managing the execution process 
    /// </summary>
    class ExecutionManager
    {

        private Thread m_executionThread;
        private bool m_isRunning;
        private AbstractAction m_action;
        private AbstractAction.AbstractActionTypeEnum m_type;
        private int m_progress;
        private String m_reportName;
        private List<ExecutionManagerOutputListener> m_outputListeners;

        /// <summary>
        /// CTor for the ExecutionManager
        /// </summary>
        /// <param name="poolSize">the number of maximum threads in the thread pool</param>
        public ExecutionManager(int poolSize)
        {
            m_outputListeners = new List<ExecutionManagerOutputListener>();
            m_isRunning = true;
            m_executionThread = new Thread(new ThreadStart(ExecuterThreadFunc));
            m_executionThread.Start();
            m_action = null;
            m_progress = 0;
        }

        /// <summary>
        /// method for starting the process of execution of an AbstractAction
        /// the method resumes the suspended thread and the thread performes another itteration in the loop
        /// </summary>
        /// <param name="action">the AbstractAction to execute</param>
        /// <param name="type">the action type (Action\TSC\TP)</param>
        /// <param name="reportName">the name of the report file</param>
        public void Execute(AbstractAction action, AbstractAction.AbstractActionTypeEnum type, String reportName)
        {
            // sets the executer member for the current execution run 
            m_action = action;
            m_reportName = reportName;
            m_type = type;
            m_progress = 0;
            System.Threading.Thread.Sleep(100);
            // resumes the hread for another itteration
            m_executionThread.Resume();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Kill()
        {
            // YC
//           m_isRunning = false;
//           System.Threading.Thread.Sleep(100);
//            m_executionThread.Resume();
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
        /// <summary>
        /// the Execution manager thread
        /// created at the start of the application and get suspended at the start
        /// for every execution of an AbstractAction it resumes for 1 itteration of the loop and then gets back to suspend mode
        /// </summary>
        private void ExecuterThreadFunc()
        {
            while (m_isRunning)
            {
                // suspend till next execution request
                m_executionThread.Suspend();
                
                // execute the Abstract action by its type.
                switch (m_type)
                {
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
                // notifying each ExecutionManagerOutputListener that execution is finished by invoking the ExecutionFinish method
                foreach (ExecutionManagerOutputListener o in m_outputListeners)
                    o.ExecutionFinish();
            }
        }
        /// <summary>
        /// method for executing an Action
        /// </summary>
        /// <param name="action">the Action to execute</param>
        private void Execute(Action action)
        {
            // notify the output listeners on the current action thats being executed 
            foreach (ExecutionManagerOutputListener o in m_outputListeners)
                o.UpdateCurrrentAction(action.Name, m_action.GetActions().Count);

            Queue resultsQueue = Queue.Synchronized(new Queue());

            //In-case we are in Test Script, we need only to run on the local machine.
            if (action.ActionType == Action.ActionTypeEnum.TEST_SCRIPT)
            {
                action.ClearEndStations();
                action.AddEndStation(new EndStationSchedule(new EndStation(0, "LocalHost", IPAddress.Parse("127.0.0.1"), EndStation.OSTypeEnum.WINDOWS, "", "", false)));
            }

            int length = action.GetEndStations().Count;
            ManualResetEvent[] doneEvents = new ManualResetEvent[length];

            for (int i = 0; i < length; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                Executer executer = new Executer(action, i, doneEvents[i], resultsQueue);
                ThreadPool.QueueUserWorkItem(executer.ExecuterCallback, null);
            }

            WaitHandle.WaitAll(doneEvents);
            Debug.WriteLine("Sleeping for " + action.Delay + " sec");
            System.Threading.Thread.Sleep(action.Delay * 1000);

            foreach (Result res in resultsQueue)
            {
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

        /// <summary>
        /// method for executing a TSC
        /// </summary>
        /// <param name="tsc">the TSC to execute</param>
        private void Execute(TSC tsc)
        {
            List<Action> actions = tsc.GetActions();
            foreach (Action a in actions)
                Execute(a);
        }

        /// <summary>
        /// method for executing a TP
        /// </summary>
        /// <param name="tp">the TP to execute</param>
        private void Execute(TP tp)
        {
            List<TSC> TSCs = tp.GetTSCs();
            foreach (TSC tsc in TSCs)
                Execute(tsc);
        }

        /// <summary>
        /// method for registering output listeners to the execution manager
        /// </summary>
        /// <param name="o">the output listener to register</param>
        public void AddOutputListener(ExecutionManagerOutputListener o)
        {
            this.m_outputListeners.Add(o);
        }

        /// <summary>
        /// method for unregistering output listeners to the execution manager
        /// </summary>
        /// <param name="o">the output listener to unregister</param>
        public void RemoveOutputListener(ExecutionManagerOutputListener o)
        {
            this.m_outputListeners.Remove(o);
        }

        /// <summary>
        /// method for unregistering all the output listeners
        /// </summary>
        public void RemoveAllOutputListeners()
        {
            this.m_outputListeners.Clear();
        }
    }
}
