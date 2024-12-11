using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Transaction
{
    public class TransactionClass
    {
        public int Id { get; set; }
        public int SenderWalletId { get; set; }
        public int ReceiverWalletId { get; set; }
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
