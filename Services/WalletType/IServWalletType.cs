using Domain.WalletType;

namespace Services.WalletType
{
    public interface IServWalletType
    {
        WalletTypeClass InsertWallet(WalletTypeClass wallet);
        WalletTypeClass EditWallet(WalletTypeClass wallet);
        WalletTypeClass GetWalletById(int id);
        List<WalletTypeClass> ListWallets();
        void DeleteWallet(int id);
    }
}
