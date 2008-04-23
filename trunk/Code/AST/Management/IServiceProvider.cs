using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace AST.Management
{
    interface IServiceProvider
    {
        void ExecuteCmd(IPAddress ip, String username, String password, String cmd);
        void ExecuteScript(IPAddress ip, String username, String password, String filename);
    }
}
