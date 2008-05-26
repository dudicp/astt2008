using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net;
using AST.Domain;
using AST.Database;

using System.Windows.Forms;


namespace AST.Management {

    class ASTManager {

        private static ASTManager m_instance = null;
        private DatabaseManager m_databaseManager;
        private List<ASTOutputListener> m_outputListeners;
        private ExecutionManager m_executionManager;
        //private NetworkBrowser m_networkBrowser;
        
        private ASTManager() {
            this.m_outputListeners = new List<ASTOutputListener>();
            this.m_executionManager = new ExecutionManager(10);
        }

        public static ASTManager GetInstance() {
            if (m_instance == null) m_instance = new ASTManager();
            return m_instance;
        }

        public void Init() {
            int res = ConfigurationManager.ReadConfiguration(ConfigurationManager.Configuration_Filename);
            switch (res) {
                case ConfigurationManager.SUCCESS: 
                    SQLHandler sql = new SQLHandler(ConfigurationManager.GetDBConnectionString());
                    m_databaseManager = new DatabaseManager(sql, new XMLHandler());
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

        public void Exit() {
            Application.Exit();
            Environment.Exit(0);
        }

        public void DeleteAbstractAction(String name, AbstractAction.AbstractActionTypeEnum type) {
            this.m_databaseManager.DeleteAbstractAction(name, type);
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayInfoMessage(name + " Deleted Successfully.");
        }

        public void DeleteReport(String reportName) {
            this.m_databaseManager.DeleteReport(reportName);
        }

        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type) {
            return this.m_databaseManager.GetInfo(type);
        }

        public List<String> GetReportsNames() {
            return this.m_databaseManager.GetReportsNames();
        }

        public List<Parameter> GetParameters(String actionName) {
            return this.m_databaseManager.GetParameters(actionName);
        }

        public Hashtable GetEndStations() {
            return this.m_databaseManager.GetAllEndStations();
        }

        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type) {
            return this.m_databaseManager.Load(name, type);
        }

        public List<Result> LoadReport(String reportName) {
            return this.m_databaseManager.LoadReport(reportName);
        }

        public void Save(AbstractAction a, AbstractAction.AbstractActionTypeEnum type, bool isNew) {
            this.m_databaseManager.Save(a, type, isNew);
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayInfoMessage(a.Name + " Saved Successfully.");
        }

        public void SaveResult(Result res, String reportName) {
            this.m_databaseManager.SaveResult(res, reportName);
        }

        public void AddEndStation(EndStation es, bool isNew) {
            this.m_databaseManager.AddEndStation(es, isNew);
        }

        public void RemoveEndStation(EndStation es) {
            this.m_databaseManager.Delete(es);
        }

        public void Execute(AbstractAction a, String executionName) 
        {
            //Console.WriteLine("Executing " + a.Name + ", Report Name: " + executionName);
            m_executionManager.Execute(a, executionName);
        }

        public void AddOutputListener(ASTOutputListener o) {
            this.m_outputListeners.Add(o);
        }

        public void RemoveOutputListener(ASTOutputListener o) {
            this.m_outputListeners.Remove(o);
        }

        public void RemoveAllOutputListeners() {
            this.m_outputListeners.Clear();
        }

        public void AddExecutionManagerOutputListener(ExecutionManagerOutputListener o) {
            this.m_executionManager.AddOutputListener(o);
        }

        public void RemoveExecutionManagerOutputListener(ExecutionManagerOutputListener o) {
            this.m_executionManager.RemoveOutputListener(o);
        }

        public void RemoveAllExecutionManagerOutputListeners() {
            this.m_executionManager.RemoveAllOutputListeners();
        }

        public void DisplayWelcomeScreen() {
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayWelcomeScreen();
        }

        private void DisplayErrorMessage(String message) {
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayErrorMessage(message);
        }

        private void DisplayInfoMessage(String message) {
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayInfoMessage(message);
        }

        /*public ArrayList GetComputerList(){
            return m_networkBrowser.getNetworkComputers();
        }*/

        public void Save(Parameter p, Action a, bool isNew) {
            this.m_databaseManager.Save(p, a.Name, isNew);
        }

        public void Delete(Parameter p, Action a) {
            this.m_databaseManager.Delete(p, a.Name);
        }

    }
}
