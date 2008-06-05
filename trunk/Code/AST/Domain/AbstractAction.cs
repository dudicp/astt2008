using System;
using System.Collections.Generic;

namespace AST.Domain{

    public abstract class AbstractAction{

        public enum AbstractActionTypeEnum { ACTION, TSC, TP };

        protected String m_name;
        protected String m_description;
        protected String m_creatorName;
        protected DateTime m_creationTime;
        protected List<EndStationSchedule> m_endStations;

        public AbstractAction(String name, String description, String creatorName, DateTime creationTime){
            m_name = name;
            m_description = description;
            m_creatorName = creatorName;
            m_creationTime = creationTime;
            m_endStations = new List<EndStationSchedule>();
        }

        public String Name{
            get { return this.m_name; }
            set { this.m_name = value; }
        }

        public String Description{
            get { return this.m_description; }
            set { this.m_description = value; }
        }

        public String CreatorName{
            get { return this.m_creatorName; }
            set { this.m_creatorName = value; }
        }

        public DateTime CreationTime{
            get { return this.m_creationTime; }
            set { this.m_creationTime = value; }
        }

        public List<EndStationSchedule> GetEndStations() {
            return m_endStations;
        }

        public abstract void AddEndStation(EndStationSchedule es);

        public abstract void RemoveEndStation(EndStationSchedule es);

        public abstract void ClearEndStations();
    }

}
