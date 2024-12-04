using Application.Wallet.DTOs;
using Domain.Wallet;

namespace Application.Wallet
{
    public interface IAplicWallet
    {
        WalletClass InsertWallet(InsertEditWalletDTO dto);
        WalletClass EditWallet(InsertEditWalletDTO dto);
        WalletClass GetWalletById(int id);
        List<WalletClass> ListWallets();
        void DeleteWallet(int id);
    }
}
