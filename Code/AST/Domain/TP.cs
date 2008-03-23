using System;
using System.Collections.Generic;

namespace AST.Domain {

    public class TP : AbstractAction{

        private List<TSC> m_tsc;
        private int m_numberOfTimes;

        public TP(String name, String description, int delay, String creatorName, DateTime creationTime, int numberOfTimes)
            : base(name, description, delay, creatorName, creationTime)
        {

            m_numberOfTimes = numberOfTimes;
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
            foreach (TSC tsc in m_tsc)
                tsc.AddEndStation(es);
        }

        public override void RemoveEndStation(EndStationSchedule es){
            foreach (TSC tsc in m_tsc)
                tsc.RemoveEndStation(es);
        }

        public override void ClearEndStations() {
            foreach (TSC tsc in m_tsc)
                tsc.ClearEndStations();
        }
    }
}
