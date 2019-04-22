using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infrastruture.Services.Providers.Messages.ApiGloboSat
{
    public class ApiGloboSatMessageRequest
    {
        public string TituloVideo { get; set; }
        public string Duracao { get; set; }
        public string NomeArquivo { get; set; }
    }
}
