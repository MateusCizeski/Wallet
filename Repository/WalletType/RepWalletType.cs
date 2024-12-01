using Domain.WalletType;
using MongoDB.Driver;

namespace Repository.WalletType
{
    public class RepWalletType : IRepWalletType
    {
        private readonly IMongoCollection<WalletTypeClass> _mongoCollection;

        public RepWalletType(IMongoCollection<WalletTypeClass> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }
    }
}
