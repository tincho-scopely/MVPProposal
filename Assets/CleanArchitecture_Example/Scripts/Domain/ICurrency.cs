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
        
        public Currency Remove(int amount)
        {
            return new Currency(Key, Quantity - amount);
        }
        
        #region EqualityMembers

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency) obj);
        }

        private bool Equals(ICurrency other)
        {
            return Key == other.Key && 
                   Quantity == other.Quantity;
        }

        #endregion
    }
}