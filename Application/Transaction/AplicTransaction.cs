using Application.Transaction.DTOs;
using Application.Transaction.Mapper;
using Domain.Transaction;
using MongoDB.Driver;
using Services.Counter;
using Services.Notification;
using Services.Transaction;
using Services.Wallet;

namespace Application.Transaction
{
    public class AplicTransaction : IAplicTransaction
    {
        #region Ctor
        private readonly IServTransaction _servTransaction;
        private readonly IServWallet _servWallet;
        private readonly IServSendGridEmailNotificationService _servNotification;

        public AplicTransaction(IServTransaction servTransaction, 
                                IServWallet servWallet,
                                IServSendGridEmailNotificationService servSendGridEmailNotificationService)
        {
            _servTransaction = servTransaction;
            _servWallet = servWallet;
            _servNotification = servSendGridEmailNotificationService;
        }
        #endregion

        #region Transaction
        public async Task Transaction(TransactionDTO dto)
        {
            if (dto.TransferAmount <= 0)
            {
                throw new Exception("O valor da transferência deve ser maior que zero.");
            }

            var walletSender = _servWallet.GetWalletById(dto.SenderWalletId);
            var walletReceive = _servWallet.GetWalletById(dto.ReceiverWalletId);

            _servTransaction.Transaction(walletSender, walletReceive, dto.TransferAmount);

            await _servNotification.NotifyTransferAsync(walletReceive.Email, dto.TransferAmount);
        }
        #endregion
    }
}
