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
            if (action.Name.Equals("ChangeIP") && (action.CreatorName.Equals("System")))
                return RHChangeIP.GetInstance();
            if (action.Name.Equals("DynamicChangeIP") && (action.CreatorName.Equals("System")))
                return RHDynamicChangeIP.GetInstance();
            
            return ResultHandler.GetInstance();
        }
    }
}
