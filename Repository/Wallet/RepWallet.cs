using Domain.Wallet;
using MongoDB.Driver;

namespace Repository.Wallet
{
    public class RepWallet : IRepWallet
    {
        private readonly IMongoCollection<WalletClass> _mongoCollection;

        public RepWallet(IMongoCollection<WalletClass> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }
    }
}
