namespace MVP_CleanArchitecture_Example.Scripts.Domain
{
    public interface ICommodity
    {
        string Key { get; set; }
        int Quantity { get; set; }
    }

    public class Commodity : ICommodity
    {
        public string Key { get; set; }
        public int Quantity { get; set; }
        
        public Commodity(string key, int quantity)
        {
            Key = key;
            Quantity = quantity;
        }
    }
}