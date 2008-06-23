using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
using System.Threading;
using System.Collections;

namespace AST.Management
{
    class Executer
    {
        private Action m_action;
        private int m_endstationIndex;
        ManualResetEvent m_doneEvent;
        Queue m_results;
        public Executer(Action a, int endstationIndex, ManualResetEvent doneEvent, Queue results)
        {
            m_action = a;
            m_endstationIndex = endstationIndex;
            m_doneEvent = doneEvent;
            m_results = results;
        }


        public void ExecuterCallback(Object threadContext)
        {
            Result res;
            String msg;
            EndStation endstation = m_action.GetEndStations()[m_endstationIndex].EndStation;
            IServiceProvider provider = ProviderFactory.GetServiceProvider(EndStation.OSTypeEnum.WINDOWS);
            IResultHandler resultHandler = ResultHandlerFactory.GetResultHandler(m_action);
            
            String command = m_action.GenerateCommand(endstation.OSType);
            DateTime startTime = DateTime.Now;
            try {
                msg = provider.ExecuteCmd(endstation.IP, endstation.Username, endstation.Password, command, m_action.Timeout, m_action.Duration);
                DateTime endTime = DateTime.Now;
                res = resultHandler.CheckResult(m_action, endstation, startTime, endTime, msg);
            }
            catch (ManagementException e) {
                res = new Result(m_action, endstation, startTime, startTime, false, e.Message);
            }
            m_results.Enqueue(res);
            m_doneEvent.Set();
        }

    }
}
