using System.Collections.Generic;
using CleanArchitecture_Example.Scripts.Domain;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class PlayerInventory : IPlayerInventory
    {
        private List<ICurrency> _currencies;

        public PlayerInventory()
        {
            _currencies = new List<ICurrency>
            {
                new Currency(CurrencyTypes.BonusRolls,100)
            };
        }

        public int GetCurrencyQuantity(string currencyKey)
        {
            return GetCurrency(currencyKey).Quantity;
        }

        public ICurrency GetCurrency(string currencyKey)
        {
            return _currencies.Find(currency => currency.Key == currencyKey);
        }

        public void AddCurrency(string currencyKey, int quantity)
        {
            var currency = GetCurrency(currencyKey);
            currency.Quantity += quantity;
        }
    }
}