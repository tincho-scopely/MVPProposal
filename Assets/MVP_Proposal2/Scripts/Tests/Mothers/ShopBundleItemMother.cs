using MVP_CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Tests.Mothers
{
    public static class ShopBundleItemMother
    {
        public static ShopBundleItem ABundle(
            int? withId = null,
            string withName = null,
            ICommodity withCost = null,
            ICommodity withItem = null)
        {
            return new ShopBundleItem(
                withId ?? 0,
                withName ?? "",
                withCost ?? new Commodity("", 0),
                withItem ?? new Commodity("", 0));
        }
    }
}