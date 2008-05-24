using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace AST.Management {
    static class ConfigurationManager {

        public const String Configuration_Filename = "config.xml";
        private static String m_databaseConnectionStr = "";
        private static String m_PSToolsFullPath = "";
        private static int m_threadPoolSize = 0;

        public const int SUCCESS = 0;
        public const int ERROR_WRITING = -1;
        public const int ERROR_INVALID_ARGUMENTS = -2;
        public const int ERROR_UNEXPECTED = -3;
        public const int ERROR_BAD_FORMAT = -1;
        public const int ERROR_READING = -2;

        public static int ReadConfiguration(String filename){
            
            if (!File.Exists(Configuration_Filename)) {
                // Initilize to default values when file doesn't exist.

                m_databaseConnectionStr = "Server=" + System.Environment.MachineName + "\\SQLEXPRESS;Database=ASTDB;Integrated Security=True;";
                m_threadPoolSize = 10;
                m_PSToolsFullPath = ".//";

                System.Diagnostics.Debug.WriteLine("ConfigurationManager::ReadConfiguration:: configuration file " + Configuration_Filename + " doesn't exist.");
                System.Diagnostics.Debug.WriteLine("using defaults values: DBConnectionString = " + m_databaseConnectionStr + ", MaxThreadPoolSize = " + m_threadPoolSize + ", PSToolPath = " + m_PSToolsFullPath);
                return SUCCESS;
            }
            
            //In-case Configuratio file exists
            try {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Configuration_Filename);

                //Reading Database connection string
                XmlNodeList list = xmlDoc.GetElementsByTagName("DatabaseConnectionString");
                if (list.Count > 0) m_databaseConnectionStr = list[0].InnerText;
                else return ERROR_BAD_FORMAT;

                //Reading max thread pool size
                list = xmlDoc.GetElementsByTagName("MaxThreadPoolSize");
                if (list.Count > 0) m_threadPoolSize = Convert.ToInt32(list[0].InnerText);
                else return ERROR_BAD_FORMAT;

                //Reading PSTools Full Path
                list = xmlDoc.GetElementsByTagName("PSToolsPath");
                if (list.Count > 0) m_PSToolsFullPath = list[0].InnerText;
                else return ERROR_BAD_FORMAT;

                System.Diagnostics.Debug.WriteLine("ConfigurationManager::ReadConfiguration:: configuration file " + Configuration_Filename + " found.");
                System.Diagnostics.Debug.WriteLine("using values: DBConnectionString = " + m_databaseConnectionStr + ", MaxThreadPoolSize = " + m_threadPoolSize + ", PSToolsPath = " + m_PSToolsFullPath);

                return SUCCESS;
            }catch(System.Xml.XmlException e){
                System.Diagnostics.Debug.WriteLine("ConfigurationManager::ReadConfiguration:: can't access " + Configuration_Filename + " or XML bad format.");
                return ERROR_READING;
            }
        }

        public static int WriteConfiguration(String DBConnectionString, String PSToolsPath, int maxTheardPoolSize) {

            try {
                XmlTextWriter textWriter = new XmlTextWriter(Configuration_Filename, null);
                textWriter.WriteStartDocument();

                // Write root element
                textWriter.WriteStartElement("Configuration");

                // Write DatabaseConnectionString element
                textWriter.WriteStartElement("DatabaseConnectionString", "");
                textWriter.WriteString(DBConnectionString);
                textWriter.WriteEndElement();

                // Write MaxThreadPoolSize element
                textWriter.WriteStartElement("MaxThreadPoolSize", "");
                textWriter.WriteString("" + maxTheardPoolSize);
                textWriter.WriteEndElement();

                // Write PSToolsPath element
                textWriter.WriteStartElement("PSToolsPath", "");
                textWriter.WriteString(PSToolsPath);
                textWriter.WriteEndElement();

                // Close root element
                textWriter.WriteEndDocument();
                textWriter.Close();

                m_databaseConnectionStr = DBConnectionString;
                m_PSToolsFullPath = PSToolsPath;
                m_threadPoolSize = maxTheardPoolSize;

                System.Diagnostics.Debug.WriteLine("ConfigurationManager::WriteConfiguration:: configuration file " + Configuration_Filename + " updated.");
                System.Diagnostics.Debug.WriteLine("using values: DBConnectionString = " + m_databaseConnectionStr + ", MaxThreadPoolSize = " + m_threadPoolSize + ", PSToolsPath = " + m_PSToolsFullPath);

                return SUCCESS;
            }
            catch (System.InvalidOperationException e) {
                System.Diagnostics.Debug.WriteLine("ConfigurationManager::WriteConfiguration:: failed to write to " + Configuration_Filename);
                return ERROR_UNEXPECTED;
            }
            catch (System.ArgumentException e) {
                System.Diagnostics.Debug.WriteLine("ConfigurationManager::WriteConfiguration:: Invalid arguments.");
                return ERROR_INVALID_ARGUMENTS;
            }
            catch (System.Exception e) {
                System.Diagnostics.Debug.WriteLine("ConfigurationManager::WriteConfiguration:: failed to save " + Configuration_Filename);
                return ERROR_WRITING;
            }
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
