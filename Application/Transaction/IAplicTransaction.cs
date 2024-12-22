using Application.Transaction.DTOs;
using Domain.Transaction;

namespace Application.Transaction
{
    public interface IAplicTransaction
    {
        Task Transaction(TransactionDTO dto);
    }
}
