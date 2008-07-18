using System;
using System.Collections;
using System.Collections.Generic;

namespace AST.Domain{
    /// <summary>
    /// 
    /// </summary>
    public class TSC : AbstractAction{

        private List<Action> m_actions;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="creatorName"></param>
        /// <param name="creationTime"></param>
        public TSC(String name, String description, String creatorName, DateTime creationTime)
            : base(name, description, creatorName, creationTime) {

                m_actions = new List<Action>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="es"></param>
        public override void AddEndStation(EndStationSchedule es){
            if (m_endStations.Contains(es)) m_endStations.Remove(es);
            m_endStations.Add(es);

            foreach (Action a in m_actions) {
                System.Diagnostics.Debug.WriteLine("Action name = " + a.Name);
                a.AddEndStation(es);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="es"></param>
        public override void RemoveEndStation(EndStationSchedule es){
            m_endStations.Remove(es);
            
            foreach (Action a in m_actions)
                a.RemoveEndStation(es);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void ClearEndStations() {
            m_endStations.Clear();

            foreach (Action a in m_actions)
                a.ClearEndStations();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public void AddAction(Action a) {
            if (m_actions.Contains(a)) m_actions.Remove(a);
            m_actions.Add(a);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public void RemoveAction(Action a) {
            m_actions.Remove(a);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearActions() {
            m_actions.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<Action> GetActions()
        {
            return m_actions;
        }
    }
}
