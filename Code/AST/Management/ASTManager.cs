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
        private Hashtable m_endStations;
        private DatabaseManager m_databaseManager;
        private List<ASTOutputListener> m_outputListeners;

        private ASTManager() {
            this.m_endStations = new Hashtable();
            this.m_outputListeners = new List<ASTOutputListener>();
        }

        public static ASTManager GetInstance() {
            if (m_instance == null) m_instance = new ASTManager();
            return m_instance;
        }

        public void Init(IPAddress ip, int port) {
            SQLHandler sql = new SQLHandler();
            sql.Connect(ip, port);
            m_databaseManager = new DatabaseManager(sql, new XMLHandler());
            m_databaseManager.Init();
        }

        public void Exit() {
            Application.Exit();
        }

        public void DeleteAbstractAction(String name, AbstractAction.AbstractActionTypeEnum type) {
            this.m_databaseManager.DeleteAbstractAction(name, type);
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

        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type) {
            return this.m_databaseManager.Load(name, type);
        }

        public List<Result> LoadReport(String reportName) {
            return this.m_databaseManager.LoadReport(reportName);
        }

        public void Save(AbstractAction a, AbstractAction.AbstractActionTypeEnum type) {
            this.m_databaseManager.Save(a, type);
        }

        public void SaveResult(Result res, String reportName) {
            this.m_databaseManager.SaveResult(res, reportName);
        }

        public void AddEndStation(EndStation es) {
            if (this.m_endStations.Contains(es.ID)) this.m_endStations.Remove(es.ID);
            this.m_endStations.Add(es.ID,es);
        }

        public void RemoveEndStation(EndStation es) {
            this.m_endStations.Remove(es.ID);
        }

        public void Execute(AbstractAction a, String executionName) {  }

        public void AddOutputListener(ASTOutputListener o) {
            this.m_outputListeners.Add(o);
        }

        public void RemoveOutputListener(ASTOutputListener o) {
            this.m_outputListeners.Remove(o);
        }

        public void RemoveAllOutputListeners() {
            this.m_outputListeners.Clear();
        }

        public void DisplayWelcomeScreen() {
            foreach (ASTOutputListener o in this.m_outputListeners)
                o.DisplayWelcomeScreen();
        }
    }
}
