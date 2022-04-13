using System;
using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Infrastructure.DTO
{
    [Serializable]
    public class ShopBundleItemDTO
    {
        public int Id;
        public string Name;
        public CurrencyDTO Cost;
        public CommodityDTO Item;

        public ShopBundleItemDTO(int id, string name, CurrencyDTO cost, CommodityDTO item)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Item = item;
        }

        public ShopBundleItem ToBundleItem() =>
            new ShopBundleItem(
                Id,
                Name,
                Cost.ToCurrency(),
                Item.ToCommodity()
            );
    }
}