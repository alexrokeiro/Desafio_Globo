using Desafio.Domain.Models;
using System;

namespace Desafio.Domain.Services.Entity
{
    public interface IGravacaoEntityService
    {
        Gravacao Novo(string StartTime, string EndTime, string Title, string Duration, long ReconcileKey);
    }
}
