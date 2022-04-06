using System.Collections.Generic;
using MVP_CleanArchitecture_Example.Scripts.Domain;
using UnityEngine;
using UniRx;

namespace MVP_CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class ShopScreenPresenter : IShowShopUseCaseOutput
    {
        private readonly ShopScreenModel _model;
        private readonly IPurchaseBundleUseCase _purchaseBundleUseCase;

        public ShopScreenPresenter(
            ShopScreenModel model,
            IPurchaseBundleUseCase purchaseBundleUseCase)
        {
            _model = model;
            _purchaseBundleUseCase = purchaseBundleUseCase;
        }
        
        public void Show(List<ShopBundleDto> bundleDtos)
        {
            var bundleModels = new List<BundleModel>(bundleDtos.Count);
            foreach (var bundleDto in bundleDtos)
            {
                bundleModels.Add(ParseBundle(bundleDto));
            }

            _model.Show.Execute(bundleModels);
        }

        private BundleModel ParseBundle(ShopBundleDto dto)
        {
            var viewData = new ShopBundleViewData
            {
                BundleId = dto.Id,
                Name = dto.Name,
                ItemImage = GetCommodityImage(dto.Item.Key),
                ItemAmount = dto.Item.Quantity.ToString(),
                CostAmount = dto.Cost.Quantity.ToString(),
                CostCommodityImage = GetCommodityImage(dto.Cost.Key)
            };
            var bundleModel = new BundleModel(viewData);
            bundleModel.OnClick.Subscribe(TryPurchaseBundle);
            
            return bundleModel;
        }

        private Sprite GetCommodityImage(string key)
        {
            return null;
        }

        private void TryPurchaseBundle(int bundleId)
        {
            _purchaseBundleUseCase.Purchase(bundleId, HandlePurchaseSucceed, HandlePurchaseFailed);
        }

        private void HandlePurchaseSucceed(int playerBonusRolls)
        {
            _model.PlayerBonusRolls.Value = playerBonusRolls.ToString();
            Debug.Log("<color=green>Yeah - Bundle purchased!</color>");
        }
        
        private void HandlePurchaseFailed()
        {
            Debug.Log("<color=red>Ups - Purchasing Bundle failed!</color>");
        }
    }
}