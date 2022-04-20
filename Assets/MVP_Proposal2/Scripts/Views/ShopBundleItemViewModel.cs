using System;
using MVP_Proposal2.Scripts.Presentation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP_Proposal2.Scripts.Views
{
    public class ShopBundleItemViewModel : MojoViewModel
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI itemAmountText;
        [SerializeField] private TextMeshProUGUI costAmountText;
        [SerializeField] private Image costCommodityImage;
        [SerializeField] private Button purchaseButton;

        private ShopBundleItemViewData _viewData;
        
        public void SetData(ShopBundleItemViewData viewData)
        {
            _viewData = viewData;
            UpdateView();
            
            //Hack for ClickBinding
            purchaseButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _viewData.OnPurchaseClick.Invoke(_viewData.BundleId);
        }
        private void UpdateView()
        {
            nameText.SetText(_viewData.Name);
            //itemImage.sprite = viewData.ItemImage; Load from source by key (resources for example)
            itemAmountText.SetText(_viewData.ItemAmount.ToString());
            costAmountText.SetText(_viewData.CostAmount.ToString());
            //costCommodityImage.sprite = viewData.CostCommodityImage; Load from source by key (resources for example)
        }
    }
}
