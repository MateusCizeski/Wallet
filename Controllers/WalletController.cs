using Application.Wallet;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    [Route("api/v1/Wallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        #region Ctor
        private readonly IAplicWallet _aplicWallet;

        public WalletController(IAplicWallet aplicWallet)
        {
            _aplicWallet = aplicWallet;
        }
        #endregion

        #region InsertWallet
        [HttpPost]
        [Route("InsertWallet")]
        public IActionResult InsertWallet([FromBody] InsertEditWalletDTO dto)
        {
            try
            {
                var wallet = _aplicWallet.InsertWallet(dto);

                return Ok(wallet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region EditWallet
        [HttpPut]
        [Route("EditWallet/{id}")]
        public IActionResult EditWallet([FromRoute] int id, [FromBody] InsertEditWalletDTO dto)
        {
            try
            {
                var wallet = _aplicWallet.EditWallet(id, dto);

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetWalletById
        [HttpGet]
        [Route("GetWalletById/{id}")]
        public IActionResult GetWallet(int id) 
        {
            try
            {
                var wallet = _aplicWallet.GetWalletById(id);

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region ListWallets
        [HttpGet]
        [Route("ListWallets")]
        public IActionResult ListWallets()
        {
            try
            {
                var wallet = _aplicWallet.ListWallets();

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region DeleteWallet
        [HttpDelete]
        [Route("DeleteWallet/{id}")]
        public IActionResult DeleteWallet([FromRoute] int id)
        {
            try
            {
                _aplicWallet.DeleteWallet(id);

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
