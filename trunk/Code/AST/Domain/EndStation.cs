using System;
using System.Net;


namespace AST.Domain{

    public class EndStation{

        public enum OSTypeEnum { WINDOWS, UNIX };//T.D
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

        public EndStation(int id, String name, IPAddress ip, OSTypeEnum osType, String username, String password){
            m_id = id;
            m_name = name;
            m_ip = ip;
            m_mac = "";
            m_osType = osType;
            m_osVersion = OSVersionEnum.None;
            m_username = username;
            m_password = password;
            m_state = StateEnum.Unknown;
        }

        public int ID{
            get { return m_id; }
            set { m_id = value; }
        }

        public String Name{
            get { return m_name; }
            set { m_name = value; }
        }

        public IPAddress IP{
            get { return m_ip; }
            set { m_ip = value; }
        }

        public String MAC{
            get { return m_mac; }
            set { m_mac = value; }
        }

        public OSTypeEnum OSType{
            get { return m_osType; }
            set { m_osType = value; }
        }

        public OSVersionEnum OSVersion{
            get { return m_osVersion; }
            set { m_osVersion = value; }
        }

        public String Username{
            get { return m_username; }
            set { m_username = value; }
        }

        public String Password{
            get { return m_password; }
            set { m_password = value; }
        }

        public StateEnum State{
            get { return m_state; }
            set { m_state = value; }
        }
    }
}
