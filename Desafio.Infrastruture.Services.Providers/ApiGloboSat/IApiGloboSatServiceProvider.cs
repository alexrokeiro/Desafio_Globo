using Desafio.Infrastruture.Services.Providers.Messages.ApiGloboSat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infrastruture.Services.Providers.ApiGloboSat
{
    public interface IApiGloboSatServiceProvider
    {
        ApiGloboSatMessageResponse EntregarConteudo(ApiGloboSatMessageRequest request);
    }
}
