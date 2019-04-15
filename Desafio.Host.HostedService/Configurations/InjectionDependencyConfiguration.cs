using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Host.HostedService.Configurations
{
    internal static class InjectionDependencyConfiguration
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {
            //DIFactory.ConfigureDI(services, configuration);
            return services;
        }
    }
}
