using Desafio.Domain.Models;
using Desafio.Domain.Services.Entity;
using Desafio.Infrastructure.DataAcess;
using System;

namespace Desafui.Domain.Services.Imp.Entity
{
    public class GravacaoEntityService : IGravacaoEntityService
    {

        private IGracavaoRepository GravacaoRepository { get; }

        public GravacaoEntityService(IGracavaoRepository gracavaoRepository)
        {
            GravacaoRepository = gracavaoRepository;
        }
        public Gravacao Novo(string startTime, string endTime, string title, string duration, long reconcileKey)
        {
            var gravacao = Gravacao.Criar(startTime, endTime, title, duration, reconcileKey);

            GravacaoRepository.CriarGravacao(gravacao);

            return gravacao;
        }
    }
}
