using System.Linq;
using CleanArchitecture_Example.Scripts.Domain;

namespace MVP_Proposal2.Scripts.Domain.Model
{
    public class PlayerInventory
    {
        private readonly Currency[] _currencies;

        public PlayerInventory(Currency[] currencies)
        {
            _currencies = currencies;
        }

        public PlayerInventory RemoveRolls(int amount)
        {
            return new PlayerInventory(DiscountBonusRolls(amount));
        }

        public int GetCommodityAmount(string key) => 
            _currencies.First(commodity => commodity.Key == key).Quantity;

        private Currency[] DiscountBonusRolls(int amount)
        {
            return _currencies.Select(commodity =>
                    commodity.Key == CurrencyTypes.BonusRolls 
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
            return _currencies.SequenceEqual(other._currencies);
        }

        #endregion
    }
}