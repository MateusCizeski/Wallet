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
    }
}
