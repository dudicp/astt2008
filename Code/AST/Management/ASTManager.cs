using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net;
using AST.Domain;
using AST.Database;

using System.Windows.Forms;


namespace AST.Management
{
    /// <summary>
    /// 
    /// </summary>
    class ASTManager
    {

        private static ASTManager m_instance = null;
        private DatabaseManager m_databaseManager;
        private List<ASTOutputListener> m_outputListeners;
        private ExecutionManager m_executionManager;

        /// <summary>
        /// CTor for the ASTManager
        /// Called from the GetInstance method
        /// implemented as a singleton
        /// </summary>
        private ASTManager()
        {
            this.m_outputListeners = new List<ASTOutputListener>();
            this.m_executionManager = new ExecutionManager(10);
        }

        /// <summary>
        /// returns the single instance of the ASTManager
        /// </summary>
        /// <returns></returns>
        public static ASTManager GetInstance()
        {
            if (m_instance == null)
                m_instance = new ASTManager();
            return m_instance;
        }

        /// <summary>
        /// method for Initializing the ASTManager instance
        /// </summary>
        public void Init()
        {
            int res = ConfigurationManager.ReadConfiguration(ConfigurationManager.Configuration_Filename);
            switch (res)
            {
                case ConfigurationManager.SUCCESS:
                    SQLHandler sql = new SQLHandler(ConfigurationManager.GetDBConnectionString());
                    if (ConfigurationManager.GetReportOption().Equals(ConfigurationManager.TXT_REPORT))
                        m_databaseManager = new DatabaseManager(sql, new TXTHandler());
                    else m_databaseManager = new DatabaseManager(sql, new XMLHandler());
                    m_databaseManager.Init();
                    break;
                case ConfigurationManager.ERROR_READING:
                    this.DisplayErrorMessage("Can't access " + ConfigurationManager.Configuration_Filename + " or invliad XML format.");
                    this.Exit();
                    break;
                case ConfigurationManager.ERROR_BAD_FORMAT:
                    this.DisplayErrorMessage("Configuration file " + ConfigurationManager.Configuration_Filename + " has bad format.");
                    this.Exit();
                    break;
                default:
                    this.DisplayErrorMessage("Unexpected error while reading the configuration file.");
                    this.Exit();
                    break;
            }
        }

        /// <summary>
        /// method for closing the application
        /// </summary>
        public void Exit()
        {
            Application.Exit();
            Environment.Exit(0);
        }

        /// <summary>
        /// Method for deleting AbstractAction
        /// </summary>
        /// <param name="name">the name of the action</param>
        /// <param name="type">the action type (Action\TSC\TP)</param>
        public void DeleteAbstractAction(String name, AbstractAction.AbstractActionTypeEnum type)
        {
            this.m_databaseManager.DeleteAbstractAction(name, type);
            // notify the ASTOutputListener
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayInfoMessage(name + " Deleted Successfully.");
        }

        /// <summary>
        /// method for getting AbstractAction Hash table by the type
        /// </summary>
        /// <param name="type">AbstractAction type (Action\TSC\TP)(</param>
        /// <returns>Abstract action Hashtable</returns>
        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type)
        {
            return this.m_databaseManager.GetInfo(type);
        }

        /// <summary>
        /// method for getting most recent AbstractActions
        /// </summary>
        /// <param name="recent">number of AbstractActions on the returned list</param>
        /// <returns>List of recent AbstractActions</returns>
        public List<RecentEntry> GetRecent(int recent)
        {
            return this.m_databaseManager.GetRecent(recent);
        }

        /// <summary>
        /// method for getting most recent AbstractActions by Type
        /// </summary>
        /// <param name="recent">number of AbstractActions on the returned list</param>
        /// <param name="type"></param>
        /// <returns>List of recent AbstractActions by Type</returns>
        public List<RecentEntry> GetRecent(int recent, AbstractAction.AbstractActionTypeEnum type)
        {
            return this.m_databaseManager.GetRecent(recent, type);
        }

        /// <summary>
        /// Method for geting action params
        /// </summary>
        /// <param name="actionName">The action name</param>
        /// <returns>List of params for the action</returns>
        public List<Parameter> GetParameters(String actionName)
        {
            return this.m_databaseManager.GetParameters(actionName);
        }

        /// <summary>
        /// Method for getting all End-Stations
        /// </summary>
        /// <returns>Hashtable of End-Stations</returns>
        public Hashtable GetEndStations()
        {
            return this.m_databaseManager.GetAllEndStations();
        }

        /// <summary>
        /// method for getting an id for the next end-station
        /// </summary>
        /// <returns>an id for the next end-station</returns>
        public int GetUnusedEndStationIndex()
        {
            // getting all end-stations
            Hashtable endStations = m_databaseManager.GetAllEndStations();

            // finding an unused id
            for (int i = 0; i < endStations.Count; i++)
                if (!endStations.Contains(i))
                    return i;

            return endStations.Count;
        }

