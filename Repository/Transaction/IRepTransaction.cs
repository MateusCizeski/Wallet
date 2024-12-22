using Domain.Transaction;
using Domain.Wallet;

namespace Repository.Transaction
{
    public interface IRepTransaction
    {
        void UpdateWalletBalances(WalletClass walletSender, WalletClass walletReceive, decimal transferAmount);
    }
}
