using Domain.Wallet;
using Repository.Wallet;

namespace Application.Wallet
{
    public interface IAplicWallet
    {
        WalletDTO InsertWallet(InsertEditWalletDTO dto);
        WalletDTO EditWallet(int id, InsertEditWalletDTO dto);
        WalletClass GetWalletById(int id);
        List<WalletDTO> ListWallets();
        void DeleteWallet(int id);
    }
}
