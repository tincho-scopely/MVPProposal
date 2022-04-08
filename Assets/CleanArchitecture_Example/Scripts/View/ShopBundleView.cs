using CleanArchitecture_Example.Scripts.InterfaceAdapters;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CleanArchitecture_Example.Scripts.View
{
    public class ShopBundleView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Image _itemImage;
        [SerializeField] private TextMeshProUGUI _itemAmountText;
        [SerializeField] private TextMeshProUGUI _costAmountText;
        [SerializeField] private Image _costCommodityImage;
        [SerializeField] private Button _purchaseButton;
        
        private BundleViewData _viewData;

        private void Awake()
        {
            _purchaseButton.onClick.AddListener(TryPurchaseItem);
        }

        public void SetData(BundleViewData viewData)
        {
            _viewData = viewData;
            _viewData.ViewData.Subscribe(UpdateView);
        }

        private void UpdateView(ShopBundleViewData viewData)
        {
            _nameText.SetText(viewData.Name);
            
            _itemImage.sprite = viewData.ItemImage;
            _itemAmountText.SetText(viewData.ItemAmount);
            
            _costAmountText.SetText(viewData.CostAmount);
            _costCommodityImage.sprite = viewData.CostCommodityImage;
        }

        private void TryPurchaseItem()
        {
            _viewData.OnClick.Execute(_viewData.ViewData.Value.BundleId);
        }
    }
}