using System;
using System.Collections;
using System.Collections.Generic;

namespace AST.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Action : AbstractAction
    {
        public enum ActionTypeEnum { BATCH_FILE, COMMAND_LINE, SCRIPT, TEST_SCRIPT };
        private int m_timeout;
        private Hashtable m_content;
        private ActionTypeEnum m_type;
        private int m_duration;
        private int m_delay;
        private Hashtable m_validtyString;
        private List<Parameter> m_parameters;
        private bool m_stopIfFails;

       

        /// <summary>
        /// This is the constructor of the Action object.
        /// </summary>
        /// <param name="name">The action name.</param>
        /// <param name="description">The action description.</param>
        /// <param name="delay">The delay after executing the action.</param>
        /// <param name="creatorName">The creator of the action.</param>
        /// <param name="creationTime">The creation time of the action.</param>
        /// <param name="timeout">The timeout for connection.</param>
        /// <param name="type">The type of the action.</param>
        /// <param name="duration">The duration of the action.</param>
        public Action(String name, String description, int delay, String creatorName, DateTime creationTime, int timeout, ActionTypeEnum type, int duration)
            : base(name, description, creatorName, creationTime)
        {
            m_timeout = timeout;
            m_type = type;
            m_delay = delay;
            m_duration = duration;
            m_stopIfFails = false;

            m_content = new Hashtable();
            m_validtyString = new Hashtable();
            m_parameters = new List<Parameter>();
        }

        /// <summary>
        /// Property value for the timeout
        /// getter + setter for the m_timeout member
        /// </summary>
        public int Timeout
        {
            get { return m_timeout; }
            set { m_timeout = value; }
        }

        /// <summary>
        /// Property value for the ActionType
        /// getter + setter for the m_type member
        /// </summary>
        public ActionTypeEnum ActionType
        {
            get { return m_type; }
            set { m_type = value; }
        }

        /// <summary>
        /// Property value for the Duration
        /// getter + setter for the m_duration member
        /// </summary>
        public int Duration
        {
            get { return m_duration; }
            set { m_duration = value; }
        }

        /// <summary>
        /// Property value for the Delay
        /// getter + setter for the m_delay member
        /// </summary>
        public int Delay
        {
            get { return m_delay; }
            set { m_delay = value; }
        }
        
        /// <summary>
        /// Property value for the StopIfFails
        /// getter + setter for the m_stopIfFails member
        /// </summary>
        public bool StopIfFails {
            get { return m_stopIfFails; }
            set { m_stopIfFails = value; }
        }

        /// <summary>
        /// getter for the m_parameters member
        /// </summary>
        /// <returns>A list of the action parameters.</returns>
        public List<Parameter> GetParameters()
        {
            return m_parameters;
        }

        /// <summary>
        /// getter for the m_content member
        /// </summary>
        /// <param name="osType">The OS type.</param>
        /// <returns>A string of the content according to the OS type.</returns>
        public String GetContent(EndStation.OSTypeEnum osType)
        {
            return (String)m_content[osType];
        }

        /// <summary>
        /// Getter for the m_content member.
        /// </summary>
        /// <returns>A hashtable of all the contents of the action.</returns>
        public Hashtable GetAllContents()
        {
            return this.m_content;
        }

        /// <summary>
        /// Getter for the m_validtyString member.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        /// <returns>The validity string according to the OS type.</returns>
        public String GetValidityString(EndStation.OSTypeEnum osType)
        {
            if (m_validtyString[osType] == null) return "";
            return (String)m_validtyString[osType];
        }
        
        /// <summary>
        /// Adds a content to the action according to the OS type.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        /// <param name="content">The content of the action.</param>
        public void AddContent(EndStation.OSTypeEnum osType, String content)
        {
            if (m_content.Contains(osType)) m_content.Remove(osType);
            m_content.Add(osType, content);
        }

        /// <summary>
        /// Removes a content that belongs to the osType.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        public void RemoveContent(EndStation.OSTypeEnum osType)
        {
            m_content.Remove(osType);
        }

        /// <summary>
        /// Adds a validity string to the action according to the OS type.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        /// <param name="vs">The validity string.</param>
        public void AddValidityString(EndStation.OSTypeEnum osType, String vs)
        {
            if (m_validtyString.Contains(osType)) m_validtyString.Remove(osType);
            m_validtyString.Add(osType, vs);
        }

        /// <summary>
        /// Removes a validity string that belongs to the osType.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        public void RemoveValidityString(EndStation.OSTypeEnum osType)
        {
            m_validtyString.Remove(osType);
        }

        /// <summary>
        /// Adds a parameter to the action.
        /// </summary>
        /// <param name="param">The parameter to add.</param>
        public void AddParameter(Parameter param)
        {
            if (m_parameters.Contains(param))
            {
                int index = m_parameters.IndexOf(param);
                m_parameters.Remove(param);
                m_parameters.Insert(index, param);
            }
            else m_parameters.Add(param);
        }

        /// <summary>
        /// Removes a parameter from the action.
        /// </summary>
        /// <param name="param">The parameter to remove.</param>
        public void RemoveParameter(Parameter param)
        {
            m_parameters.Remove(param);
        }

        /// <summary>
        /// Clears all the action parameters.
        /// </summary>
        public void ClearParameters()
        {
            m_parameters.Clear();
        }

        /// <summary>
        /// Adds an end-station to the action.
        /// </summary>
        /// <param name="es">The end-station to add.</param>
        public override void AddEndStation(EndStationSchedule es)
        {
            if (m_endStations.Contains(es)) m_endStations.Remove(es);
            m_endStations.Add(es);
        }

        /// <summary>
        /// Removes an end-station from the action.
        /// </summary>
        /// <param name="es">The end-station to remove.</param>
        public override void RemoveEndStation(EndStationSchedule es)
        {
            m_endStations.Remove(es);
        }

        /// <summary>
        /// Clears all the action end-stations.
        /// </summary>
        public override void ClearEndStations()
        {
            m_endStations.Clear();
        }

        /// <summary>
        /// Generates a command according to the OS type.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        /// <returns>A string that contains the generated command.</returns>
        public String GenerateCommand(EndStation.OSTypeEnum osType)
        {
            switch (this.ActionType)
            {
                case ActionTypeEnum.COMMAND_LINE:
                    {
                        String res = (String)m_content[osType];
                        foreach (Parameter p in m_parameters)
                            res = res + " " + p.GetValue(osType) + " " + p.Input;
                        return res;
                    }
                // for SCRIPT, TEST_SCRIPT, BATCH_FILE
                default:
                    {
                        String res = "";
                        foreach (Parameter p in m_parameters)
                            res = res + " " + p.GetValue(osType) + " " + p.Input;
                        return res;
                    }
            }
        }

        /// <summary>
        /// Gets the action as a list (that contains only the action).
        /// </summary>
        /// <returns>A list that contains only the action.</returns>
        public override List<Action> GetActions()
        {
            List<Action> actions = new List<Action>();
            actions.Add(this);
            return actions;
        }
    }
}
