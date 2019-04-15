using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Host.HostedService.Configurations
{
    internal static class AppSettingsOptionsConfigurations
    {
        public static HostBuilderContext ConfigAppSettingsFiles(this HostBuilderContext hostingContext, IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddJsonFile("Settings/appsettings.json", optional: true, reloadOnChange: true);
            
            return hostingContext;
        }
    }
}
