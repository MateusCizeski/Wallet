using Domain.WalletType;

namespace Services.WalletType
{
    public interface IServWalletType
    {
        WalletTypeClass InsertWalletType(WalletTypeClass wallet);
        WalletTypeClass EditWalletType(WalletTypeClass wallet);
        WalletTypeClass GetWalletTypeById(int id);
        List<WalletTypeClass> ListWalletsType();
        void DeleteWalletType(int id);
    }
}
