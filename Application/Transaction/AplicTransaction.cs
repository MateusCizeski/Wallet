using Services.Transaction;

namespace Application.Transaction
{
    public class AplicTransaction : IAplicTransaction
    {
        private readonly IServTransaction _servTransaction;

        public AplicTransaction(IServTransaction servTransaction)
        {
            _servTransaction = servTransaction;
        }
    }
}
