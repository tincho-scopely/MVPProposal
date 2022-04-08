using System.Collections.Generic;
using CleanArchitecture_Example.Scripts.Domain;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class PlayerInventory : IPlayerInventory
    {
        private List<ICommodity> _commodities;

        public PlayerInventory()
        {
            _commodities = new List<ICommodity>
            {
                new Commodity(CommodityDefinitions.BonusRolls,100)
            };
        }

        public int GetCommodityQuantity(string commodityKey)
        {
            return GetCommodity(commodityKey).Quantity;
        }

        public ICommodity GetCommodity(string commodityKey)
        {
            return _commodities.Find(commodity => commodity.Key == commodityKey);
        }

        public void AddCommodity(string commodityKey, int quantity)
        {
            var commodity = GetCommodity(commodityKey);
            commodity.Quantity += quantity;
        }
    }
}