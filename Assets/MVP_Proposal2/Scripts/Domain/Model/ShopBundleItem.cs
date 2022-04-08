using MVP_CleanArchitecture_Example.Scripts.Domain;

namespace MVP_Proposal2.Scripts.Domain.Model
{
    public class ShopBundleItem
    {
        public readonly int Id;
        public readonly string Name;
        public readonly ICommodity Cost;
        public readonly ICommodity Item;

        public ShopBundleItem(int id, string name, ICommodity cost, ICommodity item)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Item = item;
        }

        #region EqualityMembers
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShopBundleItem) obj);
        }

        private bool Equals(ShopBundleItem other)
        {
            return Id == other.Id && 
                   Name == other.Name && 
                   Equals(Cost, other.Cost) && 
                   Equals(Item, other.Item);
        }
        
        #endregion

        
    }
}