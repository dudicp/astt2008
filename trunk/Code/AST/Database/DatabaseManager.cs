using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AST.Domain;


namespace AST.Database
{
    /// <summary>
    /// this calss is responisble for controling the actions performed on the database
    /// (Load, Save ... )
    /// </summary>
    class DatabaseManager
    {
        private Hashtable m_endStations;
        private Hashtable m_actionInfo;
        private Hashtable m_TSCInfo;
        private Hashtable m_TPInfo;
        private IDatabaseHandler m_DBHandler;
        private IResultHandler m_resultHandler;

        /// <summary>
        /// CTor for the DatabaseManager
        /// </summary>
        /// <param name="DBhandler">a Database handler object</param>
        /// <param name="resultHandler">a Result handler object</param>
        public DatabaseManager(IDatabaseHandler DBhandler, IResultHandler resultHandler)
        {
            this.m_endStations = new Hashtable();
            this.m_actionInfo = new Hashtable();
            this.m_TSCInfo = new Hashtable();
            this.m_TPInfo = new Hashtable();
            this.m_DBHandler = DBhandler;
            this.m_resultHandler = resultHandler;
        }

        /// <summary>
        /// method for initializing all the data of the system from the database
        /// </summary>
        public void Init()
        {
            try {
                this.m_endStations = this.m_DBHandler.GetAllEndStations();
                this.m_actionInfo = this.m_DBHandler.GetInfo(AbstractAction.AbstractActionTypeEnum.ACTION);
                this.m_TSCInfo = this.m_DBHandler.GetInfo(AbstractAction.AbstractActionTypeEnum.TSC);
                this.m_TPInfo = this.m_DBHandler.GetInfo(AbstractAction.AbstractActionTypeEnum.TP);
            }
            catch (DatabaseException e) {
                throw e;
            }
        }

