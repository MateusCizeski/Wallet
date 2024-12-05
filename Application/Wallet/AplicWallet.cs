using Application.Wallet.Mapper;
using Domain.Wallet;
using MongoDB.Driver;
using Services.Counter;
using Services.Wallet;

namespace Application.Wallet
{
    public class AplicWallet : IAplicWallet
    {
        private readonly IServWallet _servWallet;
        private readonly IMapperWallet _mapperWallet;
        private readonly CounterService _counterService;

        public AplicWallet(IServWallet servWallet, IMapperWallet mapperWallet, IMongoDatabase database)
        {
            _servWallet = servWallet;
            _mapperWallet = mapperWallet;
            _counterService = new CounterService(database);
        }

        public WalletClass InsertWallet(InsertEditWalletDTO dto)
        {
           var wallet = _mapperWallet.MapperInsertWallet(dto);
            wallet.Id = _counterService.GetNextSequenceValue("wallet");
           var result = _servWallet.InsertWallet(wallet);

           return result;
        }

        public WalletClass EditWallet(int id, InsertEditWalletDTO dto)
        {
            var wallet = _servWallet.GetWalletById(id);
            _mapperWallet.MapperEditWallet(wallet, dto);
            var result = _servWallet.EditWallet(wallet);

            return result;
        }

        public WalletClass GetWalletById(int id)
        {
            var wallet = _servWallet.GetWalletById(id);

            return wallet;
        }

        public List<WalletClass> ListWallets()
        {
            var wallets = _servWallet.ListWallets();

            return wallets;
        }

        public void DeleteWallet(int id)
        {
           _servWallet.DeleteWallet(id);
        }
    }
}
