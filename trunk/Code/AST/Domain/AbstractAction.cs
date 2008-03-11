using System;

namespace AST.Domain{

    public abstract class AbstractAction{

        protected String m_name;
        protected String m_description;
        protected int m_delay;
        protected String m_creatorName;
        protected DateTime m_creationTime;

        public AbstractAction(String name, String description, int delay, String creatorName, DateTime creationTime){
            m_name = name;
            m_description = description;
            m_delay = delay;
            m_creatorName = creatorName;
            m_creationTime = creationTime;
        }

        public String Name
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }

        public String Description
        {
            get { return this.m_description; }
            set { this.m_description = value; }
        }

        public int Delay
        {
            get { return this.m_delay; }
            set { this.m_delay = value; }
        }

        public String CreatorName
        {
            get { return this.m_creatorName; }
            set { this.m_creatorName = value; }
        }

        public DateTime CreationTime
        {
            get { return this.m_creationTime; }
            set { this.m_creationTime = value; }
        }

        public abstract void AddEndStation(EndStationSchedule es);

        public abstract void RemoveEndStation(EndStationSchedule es);
    }

}
