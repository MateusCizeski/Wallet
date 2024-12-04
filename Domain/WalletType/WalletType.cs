using MongoDB.Bson.Serialization.Attributes;

namespace Domain.WalletType
{
    public class WalletTypeClass
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
