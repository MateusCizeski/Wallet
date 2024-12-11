using Domain.Transaction;
using Domain.Wallet;

namespace Repository.Transaction
{
    public interface IRepTransaction
    {
        TransactionClass InsertTransaction(TransactionClass wallet);
        TransactionClass EditTransaction(TransactionClass wallet);
        TransactionClass GetTransactionById(int id);
        List<TransactionClass> ListTransactions();
        void DeleteTransaction(int id);
        void Transaction(WalletClass walletSender, WalletClass walletReceive, decimal transferAmount);
    }
}
