namespace CleanArchitecture_Example.Scripts.Domain
{
    public interface IPlayerInventory
    {
        int GetCommodityQuantity(string commodityKey);
        ICommodity GetCommodity(string commodityKey);
        void AddCommodity(string commodityKey, int quantity);
    }
}