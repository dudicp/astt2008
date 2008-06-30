using System;
using System.Collections.Generic;
using System.Text;

namespace AST.Domain {
 
    /// <summary>
    /// 
    /// </summary>
    class RecentEntry {
        /// <summary>
        /// 
        /// </summary>
        private String m_name;
        private String m_description;
        private DateTime m_accessTime;
        private AbstractAction.AbstractActionTypeEnum m_type;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="accessTime"></param>
        /// <param name="type"></param>
        public RecentEntry(String name, String description, DateTime accessTime, AbstractAction.AbstractActionTypeEnum type) {
            m_name = name;
            m_description = description;
            m_accessTime = accessTime;
            m_type = type;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Name {
            get { return m_name; }
            set { m_name = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Description {
            get { return m_description; }
            set { m_description = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AccessTime {
            get { return m_accessTime; }
            set { m_accessTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public AbstractAction.AbstractActionTypeEnum Type {
            get { return m_type; }
            set { m_type = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static int Comparison(RecentEntry o1, RecentEntry o2) {
            return (o2.AccessTime.CompareTo(o1.AccessTime));
        }

    }
}
