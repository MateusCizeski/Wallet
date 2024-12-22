using Domain.Transaction;
using Domain.Wallet;

namespace Services.Transaction
{
    public interface IServTransaction
    {
        Task Transaction(WalletClass WalletSender, WalletClass WalletReceive, decimal transferAmount);
    }
}
