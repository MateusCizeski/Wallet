﻿using Domain.Wallet;

namespace Repository.Wallet
{
    public interface IRepWallet
    {
        WalletClass InsertWallet(WalletClass wallet);
        WalletClass EditWallet(WalletClass wallet);
        WalletClass GetWalletById(int id);
        List<WalletClass> ListWallets();
        void DeleteWallet(int id);
    }
}
