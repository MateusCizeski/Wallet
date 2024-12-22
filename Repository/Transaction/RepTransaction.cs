using Domain.Transaction;
using Domain.Wallet;
using MongoDB.Driver;

namespace Repository.Transaction {
    public class RepTransaction : IRepTransaction
    {
         #region Ctor
        private readonly IMongoCollection<WalletClass> _walletCollection;

        public RepTransaction(IMongoCollection<WalletClass> walletCollection)
        {
            _walletCollection = walletCollection;
        }
        #endregion

        #region UpdateWalletBalances
        public void UpdateWalletBalances(WalletClass walletSender, WalletClass walletReceive, decimal transferAmount)
        {
            var updateSender = Builders<WalletClass>.Update.Set(w => w.Balance, walletSender.Balance - transferAmount);
            var senderResult = _walletCollection.UpdateOne(w => w.Id == walletSender.Id, updateSender);

            if (senderResult.ModifiedCount == 0)
            {
                throw new Exception("Erro ao atualizar o saldo da carteira de origem.");
            }

            var updateReceiver = Builders<WalletClass>.Update.Set(w => w.Balance, walletReceive.Balance + transferAmount);
            var receiverResult = _walletCollection.UpdateOne(w => w.Id == walletReceive.Id, updateReceiver);

            if (receiverResult.ModifiedCount == 0)
            {
                throw new Exception("Erro ao atualizar o saldo da carteira de destino.");
            }
        }
        #endregion
    }
}
