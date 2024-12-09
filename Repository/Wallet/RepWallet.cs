using Domain.Wallet;
using MongoDB.Driver;

namespace Repository.Wallet
{
    #region DTO's
    public class WalletDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public EnumWalletType Type { get; set; }
    }
    #endregion

    public class RepWallet : IRepWallet
    {
        private readonly IMongoCollection<WalletClass> _mongoCollection;

        public RepWallet(IMongoCollection<WalletClass> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        #region InsertWallet
        public WalletDTO InsertWallet(WalletClass wallet)
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

            // Criptografa a senha antes de salvar
            wallet.Password = BCrypt.Net.BCrypt.HashPassword(wallet.Password);

            _mongoCollection.InsertOne(wallet);

            return MapToDTO(wallet);
        }
        #endregion

        #region EditWallet
        public WalletDTO EditWallet(WalletClass wallet)
        {
            var existingWallet = _mongoCollection.Find(w => w.Id == wallet.Id).FirstOrDefault();
            if (existingWallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            // Mantém a senha existente se nenhuma nova senha for enviada
            if (string.IsNullOrWhiteSpace(wallet.Password))
            {
                wallet.Password = existingWallet.Password;
            }
            else
            {
                wallet.Password = BCrypt.Net.BCrypt.HashPassword(wallet.Password);
            }

            _mongoCollection.ReplaceOne(filter: p => p.Id == wallet.Id, replacement: wallet);

            return MapToDTO(wallet);
        }
        #endregion

        #region GetWalletById
        public WalletDTO GetWalletById(int id)
        {
            var wallet = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (wallet == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            return MapToDTO(wallet);
        }
        #endregion

        #region ListWallets
        public List<WalletDTO> ListWallets()
        {
            var wallets = _mongoCollection.Find(_ => true).ToList();

            return wallets.Select(MapToDTO).ToList();
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

        #region Helpers
        private WalletDTO MapToDTO(WalletClass wallet)
        {
            return new WalletDTO
            {
                Id = wallet.Id,
                Name = wallet.Name,
                Email = wallet.Email,
                Balance = wallet.Balance,
                Type = wallet.Type
            };
        }
        #endregion
    }
}
