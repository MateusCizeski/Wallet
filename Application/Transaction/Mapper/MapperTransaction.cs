using Domain.Transaction;

namespace Application.Transaction.Mapper
{
    public class MapperTransaction : IMapperTransaction
    {
        public void MapperEditTransaction(TransactionClass transaction, InsertEditTransactionDTO dto)
        {
            transaction.SenderWalletId = dto.SenderWalletId;
            transaction.ReceiverWalletId = dto.ReceiverWalletId;
            transaction.Amount = dto.Amount;
            transaction.TransactionDate = dto.TransactionDate;
            transaction.Status = dto.Status;
        }

        public TransactionClass MapperInsertTransaction(InsertEditTransactionDTO dto)
        {
            var transaction = new TransactionClass
            {
                Id = dto.Id,
                SenderWalletId = dto.SenderWalletId,
                ReceiverWalletId = dto.ReceiverWalletId,
                Amount = dto.Amount,
                TransactionDate = dto.TransactionDate,
                Status = dto.Status
            };

            return transaction;
        }
    }
}
