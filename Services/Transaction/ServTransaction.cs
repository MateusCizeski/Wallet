using Repository.Transaction;

namespace Services.Transaction
{
    public class ServTransaction : IServTransaction
    {
        private readonly IRepTransaction _repTransaction;

        public ServTransaction(RepTransaction repTransaction)
        {
            _repTransaction = repTransaction;
        }
    }
}
