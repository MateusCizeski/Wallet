using Application.Wallet.Mapper;
using Domain.Wallet;
using Services.Wallet;

namespace Application.Wallet
{
    public class AplicWallet : IAplicWallet
    {
        private readonly IServWallet _servWallet;
        private readonly IMapperWallet _mapperWallet;

        public AplicWallet(IServWallet servWallet, IMapperWallet mapperWallet)
        {
            _servWallet = servWallet;
            _mapperWallet = mapperWallet;
        }

        public WalletClass InsertWallet(InsertEditWalletDTO dto)
        {
           var wallet = _mapperWallet.MapperInsertWallet(dto);
           var result = _servWallet.InsertWallet(wallet);

           return result;
        }

        public WalletClass EditWallet(InsertEditWalletDTO dto)
        {
            var wallet = _servWallet.GetWalletById(dto.Id);
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
