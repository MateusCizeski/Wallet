using System.ComponentModel;
using System.Text.Json.Serialization;
using Domain.WalletType;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Wallet
{
    public class WalletClass
    {
        [BsonId]
        public int Id { get; set; }
        public string Name {  get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public EnumWalletType Type { get; set; }
        public WalletTypeClass WalletType { get; set; }
    }

    public enum EnumWalletType
    {
        [Description("Pessoal")]
        Personal = 1,

        [Description("Negócios")]
        Business = 2
    }
}
