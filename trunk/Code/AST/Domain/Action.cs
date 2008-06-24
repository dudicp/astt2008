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
        private int m_delay;
        private Hashtable m_validtyString;
        private List<Parameter> m_parameters;

        public Action(String name, String description, int delay, String creatorName, DateTime creationTime, int timeout, ActionTypeEnum type, int duration)
            : base(name, description, creatorName, creationTime)
        {     
            m_timeout = timeout;
            m_type = type;
            m_delay = delay;
            m_duration = duration;

            m_content = new Hashtable();
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

        public int Delay {
            get { return m_delay; }
            set { m_delay = value; }
        }

        public List<Parameter> GetParameters(){
            return m_parameters;
        }

        public String GetContent(EndStation.OSTypeEnum osType){
            return (String)m_content[osType];
        }

        public Hashtable GetAllContents() {
            return this.m_content;
        }

        public String GetValidityString(EndStation.OSTypeEnum osType){
            return (String)m_validtyString[osType];
        }

        public void AddContent(EndStation.OSTypeEnum osType, String content){
            if (m_content.Contains(osType)) m_content.Remove(osType);
            m_content.Add(osType, content);
        }

        public void RemoveContent(EndStation.OSTypeEnum osType){
            m_content.Remove(osType);
        }

        public void AddValidityString(EndStation.OSTypeEnum osType, String vs){
            if (m_validtyString.Contains(osType)) m_validtyString.Remove(osType);
            m_validtyString.Add(osType, vs);
        }

        public void RemoveValidityString(EndStation.OSTypeEnum osType){
            m_validtyString.Remove(osType);
        }

        public void AddParameter(Parameter param){
            if (m_parameters.Contains(param)){
                int index = m_parameters.IndexOf(param);
                m_parameters.Remove(param);
                m_parameters.Insert(index, param);
            }
            else m_parameters.Add(param);
        }

        public void RemoveParameter(Parameter param){
            m_parameters.Remove(param);
        }

        public void ClearParameters() {
            m_parameters.Clear();
        }

        public override void AddEndStation(EndStationSchedule es){
            if (m_endStations.Contains(es)) m_endStations.Remove(es);
            m_endStations.Add(es);
        }

        public override void RemoveEndStation(EndStationSchedule es){
            m_endStations.Remove(es);
        }

        public override void ClearEndStations() {
            m_endStations.Clear();
        }

        public String GenerateCommand(EndStation.OSTypeEnum osType){
            switch (this.ActionType) {
                case ActionTypeEnum.COMMAND_LINE: {
                        String res = (String)m_content[osType];
                        foreach (Parameter p in m_parameters)
                            res = res + " " + p.GetValue(osType) + " " + p.Input;
                        return res;
                    }
                // for SCRIPT and TEST_SCRIPT
                default: {
                        String res = "";
                        foreach (Parameter p in m_parameters)
                            res = res + " " + p.GetValue(osType) + " " + p.Input;
                        return res;
                    }
            }
        }

        public override List<Action> GetActions()
        {
            List<Action> actions = new List<Action>();
            actions.Add(this);
            return actions;
        }
    }
}
