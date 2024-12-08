using Domain.Transaction;
using Repository.Transaction;

namespace Services.Transaction
{
    public class ServTransaction : IServTransaction
    {
        #region Ctor
        private readonly IRepTransaction _repTransaction;

        public ServTransaction(IRepTransaction repTransaction)
        {
            _repTransaction = repTransaction;
        }
        #endregion

        #region InsertTransaction
        public TransactionClass InsertTransaction(TransactionClass transaction)
        {
           _repTransaction.InsertTransaction(transaction);

            return transaction;
        }
        #endregion

        #region EditTransaction
        public TransactionClass EditTransaction(TransactionClass transaction)
        {
            _repTransaction.EditTransaction(transaction);

            return transaction;
        }
        #endregion

        #region GetTransactionById
        public TransactionClass GetTransactionById(int id)
        {
            var transaction = _repTransaction.GetTransactionById(id);

            return transaction;
        }
        #endregion

        #region ListTransactions
        public List<TransactionClass> ListTransactions()
        {
            var transactions = _repTransaction.ListTransactions();

            return transactions;
        }
        #endregion

        #region DeleteTransaction
        public void DeleteTransaction(int id)
        {
            _repTransaction.DeleteTransaction(id);
        }
        #endregion
    }
}
