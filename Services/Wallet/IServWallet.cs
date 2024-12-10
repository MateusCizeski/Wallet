using Domain.Wallet;
using Repository.Wallet;

namespace Services.Wallet
{
    public interface IServWallet
    {
        WalletDTO InsertWallet(WalletClass wallet);
        WalletDTO EditWallet(WalletClass wallet);
        WalletClass GetWalletById(int id);
        List<WalletDTO> ListWallets();
        void DeleteWallet(int id);
    }
}
