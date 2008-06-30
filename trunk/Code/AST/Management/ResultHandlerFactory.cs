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
                return RHSetIP.GetInstance();
            if (action.Name.Equals("ChangeIPAddress") && (action.CreatorName.Equals("System")))
                return RHChangeIP.GetInstance();
            
            return ResultHandler.GetInstance();
        }
    }
}
