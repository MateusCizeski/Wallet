using System.Transactions;
using Domain.Transaction;
using MongoDB.Driver;

namespace Repository.Transaction
{
    public class RepTransaction : IRepTransaction
    {
        private readonly IMongoCollection<TransactionClass> _mongoCollection;

        public RepTransaction(IMongoCollection<TransactionClass> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public TransactionClass InsertTransaction(TransactionClass transaction)
        {
            _mongoCollection.InsertOne(transaction;
            return transaction;
        }

        public TransactionClass EditTransaction(TransactionClass transaction)
        {
            _mongoCollection.ReplaceOne(filter: p => p.Id == transaction.Id, replacement: transaction);

            return transaction;
        }

        public TransactionClass GetTransactionById(int id)
        {
            var transaction = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (transaction == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            return transaction;
        }

        public List<TransactionClass> ListTransactions()
        {
            var transactions = _mongoCollection.Find(_ => true).ToList();

            return transactions;
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _mongoCollection.Find(p => p.Id == id).FirstOrDefault();

            if (transaction == null)
            {
                throw new Exception("Carteira não encontrada.");
            }

            _mongoCollection.DeleteOne(p => p.Id == id);
        }
    }
}
