using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
namespace AST.Management
{
    class ProviderFactory
    {
        public static IServiceProvider GetServiceProvider(EndStation.OSTypeEnum OSType)
        {
            switch (OSType)
            {
                case EndStation.OSTypeEnum.UNIX:
                    return null;

                default:
                    return WindowsPlatformProvider.GetInstance();

            }
        }
    }
}
