using System;
using CleanArchitecture_Example.Scripts.Domain;

namespace MVP_Proposal2.Scripts.Infrastructure.DTO
{
    [Serializable]
    public class CurrencyDTO
    {
        public string Key;
        public int Quantity;

        public CurrencyDTO(string key, int quantity)
        {
            Key = key;
            Quantity = quantity;
        }
        public ICurrency ToCurrency() => 
            new Currency(Key, Quantity);
    }
}