using MVP_CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Tests.Mothers
{
    public static class PlayerInventoryMother
    {
        public static PlayerInventory APlayerInventory(Commodity[] withCommodities = null)
        {
            return new PlayerInventory(
                withCommodities ?? new Commodity[]{ }
            );
        }
    }
}