using System.Collections.Generic;
using CleanArchitecture_Example.Scripts.InterfaceAdapters;
using TMPro;
using UniRx;
using UnityEngine;

namespace CleanArchitecture_Example.Scripts.View
{
    public class ShopScreenView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private ShopBundleView[] _bundleViews;

        [SerializeField] private TextMeshProUGUI _playerBonusRolls;
        
        private ShopScreenViewData _viewData;

        public void InjectDependencies(ShopScreenViewData viewData)
        {
            _viewData = viewData;
            _viewData.Show.Subscribe(ShowScreen);
            _viewData.PlayerBonusRolls.Subscribe(UpdatePlayerInventory);
            
            // TODO: set initial Player bonus rolls from inventory
        }

        private void UpdatePlayerInventory(string quantity)
        {
            _playerBonusRolls.SetText(quantity);
        }

        private void ShowScreen(List<BundleViewData> bundleModels)
        {
            FillBundles(bundleModels);
            _canvas.enabled = true;
        }

        private void FillBundles(IReadOnlyList<BundleViewData> bundleModels)
        {
            for (var i = 0; i < _bundleViews.Length; i++)
            {
                var bundleView = _bundleViews[i];
                bundleView.SetData(bundleModels[i]);
            }
        }
    }
}