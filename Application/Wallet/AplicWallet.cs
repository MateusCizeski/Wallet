using Services.Wallet;

namespace Application.Wallet
{
    public class AplicWallet : IAplicWallet
    {
        private readonly IServWallet _servWallet;

        public AplicWallet(IServWallet servWallet)
        {
            _servWallet = servWallet;
        }
    }
}
