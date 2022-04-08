using System;
using System.Collections.Generic;
using System.Linq;
using MVP_CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Model;
using UniRx;
using IShopBundlesRepository = MVP_Proposal2.Scripts.Domain.Repositories.IShopBundlesRepository;

namespace MVP_Proposal2.Scripts.Infrastructure
{
    public class ShopBundlesRepository : IShopBundlesRepository
    {
        private List<ShopBundleItem> _bundles;

        public IObservable<List<ShopBundleItem>> Get() =>
            _bundles != null
                ? Observable.Return(_bundles)
                : GetBundlesFromServer()
                    .Do(bundles => _bundles = bundles);

        public IObservable<Unit> Purchase(int bundleId)
        {
            //TODO: Implement server
            return Observable.ReturnUnit();
        }

        public ShopBundleItem GetById(int bundleId) =>
            _bundles.First(bundle => bundle.Id == bundleId);
        

        private IObservable<List<ShopBundleItem>> GetBundlesFromServer()
        {
            var random = new Random();
            var bundles  = new List<ShopBundleItem>();
            for (var i = 0; i < 9; i++)
            {
                bundles.Add(new ShopBundleItem(
                    i,
                    "bundle" + i,
                    new Commodity(CommodityDefinitions.BonusRolls, random.Next(5, 21)),
                    new Commodity(string.Empty, new Random().Next(1, 3))
                ));
            }

            return Observable.Return(bundles);
        }
    }
}