using Domain.Transaction;
using Domain.Wallet;
using MongoDB.Driver;

namespace Repository.Transaction {
    public class RepTransaction : IRepTransaction
    {
        #region Ctor
        private readonly IMongoCollection<TransactionClass> _mongoCollection;
        private readonly IMongoCollection<WalletClass> _walletCollection;

        public RepTransaction(IMongoCollection<TransactionClass> mongoCollection, IMongoCollection<WalletClass> walletCollection)
        {
            _mongoCollection = mongoCollection;
            _walletCollection = walletCollection;
        }
        #endregion

        #region InsertTransaction
        public TransactionClass InsertTransaction(TransactionClass transaction)
        {
            _mongoCollection.InsertOne(transaction);
            return transaction;
        }
        #endregion

        #region EditTransaction
        public TransactionClass EditTransaction(TransactionClass transaction)
        {
            _mongoCollection.ReplaceOne(filter: p => p.Id == transaction.Id, replacement: transaction);

            return transaction;
        }
        #endregion

        #region GetTransactionById
        public TransactionClass GetTransactionById(int id)
        {
            var transaction = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (transaction == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            return transaction;
        }
        #endregion

        #region ListTransactions
        public List<TransactionClass> ListTransactions()
        {
            var transactions = _mongoCollection.Find(_ => true).ToList();

            return transactions;
        }
        #endregion

        #region DeleteTransaction
        public void DeleteTransaction(int id)
        {
            var transaction = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (transaction == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            _mongoCollection.DeleteOne(p => p.Id == id);
        }
        #endregion

        #region Trasaction
        public void Transaction(WalletClass walletSender, WalletClass walletReceive, decimal transferAmount, int id)
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

            var transaction = new TransactionClass
            {
                Id = id,
                SenderWalletId = walletSender.Id,
                ReceiverWalletId = walletReceive.Id,
                Amount = transferAmount,
                TransactionDate = DateTime.UtcNow
            };

            _mongoCollection.InsertOne(transaction);
        }
        #endregion
    }
}
