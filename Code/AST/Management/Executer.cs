using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
using System.Threading;
using System.Collections;

namespace AST.Management
{
    /// <summary>
    /// responsible for execution a single action on a remote end-station
    /// </summary>
    class Executer
    {
        private Action m_action;
        private int m_endstationIndex;
        ManualResetEvent m_doneEvent;
        Queue m_results;

        /// <summary>
        /// CTor for the executor
        /// </summary>
        /// <param name="a">the action to execute</param>
        /// <param name="endstationIndex">the index of the end-station</param>
        /// <param name="doneEvent">the event that signals when the execution is done</param>
        /// <param name="results">the results queue</param>
        public Executer(Action a, int endstationIndex, ManualResetEvent doneEvent, Queue results)
        {
            m_action = a;
            m_endstationIndex = endstationIndex;
            m_doneEvent = doneEvent;
            m_results = results;
        }

        /// <summary>
        /// method for executing an action
        /// this method is sent to the thread pool to be executed when a thread in the pool is free.
        /// </summary>
        /// <param name="threadContext">null</param>
        public void ExecuterCallback(Object threadContext)
        {
            Result res;
            String msg = "";
            EndStation endstation = m_action.GetEndStations()[m_endstationIndex].EndStation;

            // getting the provider that execute the action
            IServiceProvider provider = ProviderFactory.GetServiceProvider(EndStation.OSTypeEnum.WINDOWS);
            // getting the result handler for the executed action 
            IResultHandler resultHandler = ResultHandlerFactory.GetResultHandler(m_action);
            // generation the command to be executed.
            String command = m_action.GenerateCommand(endstation.OSType);

            DateTime startTime = DateTime.Now;
            DateTime endTime;
            int errorCode;
            try {
                switch (m_action.ActionType)
                {
                    case Action.ActionTypeEnum.COMMAND_LINE:
                        msg = provider.ExecuteCmd(endstation.IP, endstation.Username, endstation.Password, command, m_action.Timeout, m_action.Duration, out errorCode);
                        endTime = DateTime.Now;
                        res = resultHandler.CheckResult(m_action, endstation, startTime, endTime, msg, errorCode);
                        break;
                    case Action.ActionTypeEnum.SCRIPT:
                        String filename = m_action.GetContent(endstation.OSType);
                        // 1. Transfer the script to the remote end-station
                        provider.CopyScript(endstation.IP, filename, endstation.Username, endstation.Password);
                        // 2. Executing the script remotely
                        msg = provider.ExecuteScript(endstation.IP, endstation.Username, endstation.Password, m_action.GetContent(endstation.OSType), command, m_action.Timeout, m_action.Duration, out errorCode);
                        endTime = DateTime.Now;
                        res = resultHandler.CheckResult(m_action, endstation, startTime, endTime, msg, errorCode);
                        // 3. Clean up
                        //provider.DeleteScript(endstation.IP, filename);
                        break;
                    case Action.ActionTypeEnum.TEST_SCRIPT:
                        msg = provider.ExecuteScript(endstation.IP, endstation.Username, endstation.Password, m_action.GetContent(endstation.OSType), command, m_action.Timeout, m_action.Duration, out errorCode);
                        endTime = DateTime.Now;
                        res = resultHandler.CheckResult(m_action, endstation, startTime, endTime, msg, errorCode);
                        break;
                    default:
                        res = new Result(m_action, endstation, startTime, startTime, false, "Not a valid action type.", 0);
                        break;
                }
            }
            catch (ManagementException e)
            {
                res = new Result(m_action, endstation, startTime, startTime, false, e.Message,0);
            }
            // put the result in the results queue
            m_results.Enqueue(res);
            // set the event for finished execution.
            m_doneEvent.Set();
        }

    }
}
