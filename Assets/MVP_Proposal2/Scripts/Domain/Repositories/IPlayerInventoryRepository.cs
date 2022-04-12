using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Domain.Repositories
{
    public interface IPlayerInventoryRepository
    {
        PlayerInventory Get();
        void Save(PlayerInventory playerInventory);
    }
}