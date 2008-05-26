using System;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.Text;
using AST.Domain;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Microsoft.ApplicationBlocks.Data;
using System.Diagnostics;

namespace AST.Database{
    
    class SQLHandler : IDatabaseHandler{

        private String m_connectionString;

        public SQLHandler(String connectionString){
            this.m_connectionString = connectionString;
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Connection Method
///////////////////////////////////////////////////////////////////////////////////////////////////////

        private SqlConnection Connect(){
            try {
                Debug.WriteLine("Connecting to: " + this.m_connectionString);
                return new SqlConnection(this.m_connectionString);
            }
            catch (Exception e){
                Debug.WriteLine("SQLHandler::Connect::Connecting to: " + this.m_connectionString + " Failed!");
                throw new ConnectionFailedException("Connection to database: " + this.m_connectionString + " failed.", e);
            }
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Load Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type) {
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION: return LoadAction(name);
                case AbstractAction.AbstractActionTypeEnum.TSC: return LoadTSC(name);
                default : return LoadTP(name);
            }
        }

        private Action LoadAction(String name) {

            ///////////////////
            //1. Load Action //
            ///////////////////
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetAction", name);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadAction:: Loading action: " + name + " failed.");
                throw new QueryFailedException("Loading action: " + name + " failed.", e);
            }
            if (!dr.Read()) throw new EmptyQueryResultException("Action: " + name + " doesn't exist.");

            //Getting the description
            String description = (String)dr.GetValue(1);

            //Getting the action type
            Action.ActionTypeEnum type;
            try {
                type = this.GetActionType((String)dr.GetValue(2));
            }
            catch (InvalidTypeException e) { throw e; }

            //Getting the timeout
            int timeout = (int)dr.GetValue(3);

            //Getting the creator name
            String creatorName = (String)dr.GetValue(4);

            //Getting the creation time
            DateTime creationTime = (DateTime)dr.GetValue(5);

            Action a = new Action(name, description, 0, creatorName, creationTime, timeout, type, 0);

