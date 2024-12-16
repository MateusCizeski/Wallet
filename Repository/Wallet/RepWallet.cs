using Domain.Wallet;
using MongoDB.Driver;

namespace Repository.Wallet
{ 
    public class RepWallet : IRepWallet
    {
        #region Ctor
        private readonly IMongoCollection<WalletClass> _mongoCollection;

        public RepWallet(IMongoCollection<WalletClass> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }
        #endregion

        #region InsertWallet
        public WalletClass InsertWallet(WalletClass wallet)
        {
            if (string.IsNullOrWhiteSpace(wallet.Email) || string.IsNullOrWhiteSpace(wallet.Password))
            {
                throw new Exception("E-mail e senha são obrigatórios.");
            }

            var existingWallet = _mongoCollection.Find(w => w.Email == wallet.Email).FirstOrDefault();

            if (existingWallet != null)
            {
                throw new Exception("Já existe uma carteira cadastrada com este e-mail.");
            }

            wallet.Password = BCrypt.Net.BCrypt.HashPassword(wallet.Password);

            _mongoCollection.InsertOne(wallet);

            return WalletEnxuta(wallet);
        }
        #endregion

        #region EditWallet
        public WalletClass EditWallet(WalletClass wallet)
        {
            var existingWallet = _mongoCollection.Find(w => w.Id == wallet.Id).FirstOrDefault();
            if (existingWallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            if (string.IsNullOrWhiteSpace(wallet.Password))
            {
                wallet.Password = existingWallet.Password;
            }
            else
            {
                wallet.Password = BCrypt.Net.BCrypt.HashPassword(wallet.Password);
            }

            _mongoCollection.ReplaceOne(filter: p => p.Id == wallet.Id, replacement: wallet);

            return WalletEnxuta(wallet);
        }
        #endregion

        #region GetWalletById
        public WalletClass GetWalletById(int id)
        {
            var wallet = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (wallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            return WalletEnxuta(wallet);
        }
        #endregion

        #region ListWallets
        public List<WalletClass> ListWallets()
        {
            var wallets = _mongoCollection.Find(_ => true).ToList();
            List<WalletClass> walletsEnxuta = new List<WalletClass>();

            foreach(var wallet in wallets)
            {
                walletsEnxuta.Add(WalletEnxuta(wallet));
            }

            return walletsEnxuta;
        }
        #endregion

        #region DeleteWallet
        public void DeleteWallet(int id)
        {
            var wallet = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (wallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            _mongoCollection.DeleteOne(p => p.Id == id);
        }
        #endregion

        #region MontaWalletEnxuta
        public WalletClass WalletEnxuta(WalletClass wallet)
        {
            var sanitizedWallet = new WalletClass
            {
                Id = wallet.Id,
                Name = wallet.Name,
                CpfCnpj = wallet.CpfCnpj,
                Email = wallet.Email,
                Balance = wallet.Balance,
                Type = wallet.Type,
                WalletType = wallet.WalletType
            };

            return sanitizedWallet;
        }
        #endregion
    }
}
