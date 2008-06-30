using System;
using System.Collections;

namespace AST.Domain
{

    /// <summary>
    /// 
    /// </summary>
    public class Parameter
    {

        public enum ParameterTypeEnum { Input, Option, Both, None };
        private String m_name;
        private String m_description;
        private ParameterTypeEnum m_type;
        private String m_validityExp;
        private Hashtable m_values;
        private String m_input;
        private bool m_isDefault;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="validityExp"></param>
        /// <param name="isDefault"></param>
        public Parameter(String name, String description, ParameterTypeEnum type, String validityExp, bool isDefault)
        {
            m_name = name;
            m_description = description;
            m_type = type;
            m_validityExp = validityExp;
            m_values = new Hashtable();
            m_input = "";
            m_isDefault = isDefault;
        }
        /// <summary>
        /// 
        /// </summary>
        public String Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ParameterTypeEnum Type
        {
            get { return m_type; }
            set { m_type = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String ValidityExp
        {
            get { return m_validityExp; }
            set { m_validityExp = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Input
        {
            get { return m_input; }
            set { m_input = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDefault
        {
            get { return m_isDefault; }
            set { m_isDefault = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="osType"></param>
        /// <returns></returns>
        public String GetValue(EndStation.OSTypeEnum osType)
        {
            return (String)m_values[osType];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Hashtable GetAllValues()
        {
            return this.m_values;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="osType"></param>
        /// <param name="value"></param>
        public void AddValue(EndStation.OSTypeEnum osType, String value)
        {
            if (m_values.Contains(osType)) m_values.Remove(osType);
            m_values.Add(osType, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="osType"></param>
        public void RemoveValue(EndStation.OSTypeEnum osType)
        {
            m_values.Remove(osType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ValidateValue()
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(Object o)
        {
            if (((Parameter)o).Name != this.Name) return false;
            else return true;
        }
    }
}
