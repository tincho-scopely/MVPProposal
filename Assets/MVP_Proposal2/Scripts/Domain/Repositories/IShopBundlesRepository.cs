using System;
using System.Collections.Generic;
using MVP_Proposal2.Scripts.Domain.Model;
using UniRx;

namespace MVP_Proposal2.Scripts.Domain.Repositories
{
    public interface IShopBundlesRepository
    {
        IObservable<List<ShopBundleItem>> Get();
        IObservable<Unit> Purchase(int bundleId);
        ShopBundleItem GetById(int bundleId);
    }
}