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
            foreach (Action a in m_actions)
                a.AddEndStation(es);
        }

        public override void RemoveEndStation(EndStationSchedule es){
            foreach (Action a in m_actions)
                a.RemoveEndStation(es);
        }

        public override void ClearEndStations() {
            foreach (Action a in m_actions)
                a.ClearEndStations();
        }
    }
}
