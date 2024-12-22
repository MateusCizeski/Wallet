using Application.Transaction;
using Application.Transaction.DTOs;
using Application.WalletType;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    [Route("api/v1/Transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        #region Ctor
        private readonly IAplicTransaction _aplicTransaction;

        public TransactionController(IAplicTransaction aplicTransaction)
        {
            _aplicTransaction = aplicTransaction;
        }
        #endregion

        #region Transaction
        [HttpPost]
        [Route("Transaction")]
        public IActionResult Transaction([FromBody] TransactionDTO dto)
        {
            try
            {
                _aplicTransaction.Transaction(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
