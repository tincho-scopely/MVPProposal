using System.Collections.Generic;
using MVP_Proposal2.Scripts.Domain.Actions;
using MVP_Proposal2.Scripts.Domain.Repositories;
using MVP_Proposal2.Scripts.Presentation;
using TMPro;
using UnityEngine;

namespace MVP_Proposal2.Scripts.Views
{
    public class ShopPopupView : MonoBehaviour, IShopPopupView
    {
        [SerializeField] private ShopBundleItemViewModel[] bundleItems;
        [SerializeField] private TextMeshProUGUI rollsText;
        
        private ShopPresenter presenter;

        public void Init(IShopBundlesRepository shopBundlesRepository, IPlayerInventoryRepository playerInventoryRepository)
        {
            var loadBundles = new LoadBundlesUseCase(shopBundlesRepository);
            var purchaseBundle = new PurchaseBundleUseCase(shopBundlesRepository, playerInventoryRepository);
            presenter = new ShopPresenter(this, loadBundles, purchaseBundle);
        }

        public void Show() => presenter.Show();
        
        public void LoadBundles(List<ShopBundleItemViewData> bundles)
        {
            for (int i = 0; i < bundles.Count; i++)
            {
                bundleItems[i].SetData(
                    bundles[i]
                );
                
            }
        }

        public void UpdateRolls(int playerRolls)
        {
            rollsText.text = playerRolls.ToString();
        }
    }
}
