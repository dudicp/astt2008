using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace AST.Management
{
    /// <summary>
    /// 
    /// </summary>
    static class ConfigurationManager
    {

        public const String Configuration_Filename = "config.xml";
        private static String m_databaseConnectionStr = "";
        private static String m_databaseName = "";
        private static String m_PSToolsFullPath = "";
        private static String m_reportsFullPath = "";
        private static int m_threadPoolSize = 0;
        private static String m_reportOption = "";

        public const int SUCCESS = 0;
        public const int ERROR_WRITING = -1;
        public const int ERROR_INVALID_ARGUMENTS = -2;
        public const int ERROR_UNEXPECTED = -3;
        public const int ERROR_BAD_FORMAT = -1;
        public const int ERROR_READING = -2;

        public const String XML_REPORT = "XML";
        public const String TXT_REPORT = "TXT";

        /// <summary>
        /// method for reading the configuration file
        /// </summary>
        /// <param name="filename">the name of the configuration file</param>
        /// <returns></returns>
        public static int ReadConfiguration(String filename)
        {

            if (!File.Exists(Configuration_Filename))
            {
                // Initilize to default values when file doesn't exist.

                m_databaseConnectionStr = "Server=" + System.Environment.MachineName + "\\SQLEXPRESS;Database=ASTDB;Integrated Security=True;";
                m_databaseName = System.Environment.MachineName + "\\SQLEXPRESS";
                m_threadPoolSize = 10;
                m_PSToolsFullPath = ".//";
                m_reportsFullPath = ".//";
                m_reportOption = "";

                System.Diagnostics.Debug.WriteLine("ConfigurationManager::ReadConfiguration:: configuration file " + Configuration_Filename + " doesn't exist.");
                System.Diagnostics.Debug.WriteLine("using defaults values: DBConnectionString = " + m_databaseConnectionStr + ", MaxThreadPoolSize = " + m_threadPoolSize + ", PSToolPath = " + m_PSToolsFullPath + ", ReportsPath = " + m_reportsFullPath);
                return SUCCESS;
            }

            //In-case Configuratio file exists
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Configuration_Filename);

                //Reading Database connection string
                XmlNodeList list = xmlDoc.GetElementsByTagName("DatabaseConnectionString");
                if (list.Count > 0)
                {
                    m_databaseConnectionStr = list[0].InnerText;
                    m_databaseName = ResolveDatabaseName(m_databaseConnectionStr);
                }
                else return ERROR_BAD_FORMAT;

                //Reading max thread pool size
                list = xmlDoc.GetElementsByTagName("MaxThreadPoolSize");
                if (list.Count > 0) m_threadPoolSize = Convert.ToInt32(list[0].InnerText);
                else return ERROR_BAD_FORMAT;

                //Reading PSTools Full Path
                list = xmlDoc.GetElementsByTagName("PSToolsPath");
                if (list.Count > 0) m_PSToolsFullPath = list[0].InnerText;
                else return ERROR_BAD_FORMAT;

                //Reading Report Full Path
                list = xmlDoc.GetElementsByTagName("ReportsPath");
                if (list.Count > 0) m_reportsFullPath = list[0].InnerText;
                else return ERROR_BAD_FORMAT;

                //Reading XML Report Option
                list = xmlDoc.GetElementsByTagName("ReportOption");
                if (list.Count > 0) m_reportOption = list[0].InnerText;
                else return ERROR_BAD_FORMAT;

                System.Diagnostics.Debug.WriteLine("ConfigurationManager::ReadConfiguration:: configuration file " + Configuration_Filename + " found.");
                System.Diagnostics.Debug.WriteLine("using values: DBConnectionString = " + m_databaseConnectionStr + ", MaxThreadPoolSize = " + m_threadPoolSize + ", PSToolsPath = " + m_PSToolsFullPath + ", ReportsPath = " + m_reportsFullPath);

                return SUCCESS;
            }
            catch (System.Xml.XmlException e)
            {
                System.Diagnostics.Debug.WriteLine("ConfigurationManager::ReadConfiguration:: can't access " + Configuration_Filename + " or XML bad format.");
                System.Diagnostics.Debug.WriteLine(e.Message);
                return ERROR_READING;
            }
        }

        /// <summary>
        /// method for creating a new configuration file from the application
        /// </summary>
        /// <param name="databaseName">Name of the database</param>
        /// <param name="PSToolsPath">PSTOOLS path</param>
        /// <param name="maxTheardPoolSize">Num of maximum threads in the thread pool</param>
        /// <param name="reportsPath">Paht of report file</param>
        /// <param name="reportOption">the selected report format (TXT\XML)</param>
        /// <returns></returns>
        public static int WriteConfiguration(String databaseName, String PSToolsPath, int maxTheardPoolSize, String reportsPath, String reportOption)
        {

            try
            {

                String DBConnectionString = "Server=" + databaseName + ";Database=ASTDB;Integrated Security=True;";

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

                // Write ReportsPath element
                textWriter.WriteStartElement("ReportsPath", "");
                textWriter.WriteString(reportsPath);
                textWriter.WriteEndElement();

                // Write XML Report Option element
                textWriter.WriteStartElement("ReportOption", "");
                textWriter.WriteString(reportOption);
                textWriter.WriteEndElement();

                // Close root element
                textWriter.WriteEndDocument();
                textWriter.Close();

                m_databaseConnectionStr = DBConnectionString;
                m_databaseName = databaseName;
                m_PSToolsFullPath = PSToolsPath;
                m_threadPoolSize = maxTheardPoolSize;
                m_reportsFullPath = reportsPath;
                m_reportOption = reportOption;

                System.Diagnostics.Debug.WriteLine("ConfigurationManager::WriteConfiguration:: configuration file " + Configuration_Filename + " updated.");
                System.Diagnostics.Debug.WriteLine("using values: DBConnectionString = " + m_databaseConnectionStr + ", MaxThreadPoolSize = " + m_threadPoolSize + ", PSToolsPath = " + m_PSToolsFullPath + ", ReportsPath = " + m_reportsFullPath);

                return SUCCESS;
            }
            catch (System.InvalidOperationException e)
            {
                System.Diagnostics.Debug.WriteLine("ConfigurationManager::WriteConfiguration:: failed to write to " + Configuration_Filename);
                System.Diagnostics.Debug.WriteLine(e.Message);
                return ERROR_UNEXPECTED;
            }
            catch (System.ArgumentException e)
            {
                System.Diagnostics.Debug.WriteLine("ConfigurationManager::WriteConfiguration:: Invalid arguments.");
                System.Diagnostics.Debug.WriteLine(e.Message);
                return ERROR_INVALID_ARGUMENTS;
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ConfigurationManager::WriteConfiguration:: failed to save " + Configuration_Filename);
                System.Diagnostics.Debug.WriteLine(e.Message);
                return ERROR_WRITING;
            }
        }

        /// <summary>
        /// method for getting the connection string 
        /// </summary>
        /// <returns>the connection string</returns>
        public static String GetDBConnectionString()
        {
            return m_databaseConnectionStr;
        }

        /// <summary>
        /// method for getting the database name
        /// </summary>
        /// <returns>the database name</returns>
        public static String GetDatabaseName()
        {
            return m_databaseName;
        }

        /// <summary>
        /// method for getting the maximum number of threads in the thread pool
        /// </summary>
        /// <returns>the number of maximum threads in the thread pool</returns>
        public static int GetMaxThreadPoolSize()
        {
            return m_threadPoolSize;
        }

        /// <summary>
        /// method for getting the PSTOOLS path
        /// </summary>
        /// <returns>PSTOOLS path</returns>
        public static String GetPSToolsFullPath()
        {
            return m_PSToolsFullPath;
        }

        /// <summary>
        /// method for getting the report full path
        /// </summary>
        /// <returns>the report full path</returns>
        public static String GetReportFullPath()
        {
            return m_reportsFullPath;
        }

        /// <summary>
        /// method for getting the selected report format ( TXT\XML )
        /// </summary>
        /// <returns>the report file selected format</returns>
        public static String GetReportOption()
        {
            return m_reportOption;
        }

        /// <summary>
        /// method for resloving the database name from the connection string
        /// </summary>
        /// <param name="connectionString">the connection string</param>
        /// <returns>the database name</returns>
        private static String ResolveDatabaseName(String connectionString)
        {
            // Server=CPUNAME\SQLEXPRESS;Database=ASTDB;Integrated Security=True;
            int startIndex = connectionString.IndexOf("=");
            int endIndex = connectionString.IndexOf(";");
            if ((startIndex > 0) && (endIndex > 0)) return connectionString.Substring(startIndex + 1, endIndex - startIndex - 1);
            else return connectionString;
        }

    }
}
