using System;
using MVP_CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Model;
using MVP_Proposal2.Scripts.Domain.Repositories;
using UniRx;
using IShopBundlesRepository = MVP_Proposal2.Scripts.Domain.Repositories.IShopBundlesRepository;

namespace MVP_Proposal2.Scripts.Domain.Actions
{
    public class PurchaseBundle
    {
        private readonly IShopBundlesRepository _shopBundlesRepository;
        private readonly IPlayerInventoryRepository _playerInventoryRepository;

        public PurchaseBundle(IShopBundlesRepository shopBundlesRepository,
            IPlayerInventoryRepository playerInventoryRepository)
        {
            _shopBundlesRepository = shopBundlesRepository;
            _playerInventoryRepository = playerInventoryRepository;
        }
        
        public IObservable<PurchaseBundleResult> Execute(int bundleId)
        {
            var playerInventory = _playerInventoryRepository.Get();
            var bundle = _shopBundlesRepository.GetById(bundleId);

            return _shopBundlesRepository.Purchase(bundleId)
                .Select(_ => playerInventory.RemoveRolls(bundle.Cost.Quantity))
                .Do(updatedInventory => _playerInventoryRepository.Save(updatedInventory))
                .Select(updatedInventory =>
                    new PurchaseBundleResult(updatedInventory.GetCommodityAmount(CommodityDefinitions.BonusRolls)));
        }
    }
}