using System;
using Desafio.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Desafio.Infrastructure.DataAcess.MongoDB
{
    public class GracavaoRepository : IGracavaoRepository
    {
        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;

        public GracavaoRepository(IConfiguration configuration)
        {
            mongoClient = new MongoClient("mongodb+srv://desafio:desafio@desafio-t15xk.mongodb.net/test?retryWrites=true");

            var databaseName = MongoUrl.Create("mongodb+srv://desafio:desafio@desafio-t15xk.mongodb.net/test?retryWrites=true").DatabaseName;
            mongoDatabase = mongoClient.GetDatabase(databaseName);
        }

        public void CriarGravacao(Gravacao model)
        {
            mongoDatabase.GetCollection<Gravacao>("Gravacoes").InsertOne(model);
        }
    }
}
