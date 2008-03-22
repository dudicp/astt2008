using System;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.Text;
using AST.Domain;

namespace AST.Database{
    
    class SQLHandler : IDatabaseHandler{

        public SQLHandler() { }

        public void Connect(IPAddress ip, int port) {
            Console.WriteLine("Connecting to: "+ip+", "+port);
        }

        public void Disconnect() {
            Console.WriteLine("Disconnecting from Database.");
        }

        public AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type) {
            return Builder.GetInstance().GetAction(name, type);
        }

        public void Save(AbstractAction action, AbstractAction.AbstractActionTypeEnum type) {
            Console.WriteLine(action.Name+" Saved.");
            Builder.GetInstance().Save(action, type);
        }

        public void Delete(String name, AbstractAction.AbstractActionTypeEnum type) {
            Console.WriteLine(name + " Deleted.");
        }

        public Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type) {
            return Builder.GetInstance().GetInfo(type);
        }
    }
}
