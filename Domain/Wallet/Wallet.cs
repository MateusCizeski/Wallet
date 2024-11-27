namespace Domain
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public EnumWalletType Type { get; set; }
        public WalletType WalletType { get; set; }
    }

    public enum EnumWalletType
    {
        Personal,
        Business
    }
}
