using CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Tests.Mothers
{
    public static class PlayerInventoryMother
    {
        public static PlayerInventory APlayerInventory(Currency[] withCurrencies = null)
        {
            return new PlayerInventory(
                withCurrencies ?? new Currency[]{ }
            );
        }
    }
}