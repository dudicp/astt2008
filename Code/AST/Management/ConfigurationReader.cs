using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace AST.Management {
    static class ConfigurationReader {

        public const String Configuration_Filename = "config.xml";
        private static String m_databaseConnectionStr = "";
        private static String m_PSToolsFullPath = "";
        private static int m_threadPoolSize = 0;

        public static void ReadConfiguration(String filename){
            
            if (!File.Exists(Configuration_Filename)) {
                // Initilize to default values when file doesn't exist.

                m_databaseConnectionStr = "Server=" + System.Environment.MachineName + "\\SQLEXPRESS;Database=ASTDB;Integrated Security=True;";
                m_threadPoolSize = 10;
                m_PSToolsFullPath = ".//";

                System.Diagnostics.Debug.WriteLine("ConfigurationReader::ReadConfiguration:: configuration file " + Configuration_Filename + " doesn't exist.");
                System.Diagnostics.Debug.WriteLine("using defaults values: DBConnectionString = " + m_databaseConnectionStr + ", MaxThreadPoolSize = " + m_threadPoolSize + ", PSToolPath = " + m_PSToolsFullPath);
                return;
            }
            
            //In-case Configuratio file exists
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Configuration_Filename);

            //Reading Database connection string
            XmlNodeList list = xmlDoc.GetElementsByTagName("DatabaseConnectionString");
            if (list.Count > 0) m_databaseConnectionStr = list[0].InnerText;

            //Reading max thread pool size
            list = xmlDoc.GetElementsByTagName("MaxThreadPoolSize");
            if (list.Count > 0) m_threadPoolSize = Convert.ToInt32(list[0].InnerText);

            //Reading PSTools Full Path
            list = xmlDoc.GetElementsByTagName("PSToolsPath");
            if (list.Count > 0) m_PSToolsFullPath = list[0].InnerText;

            System.Diagnostics.Debug.WriteLine("ConfigurationReader::ReadConfiguration:: configuration file " + Configuration_Filename + " found.");
            System.Diagnostics.Debug.WriteLine("using values: DBConnectionString = " + m_databaseConnectionStr + ", MaxThreadPoolSize = " + m_threadPoolSize + ", PSToolsPath = " + m_PSToolsFullPath);
        }

        public static String GetDBConnectionString() {
            return m_databaseConnectionStr;
        }

        public static int GetMaxThreadPoolSize() {
            return m_threadPoolSize;
        }

        public static String GetPSToolsFullPath() {
            return m_PSToolsFullPath;
        }

    }
}
