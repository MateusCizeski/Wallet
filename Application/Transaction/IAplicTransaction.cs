using Application.Transaction.DTOs;
using Domain.Transaction;

namespace Application.Transaction
{
    public interface IAplicTransaction
    {
        TransactionClass InsertTransaction(InsertEditTransactionDTO dto);
        TransactionClass EditTransaction(int id, InsertEditTransactionDTO dto);
        TransactionClass GetTransactionById(int id);
        List<TransactionClass> ListTransaction();
        void DeleteTransaction(int id);
        void Transaction(TransactionDTO dto);
    }
}
