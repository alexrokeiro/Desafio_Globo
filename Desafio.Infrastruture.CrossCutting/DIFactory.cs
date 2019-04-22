using Desafio.Domain.Services.Entity;
using Desafio.Domain.Services.Imp.Task;
using Desafio.Domain.Services.Task;
using Desafio.Infrastructure.DataAcess;
using Desafio.Infrastructure.DataAcess.MongoDB;
using Desafui.Domain.Services.Imp.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Desafio.Infrastruture.CrossCutting
{

    public class DIFactory
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            ConfigureDomainServices(services);
            ConfigureRepositories(services);
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IGracavaoRepository, GracavaoRepository>();
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<IGravacaoEntityService, GravacaoEntityService>();
            services.AddScoped<IProcessarArquivoTaskService, ProcessarArquivoTaskService>();
        }
    }

}
