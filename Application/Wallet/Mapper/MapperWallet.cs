using Domain.Wallet;

namespace Application.Wallet.Mapper
{
    public class MapperWallet : IMapperWallet
    {
        public void MapperEditWallet(WalletClass wallet, InsertEditWalletDTO dto)
        {
            wallet.Name = dto.Name;
            wallet.CpfCnpj = dto.CpfCnpj;
            wallet.Email = dto.Email;
            wallet.Balance = dto.Balance;
            wallet.Type = dto.Type;
        }

        public WalletClass MapperInsertWallet(InsertEditWalletDTO dto)
        {
            var wallet = new WalletClass
            {
                Name = dto.Name,
                CpfCnpj = dto.CpfCnpj,
                Email = dto.Email,
                Balance = dto.Balance,
                Type = dto.Type,
                Password = dto.Password,
                WalletTypeId = dto.WalletTypeId
            };

            return wallet;
        }
    }
}
