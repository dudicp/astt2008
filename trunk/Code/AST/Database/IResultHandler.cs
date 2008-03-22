using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;

namespace AST.Database{

    interface IResultHandler{

        List<Result> Load(String reportName);

        void Save(Result res, String reportName);

        void Delete(String reportName);

        List<String> GetNames();
    }
}
