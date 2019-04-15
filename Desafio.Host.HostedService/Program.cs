using Microsoft.Extensions.Hosting;
using System.IO;
using Desafio.Host.HostedService.Configurations;

namespace Desafio.Host.HostedService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostBuilder host = new HostBuilder();

            host.UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices((hostContext, services) => hostContext.ConfigureServices(services))
                .ConfigureAppConfiguration((hostContext, config) => hostContext.ConfigAppSettingsFiles(config));

            host.Build().Run();
        }
    }
}
