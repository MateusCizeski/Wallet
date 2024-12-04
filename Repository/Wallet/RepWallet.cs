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

        #region InsertWallet
        public WalletClass InsertWallet(WalletClass wallet)
        {
            _mongoCollection.InsertOne(wallet);   
            return wallet;
        }
        #endregion

        #region EditWallet
        public WalletClass EditWallet(WalletClass wallet)
        {
            _mongoCollection.ReplaceOne(filter: p => p.Id == wallet.Id, replacement: wallet);

            return wallet;
        }
        #endregion

        #region GetWalletById
        public WalletClass GetWalletById(int id)
        {
            var wallet = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if(wallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            return wallet;
        }
        #endregion

        #region ListWallets
        public List<WalletClass> ListWallets()
        {
            var wallets = _mongoCollection.Find(_ => true).ToList();

            return wallets;
        }
        #endregion

        #region DeleteWallet
        public void DeleteWallet(int id)
        {
            var wallet = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if(wallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            _mongoCollection.DeleteOne(p => p.Id == id);
        }
        #endregion
    }
}
