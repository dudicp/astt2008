using System;
using System.Collections.Generic;

namespace AST.Domain {
    /// <summary>
    /// 
    /// </summary>
    public class TP : AbstractAction{

        private List<TSC> m_tsc;
        private int m_numberOfTimes;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="creatorName"></param>
        /// <param name="creationTime"></param>
        public TP(String name, String description, String creatorName, DateTime creationTime)
            : base(name, description, creatorName, creationTime)
        {

            m_numberOfTimes = 1;
            m_tsc = new List<TSC>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TSC> GetTSCs(){
            return m_tsc;
        }
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfTimes{
            get { return m_numberOfTimes; }
            set { m_numberOfTimes = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="es"></param>
        public override void AddEndStation(EndStationSchedule es){
            if (m_endStations.Contains(es)) m_endStations.Remove(es);
            m_endStations.Add(es);
            
            foreach (TSC tsc in m_tsc)
                tsc.AddEndStation(es);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="es"></param>
        public override void RemoveEndStation(EndStationSchedule es){
            m_endStations.Remove(es);

            foreach (TSC tsc in m_tsc)
                tsc.RemoveEndStation(es);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void ClearEndStations() {
            m_endStations.Clear();

            foreach (TSC tsc in m_tsc)
                tsc.ClearEndStations();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tsc"></param>
        public void AddTSC(TSC tsc) {
            if (m_tsc.Contains(tsc)) m_tsc.Remove(tsc);
            m_tsc.Add(tsc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tsc"></param>
        public void RemoveTSC(TSC tsc) {
            m_tsc.Remove(tsc);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearTSCs() {
            m_tsc.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
