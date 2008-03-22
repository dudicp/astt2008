using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AST.Domain;


namespace AST.Database{

    class XMLHandler : IResultHandler{

        public XMLHandler() { }

        public List<Result> Load(String reportName){
            return null;
        }

        public void Save(Result res, String reportName){
            Console.WriteLine(reportName + " Updated.");
        }

        public void Delete(String reportName){
            Console.WriteLine(reportName + " Deleted.");
        }

        public List<String> GetNames(){
            return new List<String>();
        }

    }
}
