using MVP_CleanArchitecture_Example.Scripts.InterfaceAdapters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace MVP_CleanArchitecture_Example.Scripts.View
{
    public class ShopBundleView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Image _itemImage;
        [SerializeField] private TextMeshProUGUI _itemAmountText;
        [SerializeField] private TextMeshProUGUI _costAmountText;
        [SerializeField] private Image _costCommodityImage;
        [SerializeField] private Button _purchaseButton;
        
        private BundleModel _model;

        private void Awake()
        {
            _purchaseButton.onClick.AddListener(TryPurchaseItem);
        }

        public void SetData(BundleModel model)
        {
            _model = model;
            _model.ViewData.Subscribe(UpdateView);
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
            _model.OnClick.Execute(_model.ViewData.Value.BundleId);
        }
    }
}