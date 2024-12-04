using Domain.Wallet;
using Repository.Wallet;

namespace Services.Wallet
{
    public class ServWallet : IServWallet
    {
        private readonly IRepWallet _repWallet;

        public ServWallet(IRepWallet repWallet)
        {
            _repWallet = repWallet;
        }
        public WalletClass InsertWallet(WalletClass wallet)
        {
            var result = _repWallet.InsertWallet(wallet);

            return result;
        }

        public WalletClass EditWallet(WalletClass wallet)
        {
            var result = _repWallet.EditWallet(wallet);

            return result;
        }

        public WalletClass GetWalletById(int id)
        {
            var wallet = _repWallet.GetWalletById(id);

            return wallet;
        }

        public List<WalletClass> ListWallets()
        {
            var wallets = _repWallet.ListWallets();

            return wallets;
        }

        public void DeleteWallet(int id)
        {
            _repWallet.DeleteWallet(id);
        }
    }
}
