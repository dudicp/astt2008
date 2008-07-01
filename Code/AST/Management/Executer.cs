using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.IO;

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
                        msg = provider.ExecuteScript(endstation.IP, endstation.Username, endstation.Password, filename, command, m_action.Timeout, m_action.Duration, out errorCode);
                        endTime = DateTime.Now;
                        res = resultHandler.CheckResult(m_action, endstation, startTime, endTime, msg, errorCode);
                        // 3. Clean up
                        //provider.DeleteScript(endstation.IP, filename);
                        break;
                    case Action.ActionTypeEnum.TEST_SCRIPT:
                        //Executing the test script localy.
                        msg = this.ExecuteTestScript(m_action.GetContent(endstation.OSType), command, out errorCode);
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


        /// <summary>
        /// This method responsible to excecute a Test Script on the local machine, without using the
        /// Service Provider. It execute vbscript files and return the error code return and the output.
        /// </summary>
        /// <param name="filename">The full path filename of the test script.</param>
        /// <param name="arguments">The arguments for this script, with spaces between each one.</param>
        /// <param name="errorCode">Output parameter: the error code return.</param>
        /// <returns>The output of the execution.</returns>
        private String ExecuteTestScript(String filename, String arguments, out int errorCode) {
            String res = "";
            errorCode = 0;
            if (!File.Exists(filename)) throw new FileNotExistException("The script file: " + filename + " doesn't found.");

            String command = "cscript.exe";
            String args = " " + filename + " " + arguments;
            Debug.WriteLine(command + args);

            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(command, args);
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            p.StartInfo = psi;

            try {
                p.Start();
                //p.WaitForExit();
                res = p.StandardOutput.ReadToEnd();
                errorCode = p.ExitCode;
                Debug.WriteLine("output:\n" + res);
                p.Close();
            }
            catch (FileNotExistException e) { throw e; }
            catch (Exception e) {
                throw new ExecutionFailedException("Could not start process.", e);
            }
            return res;
        }
    }
}
