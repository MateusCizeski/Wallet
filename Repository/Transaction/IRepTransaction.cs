using Domain.Transaction;
using Domain.Wallet;

namespace Repository.Transaction
{
    public interface IRepTransaction
    {
        void Transaction(WalletClass walletSender, WalletClass walletReceive, decimal transferAmount);
    }
}
