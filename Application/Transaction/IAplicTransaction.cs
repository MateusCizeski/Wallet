using Application.Transaction.DTOs;
using Domain.Transaction;

namespace Application.Transaction
{
    public interface IAplicTransaction
    {
        void Transaction(TransactionDTO dto);
    }
}
