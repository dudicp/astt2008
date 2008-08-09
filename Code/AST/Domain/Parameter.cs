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
        /// Constructor for the Parameter class.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="description">The description of the parameter.</param>
        /// <param name="type">The type of the parameter.</param>
        /// <param name="validityExp">A validity expression of the parameter.</param>
        /// <param name="isDefault">A boolean variable that is true if the parameter is a default parameter.</param>
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
        /// Property value for the Name
        /// getter + setter for the m_name member 
        /// </summary>
        public String Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// Property value for the Description
        /// getter + setter for the m_description member 
        /// </summary>
        public String Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        /// <summary>
        /// Property value for the Type
        /// getter + setter for the m_type member
        /// </summary>
        public ParameterTypeEnum Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        /// <summary>
        /// Property value for the ValidityExp
        /// getter + setter for the m_validityExp member
        /// </summary>
        public String ValidityExp
        {
            get { return m_validityExp; }
            set { m_validityExp = value; }
        }

        /// <summary>
        /// Property value for the Input
        /// getter + setter for the m_input member 
        /// </summary>
        public String Input
        {
            get { return m_input; }
            set { m_input = value; }
        }

        /// <summary>
        /// Property value for the IsDefault
        /// getter + setter for the m_isDefault member 
        /// </summary>
        public bool IsDefault
        {
            get { return m_isDefault; }
            set { m_isDefault = value; }
        }

        /// <summary>
        /// Gets the value of the parameter according to the OS type.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        /// <returns>The value of the parameter according to the OS type.</returns>
        public String GetValue(EndStation.OSTypeEnum osType)
        {
            return (String)m_values[osType];
        }

        /// <summary>
        /// Gets a hashtable that contains all the values according to the OS type.
        /// </summary>
        /// <returns>A hashtable that contains all the values according to the OS type.</returns>
        public Hashtable GetAllValues()
        {
            return this.m_values;
        }

        /// <summary>
        /// Adds a value to the parameter according to the OS type.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        /// <param name="value">The parameter value.</param>
        public void AddValue(EndStation.OSTypeEnum osType, String value)
        {
            if (m_values.Contains(osType)) m_values.Remove(osType);
            m_values.Add(osType, value);
        }

        /// <summary>
        /// Removes a value from the parameter according to the OS type.
        /// </summary>
        /// <param name="osType">The OS type.</param>
        public void RemoveValue(EndStation.OSTypeEnum osType)
        {
            m_values.Remove(osType);
        }

        /// <summary>
        /// Validates the value of the parameter.
        /// </summary>
        /// <returns></returns>
        public bool ValidateValue()
        {
            return true;
        }

        /// <summary>
        /// Compares two parameters and returns true if the paremters are equal (has the same name).
        /// </summary>
        /// <param name="o">The parameter to compare with.</param>
        /// <returns>True if the paremters are equal, false otherwise.</returns>
        public override bool Equals(Object o)
        {
            if (((Parameter)o).Name != this.Name) return false;
            else return true;
        }
    }
}
