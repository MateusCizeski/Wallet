using Domain.WalletType;

namespace Application.WalletType.Mapper
{
    public interface IMapperWalletType
    {
        WalletTypeClass MapperInsertWalletType(InsertEditWalletTypeDTO dto);
        void MapperEditWalletType(WalletTypeClass wallet, InsertEditWalletTypeDTO dto);
    }
}
