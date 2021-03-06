using System;

namespace CleanArchitecture_Example.Scripts.Domain.UseCases
{
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
            var currencyKey = shopBundleDto.Cost.Key;
            _playerInventory.AddCurrency(shopBundleDto.Cost.Key, -shopBundleDto.Cost.Quantity);
            
            onSucceed?.Invoke(_playerInventory.GetCurrencyQuantity(currencyKey));
        }
    }
}