        /// <summary>
        /// Method for Loading an AbstractAction from the Database
        /// </summary>
        /// <param name="name">Action name</param>
        /// <param name="type">Action Type(Action\TSC\TP)</param>
        /// <returns>AbstarctAction object</returns>
        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type)
        {
            return this.m_databaseManager.Load(name, type);
        }

        /// <summary>
        /// Method for Saving an AbstractAction on the Database
        /// </summary>
        /// <param name="a">The AbstractAction object to save</param>
        /// <param name="type">The AbstractAction Type</param>
        /// <param name="isNew">Signals if the Action already exist</param>
        public void Save(AbstractAction a, AbstractAction.AbstractActionTypeEnum type, bool isNew)
        {
            this.m_databaseManager.Save(a, type, isNew);
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayInfoMessage(a.Name + " Saved Successfully.");
        }

        /// <summary>
        /// Method for Saving a Result on the Database
        /// </summary>
        /// <param name="res">A Result object</param>
        /// <param name="reportName">The report filename</param>
        public void Save(Result res, String reportName)
        {
            //called from the execution manager
            try
            {
                this.m_databaseManager.SaveResult(res, reportName);
            }
            catch (SaveReportException e) { }
        }

        /// <summary>
        /// Method for displaying a report
        /// </summary>
        /// <param name="reportName">The report filename</param>
        public void ShowReport(String reportName)
        {
            // getting the report full path
            String reportFilename = ConfigurationManager.GetReportFullPath() + "\\" + reportName;
            try
            {
                this.m_databaseManager.ShowReport(reportFilename);
            }
            catch (OpenFileFailedException e)
            {
                this.DisplayErrorMessage(e.Message);
            }
        }

        /// <summary>
        /// Method for adding an End-station to the database
        /// </summary>
        /// <param name="es">End-station object</param>
        /// <param name="isNew">Signals if the End-station already exist</param>
        public void AddEndStation(EndStation es, bool isNew)
        {
            this.m_databaseManager.AddEndStation(es, isNew);
        }

        /// <summary>
        /// Method for deleting End-station from the database
        /// </summary>
        /// <param name="es">an End-station object</param>
        public void RemoveEndStation(EndStation es)
        {
            this.m_databaseManager.Delete(es);
        }

        /// <summary>
        /// method for starting the process of execution of an AbstractAction
        /// the method resumes the suspended thread and the thread performes another itteration in the loop
        /// </summary>
        /// <param name="action">the AbstractAction to execute</param>
        /// <param name="type">the action type (Action\TSC\TP)</param>
        /// <param name="executionName">the name of the report file</param>
        public void Execute(AbstractAction a, AbstractAction.AbstractActionTypeEnum type, String executionName)
        {
            //Console.WriteLine("Executing " + a.Name + ", Report Name: " + executionName);
            String reportFilename = ConfigurationManager.GetReportFullPath() + "\\" + executionName;
            m_executionManager.Execute(a, type, reportFilename);
        }

        /// <summary>
        /// method for registring output listeners 
        /// </summary>
        /// <param name="o">the output listener to register</param>
        public void AddOutputListener(ASTOutputListener o)
        {
            // add o to the output listeners list
            this.m_outputListeners.Add(o);
        }

        /// <summary>
        /// method for unregistering output listeners
        /// </summary>
        /// <param name="o">the output listener to register </param>
        public void RemoveOutputListener(ASTOutputListener o)
        {
            // trmove o from the output listeners list
            this.m_outputListeners.Remove(o);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveAllOutputListeners()
        {
            // YC
            this.m_outputListeners.Clear();
        }

        /// <summary>
        /// method for registering output listeners to the execution manager
        /// </summary>
        /// <param name="o">the output listener to register</param>
        public void AddExecutionManagerOutputListener(ExecutionManagerOutputListener o)
        {
            this.m_executionManager.AddOutputListener(o);
        }

        /// <summary>
        /// method for unregistering output listeners to the execution manager
        /// </summary>
        /// <param name="o">the output listener to unregister</param>
        public void RemoveExecutionManagerOutputListener(ExecutionManagerOutputListener o)
        {
            this.m_executionManager.RemoveOutputListener(o);
        }

        /// <summary>
        /// method for unregistering all the output listeners
        /// </summary>
        public void RemoveAllExecutionManagerOutputListeners()
        {
            this.m_executionManager.RemoveAllOutputListeners();
        }

        /// <summary>
        /// method for Displaying the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            // invoke each output listener's DisplayWelcomeScreen method
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayWelcomeScreen();
        }

        /// <summary>
        /// method for Displaying error message
        /// </summary>
        /// <param name="message"></param>
        private void DisplayErrorMessage(String message)
        {
            // invoke each output listener's DisplayErrorMessage method
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayErrorMessage(message);
        }

        /// <summary>
        /// method for Displaying info message
        /// </summary>
        /// <param name="message"></param>
        private void DisplayInfoMessage(String message)
        {
            // invoke each output listener's DisplayInfoMessage method
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayInfoMessage(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="a"></param>
        /// <param name="isNew"></param>
        public void Save(Parameter p, Action a, bool isNew)
        {
            // YC
            this.m_databaseManager.Save(p, a.Name, isNew);
        }

        /// <summary>
        /// Method for deleting Parameter from the database
        /// </summary>
        /// <param name="p">a parameter object</param>
        /// <param name="a">the action containig the parameter</param>
        public void Delete(Parameter p, Action a)
        {
            this.m_databaseManager.Delete(p, a.Name);
        }

    }
}
