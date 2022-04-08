namespace CleanArchitecture_Example.Scripts.Domain
{
    public interface IPlayerInventory
    {
        int GetCurrencyQuantity(string currencyKey);
        ICurrency GetCurrency(string currencyKey);
        void AddCurrency(string currencyKey, int quantity);
    }
}