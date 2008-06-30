using System;
using System.Collections.Generic;

namespace AST.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractAction
    {

        public enum AbstractActionTypeEnum { ACTION, TSC, TP };

        protected String m_name;
        protected String m_description;
        protected String m_creatorName;
        protected DateTime m_creationTime;
        protected List<EndStationSchedule> m_endStations;
        /// <summary>
        /// CTor for the AbstractAction Object
        /// </summary>
        /// <param name="name">the name of the action</param>
        /// <param name="description">the action description</param>
        /// <param name="creatorName">the name of the creator</param>
        /// <param name="creationTime">the time the action was created</param>
        public AbstractAction(String name, String description, String creatorName, DateTime creationTime)
        {
            m_name = name;
            m_description = description;
            m_creatorName = creatorName;
            m_creationTime = creationTime;
            m_endStations = new List<EndStationSchedule>();
        }
        /// <summary>
        /// Property value for the AbstractAction name
        /// getter + setter for the m_name member
        /// </summary>
        public String Name
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }
        /// <summary>
        /// Property value for the description
        /// getter + setter for the m_description member
        /// </summary>
        public String Description
        {
            get { return this.m_description; }
            set { this.m_description = value; }
        }
        /// <summary>
        /// Property value for the creator name
        /// getter + setter for the m_creatorName member
        /// </summary>
        public String CreatorName
        {
            get { return this.m_creatorName; }
            set { this.m_creatorName = value; }
        }
        /// <summary>
        /// Property value for the creation time
        /// getter + setter for the m_creationTime member
        /// </summary>
        public DateTime CreationTime
        {
            get { return this.m_creationTime; }
            set { this.m_creationTime = value; }
        }
        /// <summary>
        /// method for getting the m_endStations member
        /// </summary>
        /// <returns></returns>
        public List<EndStationSchedule> GetEndStations()
        {
            return m_endStations;
        }
        /// <summary>
        /// Abstract method for adding an End-station 
        /// to be implemented in the derived classes
        /// </summary>
        /// <param name="es">the end-station object</param>
        public abstract void AddEndStation(EndStationSchedule es);
        /// <summary>
        /// Abstract method for removing an End-station 
        /// to be implemented in the derived classes
        /// </summary>
        /// <param name="es">the end-station object</param>
        public abstract void RemoveEndStation(EndStationSchedule es);
        /// <summary>
        /// Abstract method for removing all End-station 
        /// to be implemented in the derived classes
        /// </summary>
        public abstract void ClearEndStations();
        /// <summary>
        /// Abstract method for getting all the Actions
        /// to be implemented in the derived classes
        /// </summary>
        /// <returns>List of all actions </returns>
        public abstract List<Action> GetActions();
    }

}
