using System;
using System.Collections.Generic;
using System.Text;

namespace AST.Domain {
    class RecentEntry {

        private String m_name;
        private String m_description;
        private DateTime m_accessTime;
        private AbstractAction.AbstractActionTypeEnum m_type;

        public RecentEntry(String name, String description, DateTime accessTime, AbstractAction.AbstractActionTypeEnum type) {
            m_name = name;
            m_description = description;
            m_accessTime = accessTime;
            m_type = type;
        }

        public String Name {
            get { return m_name; }
            set { m_name = value; }
        }

        public String Description {
            get { return m_description; }
            set { m_description = value; }
        }

        public DateTime AccessTime {
            get { return m_accessTime; }
            set { m_accessTime = value; }
        }

        public AbstractAction.AbstractActionTypeEnum Type {
            get { return m_type; }
            set { m_type = value; }
        }

        public static int Comparison(RecentEntry o1, RecentEntry o2) {
            return (o2.AccessTime.CompareTo(o1.AccessTime));
        }

    }
}
