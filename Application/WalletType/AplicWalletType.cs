using Application.WalletType.Mapper;
using Domain.WalletType;
using MongoDB.Driver;
using Services.Counter;
using Services.WalletType;

namespace Application.WalletType
{
    public class AplicWalletType : IAplicWalletType
    {
        #region Ctor
        private readonly IServWalletType _servWalletType;
        private readonly IMapperWalletType _mapperWalletType;
        private readonly CounterService _counterService;

        public AplicWalletType(IServWalletType servWalletType, IMapperWalletType mapperWalletType, CounterService counterService)
        {
            _servWalletType = servWalletType;
            _mapperWalletType = mapperWalletType;
            _counterService = counterService;
        }
        #endregion

        #region InsertWalletType
        public WalletTypeClass InsertWalletType(InsertEditWalletTypeDTO dto)
        {
           var walletType = _mapperWalletType.MapperInsertWalletType(dto);
           walletType.Id = _counterService.GetNextSequenceValue("");

           return walletType;
        }
        #endregion

        #region EditWalletType
        public WalletTypeClass EditWalletType(int id, InsertEditWalletTypeDTO dto)
        {
            var walletType = _servWalletType.GetWalletTypeById(id);
            _mapperWalletType.MapperEditWalletType(walletType, dto);

            return walletType;
        }
        #endregion

        #region GetWalletTypeById
        public WalletTypeClass GetWalletTypeById(int id)
        {
            var walletType = _servWalletType.GetWalletTypeById(id);

            return walletType;
        }
        #endregion

        #region ListWalletsType
        public List<WalletTypeClass> ListWalletsType()
        {
            var wallets = _servWalletType.ListWalletsType();

            return wallets;
        }
        #endregion

        #region DeleteWalletType
        public void DeleteWalletType(int id)
        {
            _servWalletType.DeleteWalletType(id);
        }
        #endregion
    }
}
