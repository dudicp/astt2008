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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="ip"></param>
        /// <param name="osType"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isDefault"></param>
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
        /// 
        /// </summary>
        public int ID
        {
            get { return m_id; }
            set { m_id = value; }
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
        public IPAddress IP
        {
            get { return m_ip; }
            set { m_ip = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String MAC
        {
            get { return m_mac; }
            set { m_mac = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public OSTypeEnum OSType
        {
            get { return m_osType; }
            set { m_osType = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public OSVersionEnum OSVersion
        {
            get { return m_osVersion; }
            set { m_osVersion = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Username
        {
            get { return m_username; }
            set { m_username = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Password
        {
            get { return m_password; }
            set { m_password = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public StateEnum State
        {
            get { return m_state; }
            set { m_state = value; }
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
        /// <returns></returns>
        public override String ToString()
        {
            return this.ID + " " + this.m_name + " " + this.m_ip.ToString() + " " + this.m_mac + " " + this.m_osType + " " + this.m_osVersion + " " + this.m_username + " " + this.m_password + " " + this.m_state;
        }
    }
}
