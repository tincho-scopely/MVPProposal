using System;

namespace MVP_CleanArchitecture_Example.Scripts.Domain
{
    public interface IPurchaseBundleUseCase
    {
        void Purchase(int bundleId, Action<int> onSucceed, Action onFailed);
    }

    // This use case is the one to add Tests
    public class PurchaseBundleUseCase : IPurchaseBundleUseCase
    {
        private readonly IShopBundlesRepository _bundlesRepository;
        private readonly IEndpointHelper _endpointHelper;
        private readonly IPlayerInventory _playerInventory;

        public PurchaseBundleUseCase(
            IShopBundlesRepository bundlesRepository,
            IEndpointHelper endpointHelper,
            IPlayerInventory playerInventory)
        {
            _bundlesRepository = bundlesRepository;
            _endpointHelper = endpointHelper;
            _playerInventory = playerInventory;
        }

        public void Purchase(int bundleId, Action<int> onSucceed, Action onFailed)
        {
            var bundleDto = _bundlesRepository.GetBundleById(bundleId);
            
            _endpointHelper.PurchaseBundle(
                bundleId, 
                () =>
                {
                    HandlePurchaseSucceed(bundleDto, onSucceed);
                }, 
                onFailed
            );
        }

        private void HandlePurchaseSucceed(ShopBundleDto shopBundleDto, Action<int> onSucceed)
        {
            var commodityKey = shopBundleDto.Cost.Key;
            _playerInventory.AddCommodity(shopBundleDto.Cost.Key, -shopBundleDto.Cost.Quantity);
            
            onSucceed?.Invoke(_playerInventory.GetCommodityQuantity(commodityKey));
        }
    }
}