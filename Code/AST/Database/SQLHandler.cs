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

        private SqlConnection Connect(){
            try {
                Debug.WriteLine("Connecting to: " + this.m_connectionString);
                return new SqlConnection(this.m_connectionString);
            }
            catch (Exception e){
                Debug.WriteLine("SQLHandler::Connect::Connecting to: " + this.m_connectionString + " Failed!");
                //Throw ConnectionException
                return null;
            }
        }

        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type) {
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION: return LoadAction(name);
                case AbstractAction.AbstractActionTypeEnum.TSC: return LoadTSC(name);
                case AbstractAction.AbstractActionTypeEnum.TP: return LoadTP(name);
                default:{
                    Debug.WriteLine("SQLHandler::Load::Invalid AbstractAction Type: " + type.ToString());
                    return null;
                    //throw
                    }
            }
        }

        public void Save(AbstractAction action, AbstractAction.AbstractActionTypeEnum type) {
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION:{
                        this.Save((Action)action);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TSC:{
                        this.Save((TSC)action);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TP:{
                        this.Save((TP)action);
                        break;
                    }
                default:{
                    Debug.WriteLine("SQLHandler::Load::Invalid AbstractAction Type: " + type.ToString());
                    //throw
                    break;
                    }
            }
        }

        public void Delete(String name, AbstractAction.AbstractActionTypeEnum type) {
            switch (type) {
                case AbstractAction.AbstractActionTypeEnum.ACTION: {
                        DeleteAction(name);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TSC: {
                        DeleteTSC(name);
                        break;
                    }
                case AbstractAction.AbstractActionTypeEnum.TP: {
                        DeleteTP(name);
                        break;
                    }
                default: {
                        Debug.WriteLine("SQLHandler::Delete::Invalid AbstractAction Type: " + type.ToString());
                        break;
                        //throw
                    }
            }
        }

        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type) {
            switch (type){
                case AbstractAction.AbstractActionTypeEnum.ACTION:{
                        return GetActionsInfo();
                    }
                case AbstractAction.AbstractActionTypeEnum.TSC:{
                        return GetTSCsInfo();
                    }
                case AbstractAction.AbstractActionTypeEnum.TP:{
                        return GetTPsInfo();
                    }
                default:{
                    Debug.WriteLine("Invalid AbstractAction Type: " + type.ToString());
                    return null;
                    //throw
                    }
            }
            
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      End-Stations Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Save(EndStation es) {
            SqlConnection connection = this.Connect();
            try {
                SqlHelper.ExecuteNonQuery(connection, "sp_insertEndStation", es.ID, es.Name, es.IP.ToString(), es.MAC.ToString(), es.OSType.ToString(), es.OSVersion.ToString(), es.Username, es.Password);
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Save(EndStation):: Query Failed!");
                //Throw ConnectionException
            }
        }

        public void Delete(EndStation es){
        }

        public Hashtable GetAllEndStations(){

            Debug.WriteLine("Loading End-Stations:");

            SqlConnection connection = this.Connect();

            Hashtable res = new Hashtable();

            SqlDataReader dr = null;
            try{
                dr = SqlHelper.ExecuteReader(connection, "sp_GetAllEndStations", null);
            }
            catch (Exception e){
                Debug.WriteLine("GetAllEndStations Failed!");
                //Throw ConnectionException
            }

            while (dr.Read()){

                //Getting End-Station ID
                int id = (int)dr.GetValue(0);

                //Getting End-Station Name
                String name = (String)dr.GetValue(1);

                //Getting End-Station IP Address
                IPAddress parsed;
                if (!IPAddress.TryParse((String)dr.GetValue(2), out parsed)){
                    Debug.WriteLine("Invalid IP Address for EndStation " + id);
                    //throw
                }
                IPAddress ip = IPAddress.Parse((String)dr.GetValue(2));

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

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Get Information Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        private Hashtable GetActionsInfo(){

            SqlConnection connection = this.Connect(); //Creating Connection

            Hashtable info = new Hashtable();

            SqlDataReader dr = null;
            try{
                dr = SqlHelper.ExecuteReader(connection, "sp_GetActionsInfo", null);
            }
            catch (Exception e){
                Debug.WriteLine("SQLHandler::GetActionsInfo:: Query Failed!");
                //Throw ConnectionException
            }

            while (dr.Read()){
                String name = (String)dr.GetValue(0);
                String description = (String)dr.GetValue(1);

                info.Add(name, description);
            }

            return info;
        }

        private Hashtable GetTSCsInfo(){
            return new Hashtable();
        }

        private Hashtable GetTPsInfo(){
            return new Hashtable();
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Load Abstract Actions
///////////////////////////////////////////////////////////////////////////////////////////////////////

        private Action LoadAction(String name){
            //return (Action)Builder.GetInstance().GetAction(name, AbstractAction.AbstractActionTypeEnum.ACTION);
            
            ///////////////////
            //1. Load Action //
            ///////////////////
            SqlConnection connection = this.Connect(); //Creating Connection

            SqlDataReader dr = null;
            try{
                dr = SqlHelper.ExecuteReader(connection, "sp_GetAction", name);
            }
            catch (Exception e){
                Debug.WriteLine("SQLHandler::LoadAction:: Query Failed!");
                //Throw ConnectionException
            }

            if(!dr.Read()); //throw no result for query

            //Getting the description
            String description = (String)dr.GetValue(1);

            //Getting the action type
            Action.ActionTypeEnum type = this.GetActionType((String)dr.GetValue(2));

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
            connection = this.Connect(); //Creating Connection

            dr = null;
            try{
                dr = SqlHelper.ExecuteReader(connection, "sp_GetActionContents", name);
            }
            catch (Exception e){
                Debug.WriteLine("SQLHandler::LoadAction:: Query Failed!");
                //Throw ConnectionException
            }

            while (dr.Read()){

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

        private TSC LoadTSC(String name){
            return null;
        }

        private TP LoadTP(String name){
            return null;
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Save Abstract Actions
///////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Save(Action action){

            // 1. Saving Action
            SqlConnection connection = this.Connect();
            try {
                SqlHelper.ExecuteNonQuery(connection, "sp_InsertAction", action.Name, action.Description, action.ActionType.ToString(), action.Timeout, action.CreatorName, action.CreationTime);
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Save(Action):: Query Failed!");
                //Throw ConnectionException
            }

            // 2. Saving Action Content
            ICollection keys = action.GetAllContents().Keys;
            foreach (EndStation.OSTypeEnum key in keys) {
                connection = this.Connect();
                try {
                    String validityString;
                    if (action.GetValidityString(key) != null) validityString = action.GetValidityString(key);
                    else validityString = "";

                    SqlHelper.ExecuteNonQuery(connection, "sp_InsertActionContent", action.Name, key, action.GetContent(key), validityString);
                }
                catch (Exception e) {
                    Debug.WriteLine("SQLHandler::Save(Action):: Query Failed!");
                    //Throw ConnectionException
                }
            }
        }

        private void Save(TSC tsc) { }

        private void Save(TP tp) { }

        private void DeleteAction(String name) {
            SqlConnection connection = this.Connect();
            try {
                SqlHelper.ExecuteNonQuery(connection, "sp_DeleteAction", name);
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::DeleteAction:: Query Failed!");
                //Throw ConnectionException
            }
        }

        private void DeleteTSC(String name) { }

        private void DeleteTP(String name) { }

///////////////////////////////////////////////////////////////////////////////////////////////////////
//      Parameters Methods
///////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Parameter> GetParameters(String actionName) {
            List<Parameter> res = new List<Parameter>();

            //////////////////////
            //  Load Parameter  //
            //////////////////////
            SqlConnection connection = this.Connect(); //Creating Connection

            SqlDataReader dr = null;
            try {
                dr = SqlHelper.ExecuteReader(connection, "sp_GetActionParameters", actionName);
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::GetParameters:: Query Failed!");
                //Throw ConnectionException
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

                ///////////////////////////
                //Load Parameter Content //
                ///////////////////////////
                connection = this.Connect(); //Creating Connection

                SqlDataReader contentDR = null;
                try {
                    contentDR = SqlHelper.ExecuteReader(connection, "sp_GetParameterContents", actionName, parameterName);
                }
                catch (Exception e) {
                    Debug.WriteLine("SQLHandler::GetParameters:: Query Failed!");
                    //Throw ConnectionException
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

        public void Save(Parameter p, String actionName) {
            // 1. Saving Parameter
            SqlConnection connection = this.Connect();
            try {
                SqlHelper.ExecuteNonQuery(connection, "sp_InsertParameter", actionName, p.Name, p.Description, p.Type.ToString(), p.Input, p.ValidityExp);
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Save(Parameter):: Query Failed!");
                //Throw ConnectionException
            }

            // 2. Saving Parameter Value
            ICollection keys = p.GetAllValues().Keys;
            foreach (EndStation.OSTypeEnum key in keys) {
                connection = this.Connect();
                try {
                    SqlHelper.ExecuteNonQuery(connection, "sp_InsertParameterContent", actionName, p.Name, key, p.GetValue(key));
                }
                catch (Exception e) {
                    Debug.WriteLine("SQLHandler::Save(Action):: Query Failed!");
                    //Throw ConnectionException
                }
            }
        }

        public void Delete(Parameter p, String actionName) {
            SqlConnection connection = this.Connect();
            try {
                SqlHelper.ExecuteNonQuery(connection, "sp_DeleteParameter", actionName, p.Name);
            }
            catch (Exception e) {
                Debug.WriteLine("SQLHandler::Delete(Parameter):: Query Failed!");
                //Throw ConnectionException
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
                default:{
                    Debug.WriteLine("Unknown OSType " + str);
                    //throw
                    return EndStation.OSTypeEnum.UNKNOWN;
                    }
            }
        }

        private Action.ActionTypeEnum GetActionType(String str){
            switch (str){
                case "COMMAND_LINE": return Action.ActionTypeEnum.COMMAND_LINE;
                case "SCRIPT": return Action.ActionTypeEnum.SCRIPT;
                case "TEST_SCRIPT": return Action.ActionTypeEnum.TEST_SCRIPT;
                default:{
                        Debug.WriteLine("Unknown Action Type " + str);
                        //throw
                        return Action.ActionTypeEnum.COMMAND_LINE;
                    }
            }
        }

        private Parameter.ParameterTypeEnum GetParameterType(String str){
            switch (str){
                case "Input": return Parameter.ParameterTypeEnum.Input;
                case "Option": return Parameter.ParameterTypeEnum.Option;
                case "Both": return Parameter.ParameterTypeEnum.Both;
                default:{
                    Debug.WriteLine("Unknown Parameter Type " + str);
                    //throw
                    return Parameter.ParameterTypeEnum.None;
                    }
            }
        }
    }
}
