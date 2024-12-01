using Repository.Wallet;

namespace Services.Wallet
{
    public class ServWallet : IServWallet
    {
        private readonly IRepWallet _repWallet;

        public ServWallet(IRepWallet repWallet)
        {
            _repWallet = repWallet;
        }
    }
}
