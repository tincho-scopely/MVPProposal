using System.Collections.Generic;
using MVP_CleanArchitecture_Example.Scripts.InterfaceAdapters;
using TMPro;
using UnityEngine;
using UniRx;

namespace MVP_CleanArchitecture_Example.Scripts.View
{
    public class ShopScreenView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private ShopBundleView[] _bundleViews;

        [SerializeField] private TextMeshProUGUI _playerBonusRolls;
        
        private ShopScreenModel _model;

        public void InjectDependencies(ShopScreenModel model)
        {
            _model = model;
            _model.Show.Subscribe(ShowScreen);
            _model.PlayerBonusRolls.Subscribe(UpdatePlayerInventory);
            
            // TODO: set initial Player bonus rolls from inventory
        }

        private void UpdatePlayerInventory(string quantity)
        {
            _playerBonusRolls.SetText(quantity);
        }

        private void ShowScreen(List<BundleModel> bundleModels)
        {
            FillBundles(bundleModels);
            _canvas.enabled = true;
        }

        private void FillBundles(IReadOnlyList<BundleModel> bundleModels)
        {
            for (var i = 0; i < _bundleViews.Length; i++)
            {
                var bundleView = _bundleViews[i];
                bundleView.SetData(bundleModels[i]);
            }
        }
    }
}