using System.Collections.Generic;
using CleanArchitecture_Example.Scripts.Domain;
using UniRx;
using UnityEngine;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class ShopScreenPresenter : IShowShopUseCaseOutput
    {
        private readonly ShopScreenViewData _viewData;
        private readonly IPurchaseBundleUseCase _purchaseBundleUseCase;
        private readonly IImageRepository _commoditiesImagesRepository;
        private readonly IImageRepository _currenciesImagesRepository;

        public ShopScreenPresenter(
            ShopScreenViewData viewData,
            IPurchaseBundleUseCase purchaseBundleUseCase,
            IImageRepository commoditiesImagesRepository,
            IImageRepository currenciesImagesRepository)
        {
            _viewData = viewData;
            _purchaseBundleUseCase = purchaseBundleUseCase;
            _commoditiesImagesRepository = commoditiesImagesRepository;
            _currenciesImagesRepository = currenciesImagesRepository;
        }
        
        public void SetOutput(int playerBonusRolls, List<ShopBundleDto> bundleDtos)
        {
            var bundleModels = new List<BundleViewData>(bundleDtos.Count);
            foreach (var bundleDto in bundleDtos)
            {
                bundleModels.Add(ParseBundle(bundleDto));
            }

            _viewData.PlayerBonusRolls.Value = playerBonusRolls.ToString();
            _viewData.Show.Execute(bundleModels);
        }

        private BundleViewData ParseBundle(ShopBundleDto dto)
        {
            var viewData = new ShopBundleViewData
            {
                BundleId = dto.Id,
                Name = dto.Name,
                ItemImage = _commoditiesImagesRepository.GetSprite(dto.Item.Key),
                ItemAmount = dto.Item.Quantity.ToString(),
                CostAmount = dto.Cost.Quantity.ToString(),
                CostCommodityImage = _currenciesImagesRepository.GetSprite(dto.Cost.Key)
            };
            var bundleViewData = new BundleViewData(viewData);
            bundleViewData.OnClick.Subscribe(TryPurchaseBundle);
            
            return bundleViewData;
        }

        private void TryPurchaseBundle(int bundleId)
        {
            _purchaseBundleUseCase.Purchase(bundleId, HandlePurchaseSucceed, HandlePurchaseFailed);
        }

        private void HandlePurchaseSucceed(int playerBonusRolls)
        {
            _viewData.PlayerBonusRolls.Value = playerBonusRolls.ToString();
            Debug.Log("<color=green>Yeah - Bundle purchased!</color>");
        }
        
        private void HandlePurchaseFailed()
        {
            Debug.Log("<color=red>Ups - Purchasing Bundle failed!</color>");
        }
    }
}