using Domain.Wallet;
using Repository.Wallet;

namespace Services.Wallet
{
    public class ServWallet : IServWallet
    {
        #region Ctor
        private readonly IRepWallet _repWallet;

        public ServWallet(IRepWallet repWallet)
        {
            _repWallet = repWallet;
        }
        #endregion

        #region InsertWallet
        public WalletClass InsertWallet(WalletClass wallet)
        {
            var result = _repWallet.InsertWallet(wallet);

            return result;
        }
        #endregion

        #region EditWallet
        public WalletClass EditWallet(WalletClass wallet)
        {
            var result = _repWallet.EditWallet(wallet);

            return result;
        }
        #endregion

        #region GetWalletById
        public WalletClass GetWalletById(int id)
        {
            var wallet = _repWallet.GetWalletById(id);

            return wallet;
        }
        #endregion

        #region ListWallets
        public List<WalletClass> ListWallets()
        {
            var wallets = _repWallet.ListWallets();

            return wallets;
        }
        #endregion

        #region DeleteWallet
        public void DeleteWallet(int id)
        {
            _repWallet.DeleteWallet(id);
        }
        #endregion
    }
}
