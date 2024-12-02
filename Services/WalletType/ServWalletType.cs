using Repository.WalletType;

namespace Services.WalletType
{
    public class ServWalletType : IServWalletType
    {
        private readonly IRepWalletType _repWalletType;

        public ServWalletType(IRepWalletType repWalletType)
        {
            _repWalletType = repWalletType;
        }
    }
}
