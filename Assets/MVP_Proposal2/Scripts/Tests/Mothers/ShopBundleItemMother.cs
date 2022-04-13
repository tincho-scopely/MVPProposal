using CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Tests.Mothers
{
    public static class ShopBundleItemMother
    {
        public static ShopBundleItem ABundle(
            int? withId = null,
            string withName = null,
            ICurrency withCost = null,
            ICommodity withItem = null)
        {
            return new ShopBundleItem(
                withId ?? 0,
                withName ?? "",
                withCost ?? new Currency("", 0),
                withItem ?? new Commodity("", 0));
        }
    }
}