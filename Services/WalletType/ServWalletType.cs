using Domain.WalletType;
using Repository.WalletType;

namespace Services.WalletType
{
    public class ServWalletType : IServWalletType
    {
        #region Ctor
        private readonly IRepWalletType _repWalletType;

        public ServWalletType(IRepWalletType repWalletType)
        {
            _repWalletType = repWalletType;
        }
        #endregion

        #region InsertWallet
        public WalletTypeClass InsertWallet(WalletTypeClass walletType)
        {
           _repWalletType.InsertWalletType(walletType);

            return walletType;
        }
        #endregion

        #region EditWallet
        public WalletTypeClass EditWallet(WalletTypeClass walletType)
        {
           _repWalletType.EditWalletType(walletType);

            return walletType;
        }
        #endregion

        #region GetWalletById
        public WalletTypeClass GetWalletById(int id)
        {
           var walletType = _repWalletType.GetWalletTypeById(id);

            return walletType;
        }
        #endregion

        #region ListWallets
        public List<WalletTypeClass> ListWallets()
        {
            var walletsType = _repWalletType.ListWalletsType();

            return walletsType;
        }
        #endregion

        #region DeleteWallet
        public void DeleteWallet(int id)
        {
            _repWalletType.DeleteWalletType(id);
        }
        #endregion
    }
}
