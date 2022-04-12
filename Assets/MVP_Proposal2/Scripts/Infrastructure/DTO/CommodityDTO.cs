using System;
using MVP_CleanArchitecture_Example.Scripts.Domain;

namespace MVP_Proposal2.Scripts.Infrastructure.DTO
{
    [Serializable]
    public class CommodityDTO
    {
        public string Key;
        public int Quantity;

        public CommodityDTO(string key, int quantity)
        {
            Key = key;
            Quantity = quantity;
        }
        public ICommodity ToCommodity() => 
            new Commodity(Key, Quantity);
    }
}