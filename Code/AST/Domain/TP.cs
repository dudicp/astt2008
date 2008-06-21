using System;
using System.Collections.Generic;

namespace AST.Domain {

    public class TP : AbstractAction{

        private List<TSC> m_tsc;
        private int m_numberOfTimes;

        public TP(String name, String description, String creatorName, DateTime creationTime)
            : base(name, description, creatorName, creationTime)
        {

            m_numberOfTimes = 1;
            m_tsc = new List<TSC>();
        }

        public List<TSC> GetTSCs(){
            return m_tsc;
        }

        public int NumberOfTimes{
            get { return m_numberOfTimes; }
            set { m_numberOfTimes = value; }
        }

        public override void AddEndStation(EndStationSchedule es){
            if (m_endStations.Contains(es)) m_endStations.Remove(es);
            m_endStations.Add(es);
            
            foreach (TSC tsc in m_tsc)
                tsc.AddEndStation(es);
        }

        public override void RemoveEndStation(EndStationSchedule es){
            m_endStations.Remove(es);

            foreach (TSC tsc in m_tsc)
                tsc.RemoveEndStation(es);
        }

        public override void ClearEndStations() {
            m_endStations.Clear();

            foreach (TSC tsc in m_tsc)
                tsc.ClearEndStations();
        }

        public void AddTSC(TSC tsc) {
            if (m_tsc.Contains(tsc)) m_tsc.Remove(tsc);
            m_tsc.Add(tsc);
        }

        public void RemoveTSC(TSC tsc) {
            m_tsc.Remove(tsc);
        }

        public void ClearTSCs() {
            m_tsc.Clear();
        }

        public override List<Action> GetActions()
        {
            List<Action> actions = new List<Action>();
            List<Action> tmp;
            foreach (TSC tsc in m_tsc)
            {
                tmp = tsc.GetActions();
                actions.AddRange(tmp);
            }

            return actions;

        }
    }
}
