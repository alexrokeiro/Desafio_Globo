using Desafio.Host.HostedService.HostedServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Host.HostedService.Configurations
{
    public static class HostServiceConfiguration
    {
        public static void ConfigureServices(this HostBuilderContext hostingContext, IServiceCollection services)
        {
            services.ConfigureDI(hostingContext.Configuration);
            services.AddHostedService<DesafioHostedService>();

        }
    }
}
