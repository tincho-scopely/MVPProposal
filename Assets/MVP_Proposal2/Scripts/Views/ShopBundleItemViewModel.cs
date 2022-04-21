using System;
using MVP_Proposal2.Scripts.Presentation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP_Proposal2.Scripts.Views
{
    public class ShopBundleItemViewModel : MojoViewModel
    {
        #region ReplaceForMojoBindings

        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI itemAmountText;
        [SerializeField] private TextMeshProUGUI costAmountText;
        [SerializeField] private Image costCommodityImage;
        [SerializeField] private Button purchaseButton;

        #endregion

        #region Properties

        private string _bundleName;

        public string BundleName
        {
            get => _bundleName;
            set
            {
                _bundleName = value;
                RaisePropertyChange(nameText, BundleName);
            }
        }
        
        private int _itemAmount;

        public int ItemAmount
        {
            get => _itemAmount;
            set
            {
                _itemAmount = value;
                RaisePropertyChange(itemAmountText, ItemAmount.ToString());
            }
        }
        
        private int _costAmount;

        public int CostAmount
        {
            get => _costAmount;
            set
            {
                _costAmount = value;
                RaisePropertyChange(costAmountText, CostAmount.ToString());
            }
        }

        #endregion
        

        private ShopBundleItemViewData _viewData;
        
        public void MojoSetData(ShopBundleItemViewData viewData)
        {
            _viewData = viewData;
            UpdateView();
            
            //Hack for ClickBinding
            purchaseButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _viewData.OnPurchase.Invoke(_viewData.BundleId);
        }
        private void UpdateView()
        {
            BundleName = _viewData.Name;
            ItemAmount = _viewData.ItemAmount;
            CostAmount = _viewData.CostAmount;
            //itemImage.sprite = viewData.ItemImage; Load from source by key (resources for example)
            //costCommodityImage.sprite = viewData.CostCommodityImage; Load from source by key (resources for example)
        }
    }
}
