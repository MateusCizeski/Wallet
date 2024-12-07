using Domain.Transaction;

namespace Services.Transaction
{
    public interface IServTransaction
    {
        TransactionClass InsertTransaction(TransactionClass wallet);
        TransactionClass EditTransaction(TransactionClass wallet);
        TransactionClass GetTransactionById(int id);
        List<TransactionClass> ListTransactions();
        void DeleteTransaction(int id);
    }
}
