using System;
using MVP_Proposal2.Scripts.Presentation;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVP_Proposal2.Scripts.Views
{
    public class ShopBundleItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI itemAmountText;
        [SerializeField] private TextMeshProUGUI costAmountText;
        [SerializeField] private Image costCommodityImage;
        [SerializeField] private Button purchaseButton;

        public void Init(ShopBundleItemViewData viewData, Action<int> onPurchaseClick)
        {
            SetView(viewData);
            purchaseButton.onClick.AddListener(() => onPurchaseClick(viewData.BundleId));
        }
        private void SetView(ShopBundleItemViewData viewData)
        {
            nameText.SetText(viewData.Name);
            //itemImage.sprite = viewData.ItemImage; Load from source by key (resources for example)
            itemAmountText.SetText(viewData.ItemAmount.ToString());
            costAmountText.SetText(viewData.CostAmount.ToString());
            //costCommodityImage.sprite = viewData.CostCommodityImage; Load from source by key (resources for example)
        }
    }
}
