namespace Application.WalletType
{
    public class AplicWalletType : IAplicWalletType
    {
        private readonly IAplicWalletType _aplicWalletType;

        public AplicWalletType(IAplicWalletType aplicWalletType)
        {
            _aplicWalletType = aplicWalletType;
        }
    }
}
