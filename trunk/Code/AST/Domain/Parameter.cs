using System;
using System.Collections;

namespace AST.Domain{

    public class Parameter{

        public enum ParameterTypeEnum {Input, Option, Both, None};

        private String m_name;
        private String m_description;
        private ParameterTypeEnum m_type;
        private String m_validityExp;
        private Hashtable m_values;
        private String m_input;

        public Parameter(String name, String description, ParameterTypeEnum type, String validityExp){
            m_name = name;
            m_description = description;
            m_type = type;
            m_validityExp = validityExp;
            m_values = new Hashtable();
            m_input = "";
        }

        public String Name{
            get { return m_name; }
            set { m_name = value; }
        }

        public String Description{
            get { return m_description; }
            set { m_description = value; }
        }

        public ParameterTypeEnum Type{
            get { return m_type; }
            set { m_type = value; }
        }

        public String ValidityExp{
            get { return m_validityExp; }
            set { m_validityExp = value; }
        }

        public String Input{
            get { return m_input; }
            set { m_input = value; }
        }

        public String GetValue(EndStation.OSTypeEnum osType){
            return (String)m_values[osType];
        }

        public void AddValue(EndStation.OSTypeEnum osType, String value){
            if (m_values.Contains(osType)) m_values.Remove(osType);
            m_values.Add(osType, value);
        }

        public void RemoveValue(EndStation.OSTypeEnum osType){
            m_values.Remove(osType);
        }

        public bool ValidateValue(){
            return true;
        }
    }
}
