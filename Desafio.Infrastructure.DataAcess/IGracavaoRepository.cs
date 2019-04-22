using Desafio.Domain.Models;
using System;

namespace Desafio.Infrastructure.DataAcess
{
    public interface IGracavaoRepository
    {
        void CriarGravacao(Gravacao model);
    }
}
