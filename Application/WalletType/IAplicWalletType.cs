using Domain.WalletType;

namespace Application.WalletType
{
    public interface IAplicWalletType
    {
        WalletTypeClass InsertWalletType(InsertEditWalletTypeDTO dto);
        WalletTypeClass EditWalletType(int id, InsertEditWalletTypeDTO dto);
        WalletTypeClass GetWalletTypeById(int id);
        List<WalletTypeClass> ListWalletsType();
        void DeleteWalletType(int id);
    }
}
