using System;
using System.Collections;
using System.Collections.Generic;

namespace AST.Domain{

    public class TSC : AbstractAction{

        private List<Action> m_actions;

        public TSC(String name, String description, int delay, String creatorName, DateTime creationTime)
            : base(name, description, delay, creatorName, creationTime) {

                m_actions = new List<Action>();
        }

        public List<Action> GetActions(){
            return m_actions;
        }

        public override void AddEndStation(EndStationSchedule es){
            if (m_endStations.Contains(es)) m_endStations.Remove(es);
            m_endStations.Add(es);

            foreach (Action a in m_actions)
                a.AddEndStation(es);
        }

        public override void RemoveEndStation(EndStationSchedule es){
            m_endStations.Remove(es);
            
            foreach (Action a in m_actions)
                a.RemoveEndStation(es);
        }

        public override void ClearEndStations() {
            m_endStations.Clear();

            foreach (Action a in m_actions)
                a.ClearEndStations();
        }

        public void AddAction(Action a) {
            if (m_actions.Contains(a)) m_actions.Remove(a);
            m_actions.Add(a);
        }

        public void RemoveAction(Action a) {
            m_actions.Remove(a);
        }

        public void ClearActions() {
            m_actions.Clear();
        }
    }
}