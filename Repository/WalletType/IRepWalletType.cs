using Domain.WalletType;

namespace Repository.WalletType
{
    public interface IRepWalletType
    {
        WalletTypeClass InsertWallet(WalletTypeClass wallet);
        WalletTypeClass EditWallet(WalletTypeClass wallet);
        WalletTypeClass GetWalletById(int id);
        List<WalletTypeClass> ListWallets();
        void DeleteWallet(int id);
    }
}
