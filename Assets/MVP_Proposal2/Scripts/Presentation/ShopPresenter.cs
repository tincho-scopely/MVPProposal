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
        private readonly LoadBundles _loadBundles;
        private readonly PurchaseBundle _purchaseBundle;

        public ShopPresenter(IShopPopupView view, LoadBundles loadBundles, PurchaseBundle purchaseBundle)
        {
            _view = view;
            _loadBundles = loadBundles;
            _purchaseBundle = purchaseBundle;
        }

        public void Show()
        {
            _loadBundles.Execute()
                .Do(LoadBundles)
                .Subscribe();
        }

        private void LoadBundles(List<ShopBundleItem> bundles) => 
            _view.LoadBundles(bundles.Select(ShopBundleItemViewData.From).ToList());

        public void PurchaseBundle(int bundleId)
        {
            _purchaseBundle.Execute(bundleId)
                .Do(result => _view.UpdateRolls(result.PlayerRollsAmount))
                .Subscribe();
        }
    }
}