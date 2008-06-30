using System;
using System.Collections.Generic;
using System.Text;
using AST.Domain;
namespace AST.Management
{
    /// <summary>
    /// responsible for returning the instance of the provider compatible with the OS type
    /// </summary>
    class ProviderFactory
    {
        /// <summary>
        /// method for getting an instance of the compatible ServiceProvider
        /// </summary>
        /// <param name="OSType"></param>
        /// <returns></returns>
        public static IServiceProvider GetServiceProvider(EndStation.OSTypeEnum OSType)
        {
            switch (OSType)
            {
                case EndStation.OSTypeEnum.WINDOWS:
                    return WindowsPlatformProvider.GetInstance();
                case EndStation.OSTypeEnum.UNIX:
                    return null;

                default:
                    return WindowsPlatformProvider.GetInstance();

            }
        }
    }
}
