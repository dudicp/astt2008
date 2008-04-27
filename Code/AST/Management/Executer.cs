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
        private int m_endstationIndex;
        ManualResetEvent m_doneEvent;

        public Executer(Action a, int endstationIndex, ManualResetEvent doneEvent)
        {
            m_action = a;
            m_endstationIndex = endstationIndex;
            m_doneEvent = doneEvent; 
        }


        public void ExecuterCallback(Object threadContext)
        {
            EndStation endstation = m_action.GetEndStations()[m_endstationIndex].EndStation;
            IServiceProvider provider = ProviderFactory.GetServiceProvider(EndStation.OSTypeEnum.WINDOWS);
            String command = m_action.GenerateCommand(endstation.OSType);
            provider.ExecuteCmd(endstation.IP, endstation.Username, endstation.Password, command);
            m_doneEvent.Set();
        }

    }
}
