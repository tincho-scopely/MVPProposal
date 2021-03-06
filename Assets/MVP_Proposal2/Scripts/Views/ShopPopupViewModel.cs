using System.Collections.Generic;
using MVP_Proposal2.Scripts.Domain.Actions;
using MVP_Proposal2.Scripts.Presentation;
using MVP_Proposal2.Scripts.Providers;
using TMPro;
using UnityEngine;

namespace MVP_Proposal2.Scripts.Views
{
    public class ShopPopupViewModel : MojoViewModel, IShopPopupView
    {
        [SerializeField] private ShopBundleItemViewModel[] bundleItems;
        [SerializeField] private TextMeshProUGUI rollsText;

        private int _rolls;

        public int Rolls
        {
            get => _rolls;
            set
            {
                _rolls = value;
                RaisePropertyChange(rollsText, Rolls.ToString());
            }
        }

        private ShopPresenter presenter;

        public override void Start()
        {
            base.Start();

            var loadBundles = new LoadBundlesUseCase(DependencyProvider.ShopBundlesRepository);
            var purchaseBundle = new PurchaseBundleUseCase(DependencyProvider.ShopBundlesRepository,
                DependencyProvider.PlayerInventoryRepository);
            presenter = new ShopPresenter(this, loadBundles, purchaseBundle);
            Show();
        }

        public void Show() => presenter.Show();

        public void LoadBundles(List<ShopBundleItemViewData> bundles)
        {
            //Real Implementation:
            // Bundles = bundles;
            
            
            // Logica del Collection Binding
            for (int i = 0; i < bundles.Count; i++)
            {
                bundleItems[i].MojoSetData(
                    bundles[i]
                );
            }
        }

        public void UpdateRolls(int playerRolls)
        {
            Rolls = playerRolls;
        }
    }
}