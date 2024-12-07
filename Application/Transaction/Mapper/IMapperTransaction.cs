using Domain.Transaction;

namespace Application.Transaction.Mapper
{
    public interface IMapperTransaction
    {
        TransactionClass MapperInsertTransaction(InsertEditTransactionDTO dto);
        void MapperEditTransaction(TransactionClass transaction, InsertEditTransactionDTO dto);
    }
}
