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

        public Commodity Remove(int amount)
        {
            return new Commodity(Key, Quantity - amount);
        }
        
        #region EqualityMembers

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Commodity) obj);
        }

        private bool Equals(ICommodity other)
        {
            return Key == other.Key && 
                   Quantity == other.Quantity;
        }

        #endregion

        
    }
}