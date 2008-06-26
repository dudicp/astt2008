using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;

namespace AST.Management
{
    class ResultHandlerFactory
    {
        public static IResultHandler GetResultHandler(Action action)
        {
            if (action.Name.Equals("SetIP") && (action.CreatorName.Equals("System")))
                return SetIPRH.GetInstance();
            else
                return ResultHandler.GetInstance();
        }
    }
}
