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
        private Hashtable m_endStations;

        public SQLHandler(String connectionString){
            this.m_connectionString = connectionString;
            m_endStations = new Hashtable();
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
        
    #region Load Methods
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

        private Parameter LoadParameter(String actionName, String parameterName) {
            //  1. Load Parameter
            SqlConnection connection;
            SqlDataReader dr = null;
            try {
                connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetParameter", actionName, parameterName);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadParameter:: Loading parameter " + parameterName + " of action: " + actionName + " failed.");
                throw new QueryFailedException("Loading parameter " + parameterName + " of action: " + actionName + " failed.", e);
            }

            if (!dr.Read()) throw new EmptyQueryResultException("Parameter: " + parameterName + " doesn't exist.");

            //Getting the description of the parameter
            String description = (String)dr.GetValue(2);

            Parameter.ParameterTypeEnum type = this.GetParameterType((String)dr.GetValue(3));

            //Getting the default input of the parameter
            String input = (String)dr.GetValue(4);

            //Getting the description of the parameter
            String validityExp = (String)dr.GetValue(5);

            //Getting the bit of isDefault
            bool isDefault = (bool)dr.GetValue(6);

            Parameter p = new Parameter(parameterName, description, type, validityExp, isDefault);
            p.Input = input;

            // 2.Load Parameter Content
            SqlDataReader contentDR = null;
            try {
                connection = this.Connect(); //Creating Connection
                contentDR = SqlHelper.ExecuteReader(connection, "sp_GetParameterContents", actionName, parameterName);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadParameter:: Loading parameter " + parameterName + " of action: " + actionName + " failed.");
                throw new QueryFailedException("Loading parameter " + parameterName + " of action: " + actionName + " failed.", e);
            }

            while (contentDR.Read()) {

                //Getting content OSTYpe
                EndStation.OSTypeEnum OSType = this.GetOSType((String)contentDR.GetValue(2));

                //Getting content value
                String value = (String)contentDR.GetValue(3);

                p.AddValue(OSType, value);
            }
            return p;

        }

        /// <summary>
        /// This method loads TSC from the database, the loading process:
        /// 1. Load TSC information.
        /// 2. For each action in this TSC
        ///     2.1. Load Action
        ///     2.2. Load Paramters of this action in this TSC.
        ///     2.3. Load End-Stations of this action in this TSC.
        /// </summary>
        /// <param name="name">The name of the TSC</param>
        /// <returns>The loaded TSC</returns>
        private TSC LoadTSC(String name) {

            //1. Load TSC Info
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetTSC", name);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadTSC:: Loading TSC: " + name + " failed.");
                throw new QueryFailedException("Loading TSC: " + name + " failed.", e);
            }
            if (!dr.Read()) throw new EmptyQueryResultException("TSC: " + name + " doesn't exist.");

            //Getting the description
            String description = (String)dr.GetValue(1);

            //Getting the creator name
            String creatorName = (String)dr.GetValue(2);

            //Getting the creation time
            DateTime creationTime = (DateTime)dr.GetValue(3);

            TSC tsc = new TSC(name, description, creatorName, creationTime);

            //2. Load Actions
            dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetActionsInTSC", name);
            
                while (dr.Read()) {
                    //2.1 Load Action
                    String actionName = (String)dr.GetValue(1);
                    Action a = this.LoadAction(actionName);

                    int delay = (int)dr.GetValue(3);
                    a.Delay = delay;

                    int executionOrder = (int)dr.GetValue(2);
                    
                    SqlDataReader parameterDR = null;
                    connection = this.Connect();
                    parameterDR = SqlHelper.ExecuteReader(connection, "sp_GetParametersInTSC", name,actionName,executionOrder);

                    //2.2 Load Parameters
                    while (parameterDR.Read()) {
                        String parameterName = (String)parameterDR.GetValue(3);
                        Parameter p = this.LoadParameter(actionName, parameterName);
                        p.Input = (String)parameterDR.GetValue(4);

                        a.AddParameter(p);
                    }


                    SqlDataReader endStationsDR = null;
                    connection = this.Connect();
                    endStationsDR = SqlHelper.ExecuteReader(connection, "sp_GetEndStationsInTSC", name, actionName, executionOrder);

                    //2.3 Load End-Stations
                    while (endStationsDR.Read()) {
                        int esID = (int)endStationsDR.GetValue(0);
                        if (this.m_endStations.Contains(esID)) {
                            EndStationSchedule ess = new EndStationSchedule((EndStation)m_endStations[esID]);
                            a.AddEndStation(ess);
                        }
                        else {
                            Debug.WriteLine("SQLHandler::LoadTSC:: End-Station: " + esID + " not found in the system.");
                        }
                    }
                    tsc.AddAction(a); // Adding the action to the tsc.
                }

                return tsc;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadTSC:: Loading TSC: " + name + " failed.");
                throw new QueryFailedException("Loading TSC: " + name + " failed.", e);
            }
        }

        /// <summary>
        /// This method loads TP from the database, the basic flow is:
        /// 1. Load TP information.
        /// 2. Load each TSC in this TP
        /// </summary>
        /// <param name="name">The name of the TP</param>
        /// <returns>The loaded TP</returns>
        private TP LoadTP(String name) {
            
            //1. Load TP Information
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetTP", name);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadTP:: Loading TP: " + name + " failed.");
                throw new QueryFailedException("Loading TP: " + name + " failed.", e);
            }
            if (!dr.Read()) throw new EmptyQueryResultException("TP: " + name + " doesn't exist.");

            //Getting the description
            String description = (String)dr.GetValue(1);

            //Getting the creator name
            String creatorName = (String)dr.GetValue(2);

            //Getting the creation time
            DateTime creationTime = (DateTime)dr.GetValue(3);

            TP tp = new TP(name, description, creatorName, creationTime);

            //2. Load TSC
            dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetTSCsInTP", name);

                while (dr.Read()) {
                    String tscName = (String)dr.GetValue(1);
                    TSC tsc = this.LoadTSC(tscName);

                    int executionOrder = (int)dr.GetValue(2);

                    tp.AddTSC(tsc); // Adding the TSC to the TP.
                }

                return tp;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadTP:: Loading TP: " + name + " failed.");
                throw new QueryFailedException("Loading TP: " + name + " failed.", e);
            }
        }

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Save Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Save Methods

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
                String storedProcedureName;
                if (this.IsExist(es)) storedProcedureName = "sp_UpdateEndStation";
                else storedProcedureName = "sp_InsertEndStation";
                SqlConnection connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, storedProcedureName, es.ID, es.Name, es.IP.ToString(), es.MAC, es.OSType.ToString(), es.OSVersion.ToString(), es.Username, es.Password, es.IsDefault);
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

        /// <summary>
        /// This method saves a TSC. The basic flow of this method is:
        /// 1. Delete TSC from database (if exists).
        /// 2. Saving the TSC information.
        /// 3. For each action in the TSC:
        ///     3.1. Update the action in TSC table.
        ///     3.2. Update the parameters in TSC table.
        ///     3.3. Update the end-stations in EndStationInTSC table.
        /// </summary>
        /// <param name="tsc">The requested TSC</param>
        private void Save(TSC tsc) {
            
            // 1. Deleting the old TSC if exists.
            try {

                SqlConnection connection;

                String storedProcedureName;
                if (this.IsExist(tsc, AbstractAction.AbstractActionTypeEnum.TSC)) {
                    connection = this.Connect();
                    SqlHelper.ExecuteNonQuery(connection, "sp_DeleteTSCContent", tsc.Name);
                    storedProcedureName = "sp_UpdateTSC";
                }
                else storedProcedureName = "sp_InsertTSC";

                // 2. Saving the TSC information.
                connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, storedProcedureName, tsc.Name, tsc.Description, tsc.CreatorName, tsc.CreationTime);

                // 3. For each action in the TSC
                int executionOrder = 0;
                foreach (Action a in tsc.GetActions()) {

                    //3.1. Update the action in TSC table.
                    connection = this.Connect();
                    SqlHelper.ExecuteNonQuery(connection, "sp_InsertActionToTSC", tsc.Name, a.Name, executionOrder, a.Delay);

                    //3.2. Update the parameters in TSC table.
                    foreach (Parameter p in a.GetParameters()) {
                        connection = this.Connect();
                        SqlHelper.ExecuteNonQuery(connection, "sp_InsertParameterToTSC", tsc.Name, a.Name, executionOrder, p.Name, p.Input);
                    }

                    //3.3. Update the end-stations in EndStationInTSC table.
                    foreach (EndStationSchedule ess in a.GetEndStations()) {
                        connection = this.Connect();
                        SqlHelper.ExecuteNonQuery(connection, "sp_InsertEndStationToTSC", tsc.Name, a.Name, executionOrder, ess.EndStation.ID);
                    }
                    executionOrder++;
                }
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Save(TSC):: Saving tsc: " + tsc.Name + " failed.");
                throw new QueryFailedException("Saving tsc: " + tsc.Name + " failed.", e);
            }
        }

        /// <summary>
        /// This method saves a TP. The basic flow of this method is:
        /// 1. Delete TP from database (if exists).
        /// 2. Saving the TP information.
        /// 3. Saving each TSC in the TP.
        /// </summary>
        /// <param name="tsc">The requested TP</param>
        private void Save(TP tp) {

            // 1. Deleting the old TSC if exists.
            try {
                SqlConnection connection;

                String storedProcedureName;
                if (this.IsExist(tp, AbstractAction.AbstractActionTypeEnum.TP)) {
                    connection = this.Connect();
                    SqlHelper.ExecuteNonQuery(connection, "sp_DeleteTPContent", tp.Name);
                    storedProcedureName = "sp_UpdateTP";
                }
                else storedProcedureName = "sp_InsertTP";

                // 2. Saving the TSC information.
                connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, storedProcedureName, tp.Name, tp.Description, tp.CreatorName, tp.CreationTime);

                // 3. Saving each TSC in the TP.
                int executionOrder = 0;
                foreach (TSC tsc in tp.GetTSCs()) {

                    connection = this.Connect();
                    SqlHelper.ExecuteNonQuery(connection, "sp_InsertTSCToTP", tp.Name, tsc.Name, executionOrder++);
                }
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Save(TP):: Saving TP: " + tp.Name + " failed.");
                throw new QueryFailedException("Saving TP: " + tp.Name + " failed.", e);
            }
        }

        public void Save(Parameter p, String actionName) {
            // 1. Saving Parameter
            SqlConnection connection;
            try {
                String storedProcedureName;
                if (this.IsExist(p, actionName)) storedProcedureName = "sp_UpdateParameter";
                else storedProcedureName = "sp_InsertParameter";

                connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, storedProcedureName, actionName, p.Name, p.Description, p.Type.ToString(), p.Input, p.ValidityExp, p.IsDefault);
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

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Delete Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Delete Methods

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

        private void DeleteTSC(String name) {
            try {
                SqlConnection connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, "sp_DeleteTSC", name);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::DeleteTSC:: Deleting TSC: " + name + " failed.");
                throw new QueryFailedException("Deleting TSC: " + name + " failed.", e);
            }
        }

        private void DeleteTP(String name) {
            try {
                SqlConnection connection = this.Connect();
                SqlHelper.ExecuteNonQuery(connection, "sp_DeleteTP", name);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::DeleteTP:: Deleting TP: " + name + " failed.");
                throw new QueryFailedException("Deleting TP: " + name + " failed.", e);
            }
        }

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

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Get Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Get Methods

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

                //Getting End-Station Default
                bool isDefault = (bool)dr.GetValue(8);

                EndStation es = new EndStation(id, name, ip, osType, username, password,isDefault);

                es.MAC = mac;

                res.Add(es.ID, es);

                Debug.WriteLine(es.ToString());
            }
            this.m_endStations = res;

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
            Hashtable info = new Hashtable();
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetTSCsInfo", null);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetTSCsInfo:: Load information of all tscs failed.");
                throw new QueryFailedException("Load information of all tscs failed.", e);
            }
            while (dr.Read()) {
                String name = (String)dr.GetValue(0);
                String description = (String)dr.GetValue(1);

                info.Add(name, description);
            }
            return info;
        }

        private Hashtable GetTPsInfo() {
            Hashtable info = new Hashtable();
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetTPsInfo", null);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetTPsInfo:: Load information of all TP's failed.");
                throw new QueryFailedException("Load information of all TP's failed.", e);
            }
            while (dr.Read()) {
                String name = (String)dr.GetValue(0);
                String description = (String)dr.GetValue(1);

                info.Add(name, description);
            }
            return info;
        }

        public List<RecentEntry> GetRecent(int recent) {
            List<RecentEntry> recentActions = this.GetRecent(recent, AbstractAction.AbstractActionTypeEnum.ACTION);
            List<RecentEntry> recentTSCs = this.GetRecent(recent, AbstractAction.AbstractActionTypeEnum.TSC);
            List<RecentEntry> recentTPs = this.GetRecent(recent, AbstractAction.AbstractActionTypeEnum.TP);

            List<RecentEntry> allRecents = new List<RecentEntry>();
            allRecents.AddRange(recentActions);
            allRecents.AddRange(recentTSCs);
            allRecents.AddRange(recentTPs);

            allRecents.Sort(RecentEntry.Comparison);

            List<RecentEntry> res = new List<RecentEntry>();
            for (int i = 0; i < recent; i++)
                if(allRecents.Count > i)
                    res.Add(allRecents[i]);

            return res;
        }

        public List<RecentEntry> GetRecent(int recent, AbstractAction.AbstractActionTypeEnum type) {
            String storedProcedureName;
            switch (type) {
                case AbstractAction.AbstractActionTypeEnum.ACTION:
                    storedProcedureName = "sp_GetRecentActions";
                    break;
                case AbstractAction.AbstractActionTypeEnum.TSC:
                    storedProcedureName = "sp_GetRecentTSCs";
                    break;
                default:
                    storedProcedureName = "sp_GetRecentTPs";
                    break;
            }
            List<RecentEntry> info = new List<RecentEntry>();
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, storedProcedureName, null);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetRecent:: Load information of all actions failed.");
                throw new QueryFailedException("Load information of all actions failed.", e);
            }
            while (dr.Read() && recent-- > 0) {
                String name = (String)dr.GetValue(0);
                String description = (String)dr.GetValue(1);
                DateTime creationTime = (DateTime)dr.GetValue(2);
                RecentEntry re = new RecentEntry(name, description, creationTime, type);
                info.Add(re);
            }
            return info;
        }

        public List<Parameter> GetParameters(String actionName) {
            List<Parameter> res = new List<Parameter>();

            //  1. Load Parameters
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
                //Loading each paramter
                Parameter p = this.LoadParameter(actionName, (String)dr.GetValue(1));
                res.Add(p);
            }
            return res;
        }

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      IsExist Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region IsExist Methods

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

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Other Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Other Methods

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

    #endregion
    }
}
