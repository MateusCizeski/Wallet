using Domain.Transaction;

namespace Application.Transaction
{
    public class InsertEditTransactionDTO
    {
        public int Id { get; set; }
        public int SenderWalletId { get; set; }
        public int ReceiverWalletId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public EnumTransactionStatus Status { get; set; } = EnumTransactionStatus.Pending;
    }
}
