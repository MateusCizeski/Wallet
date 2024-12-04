using Domain.Wallet;

namespace Application.Wallet.Mapper
{
    public interface IMapperWallet
    {
        WalletClass MapperInsertWallet(InsertEditWalletDTO dto);
        void MapperEditWallet(WalletClass wallet, InsertEditWalletDTO dto);
    }
}
