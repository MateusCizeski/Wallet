using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Transaction
{
    public class TransactionClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string SenderWalletId { get; set; } = string.Empty;
        public string ReceiverWalletId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public EnumTransactionStatus Status { get; set; } = EnumTransactionStatus.Pending;
    }

    public enum EnumTransactionStatus
    {
        [Description("Pendente")]
        Pending = 1,

        [Description("Autorizado")]
        Authorized = 2,

        [Description("Rejeitado")]
        Rejected = 3,

        [Description("Concluído")]
        Completed = 4
    }
}
