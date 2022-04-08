namespace CleanArchitecture_Example.Scripts.Domain
{
    public interface ICurrency
    {
        string Key { get; }
        int Quantity { get; set; }
    }

    public class Currency : ICurrency
    {
        public string Key { get; set; }
        public int Quantity { get; set; }
        
        public Currency(string key, int quantity)
        {
            Key = key;
            Quantity = quantity;
        }
    }
}