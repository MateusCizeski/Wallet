using Domain.Wallet;
using Repository.Wallet;

namespace Services.Wallet
{
    public interface IServWallet
    {
        WalletClass InsertWallet(WalletClass wallet);
        WalletClass EditWallet(WalletClass wallet);
        WalletClass GetWalletById(int id);
        List<WalletClass> ListWallets();
        void DeleteWallet(int id);
    }
}
