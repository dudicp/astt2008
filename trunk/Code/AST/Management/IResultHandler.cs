using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;

namespace AST.Management
{
    interface IResultHandler
    {
         Result CheckResult(Action action, EndStation endStation,DateTime startTime, DateTime endTime, String message);
    }
}