            ////////////////////
            //2. Set Contents //
            ////////////////////
            dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetActionContents", name);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadAction:: Loading action contents of: " + name + " failed.");
                throw new QueryFailedException("Loading action contents of: " + name + " failed.", e);
            }

            while (dr.Read()) {

                //Getting the content OSType
                EndStation.OSTypeEnum OSType = this.GetOSType((String)dr.GetValue(1));

                //Getting the content
                String actionContent = (String)dr.GetValue(2);

                //Getting the validity String
                String validityString = (String)dr.GetValue(3);

                a.AddContent(OSType, actionContent);
                a.AddValidityString(OSType, validityString);
            }

            return a;
        }

        private TSC LoadTSC(String name) {
            return null;
        }

        private TP LoadTP(String name) {
            return null;
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Save Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Save(AbstractAction action, AbstractAction.AbstractActionTypeEnum type) {
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION:
                    this.Save((Action)action);
                    break;
                case AbstractAction.AbstractActionTypeEnum.TSC:
                    this.Save((TSC)action);
                    break;
                default: 
                    this.Save((TP)action);
                    break;
            }
        }

        public void Save(EndStation es) {
            try {
                SqlConnection connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, "sp_insertEndStation", es.ID, es.Name, es.IP.ToString(), es.MAC.ToString(), es.OSType.ToString(), es.OSVersion.ToString(), es.Username, es.Password);
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Save(EndStation):: Saving End-Station " + es.Name + "(" + es.ID + ") failed.");
                throw new QueryFailedException("Saving End-Station " + es.Name + "(" + es.ID + ") failed.", e);
            }
        }

        private void Save(Action action) {

            // 1. Saving Action
            try {
                String storedProcedureName;
                if (this.IsExist(action, AbstractAction.AbstractActionTypeEnum.ACTION)) storedProcedureName = "sp_UpdateAction";
                else storedProcedureName = "sp_InsertAction";

                SqlConnection connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, storedProcedureName, action.Name, action.Description, action.ActionType.ToString(), action.Timeout, action.CreatorName, action.CreationTime);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Save(Action):: Saving action: " + action.Name + " failed.");
                throw new QueryFailedException("Saving action: " + action.Name + " failed.", e);
            }

            // 2. Saving Action Content
            ICollection keys = action.GetAllContents().Keys;
            foreach (EndStation.OSTypeEnum key in keys) {
                try {
                    SqlConnection connection = this.Connect();
                    String validityString;
                    if (action.GetValidityString(key) != null) validityString = action.GetValidityString(key);
                    else validityString = "";

                    SqlHelper.ExecuteNonQuery(connection, "sp_InsertActionContent", action.Name, key, action.GetContent(key), validityString);
                }
                catch (ConnectionFailedException e) { throw e; }
                catch (Exception e) {
                    Debug.WriteLine("SQLHandler::Save(Action):: Saving action content: " + key.ToString() + " failed.");
                    throw new QueryFailedException("Saving action content: " + key.ToString() + " failed.", e);
                }
            }
        }

        private void Save(TSC tsc) { }

        private void Save(TP tp) { }

        public void Save(Parameter p, String actionName) {
            // 1. Saving Parameter
            SqlConnection connection;
            try {
                String storedProcedureName;
                if (this.IsExist(p, actionName)) storedProcedureName = "sp_UpdateParameter";
                else storedProcedureName = "sp_InsertParameter";

                connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, storedProcedureName, actionName, p.Name, p.Description, p.Type.ToString(), p.Input, p.ValidityExp);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Save(Parameter):: Saving paramter: " + p.Name + " failed.");
                throw new QueryFailedException("Saving paramter: " + p.Name + " failed.", e);
            }

            // 2. Saving Parameter Value
            ICollection keys = p.GetAllValues().Keys;
            foreach (EndStation.OSTypeEnum key in keys) {
                try {
                    connection = this.Connect();
                    SqlHelper.ExecuteNonQuery(connection, "sp_InsertParameterContent", actionName, p.Name, key, p.GetValue(key));
                }
                catch (ConnectionFailedException e) { throw e; }
                catch (Exception e) {
                    Debug.WriteLine("SQLHandler::Save(Parameter):: Saving content: " + key.ToString() + " of paramter: " + p.Name + " failed.");
                    throw new QueryFailedException("Saving content: " + key.ToString() + " of paramter: " + p.Name + " failed.", e);
                }
            }
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Delete Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Delete(String name, AbstractAction.AbstractActionTypeEnum type) {
            switch (type) {
                case AbstractAction.AbstractActionTypeEnum.ACTION:
                    DeleteAction(name);
                    break;
                case AbstractAction.AbstractActionTypeEnum.TSC:
                    DeleteTSC(name);
                    break;
                default: 
                    DeleteTP(name);
                    break;
            }
        }

        public void Delete(EndStation es) {
            try {
                SqlConnection connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, "sp_DeleteEndStation", es.ID);
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Delete(EndStation):: Deleting End-Station " + es.Name + "(" + es.ID + ") failed.");
                throw new QueryFailedException("Deleting End-Station " + es.Name + "(" + es.ID + ") failed.", e);
            }
        }

        private void DeleteAction(String name) {
            try {
                SqlConnection connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, "sp_DeleteAction", name);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::DeleteAction:: Deleting action: " + name + " failed.");
                throw new QueryFailedException("Deleting action: " + name + " failed.", e);
            }
        }

        private void DeleteTSC(String name) { }

        private void DeleteTP(String name) { }

        public void Delete(Parameter p, String actionName) {
            try {
                SqlConnection connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, "sp_DeleteParameter", actionName, p.Name);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Delete(Parameter):: Deleting parameter: " + p.Name + " failed.");
                throw new QueryFailedException("Deleting parameter: " + p.Name + " failed.", e);
            }
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Get Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type) {
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION: return GetActionsInfo();
                case AbstractAction.AbstractActionTypeEnum.TSC: return GetTSCsInfo();
                default: return GetTPsInfo();
            }            
        }

        public Hashtable GetAllEndStations() {
            SqlDataReader dr = null;
            Hashtable res = new Hashtable();
            try {
                SqlConnection connection = this.Connect();
                dr = SqlHelper.ExecuteReader(connection, "sp_GetAllEndStations", null);
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetAllEndStations:: Get all end-stations failed.");
                throw new QueryFailedException("Get all end-stations failed.", e);
            }

            while (dr.Read()) {

                //Getting End-Station ID
                int id = (int)dr.GetValue(0);

                //Getting End-Station Name
                String name = (String)dr.GetValue(1);

                //Getting End-Station IP Address
                IPAddress parsed;
                IPAddress ip;
                if (!IPAddress.TryParse((String)dr.GetValue(2), out parsed)) {
                    Debug.WriteLine("Invalid IP Address for EndStation " + id);
                    continue; // if one end-station has invalid ip address we ignore it and continue loading the next end-stations.
                }
                else ip = IPAddress.Parse((String)dr.GetValue(2));

                //Getting End-Station MAC Address
                String mac = (String)dr.GetValue(3);

                //Getting End-Station OS Type
                EndStation.OSTypeEnum osType = this.GetOSType((String)dr.GetValue(4));

                //Getting End-Station UserName
                String username = (String)dr.GetValue(6);

                //Getting End-Station Password
                String password = (String)dr.GetValue(7);

                EndStation es = new EndStation(id, name, ip, osType, username, password);

                es.MAC = mac;

                res.Add(es.ID, es);

                Debug.WriteLine(es.ToString());
            }

            return res;
        }

        private Hashtable GetActionsInfo() {
            Hashtable info = new Hashtable();
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetActionsInfo", null);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetActionsInfo:: Load information of all actions failed.");
                throw new QueryFailedException("Load information of all actions failed.", e);
            }
            while (dr.Read()) {
                String name = (String)dr.GetValue(0);
                String description = (String)dr.GetValue(1);

                info.Add(name, description);
            }
            return info;
        }

        private Hashtable GetTSCsInfo() {
            return new Hashtable();
        }

        private Hashtable GetTPsInfo() {
            return new Hashtable();
        }

        public List<Parameter> GetParameters(String actionName) {
            List<Parameter> res = new List<Parameter>();

            //  1. Load Parameter
            SqlConnection connection;
            SqlDataReader dr = null;
            try {
                connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetActionParameters", actionName);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetParameters:: Loading parameters of action: " + actionName + " failed.");
                throw new QueryFailedException("Loading parameters of action: " + actionName + " failed.", e);
            }

            while (dr.Read()) {

                //Getting the name of the parameter
                String parameterName = (String)dr.GetValue(1);

                //Getting the description of the parameter
                String description = (String)dr.GetValue(2);

                Parameter.ParameterTypeEnum type = this.GetParameterType((String)dr.GetValue(3));

                //Getting the description of the parameter
                String validityExp = (String)dr.GetValue(5);

                Parameter p = new Parameter(parameterName, description, type, validityExp);

                // 2.Load Parameter Content
                SqlDataReader contentDR = null;
                try {
                    connection = this.Connect(); //Creating Connection
                    contentDR = SqlHelper.ExecuteReader(connection, "sp_GetParameterContents", actionName, parameterName);
                }
                catch (ConnectionFailedException e) { throw e; }
                catch (Exception e) {
                    Debug.WriteLine("SQLHandler::GetParameters:: Loading parameter contents of: " + p.Name + " failed.");
                    throw new QueryFailedException("Loading parameter contents of: " + p.Name + " failed.", e);
                }

                while (contentDR.Read()) {

                    //Getting content OSTYpe
                    EndStation.OSTypeEnum OSType = this.GetOSType((String)contentDR.GetValue(2));

                    //Getting content value
                    String value = (String)contentDR.GetValue(3);

                    p.AddValue(OSType, value);
                }
                res.Add(p);
            }
            return res;
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      IsExist Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsExist(AbstractAction action, AbstractAction.AbstractActionTypeEnum type) {
            String storedProcedureName = "";
            switch (type) {
                case AbstractAction.AbstractActionTypeEnum.ACTION:
                    storedProcedureName = "sp_GetAction";
                    break;
                case AbstractAction.AbstractActionTypeEnum.TSC:
                    storedProcedureName = "sp_GetTSC";
                    break;
                default:
                    storedProcedureName = "sp_GetTP";
                    break;
            }

            try {
                SqlConnection connection = this.Connect();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(connection, storedProcedureName, action.Name);
                return dr.HasRows;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::IsExist(AbstractAction):: Loading information of: " + action.Name + " failed.");
                throw new QueryFailedException("Loading information of of: " + action.Name + " failed.", e);
            }

        }

        public bool IsExist(EndStation es) {
            try {
                SqlConnection connection = this.Connect();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(connection, "sp_GetEndStation", es.ID);
                return dr.HasRows;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::IsExist(EndStation):: Loading information of end-station: " + es.Name + " failed.");
                throw new QueryFailedException("Loading information of end-station: " + es.Name + " failed.", e);
            }
        }

        public bool IsExist(Parameter p, String actionName) {
            try {
                SqlConnection connection = this.Connect();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(connection, "sp_GetParameter", actionName, p.Name);
                return dr.HasRows;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::IsExist(Parameter):: Loading information of parameter: " + p.Name + " failed.");
                throw new QueryFailedException("Loading information of parameter: " + p.Name + " failed.", e);
            }
        }


