using Domain.Wallet;
using Repository.Transaction;
using Services.Notification;

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

        #region Transaction
        public async Task Transaction(WalletClass walletSender, WalletClass walletReceive, decimal transferAmount)
        {
            if (walletSender == null)
            {
                throw new Exception("Carteira de origem não encontrada.");
            }

            if (walletReceive == null)
            {
                throw new Exception("Carteira de destino não encontrada.");
            }

            if (walletSender.Id == walletReceive.Id)
            {
                throw new Exception("Carteira de origem e carteira de destino não podem ser as mesmas.");
            }

            if(walletSender.Balance < transferAmount)
            {
                throw new Exception("Saldo insuficiente na carteira de origem.");
            }

            if (walletSender.Type == EnumWalletType.Business)
            {
                throw new Exception("Carteiras de negócios não podem realizar transferências.");
            }

            if (walletReceive.Type == EnumWalletType.Business && walletSender.Type != EnumWalletType.Personal)
            {
                throw new Exception("Somente carteiras pessoais podem transferir para carteiras de negócios.");
            }

            _repTransaction.UpdateWalletBalances(walletSender, walletReceive, transferAmount);
        }
        #endregion
    }
}
