using Application.Wallet.Mapper;
using Domain.Wallet;
using MongoDB.Driver;
using Repository.Wallet;
using Services.Counter;
using Services.Wallet;

namespace Application.Wallet
{
    public class AplicWallet : IAplicWallet
    {
        #region Ctor
        private readonly IServWallet _servWallet;
        private readonly IMapperWallet _mapperWallet;
        private readonly CounterService _counterService;

        public AplicWallet(IServWallet servWallet, IMapperWallet mapperWallet, CounterService counterService)
        {
            _servWallet = servWallet;
            _mapperWallet = mapperWallet;
            _counterService = counterService;
        }
        #endregion

        #region InsertWallet
        public WalletClass InsertWallet(InsertEditWalletDTO dto)
        {
           var wallet = _mapperWallet.MapperInsertWallet(dto);
           wallet.Id = _counterService.GetNextSequenceValue("wallet");
           var result = _servWallet.InsertWallet(wallet);

           return result;
        }
        #endregion

        #region EditWallet
        public WalletClass EditWallet(int id, InsertEditWalletDTO dto)
        {
            var walletDto = _servWallet.GetWalletById(id);
            _mapperWallet.MapperEditWallet(walletDto, dto);
            var result = _servWallet.EditWallet(walletDto);

            return result;
        }
        #endregion

        #region GetWalletById
        public WalletClass GetWalletById(int id)
        {
            var wallet = _servWallet.GetWalletById(id);

            return wallet;
        }
        #endregion

        #region ListWallets
        public List<WalletClass> ListWallets()
        {
            var wallets = _servWallet.ListWallets();

            return wallets;
        }
        #endregion

        #region DeleteWallet
        public void DeleteWallet(int id)
        {
           _servWallet.DeleteWallet(id);
        }
        #endregion
    }
}
