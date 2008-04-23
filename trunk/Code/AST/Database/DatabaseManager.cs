using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AST.Domain;


namespace AST.Database
{
    class DatabaseManager
    {
        private Hashtable m_actionInfo;
        private Hashtable m_TSCInfo;
        private Hashtable m_TPInfo;
        private List<String> m_reportsNames;
        private IDatabaseHandler m_DBHandler;
        private IResultHandler m_resultHandler;

        public DatabaseManager(IDatabaseHandler DBhandler, IResultHandler resultHandler){
            this.m_actionInfo = new Hashtable();
            this.m_TSCInfo = new Hashtable();
            this.m_TPInfo = new Hashtable();
            this.m_reportsNames = new List<String>();
            this.m_DBHandler = DBhandler;
            this.m_resultHandler = resultHandler;
        }

        public void Init(){
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
                default:{
                    //throw exception
                    return null;
                    }
            }
        }

        public List<String> GetReportsNames(){
            return this.m_reportsNames;
        }

        public List<Parameter> GetParameters(String actionName) {
            return this.m_DBHandler.GetParameters(actionName);
        }

        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type){
            return this.m_DBHandler.Load(name, type);
        }

        public List<Result> LoadReport(String reportName){
            return this.m_resultHandler.Load(reportName);
        }

        public void Save(AbstractAction a, AbstractAction.AbstractActionTypeEnum type){
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
            this.m_DBHandler.Save(a, type);
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
    }
}