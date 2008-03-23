using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using AST.Domain;

namespace AST.Database{

    interface IDatabaseHandler{

        AbstractAction Load(String name, AbstractAction.AbstractActionTypeEnum type);

        void Save(AbstractAction action, AbstractAction.AbstractActionTypeEnum type);

        void Delete(String name, AbstractAction.AbstractActionTypeEnum type);

        Hashtable GetInfo(AbstractAction.AbstractActionTypeEnum type);

        List<Parameter> GetParameters(String actionName);
    }
}
