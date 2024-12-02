using Application.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Controllers
{
    [Route("api/v1/Transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IAplicTransaction _aplicTransaction;

        public TransactionController(IAplicTransaction aplicTransaction)
        {
            _aplicTransaction = aplicTransaction;
        }
    }
}
