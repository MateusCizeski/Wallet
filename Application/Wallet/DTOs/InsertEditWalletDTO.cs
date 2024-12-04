using Domain.Wallet;
using Domain.WalletType;

namespace Application.Wallet
{
    public class InsertEditWalletDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public EnumWalletType Type { get; set; }
        public WalletTypeClass WalletType { get; set; }
    }
}
