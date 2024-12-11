namespace Application.Transaction.DTOs
{
    public class TransactionDTO
    {
        public int SenderWalletId { get; set; }
        public int ReceiverWalletId { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
