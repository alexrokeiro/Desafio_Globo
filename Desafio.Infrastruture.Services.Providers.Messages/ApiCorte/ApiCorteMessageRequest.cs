using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infrastruture.Services.Providers.Messages.ApiCorte
{
    public class ApiCorteMessageRequest
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}
