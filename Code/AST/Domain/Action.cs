using System;
using System.Collections;
using System.Collections.Generic;

namespace AST.Domain{

    public class Action : AbstractAction{
        
        public enum ActionTypeEnum { COMMAND_LINE, SCRIPT, TEST_SCRIPT };

        private int m_timeout;
        private Hashtable m_content;
        private ActionTypeEnum m_type;
        private int m_duration;
        private List<EndStationSchedule> m_endStations;
        private Hashtable m_validtyString;
        private List<Parameter> m_parameters;

        public Action(String name, String description, int delay, String creatorName, DateTime creationTime, int timeout, ActionTypeEnum type, int duration)
            : base(name, description, delay, creatorName, creationTime)
        {     
            m_timeout = timeout;
            m_type = type;
            m_duration = duration;

            m_content = new Hashtable();
            m_endStations = new List<EndStationSchedule>();
            m_validtyString = new Hashtable();
            m_parameters = new List<Parameter>();
        }

        public int Timeout{
            get { return m_timeout; }
            set { m_timeout = value; }
        }

        public ActionTypeEnum ActionType{
            get { return m_type; }
            set { m_type = value; }
        }

        public int Duration{
            get { return m_duration; }
            set { m_duration = value; }
        }

        public List<EndStationSchedule> GetEndStations(){
            return m_endStations;
        }

        public List<Parameter> GetParameters(){
            return m_parameters;
        }

        public String GetContent(EndStation.OSTypeEnum osType){
            return (String)m_content[osType];
        }

        public String GetValidityString(EndStation.OSTypeEnum osType){
            return (String)m_validtyString[osType];
        }

        public void AddContent(EndStation.OSTypeEnum osType, String content){
            m_content.Add(osType, content);
        }

        public void RemoveContent(EndStation.OSTypeEnum osType){
            m_content.Remove(osType);
        }

        public void AddValidityString(EndStation.OSTypeEnum osType, String vs){
            m_validtyString.Add(osType, vs);
        }

        public void RemoveValidityString(EndStation.OSTypeEnum osType){
            m_validtyString.Remove(osType);
        }

        public void AddParameter(Parameter param){
            m_parameters.Add(param);
        }

        public void RemoveParameter(Parameter param){
            m_parameters.Remove(param);
        }

        public override void AddEndStation(EndStationSchedule es){
            m_endStations.Add(es);
        }

        public override void RemoveEndStation(EndStationSchedule es){
            m_endStations.Remove(es);
        }

        public String GenerateCommand(EndStation.OSTypeEnum osType){
            String res = (String)m_content[osType];
            foreach (Parameter p in m_parameters)
                res = res + " " + p.GetValue(osType) + " " + p.Input;
            return res;
        }
    }
}
