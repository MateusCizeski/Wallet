using Application.Transaction.DTOs;
using Application.Transaction.Mapper;
using Domain.Transaction;
using MongoDB.Driver;
using Services.Counter;
using Services.Transaction;
using Services.Wallet;

namespace Application.Transaction
{
    public class AplicTransaction : IAplicTransaction
    {
        #region Ctor
        private readonly IServTransaction _servTransaction;
        private readonly IMapperTransaction _mapperTransaction;
        private readonly CounterService _counterService;
        private readonly IServWallet _servWallet;

        public AplicTransaction(IServTransaction servTransaction, 
                                IMapperTransaction mapperTransaction, 
                                CounterService counterService, 
                                IServWallet servWallet)
        {
            _servTransaction = servTransaction;
            _mapperTransaction = mapperTransaction;
            _counterService = counterService;
            _servWallet = servWallet;
        }
        #endregion

        #region Transaction
        public void Transaction(TransactionDTO dto)
        {
            var walletSender = _servWallet.GetWalletById(dto.SenderWalletId);
            var walletReceive = _servWallet.GetWalletById(dto.ReceiverWalletId);

            _servTransaction.Transaction(walletSender, walletReceive, dto.TransferAmount);
        }
        #endregion
    }
}
