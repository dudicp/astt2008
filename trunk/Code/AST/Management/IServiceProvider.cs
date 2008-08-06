using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace AST.Management
{
    interface IServiceProvider
    {
        String ExecuteCmd(IPAddress ip, String username, String password, String cmd, int timeout, int duration, out int errorCode);
        String ExecuteBatch(IPAddress ip, String username, String password, String filename, String arguments, int timeout, int duration, out int errorCode);
        String ExecuteScript(IPAddress ip, String username, String password, String filename, String arguments, int timeout, int duration, out int errorCode);
        void CopyScript(IPAddress ip, String filename, String username, String password);
        void DeleteScript(IPAddress ip, String filename);
    }
}
