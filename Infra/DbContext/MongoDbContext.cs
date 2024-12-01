using Domain.Wallet;
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

        public IMongoCollection<WalletClass> Orders => _database.GetCollection<WalletClass>("Wallet");
    }
}
