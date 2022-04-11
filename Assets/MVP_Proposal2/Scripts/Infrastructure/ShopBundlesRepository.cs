using System;
using System.Collections.Generic;
using System.Linq;
using MVP_Proposal2.Scripts.Domain.Model;
using MVP_Proposal2.Scripts.Domain.Services;
using MVP_Proposal2.Scripts.Infrastructure.DTO;
using UniRx;
using UnityEngine;
using IShopBundlesRepository = MVP_Proposal2.Scripts.Domain.Repositories.IShopBundlesRepository;

namespace MVP_Proposal2.Scripts.Infrastructure
{
    public class ShopBundlesRepository : IShopBundlesRepository
    {
        private readonly IShopApiGateway _shopApiGateway;
        private List<ShopBundleItem> _bundles;

        public ShopBundlesRepository(IShopApiGateway shopApiGateway)
        {
            _shopApiGateway = shopApiGateway;
        }

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
            return _shopApiGateway.Get("ShopBundles")
                .Select(JsonUtility.FromJson<ShopBundlesDTO>)
                .Select(bundles => bundles.ToBundles());
        }
    }
}