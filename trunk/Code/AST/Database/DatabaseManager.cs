using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AST.Domain;


namespace AST.Database
{
    class DatabaseManager
    {
        private Hashtable m_endStations;
        private Hashtable m_actionInfo;
        private Hashtable m_TSCInfo;
        private Hashtable m_TPInfo;
        private List<String> m_reportsNames;
        private IDatabaseHandler m_DBHandler;
        private IResultHandler m_resultHandler;

        public DatabaseManager(IDatabaseHandler DBhandler, IResultHandler resultHandler){
            this.m_endStations = new Hashtable();
            this.m_actionInfo = new Hashtable();
            this.m_TSCInfo = new Hashtable();
            this.m_TPInfo = new Hashtable();
            this.m_reportsNames = new List<String>();
            this.m_DBHandler = DBhandler;
            this.m_resultHandler = resultHandler;
        }

        public void Init(){
            this.m_endStations = this.m_DBHandler.GetAllEndStations();
            this.m_actionInfo = this.m_DBHandler.GetInfo(AbstractAction.AbstractActionTypeEnum.ACTION);
            this.m_TSCInfo = this.m_DBHandler.GetInfo(AbstractAction.AbstractActionTypeEnum.TSC);
            this.m_TPInfo = this.m_DBHandler.GetInfo(AbstractAction.AbstractActionTypeEnum.TP);
            this.m_reportsNames = this.m_resultHandler.GetNames();
        }

        public void DeleteAbstractAction(String name, AbstractAction.AbstractActionTypeEnum type){
            switch (type)
            {
                case AbstractAction.AbstractActionTypeEnum.ACTION:{
                    this.m_actionInfo.Remove(name);
                    break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TSC:{
                    this.m_TSCInfo.Remove(name);
                    break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TP:{
                    this.m_TPInfo.Remove(name);
                    break;
                    }
            }
            this.m_DBHandler.Delete(name, type);
        }

        public void DeleteReport(String name){
            this.m_reportsNames.Remove(name);
            this.m_resultHandler.Delete(name);
        }

        public bool Exist(String filename){
            return true;
        }

        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type){
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION: return this.m_actionInfo;
                case AbstractAction.AbstractActionTypeEnum.TSC: return this.m_TSCInfo;
                case AbstractAction.AbstractActionTypeEnum.TP: return this.m_TPInfo;
                default: throw new InvalidCastException("Unknown type: "+type.ToString());
            }
        }

        public List<RecentEntry> GetRecent(int recent) {
            return this.m_DBHandler.GetRecent(recent);
        }

        public List<RecentEntry> GetRecent(int recent, AbstractAction.AbstractActionTypeEnum type) {
            return this.m_DBHandler.GetRecent(recent, type);
        }

        public List<String> GetReportsNames(){
            return this.m_reportsNames;
        }

        public List<Parameter> GetParameters(String actionName) {
            return this.m_DBHandler.GetParameters(actionName);
        }

        public Hashtable GetAllEndStations(){
            return this.m_endStations;
        }

        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type){
            return this.m_DBHandler.Load(name, type);
        }

        public List<Result> LoadReport(String reportName){
            return this.m_resultHandler.Load(reportName);
        }

        public void Save(AbstractAction a, AbstractAction.AbstractActionTypeEnum type, bool isNew){

            //if we create new action that its name already exist
            if ((isNew) && (this.m_DBHandler.IsExist(a, type))) throw new InvalidNameException("The name: " + a.Name + " already exists.");

            this.m_DBHandler.Save(a, type);
            
            switch (type) {
                case AbstractAction.AbstractActionTypeEnum.ACTION: {
                        if (this.m_actionInfo.Contains(a.Name))
                            this.m_actionInfo.Remove(a.Name);
                        this.m_actionInfo.Add(a.Name, a.Description);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TSC: {
                        if (this.m_TSCInfo.Contains(a.Name))
                            this.m_TSCInfo.Remove(a.Name);
                        this.m_TSCInfo.Add(a.Name, a.Description);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TP: {
                    if (this.m_TPInfo.Contains(a.Name))
                        this.m_TPInfo.Remove(a.Name);
                    this.m_TPInfo.Add(a.Name, a.Description);
                    break;
                    }
            }
            
        }

        public void SaveResult(Result res, String reportName) {
            if (this.m_reportsNames.Contains(reportName)) {
                int index = this.m_reportsNames.IndexOf(reportName);
                this.m_reportsNames.Remove(reportName);
                this.m_reportsNames.Insert(index, reportName);
            }
            else this.m_reportsNames.Add(reportName);

            this.m_resultHandler.Save(res, reportName);
        }

        public void AddEndStation(EndStation es, bool isNew){

            //if we create new end-station that its ID already exist
            if ((isNew) && (this.m_DBHandler.IsExist(es))) throw new InvalidNameException("The ID: " + es.ID + " already exists.");
            this.m_DBHandler.Save(es);

            if (this.m_endStations.Contains(es.ID)) this.m_endStations.Remove(es.ID);
            this.m_endStations.Add(es.ID, es);
        }

        public void Delete(EndStation es){
            this.m_endStations.Remove(es.ID);
            this.m_DBHandler.Delete(es);
        }

        public void Save(Parameter p, String actionName, bool isNew) {
            //if we create new parameter that its name already exist
            if ((isNew) && (this.m_DBHandler.IsExist(p, actionName))) throw new InvalidNameException("The name: " + p.Name + " already exists.");

            this.m_DBHandler.Save(p, actionName);
        }

        public void Delete(Parameter p, String actionName) {
            this.m_DBHandler.Delete(p, actionName);
        }
    }
}
