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

        public WalletTypeClass InsertWalletType(WalletTypeClass wallet)
        {
            _mongoCollection.InsertOne(wallet);
            return wallet;
        }

        public WalletTypeClass EditWalletType(WalletTypeClass wallet)
        {
            _mongoCollection.ReplaceOne(filter: p => p.Id == wallet.Id, replacement: wallet);

            return wallet;
        }

        public WalletTypeClass GetWalletTypeById(int id)
        {
            var wallet = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (wallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            return wallet;
        }

        public List<WalletTypeClass> ListWalletsType()
        {
            var types = _mongoCollection.Find(_ => true).ToList();

            return types;
        }

        public void DeleteWalletType(int id)
        {
            var wallet = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (wallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            _mongoCollection.DeleteOne(p => p.Id == id);
        }
    }
}
