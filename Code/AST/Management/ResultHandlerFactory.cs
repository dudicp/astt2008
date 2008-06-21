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
            return ResultHandler.GetInstance();
        }
    }
}