///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Other Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        private EndStation.OSTypeEnum GetOSType(String str){
            switch (str)
            {
                case "WINDOWS": return EndStation.OSTypeEnum.WINDOWS;
                case "UNIX": return EndStation.OSTypeEnum.UNIX;
                default:
                    Debug.WriteLine("Unknown OSType " + str);
                    return EndStation.OSTypeEnum.UNKNOWN;
            }
        }

        private Action.ActionTypeEnum GetActionType(String str){
            switch (str){
                case "COMMAND_LINE": return Action.ActionTypeEnum.COMMAND_LINE;
                case "SCRIPT": return Action.ActionTypeEnum.SCRIPT;
                case "TEST_SCRIPT": return Action.ActionTypeEnum.TEST_SCRIPT;
                default:
                    Debug.WriteLine("Unknown Action Type " + str);
                    throw new InvalidTypeException("Unknown action type " + str);
            }
        }

        private Parameter.ParameterTypeEnum GetParameterType(String str){
            switch (str){
                case "Input": return Parameter.ParameterTypeEnum.Input;
                case "Option": return Parameter.ParameterTypeEnum.Option;
                case "Both": return Parameter.ParameterTypeEnum.Both;
                default:
                    Debug.WriteLine("Unknown Parameter Type " + str);
                    return Parameter.ParameterTypeEnum.None;
            }
        }
    }
}
