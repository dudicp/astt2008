using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;

namespace AST.Database{

    interface IResultHandler{

        void Save(Result res, String reportName);

        void ShowReport(String reportName);
    }
}
