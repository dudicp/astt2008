using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace AST.Management
{
    interface IServiceProvider
    {
        String ExecuteCmd(IPAddress ip, String username, String password, String cmd, int timeout, int duration);
        String ExecuteScript(IPAddress ip, String username, String password, String filename, int timeout, int duration);
    }
}
