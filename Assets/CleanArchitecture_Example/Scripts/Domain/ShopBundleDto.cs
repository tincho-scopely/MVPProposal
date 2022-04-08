namespace CleanArchitecture_Example.Scripts.Domain
{
    public class ShopBundleDto
    {
        public readonly int Id;
        public readonly string Name;
        public readonly ICurrency Cost;
        public readonly ICommodity Item;
        
        // Example of a field that the View won't print
        public readonly string Segment;

        public ShopBundleDto(
            int id,
            string name,
            ICurrency cost, 
            ICommodity item, 
            string segment)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Item = item;
            Segment = segment;
        }
    }
}