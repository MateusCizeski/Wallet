using Application.WalletType;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    [Route("api/v1/WalletType")]
    [ApiController]
    public class WalletTypeController : ControllerBase
    {
        private readonly IAplicWalletType _aplicWalletType;

        public WalletTypeController(IAplicWalletType aplicWalletType)
        {
            _aplicWalletType = aplicWalletType;
        }
    }
}
