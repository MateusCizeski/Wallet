using Application.Wallet;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    [Route("api/v1/Wallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IAplicWallet _aplicWallet;

        public WalletController(IAplicWallet aplicWallet)
        {
            _aplicWallet = aplicWallet;
        }
    }
}
