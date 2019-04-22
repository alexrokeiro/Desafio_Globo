using Desafio.Infrastruture.Services.Providers.Messages.ApiCorte;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infrastruture.Services.Providers.ApiCorte
{
    public interface IApiCorteServiceProvider
    {
        ApiCorteMessageResponse Cortar(ApiCorteMessageRequest request);
        ApiConsultaCorteMessageResponse ConsultarCorte(ApiConsultaCorteMessageRequest request);
    }
}
