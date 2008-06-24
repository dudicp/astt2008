using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AST.Domain;
using System.IO;


namespace AST.Database{

    class TXTHandler : IResultHandler{

        public TXTHandler() { }

        public void Save(Result res, String reportName){
            TextWriter tw = new StreamWriter(reportName+".txt",true);

            tw.WriteLine("-------------------------------------------------");
            tw.WriteLine("Action: "+res.GetAction().Name);
            tw.WriteLine("End-Station: " + res.GetEndStation().Name + "(" + res.GetEndStation().IP.ToString() +")");
            tw.WriteLine("Start Time: " + res.StartTime.ToString());
            tw.WriteLine("End Time: " + res.EndTime.ToString());
            if(res.Status)
                tw.WriteLine("Status: Success");
            else
                tw.WriteLine("Status: Failed");
            tw.WriteLine("Message: \n" + res.Message);
            tw.WriteLine("-------------------------------------------------");
            tw.Close();
        }
    }
}
