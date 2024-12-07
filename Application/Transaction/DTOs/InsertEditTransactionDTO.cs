using Domain.Transaction;

namespace Application.Transaction
{
    public class InsertEditTransactionDTO
    {
        public int Id { get; set; }
        public string SenderWalletId { get; set; } = string.Empty;
        public string ReceiverWalletId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public EnumTransactionStatus Status { get; set; } = EnumTransactionStatus.Pending;
    }
}
