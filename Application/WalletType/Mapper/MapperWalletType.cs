using Domain.WalletType;

namespace Application.WalletType.Mapper
{
    public class MapperWalletType : IMapperWalletType
    {
        public void MapperEditWalletType(WalletTypeClass walletType, InsertEditWalletTypeDTO dto)
        {
            walletType.Description = dto.Description;
        }

        public WalletTypeClass MapperInsertWalletType(InsertEditWalletTypeDTO dto)
        {
            var walletType = new WalletTypeClass
            {
                Description = dto.Description,
            };

            return walletType;
        }
    }
}
