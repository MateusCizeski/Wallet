using Domain.Transaction;
using Domain.Wallet;
using Domain.WalletType;
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

        public IMongoDatabase Database => _database;
        public IMongoCollection<WalletClass> Wallets => _database.GetCollection<WalletClass>("Wallet");
        public IMongoCollection<WalletTypeClass> WalletTypes => _database.GetCollection<WalletTypeClass>("WalletType");
        public IMongoCollection<TransactionClass> Transactions => _database.GetCollection<TransactionClass>("Transaction");
    }
}
