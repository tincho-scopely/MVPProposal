using System;
using System.Collections.Generic;
using MVP_Proposal2.Scripts.Domain.Model;
using MVP_Proposal2.Scripts.Domain.Repositories;

namespace MVP_Proposal2.Scripts.Domain.Actions
{
    public class LoadBundles
    {
        private readonly IShopBundlesRepository _shopBundlesRepository;

        public LoadBundles(IShopBundlesRepository shopBundlesRepository)
        {
            _shopBundlesRepository = shopBundlesRepository;
        }

        public IObservable<List<ShopBundleItem>> Execute() => _shopBundlesRepository.Get();
    }
}