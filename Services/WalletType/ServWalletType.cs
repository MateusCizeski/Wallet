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

        #region InsertWalletType
        public WalletTypeClass InsertWalletType(WalletTypeClass walletType)
        {
           _repWalletType.InsertWalletType(walletType);

            return walletType;
        }
        #endregion

        #region EditWalletType
        public WalletTypeClass EditWalletType(WalletTypeClass walletType)
        {
           _repWalletType.EditWalletType(walletType);

            return walletType;
        }
        #endregion

        #region GetWalletTypeById
        public WalletTypeClass GetWalletTypeById(int id)
        {
           var walletType = _repWalletType.GetWalletTypeById(id);

            return walletType;
        }
        #endregion

        #region ListWalletsType
        public List<WalletTypeClass> ListWalletsType()
        {
            var walletsType = _repWalletType.ListWalletsType();

            return walletsType;
        }
        #endregion

        #region DeleteWalletType
        public void DeleteWalletType(int id)
        {
            _repWalletType.DeleteWalletType(id);
        }
        #endregion
    }
}
