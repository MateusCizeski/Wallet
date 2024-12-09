using Domain.Wallet;

namespace Repository.Wallet
{
    public interface IRepWallet
    {
        WalletDTO InsertWallet(WalletClass wallet);
        WalletDTO EditWallet(WalletClass wallet);
        WalletDTO GetWalletById(int id);
        List<WalletDTO> ListWallets();
        void DeleteWallet(int id);
    }
}
