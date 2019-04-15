using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.Host.HostedService.HostedServices
{
    public class DesafioHostedService : IHostedService, IDisposable
    {
        public string PastaOrigem { get; }
        public string PastaDestino { get; }

        public DesafioHostedService(IConfiguration config)
        {
            PastaDestino = config.GetSection("PastaDestino").Value;
            PastaOrigem = config.GetSection("PastaOrigem").Value;
        }

        public void Dispose()
        {
            Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = @"D:\testes\temp";
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.EnableRaisingEvents = true;

            return Task.CompletedTask;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            
            string x = "criado";
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
