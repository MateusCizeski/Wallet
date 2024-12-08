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

        public IMongoCollection<WalletClass> wallet => _database.GetCollection<WalletClass>("wallet");
        public IMongoCollection<WalletTypeClass> walletType => _database.GetCollection<WalletTypeClass>("walletType");
        public IMongoCollection<TransactionClass> wransaction => _database.GetCollection<TransactionClass>("transaction");
    }
}
