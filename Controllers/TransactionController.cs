using Application.Transaction;
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

        #region InsertTransaction
        [HttpPost]
        [Route("InsertTransaction")]
        public IActionResult InsertTransaction([FromBody] InsertEditTransactionDTO dto)
        {
            try
            {
                var transaction = _aplicTransaction.InsertTransaction(dto);

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region EditWalletType
        [HttpPut]
        [Route("EditTransaction/{id}")]
        public IActionResult EditTransaction([FromRoute] int id, [FromBody] InsertEditTransactionDTO dto)
        {
            try
            {
                var transaction = _aplicTransaction.EditTransaction(id, dto);

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetTransactionById
        [HttpGet]
        [Route("GetTransactionById/{id}")]
        public IActionResult GetTransaction(int id)
        {
            try
            {
                var transaction = _aplicTransaction.GetTransactionById(id);

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region ListTransactions
        [HttpGet]
        [Route("ListTransactions")]
        public IActionResult ListTransactions()
        {
            try
            {
                var wallet = _aplicTransaction.ListTransaction();

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region DeleteTransaction
        [HttpDelete]
        [Route("DeleteTransaction/{id}")]
        public IActionResult DeleteTransaction([FromRoute] int id)
        {
            try
            {
                _aplicTransaction.DeleteTransaction(id);

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
