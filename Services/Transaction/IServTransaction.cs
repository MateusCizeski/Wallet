using Domain.Transaction;
using Domain.Wallet;

namespace Services.Transaction
{
    public interface IServTransaction
    {
        void Transaction(WalletClass WalletSender, WalletClass WalletReceive, decimal transferAmount);
    }
}
