using Desafio.Domain.Models;
using Desafio.Domain.Services.Entity;
using Desafio.Domain.Services.Task;
using Desafio.Infrastruture.Services.Providers.ApiCorte;
using Desafio.Infrastruture.Services.Providers.ApiGloboSat;
using Desafio.Infrastruture.Services.Providers.Messages.ApiCorte;
using Desafio.Infrastruture.Services.Providers.Messages.ApiGloboSat;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Desafio.Domain.Services.Imp.Task
{
    public class ProcessarArquivoTaskService : IProcessarArquivoTaskService
    {
        private IGravacaoEntityService GravacaoEntityService { get; }
        private IApiCorteServiceProvider ApiCorteServiceProvider { get; }
        private IApiGloboSatServiceProvider ApiGloboSatServiceProvider { get; }
        private string Path { get; }

        public ProcessarArquivoTaskService(IGravacaoEntityService gravacaoEntityService)
        {
            GravacaoEntityService = gravacaoEntityService;
            var apiCortesServiceProviderMock = new Mock<IApiCorteServiceProvider>();
            var apiGloboSatServiceProviderMock = new Mock<IApiGloboSatServiceProvider>();

            apiCortesServiceProviderMock.Setup(u => u.Cortar(It.IsAny<ApiCorteMessageRequest>()))
                .Returns(new ApiCorteMessageResponse() { IdJob = 1, Message = "Sucess" });

            apiCortesServiceProviderMock.Setup(u => u.ConsultarCorte(It.IsAny<ApiConsultaCorteMessageRequest>()))
                .Returns(new ApiConsultaCorteMessageResponse() { Message = "Sucess" });

            apiGloboSatServiceProviderMock.Setup(u => u.EntregarConteudo(It.IsAny<ApiGloboSatMessageRequest>()))
                .Returns(new ApiGloboSatMessageResponse() { });

            ApiCorteServiceProvider = apiCortesServiceProviderMock.Object;
            ApiGloboSatServiceProvider = apiGloboSatServiceProviderMock.Object;
            Path = "Caminho";
        }

        public void ProcessarArquivo(string path)
        {
            var gravacoes = new List<Gravacao>();

            string[] lines = File.ReadAllLines(path);
            string startTime;
            string endTime;
            string title;
            string duration;
            string reconcileKey;
            string filename = string.Empty;

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                if (lines[i].Contains("----"))
                    break;

                startTime = lines[i].Substring(6, 22);
                endTime = lines[i].Substring(29, 22);
                title = lines[i].Substring(106, 32);
                duration = lines[i].Substring(184, 11);
                reconcileKey = lines[i].Substring(279, 32);

                var gravacao = GravacaoEntityService.Novo(startTime, endTime, title, duration, long.Parse(reconcileKey));

                gravacoes.Add(gravacao);

            }

            if (lines[1].Contains("Filename"))
            {
                filename = lines[1].Substring(15, 39);
            }

            foreach (var gravacao in gravacoes)
            {
                if (TimeSpan.Parse(gravacao.Duration.Split(';')[0]).TotalSeconds > 30)
                {
                    var requestApiCorte = new ApiCorteMessageRequest() { StartTime = gravacao.StartTime, EndTime = gravacao.EndTime, Name = filename, Path = Path };
                    var responseApiCorte = ApiCorteServiceProvider.Cortar(requestApiCorte);

                    var startTimeSpan = TimeSpan.Zero;
                    var periodTimeSpan = TimeSpan.FromSeconds(15);

                    var timer = new System.Threading.Timer((e) =>
                    {
                        ConsultaCorte(responseApiCorte.IdJob);
                    }, null, startTimeSpan, periodTimeSpan);
                }

                var requestGloboSat = new ApiGloboSatMessageRequest() { Duracao = gravacao.Duration, TituloVideo = gravacao.Title, NomeArquivo = filename };
                var responseGloboSat = ApiGloboSatServiceProvider.EntregarConteudo(requestGloboSat);
            }
        }

        private void ConsultaCorte(long idCorte)
        {
            var requestConsultarCorte = new ApiConsultaCorteMessageRequest() { IdCorte = idCorte };
            var responseConsultaCorte = ApiCorteServiceProvider.ConsultarCorte(requestConsultarCorte);
            
        }
    }
}
