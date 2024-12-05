using Domain.WalletType;

namespace Repository.WalletType
{
    public interface IRepWalletType
    {
        WalletTypeClass InsertWalletType(WalletTypeClass wallet);
        WalletTypeClass EditWalletType(WalletTypeClass wallet);
        WalletTypeClass GetWalletTypeById(int id);
        List<WalletTypeClass> ListWalletsType();
        void DeleteWalletType(int id);
    }
}
