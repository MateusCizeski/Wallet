using Domain;
using MongoDB.Driver;

namespace Infra
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Domain.Wallet> Orders => _database.GetCollection<Domain.Wallet>("Wallet");
    }
}
