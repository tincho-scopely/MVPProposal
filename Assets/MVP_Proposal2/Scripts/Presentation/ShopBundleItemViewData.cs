using System;
using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Presentation
{
    public class ShopBundleItemViewData
    {
        public readonly int BundleId;
        public readonly string Name;
        public readonly int ItemAmount;
        public readonly string ItemImage;
        public readonly int CostAmount;
        public readonly string CostCommodityImage;
        public Action<int> OnPurchase;

        public ShopBundleItemViewData(int bundleId, string name, int itemAmount, string itemImage, 
            int costAmount, string costCommodityImage, Action<int> onPurchase)
        {
            BundleId = bundleId;
            Name = name;
            ItemAmount = itemAmount;
            ItemImage = itemImage;
            CostAmount = costAmount;
            CostCommodityImage = costCommodityImage;
            OnPurchase = onPurchase;
        }

        public static ShopBundleItemViewData From(ShopBundleItem shopBundleItem, Action<int> onPurchase) =>
            new ShopBundleItemViewData(
                shopBundleItem.Id,
                shopBundleItem.Name,
                shopBundleItem.Cost.Quantity,
                shopBundleItem.Item.Key,
                shopBundleItem.Cost.Quantity,
                shopBundleItem.Cost.Key,
                onPurchase
            );
    }
}