using System.Collections.Generic;
using System.Linq;
using MVP_Proposal2.Scripts.Domain.Actions;
using MVP_Proposal2.Scripts.Domain.Model;
using UniRx;

namespace MVP_Proposal2.Scripts.Presentation
{
    public class ShopPresenter
    {
        private readonly IShopPopupView _view;
        private readonly LoadBundlesUseCase _loadBundlesUseCase;
        private readonly PurchaseBundleUseCase _purchaseBundleUseCase;

        public ShopPresenter(IShopPopupView view, LoadBundlesUseCase loadBundlesUseCase, PurchaseBundleUseCase purchaseBundleUseCase)
        {
            _view = view;
            _loadBundlesUseCase = loadBundlesUseCase;
            _purchaseBundleUseCase = purchaseBundleUseCase;
        }

        public void Show()
        {
            _loadBundlesUseCase.Execute()
                .Do(LoadBundles)
                .Subscribe();
        }

        private void LoadBundles(List<ShopBundleItem> bundles) => 
            _view.LoadBundles(bundles.Select(ShopBundleItemViewData.From).ToList());

        public void PurchaseBundle(int bundleId)
        {
            _purchaseBundleUseCase.Execute(bundleId)
                .Do(result => _view.UpdateRolls(result.PlayerRollsAmount))
                .Subscribe();
        }
    }
}