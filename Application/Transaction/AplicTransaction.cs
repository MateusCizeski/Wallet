using Application.Transaction.Mapper;
using Domain.Transaction;
using MongoDB.Driver;
using Services.Counter;
using Services.Transaction;

namespace Application.Transaction
{
    public class AplicTransaction : IAplicTransaction
    {
        #region Ctor
        private readonly IServTransaction _servTransaction;
        private readonly IMapperTransaction _mapperTransaction;
        private readonly CounterService _counterService;

        public AplicTransaction(IServTransaction servTransaction, IMapperTransaction mapperTransaction, IMongoDatabase database)
        {
            _servTransaction = servTransaction;
            _mapperTransaction = mapperTransaction;
            _counterService = new CounterService(database);
        }
        #endregion

        #region InsertTransaction
        public TransactionClass InsertTransaction(InsertEditTransactionDTO dto)
        {
            var transation = _mapperTransaction.MapperInsertTransaction(dto);
            transation.Id = _counterService.GetNextSequenceValue("transaction");
            _servTransaction.InsertTransaction(transation);

            return transation;
        }
        #endregion

        #region EditTransaction
        public TransactionClass EditTransaction(int id, InsertEditTransactionDTO dto)
        {
            var transaction = _servTransaction.GetTransactionById(id);
            _mapperTransaction.MapperEditTransaction(transaction ,dto);

            return transaction;
        }
        #endregion

        #region GetTransactionById
        public TransactionClass GetTransactionById(int id)
        {
            var transaction = _servTransaction.GetTransactionById(id);

            return transaction;
        }
        #endregion

        #region ListTransaction
        public List<TransactionClass> ListTransaction()
        {
           var transactions = _servTransaction.ListTransactions();

            return transactions;
        }
        #endregion

        #region DeleteTransaction
        public void DeleteTransaction(int id)
        {
            _servTransaction.DeleteTransaction(id);
        }
        #endregion
    }
}
