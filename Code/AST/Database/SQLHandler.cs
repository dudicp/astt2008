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
    /// <summary>
    /// this class is responsible for handeling actions on a SQL Server database 
    /// </summary>
    class SQLHandler : IDatabaseHandler{

        private String m_connectionString;
        private Hashtable m_endStations;
        
        /// <summary>
        /// CTor for the SQLHandler
        /// </summary>
        /// <param name="connectionString"></param>
        public SQLHandler(String connectionString){
            this.m_connectionString = connectionString;
            m_endStations = new Hashtable();
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Connection Method
///////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Method for connecting to the SQL Server database
        /// </summary>
        /// <returns>the connection object (SqlConnection) to the database</returns>
        private SqlConnection Connect(){
            try {
                Debug.WriteLine("Connecting to: " + this.m_connectionString);
                SqlConnection res = new SqlConnection(this.m_connectionString);
                //Only to check if the connection establish otherwise we will catch the exception
                res.Open();
                return res;
            }
            catch (Exception e){
                Debug.WriteLine("SQLHandler::Connect::Connecting to: " + this.m_connectionString + " Failed!");
                throw new ConnectionFailedException("Connection to database with the connection string " + this.m_connectionString + " has failed.", e);
            }
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Load Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////
        
    #region Load Methods
       
        /// <summary>
        /// Method for Loading an AbstractAction from the Database
        /// </summary>
        /// <param name="name">Action name</param>
        /// <param name="type">Action Type(Action\TSC\TP)</param>
        /// <returns>AbstractAction object</returns>
        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type) {
            try {
                switch (type) {
                    case AbstractAction.AbstractActionTypeEnum.ACTION: return LoadAction(name);
                    case AbstractAction.AbstractActionTypeEnum.TSC: return LoadTSC(name);
                    default: return LoadTP(name);
                }
            }
            catch (QueryFailedException e) { throw e; }
            catch (EmptyQueryResultException e) { throw e; }
            catch (InvalidTypeException e) { throw e; }
            catch (ConnectionFailedException e) { throw e; }

        }
        /// <summary>
        /// method for loading an action from a SQL database.
        /// </summary>
        /// <param name="name">action name</param>
        /// <returns>Action object that was loaded from the DB</returns>
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
                throw new QueryFailedException("Loading action " + name + " failed.", e);
            }
            if (!dr.Read()) throw new EmptyQueryResultException("Action " + name + " doesn't exist.");

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

            int duration = (int)dr.GetValue(6);

            Action a = new Action(name, description, 0, creatorName, creationTime, timeout, type, duration);

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
                throw new QueryFailedException("Loading action contents of " + name + " failed.", e);
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
        /// <summary>
        /// method for loading a parameter from a SQL database.
        /// </summary>
        /// <param name="actionName">the name of the action containing the parameter</param>
        /// <param name="parameterName">the parameter name</param>
        /// <returns>Parameter object that was loaded from the DB</returns>
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
                throw new QueryFailedException("Loading parameter " + parameterName + " of action " + actionName + " failed.", e);
            }

            if (!dr.Read()) throw new EmptyQueryResultException("Parameter " + parameterName + " doesn't exist.");

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
                Debug.WriteLine("SQLHandler::LoadParameter:: Loading parameter " + parameterName + " of action " + actionName + " failed.");
                throw new QueryFailedException("Loading parameter " + parameterName + " of action " + actionName + " failed.", e);
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
                throw new QueryFailedException("Loading test scenario " + name + " failed.", e);
            }
            if (!dr.Read()) throw new EmptyQueryResultException("Test scenario " + name + " doesn't exist.");

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

                    bool stopIfFails = (bool)dr.GetValue(4);
                    a.StopIfFails = stopIfFails;

                    SqlDataReader parameterDR = null;
                    connection = this.Connect();
                    parameterDR = SqlHelper.ExecuteReader(connection, "sp_GetParametersInTSC", name, actionName, executionOrder);

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
                            Debug.WriteLine("SQLHandler::LoadTSC:: End-Station " + esID + " not found in the system.");
                        }
                    }
                    tsc.AddAction(a); // Adding the action to the tsc.
                }

                //3. Load TSC's end-stations
                SqlDataReader endStationsRootDR = null;
                connection = this.Connect();
                endStationsRootDR = SqlHelper.ExecuteReader(connection, "sp_GetEndStationsInTSCRoot", tsc.Name);

                List<EndStationSchedule> tscEndStations = new List<EndStationSchedule>();

                while (endStationsRootDR.Read()) {
                    int esID = (int)endStationsRootDR.GetValue(0);
                    if (this.m_endStations.Contains(esID)) {
                        EndStationSchedule ess = new EndStationSchedule((EndStation)m_endStations[esID]);
                        tscEndStations.Add(ess);
                    }
                    else {
                        Debug.WriteLine("SQLHandler::LoadTSC:: End-Station " + esID + " not found in the system.");
                    }
                }

                tsc.SetEndStations(tscEndStations);
                return tsc;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (QueryFailedException e) { throw e; }
            catch (EmptyQueryResultException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::LoadTSC:: Loading TSC " + name + " failed.");
                throw new QueryFailedException("Loading test scenario " + name + " failed.", e);
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
                throw new QueryFailedException("Loading test plan " + name + " failed.", e);
            }
            if (!dr.Read()) throw new EmptyQueryResultException("Test plan " + name + " doesn't exist.");

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
                throw new QueryFailedException("Loading test plan " + name + " failed.", e);
            }
        }

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Save Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Save Methods
        /// <summary>
        /// method for Saving AbstractActions (Action\TSC\TP) on the SQL database.
        /// </summary>
        /// <param name="action">the AbstractAction to save on the DB</param>
        /// <param name="type">the action type (Action\TSC\TP)</param>
        public void Save(AbstractAction action, AbstractAction.AbstractActionTypeEnum type) {
            try {
                switch (type) {
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
            catch (DatabaseException e) { throw e; }
        }
        /// <summary>
        /// method for Saving End-stations on the SQL database.
        /// </summary>
        /// <param name="es">the end-station to save on the DB</param>
        public void Save(EndStation es) {
            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();
                try {
                    String storedProcedureName;
                    if (this.IsExist(es)) storedProcedureName = "sp_UpdateEndStation";
                    else storedProcedureName = "sp_InsertEndStation";

                    SqlHelper.ExecuteNonQuery(transaction, storedProcedureName, es.ID, es.Name, es.IP.ToString(), es.MAC, es.OSType.ToString(), es.OSVersion.ToString(), es.Username, es.Password, es.IsDefault);
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e;
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::Save(EndStation):: Saving End-Station " + es.Name + "(" + es.ID + ") failed.");
                    throw new QueryFailedException("Saving End-Station " + es.Name + "(" + es.ID + ") failed.", e);
                }
                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }
        /// <summary>
        /// method for Saving Action on the SQL database.
        /// </summary>
        /// <param name="action">the Action to save on the DB</param>
        private void Save(Action action) {

            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                // 1. Saving Action
                try {
                    String storedProcedureName;
                    if (this.IsExist(action, AbstractAction.AbstractActionTypeEnum.ACTION)) storedProcedureName = "sp_UpdateAction";
                    else storedProcedureName = "sp_InsertAction";

                    SqlHelper.ExecuteNonQuery(transaction, storedProcedureName, action.Name, action.Description, action.ActionType.ToString(), action.Timeout, action.CreatorName, action.CreationTime, action.Duration);
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e; 
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::Save(Action):: Saving action: " + action.Name + " failed.");
                    throw new QueryFailedException("Saving action " + action.Name + " failed.", e);
                }

                // 2. Saving Action Content
                ICollection keys = action.GetAllContents().Keys;
                foreach (EndStation.OSTypeEnum key in keys) {
                    try {
                        String validityString;
                        if (action.GetValidityString(key) != null) validityString = action.GetValidityString(key);
                        else validityString = "";

                        SqlHelper.ExecuteNonQuery(transaction, "sp_InsertActionContent", action.Name, key, action.GetContent(key), validityString);
                    }
                    catch (ConnectionFailedException e) {
                        transaction.Rollback();
                        connection.Close();
                        throw e; 
                    }
                    catch (Exception e) {
                        transaction.Rollback();
                        connection.Close();
                        Debug.WriteLine("SQLHandler::Save(Action):: Saving action content: " + key.ToString() + " failed.");
                        throw new QueryFailedException("Saving action content " + key.ToString() + " failed.", e);
                    }
                }
                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
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
        /// 4. Saving the TSC end-stations
        /// </summary>
        /// <param name="tsc">The requested TSC</param>
        private void Save(TSC tsc) {

            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                // 1. Deleting the old TSC if exists.
                try {
                    String storedProcedureName;
                    if (this.IsExist(tsc, AbstractAction.AbstractActionTypeEnum.TSC)) {
                        SqlHelper.ExecuteNonQuery(transaction, "sp_DeleteTSCContent", tsc.Name);
                        storedProcedureName = "sp_UpdateTSC";
                    }
                    else storedProcedureName = "sp_InsertTSC";

                    // 2. Saving the TSC information.
                    SqlHelper.ExecuteNonQuery(transaction, storedProcedureName, tsc.Name, tsc.Description, tsc.CreatorName, tsc.CreationTime);

                    // 3. For each action in the TSC
                    int executionOrder = 0;
                    foreach (Action a in tsc.GetActions()) {

                        //3.1. Update the action in TSC table.
                        SqlHelper.ExecuteNonQuery(transaction, "sp_InsertActionToTSC", tsc.Name, a.Name, executionOrder, a.Delay, a.StopIfFails);

                        //3.2. Update the parameters in TSC table.
                        foreach (Parameter p in a.GetParameters()) {
                            SqlHelper.ExecuteNonQuery(transaction, "sp_InsertParameterToTSC", tsc.Name, a.Name, executionOrder, p.Name, p.Input);
                        }

                        //3.3. Update the end-stations in EndStationInTSC table.
                        foreach (EndStationSchedule ess in a.GetEndStations()) {
                            SqlHelper.ExecuteNonQuery(transaction, "sp_InsertEndStationToTSC", tsc.Name, a.Name, executionOrder, ess.EndStation.ID);
                        }
                        executionOrder++;
                    }

                    // 4. Saving the TSC end-stations
                    foreach (EndStationSchedule ess in tsc.GetEndStations()) {
                        SqlHelper.ExecuteNonQuery(transaction, "sp_InsertEndStationToTSCRoot", tsc.Name, ess.EndStation.ID);
                    }

                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e; 
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::Save(TSC):: Saving TSC: " + tsc.Name + " failed.");
                    throw new QueryFailedException("Saving test scenario " + tsc.Name + " failed.", e);
                }
                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }

        /// <summary>
        /// This method saves a TP. The basic flow of this method is:
        /// 1. Delete TP from database (if exists).
        /// 2. Saving the TP information.
        /// 3. Saving each TSC in the TP.
        /// </summary>
        /// <param name="tp">The requested TP</param>
        private void Save(TP tp) {
            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                // 1. Deleting the old TSC if exists.
                try {
                    String storedProcedureName;
                    if (this.IsExist(tp, AbstractAction.AbstractActionTypeEnum.TP)) {
                        SqlHelper.ExecuteNonQuery(transaction, "sp_DeleteTPContent", tp.Name);
                        storedProcedureName = "sp_UpdateTP";
                    }
                    else storedProcedureName = "sp_InsertTP";

                    // 2. Saving the TSC information.
                    SqlHelper.ExecuteNonQuery(transaction, storedProcedureName, tp.Name, tp.Description, tp.CreatorName, tp.CreationTime);

                    // 3. Saving each TSC in the TP.
                    int executionOrder = 0;
                    foreach (TSC tsc in tp.GetTSCs()) {

                        SqlHelper.ExecuteNonQuery(transaction, "sp_InsertTSCToTP", tp.Name, tsc.Name, executionOrder++);
                    }
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e; 
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::Save(TP):: Saving TP: " + tp.Name + " failed.");
                    throw new QueryFailedException("Saving test plan " + tp.Name + " failed.", e);
                }
                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }
        /// <summary>
        /// method for saving Parameters on the DB
        /// </summary>
        /// <param name="p">the parameter to save on the DB</param>
        /// <param name="actionName">the name of the action containing the parameter</param>
        public void Save(Parameter p, String actionName) {
            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                // 1. Saving Parameter
                try {
                    String storedProcedureName;
                    if (this.IsExist(p, actionName)) storedProcedureName = "sp_UpdateParameter";
                    else storedProcedureName = "sp_InsertParameter";

                    SqlHelper.ExecuteNonQuery(transaction, storedProcedureName, actionName, p.Name, p.Description, p.Type.ToString(), p.Input, p.ValidityExp, p.IsDefault);
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e; 
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::Save(Parameter):: Saving paramter: " + p.Name + " failed.");
                    throw new QueryFailedException("Saving paramter " + p.Name + " failed.", e);
                }

                // 2. Saving Parameter Value
                ICollection keys = p.GetAllValues().Keys;
                foreach (EndStation.OSTypeEnum key in keys) {
                    try {
                        SqlHelper.ExecuteNonQuery(transaction, "sp_InsertParameterContent", actionName, p.Name, key, p.GetValue(key));
                    }
                    catch (ConnectionFailedException e) {
                        transaction.Rollback();
                        connection.Close();
                        throw e;
                    }
                    catch (Exception e) {
                        transaction.Rollback();
                        connection.Close();
                        Debug.WriteLine("SQLHandler::Save(Parameter):: Saving content: " + key.ToString() + " of paramter: " + p.Name + " failed.");
                        throw new QueryFailedException("Saving content " + key.ToString() + " of paramter " + p.Name + " failed.", e);
                    }
                }

                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Delete Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Delete Methods
        /// <summary>
        /// method for deleting AbstractActions from the DB
        /// </summary>
        /// <param name="name">the AbstractAction to delete from the DB</param>
        /// <param name="type">the action type (Action\TSC\TP)</param>
        public void Delete(String name, AbstractAction.AbstractActionTypeEnum type)
        {
            try {
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
            catch (ConnectionFailedException e) { throw e; }
            catch (QueryFailedException e) { throw e; }

        }
        /// <summary>
        /// method for deleting End-stations on the SQL database.
        /// </summary>
        /// <param name="es">the end-station to delete from the DB</param>
        public void Delete(EndStation es)
        {
            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                try {
                    SqlHelper.ExecuteNonQuery(transaction, "sp_DeleteEndStation", es.ID);
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e;
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::Delete(EndStation):: Deleting End-Station " + es.Name + "(" + es.ID + ") failed.");
                    throw new QueryFailedException("Deleting End-Station " + es.Name + "(" + es.ID + ") failed.", e);
                }
                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }
        /// <summary>
        /// method for deleting Actions from the DB
        /// </summary>
        /// <param name="name">the Action name</param>
        private void DeleteAction(String name) {
            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                try {
                    SqlHelper.ExecuteNonQuery(transaction, "sp_DeleteAction", name);
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e;
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::DeleteAction:: Deleting action " + name + " failed.\nThere exists a test scenario that contains " + name + ".");
                    throw new QueryFailedException("Deleting action " + name + " failed.\nThere exists a test scenario that contains " + name + ".", e);
                }
                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }
        /// <summary>
        /// method for deleting TSC from the DB
        /// </summary>
        /// <param name="name">the TSC name</param>
        private void DeleteTSC(String name)
        {
            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                try {
                    SqlHelper.ExecuteNonQuery(transaction, "sp_DeleteTSC", name);
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e;
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::DeleteTSC:: Deleting TSC: " + name + " failed.");
                    throw new QueryFailedException("Deleting test scenario " + name + " failed.\nThere exists a test plan that contains " + name + ".", e);
                }
                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }
        /// <summary>
        /// method for deleting TP from the DB
        /// </summary>
        /// <param name="name">the TP name</param>
        private void DeleteTP(String name)
        {
            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                try {
                    SqlHelper.ExecuteNonQuery(transaction, "sp_DeleteTP", name);
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e;
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::DeleteTP:: Deleting TP: " + name + " failed.");
                    throw new QueryFailedException("Deleting test plan " + name + " failed.", e);
                }

                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }
        /// <summary>
        /// method for deleting Parameters from the DB
        /// </summary>
        /// <param name="p">the parameter name</param>
        /// <param name="actionName">the name of the action containing the parameter</param>
        public void Delete(Parameter p, String actionName) {
            try {
                SqlConnection connection = this.Connect();
                SqlTransaction transaction = connection.BeginTransaction();

                try {
                    SqlHelper.ExecuteNonQuery(transaction, "sp_DeleteParameter", actionName, p.Name);
                }
                catch (ConnectionFailedException e) {
                    transaction.Rollback();
                    connection.Close();
                    throw e; 
                }
                catch (Exception e) {
                    transaction.Rollback();
                    connection.Close();
                    Debug.WriteLine("SQLHandler::Delete(Parameter):: Deleting parameter: " + p.Name + " failed.");
                    throw new QueryFailedException("Deleting parameter " + p.Name + " failed.", e);
                }

                transaction.Commit();
                connection.Close();
            }
            catch (ConnectionFailedException e) {
                throw e;
            }
        }

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Get Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Get Methods
        /// <summary>
        /// method for getting AbstractActions by type
        /// </summary>
        /// <param name="type">the AbstractAction type (Action\TSC\TP)</param>
        /// <returns>HashTable of all the actions of the requested type</returns>
        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type) {
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION: return GetActionsInfo();
                case AbstractAction.AbstractActionTypeEnum.TSC: return GetTSCsInfo();
                default: return GetTPsInfo();
            }            
        }
        /// <summary>
        /// method for getting all End-stations in the DB
        /// </summary>
        /// <returns>HashTable of all the end-stations in the DB</returns>
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

        public Hashtable GetAdditionalActionsInfo()
        {
            Hashtable info = new Hashtable();
            SqlDataReader dr = null;
            try
            {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetAdditionalActionsInfo", null);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e)
            {
                Debug.WriteLine("SQLHandler::GetActionsInfo:: Load information of all additional actions failed.");
                throw new QueryFailedException("Load information of all additional actions failed.", e);
            }
            while (dr.Read())
            {
                String name = (String)dr.GetValue(0);
                String description = (String)dr.GetValue(1);

                info.Add(name, description);
            }
            return info;
        }

        /// <summary>
        /// method for getting all the Actions in the DB
        /// </summary>
        /// <returns>HashTable of all the actions in the BB</returns>
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
        /// <summary>
        /// method for getting all the TSCs in the DB
        /// </summary>
        /// <returns>HashTable of all the TSCs in the BB</returns>
        private Hashtable GetTSCsInfo()
        {
            Hashtable info = new Hashtable();
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetTSCsInfo", null);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetTSCsInfo:: Load information of all tscs failed.");
                throw new QueryFailedException("Load information of all test scenarios failed.", e);
            }
            while (dr.Read()) {
                String name = (String)dr.GetValue(0);
                String description = (String)dr.GetValue(1);

                info.Add(name, description);
            }
            return info;
        }
        /// <summary>
        /// method for getting all the TPs in the DB
        /// </summary>
        /// <returns>HashTable of all the TPs in the BB</returns>
        private Hashtable GetTPsInfo()
        {
            Hashtable info = new Hashtable();
            SqlDataReader dr = null;
            try {
                SqlConnection connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetTPsInfo", null);
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetTPsInfo:: Load information of all TP's failed.");
                throw new QueryFailedException("Load information of all test plans failed.", e);
            }
            while (dr.Read()) {
                String name = (String)dr.GetValue(0);
                String description = (String)dr.GetValue(1);

                info.Add(name, description);
            }
            return info;
        }
        /// <summary>
        /// method for getting the most recently added Actions in the DB
        /// </summary>
        /// <param name="recent">the number of recent AbstractActions to return</param>
        /// <returns>List of the most recently added Actions</returns>
        public List<RecentEntry> GetRecent(int recent) {
            // retrive all the recent AbstractActions by their type
            List<RecentEntry> recentActions = this.GetRecent(recent, AbstractAction.AbstractActionTypeEnum.ACTION);
            List<RecentEntry> recentTSCs = this.GetRecent(recent, AbstractAction.AbstractActionTypeEnum.TSC);
            List<RecentEntry> recentTPs = this.GetRecent(recent, AbstractAction.AbstractActionTypeEnum.TP);

            // combine all the  lists in to one big list
            List<RecentEntry> allRecents = new List<RecentEntry>();
            allRecents.AddRange(recentActions);
            allRecents.AddRange(recentTSCs);
            allRecents.AddRange(recentTPs);

            // sort the list by order of recently added
            allRecents.Sort(RecentEntry.Comparison);

            List<RecentEntry> res = new List<RecentEntry>();
            for (int i = 0; i < recent; i++)
                if(allRecents.Count > i)
                    res.Add(allRecents[i]);

            return res;
        }
        /// <summary>
        /// method for getting the most recently added Actions in the DB by their type
        /// </summary>
        /// <param name="recent">the number of recent AbstractActions to return</param>
        /// <param name="type"></param>
        /// <returns>List of recently added actions by their type</returns>
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
        /// <summary>
        /// method for getting all the parameters defined in an action
        /// </summary>
        /// <param name="actionName">the name of the action containing the parameters</param>
        /// <returns>List of all the parameters in defined in the action</returns>
        public List<Parameter> GetParameters(String actionName) {
            List<Parameter> res = new List<Parameter>();

            //  1. Load Parameters
            SqlConnection connection;
            SqlDataReader dr = null;
            try {
                connection = this.Connect(); //Creating Connection
                dr = SqlHelper.ExecuteReader(connection, "sp_GetActionParameters", actionName);

                while (dr.Read()) {
                    //Loading each paramter
                    Parameter p = this.LoadParameter(actionName, (String)dr.GetValue(1));
                    res.Add(p);
                }
                return res;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (QueryFailedException e) { throw e; }
            catch (EmptyQueryResultException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetParameters:: Loading parameters of action: " + actionName + " failed.");
                throw new QueryFailedException("Loading parameters of action " + actionName + " failed.", e);
            }
        }

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      IsExist Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region IsExist Methods
        /// <summary>
        /// method for checking if an AbstractAction exists on the DB
        /// </summary>
        /// <param name="action">the action name</param>
        /// <param name="type">the action type (Action\TSC\TP)</param>
        /// <returns>true if the action exists on the DB</returns>
        public bool IsExist(AbstractAction action, AbstractAction.AbstractActionTypeEnum type) {
            String storedProcedureName = "";
            // select the apropriate store procedure to call
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
                // connect to the DB
                SqlConnection connection = this.Connect();
                SqlDataReader dr = null;
                // read data from DB
                dr = SqlHelper.ExecuteReader(connection, storedProcedureName, action.Name);
                return dr.HasRows;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::IsExist(AbstractAction):: Loading information of: " + action.Name + " failed.");
                throw new QueryFailedException("Loading information of " + action.Name + " failed.", e);
            }

        }
        /// <summary>
        /// method for checking if an End-station exists on the DB
        /// </summary>
        /// <param name="es">the End-station</param>
        /// <returns>true if the End-station exists on the DB</returns>
        public bool IsExist(EndStation es)
        {
            try {
                // connect to the DB
                SqlConnection connection = this.Connect();
                SqlDataReader dr = null;
                // Read Data from the DB 
                dr = SqlHelper.ExecuteReader(connection, "sp_GetEndStation", es.ID);
                return dr.HasRows;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::IsExist(EndStation):: Loading information of end-station: " + es.Name + " failed.");
                throw new QueryFailedException("Loading information of end-station " + es.Name + " failed.", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">the parameter</param>
        /// <param name="actionName">the name of the action containing the parameter</param>
        /// <returns>true if the parameter exists on the DB</returns>
        public bool IsExist(Parameter p, String actionName)
        {
            try {
                SqlConnection connection = this.Connect();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(connection, "sp_GetParameter", actionName, p.Name);
                return dr.HasRows;
            }
            catch (ConnectionFailedException e) { throw e; }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::IsExist(Parameter):: Loading information of parameter: " + p.Name + " failed.");
                throw new QueryFailedException("Loading information of parameter " + p.Name + " failed.", e);
            }
        }

    #endregion

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Other Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

    #region Other Methods
        /// <summary>
        /// method for getting the OS type 
        /// </summary>
        /// <param name="str">the string describing the OS Type</param>
        /// <returns>OSTypeEnum compatible with the str param</returns>
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
        /// <summary>
        /// method for getting the AbstractAction type 
        /// </summary>
        /// <param name="str">the string describing the AbstractAction Type</param>
        /// <returns>ActionTypeEnum compatible with the str param</returns>
        private Action.ActionTypeEnum GetActionType(String str){
            switch (str){
                case "COMMAND_LINE": return Action.ActionTypeEnum.COMMAND_LINE;
                case "BATCH_FILE": return Action.ActionTypeEnum.BATCH_FILE;
                case "SCRIPT": return Action.ActionTypeEnum.SCRIPT;
                case "TEST_SCRIPT": return Action.ActionTypeEnum.TEST_SCRIPT;
                default:
                    Debug.WriteLine("Unknown Action Type " + str);
                    throw new InvalidTypeException("Unknown action type " + str);
            }
        }
        /// <summary>
        /// method for getting the Parameter type 
        /// </summary>
        /// <param name="str">the string describing the Parameter Type</param>
        /// <returns>ParameterTypeEnum compatible with the str param</returns>
        private Parameter.ParameterTypeEnum GetParameterType(String str)
        {
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