        /// <summary>
        /// method for deleting an abstract action (Action\TSC\TP) from the database.
        /// </summary>
        /// <param name="name">the action name</param>
        /// <param name="type">the action type(Action\TSC\TP)</param>
        public void DeleteAbstractAction(String name, AbstractAction.AbstractActionTypeEnum type)
        {
            try {
                this.m_DBHandler.Delete(name, type);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (QueryFailedException e) { throw e; }

            switch (type)
            {
                case AbstractAction.AbstractActionTypeEnum.ACTION:
                    {
                        this.m_actionInfo.Remove(name);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TSC:
                    {
                        this.m_TSCInfo.Remove(name);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TP:
                    {
                        this.m_TPInfo.Remove(name);
                        break;
                    }
            }
        }

        /// <summary>
        /// method for getting AbstractAction Hash table by the type
        /// </summary>
        /// <param name="type">AbstractAction type (Action\TSC\TP)(</param>
        /// <returns>Abstract action Hashtable</returns>
        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type)
        {
            try {
                switch (type) {
                    case AbstractAction.AbstractActionTypeEnum.ACTION: return this.m_actionInfo;
                    case AbstractAction.AbstractActionTypeEnum.TSC: return this.m_TSCInfo;
                    case AbstractAction.AbstractActionTypeEnum.TP: return this.m_TPInfo;
                    default: throw new InvalidCastException("Unknown type: " + type.ToString());
                }
            }
            catch (DatabaseException e) { throw e; }
        }

        /// <summary>
        /// method for getting most recent AbstractActions
        /// </summary>
        /// <param name="recent">number of AbstractActions on the returned list</param>
        /// <returns>List of recent AbstractActions</returns>
        public List<RecentEntry> GetRecent(int recent)
        {
            try {
                return this.m_DBHandler.GetRecent(recent);
            }
            catch (DatabaseException e) { throw e; }
        }
        /// <summary>
        /// method for getting most recent AbstractActions by Type
        /// </summary>
        /// <param name="recent">number of AbstractActions on the returned list</param>
        /// <param name="type"></param>
        /// <returns>List of recent AbstractActions by Type</returns>
        public List<RecentEntry> GetRecent(int recent, AbstractAction.AbstractActionTypeEnum type)
        {
            try{
                return this.m_DBHandler.GetRecent(recent, type);
            }
            catch (DatabaseException e) { throw e; }
        }

        /// <summary>
        /// Method for geting action params
        /// </summary>
        /// <param name="actionName">The action name</param>
        /// <returns>List of params for the action</returns>
        public List<Parameter> GetParameters(String actionName)
        {
            try {
                return this.m_DBHandler.GetParameters(actionName);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                System.Diagnostics.Debug.WriteLine("SQLHandler::GetParameters:: Loading parameters of action: " + actionName + " failed.");
                throw new QueryFailedException("Loading parameters of action " + actionName + " failed.", e);
            }
        }

        /// <summary>
        /// Method for getting all End-Stations
        /// </summary>
        /// <returns>Hashtable of End-Stations</returns>
        public Hashtable GetAllEndStations()
        {
            return this.m_endStations;
        }

        /// <summary>
        /// Method for Loading an AbstractAction from the Database
        /// </summary>
        /// <param name="name">Action name</param>
        /// <param name="type">Action Type(Action\TSC\TP)</param>
        /// <returns>AbstarctAction object</returns>
        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type)
        {
            try {
                return this.m_DBHandler.Load(name, type);
            }
            catch (DatabaseException e) { throw e; }
        }

        /// <summary>
        /// Method for Saving an AbstractAction on the Database
        /// </summary>
        /// <param name="a">The AbstractAction object to save</param>
        /// <param name="type">The AbstractAction Type</param>
        /// <param name="isNew">Signals if the Action already exist</param>
        public void Save(AbstractAction a, AbstractAction.AbstractActionTypeEnum type, bool isNew)
        {
            //if we create new action that its name already exist
            if ((isNew) && (this.m_DBHandler.IsExist(a, type))) throw new InvalidNameException("The name " + a.Name + " already exists.");

            try {
                this.m_DBHandler.Save(a, type);
            }
            catch (DatabaseException e) { throw e; }

            switch (type)
            {
                case AbstractAction.AbstractActionTypeEnum.ACTION:
                    {
                        if (this.m_actionInfo.Contains(a.Name))
                            this.m_actionInfo.Remove(a.Name);
                        this.m_actionInfo.Add(a.Name, a.Description);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TSC:
                    {
                        if (this.m_TSCInfo.Contains(a.Name))
                            this.m_TSCInfo.Remove(a.Name);
                        this.m_TSCInfo.Add(a.Name, a.Description);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TP:
                    {
                        if (this.m_TPInfo.Contains(a.Name))
                            this.m_TPInfo.Remove(a.Name);
                        this.m_TPInfo.Add(a.Name, a.Description);
                        break;
                    }
            }

        }

        /// <summary>
        /// Method for Saving a Result on the Database
        /// </summary>
        /// <param name="res">A Result object</param>
        /// <param name="reportName">The report filename</param>
        public void SaveResult(Result res, String reportName)
        {
            try
            {
                this.m_resultHandler.Save(res, reportName);
            }
            catch (SaveReportException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method for adding an End-station to the database
        /// </summary>
        /// <param name="es">End-station object</param>
        /// <param name="isNew">Signals if the End-station already exist</param>
        public void AddEndStation(EndStation es, bool isNew)
        {
            //if we create new end-station that its ID already exist
            if ((isNew) && (this.m_DBHandler.IsExist(es))) throw new InvalidNameException("The ID: " + es.ID + " already exists.");
            try {
                this.m_DBHandler.Save(es);
            }
            catch (DatabaseException e) { throw e; }

            if (this.m_endStations.Contains(es.ID)) this.m_endStations.Remove(es.ID);
            this.m_endStations.Add(es.ID, es);
        }

        /// <summary>
        /// Method for deleting End-station from the database
        /// </summary>
        /// <param name="es">an End-station object</param>
        public void Delete(EndStation es)
        {
            try {
                this.m_endStations.Remove(es.ID);
                this.m_DBHandler.Delete(es);
            }
            catch (DatabaseException e) { throw e; }
        }

        /// <summary>
        /// Method for saving parameter to the database
        /// </summary>
        /// <param name="p">a param object</param>
        /// <param name="actionName">The Action name</param>
        /// <param name="isNew">Signals if the End-station already exist</param>
        public void Save(Parameter p, String actionName, bool isNew)
        {
            //if we create new parameter that its name already exist
            if ((isNew) && (this.m_DBHandler.IsExist(p, actionName))) throw new InvalidNameException("The name: " + p.Name + " already exists.");

            try {
                this.m_DBHandler.Save(p, actionName);
            }
            catch (DatabaseException e) { throw e; }
        }

        /// <summary>
        /// Method for deleting Parameter from the database
        /// </summary>
        /// <param name="p">a parameter object</param>
        /// <param name="actionName">The Action name</param>
        public void Delete(Parameter p, String actionName)
        {
            try {
                this.m_DBHandler.Delete(p, actionName);
            }
            catch (DatabaseException e) { throw e; }
        }

        /// <summary>
        /// Method for displaying a report
        /// </summary>
        /// <param name="filename">The report filename</param>
        public void ShowReport(String filename)
        {
            try
            {
                this.m_resultHandler.ShowReport(filename);
            }
            catch (OpenFileFailedException e)
            {
                throw e;
            }
        }
    }
}
