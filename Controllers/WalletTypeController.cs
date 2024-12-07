using Application.WalletType;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    [Route("api/v1/WalletType")]
    [ApiController]
    public class WalletTypeController : ControllerBase
    {
        #region Ctor
        private readonly IAplicWalletType _aplicWalletType;

        public WalletTypeController(IAplicWalletType aplicWalletType)
        {
            _aplicWalletType = aplicWalletType;
        }
        #endregion

        #region InsertWalletType
        [HttpPost]
        [Route("InsertWalletType")]
        public IActionResult InsertWalletType([FromBody] InsertEditWalletTypeDTO dto)
        {
            try
            {
                var walletType = _aplicWalletType.InsertWalletType(dto);

                return Ok(walletType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region EditWalletType
        [HttpPut]
        [Route("EditWalletType/{id}")]
        public IActionResult EditWalletType([FromRoute] int id, [FromBody] InsertEditWalletTypeDTO dto)
        {
            try
            {
                var walletType = _aplicWalletType.EditWalletType(id, dto);

                return Ok(walletType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetWalletTypeById
        [HttpGet]
        [Route("GetWalletTypeById/{id}")]
        public IActionResult GetWalletType(int id)
        {
            try
            {
                var walletType = _aplicWalletType.GetWalletTypeById(id);

                return Ok(walletType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region ListWalletsType
        [HttpGet]
        [Route("ListWalletsType")]
        public IActionResult ListWalletsType()
        {
            try
            {
                var wallet = _aplicWalletType.ListWalletsType();

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region DeleteWalletType
        [HttpDelete]
        [Route("DeleteWalletType/{id}")]
        public IActionResult DeleteWalletType([FromRoute] int id)
        {
            try
            {
                _aplicWalletType.DeleteWalletType(id);

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
