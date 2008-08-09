using System;
using System.Net;


namespace AST.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class EndStation
    {
        public enum OSTypeEnum { WINDOWS, UNIX, UNKNOWN };//T.D
        public enum OSVersionEnum { None, WIN2000, WINXP, VISTA };//T.D
        public enum StateEnum { Unknown, Idle, Hibernate, Sleep };//T.D

        private int m_id;
        private String m_name;
        private IPAddress m_ip;
        private String m_mac;
        private OSTypeEnum m_osType;
        private OSVersionEnum m_osVersion;
        private String m_username;
        private String m_password;
        private StateEnum m_state;
        private bool m_isDefault;

        /// <summary>
        /// A constructor for the EndStation object.
        /// </summary>
        /// <param name="id">The ID of the end-station.</param>
        /// <param name="name">The name of the end-station.</param>
        /// <param name="ip">The IP address of the end-station.</param>
        /// <param name="osType">The OS type of the end-station.</param>
        /// <param name="username">The username for the end-station.</param>
        /// <param name="password">The password for the end-station.</param>
        /// <param name="isDefault">A boolean variable that is true if the end-station is a default end-station.</param>
        public EndStation(int id, String name, IPAddress ip, OSTypeEnum osType, String username, String password, bool isDefault)
        {
            m_id = id;
            m_name = name;
            m_ip = ip;
            m_mac = "";
            m_osType = osType;
            m_osVersion = OSVersionEnum.None;
            m_username = username;
            m_password = password;
            m_state = StateEnum.Unknown;
            m_isDefault = isDefault;
        }

        /// <summary>
        /// Property value for the ID
        /// getter + setter for the m_id member 
        /// </summary>
        public int ID
        {
            get { return m_id; }
            set { m_id = value; }
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
        /// Property value for the IP
        /// getter + setter for the m_ip member 
        /// </summary>
        public IPAddress IP
        {
            get { return m_ip; }
            set { m_ip = value; }
        }

        /// <summary>
        /// Property value for the MAC
        /// getter + setter for the m_mac member 
        /// </summary>
        public String MAC
        {
            get { return m_mac; }
            set { m_mac = value; }
        }

        /// <summary>
        /// Property value for the OSType
        /// getter + setter for the m_osType member 
        /// </summary>
        public OSTypeEnum OSType
        {
            get { return m_osType; }
            set { m_osType = value; }
        }

        /// <summary>
        /// Property value for the OSVersion
        /// getter + setter for the m_osVersion member 
        /// </summary>
        public OSVersionEnum OSVersion
        {
            get { return m_osVersion; }
            set { m_osVersion = value; }
        }

        /// <summary>
        /// Property value for the Username
        /// getter + setter for the m_username member 
        /// </summary>
        public String Username
        {
            get { return m_username; }
            set { m_username = value; }
        }

        /// <summary>
        /// Property value for the Password
        /// getter + setter for the m_password member 
        /// </summary>
        public String Password
        {
            get { return m_password; }
            set { m_password = value; }
        }

        /// <summary>
        /// Property value for the State
        /// getter + setter for the m_state member 
        /// </summary>
        public StateEnum State
        {
            get { return m_state; }
            set { m_state = value; }
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
        /// ToString for the end-station class.
        /// </summary>
        /// <returns>A string that represents the end-station.</returns>
        public override String ToString()
        {
            return this.ID + " " + this.m_name + " " + this.m_ip.ToString() + " " + this.m_mac + " " + this.m_osType + " " + this.m_osVersion + " " + this.m_username + " " + this.m_password + " " + this.m_state;
        }
    }
}
