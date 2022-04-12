using System.Linq;
using MVP_CleanArchitecture_Example.Scripts.Domain;

namespace MVP_Proposal2.Scripts.Domain.Model
{
    public class PlayerInventory
    {
        private readonly Commodity[] _commodities;

        public PlayerInventory(Commodity[] commodities)
        {
            _commodities = commodities;
        }

        public PlayerInventory RemoveRolls(int amount)
        {
            return new PlayerInventory(DiscountBonusRolls(amount));
        }

        public int GetCommodityAmount(string key) => 
            _commodities.First(commodity => commodity.Key == key).Quantity;

        private Commodity[] DiscountBonusRolls(int amount)
        {
            return _commodities.Select(commodity =>
                    commodity.Key == CommodityDefinitions.BonusRolls 
                        ? commodity.Remove(amount) 
                        : commodity)
                .ToArray();
        }

        #region EqualityMembers

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlayerInventory) obj);
        }

        private bool Equals(PlayerInventory other)
        {
            return _commodities.SequenceEqual(other._commodities);
        }

        #endregion
    }
}