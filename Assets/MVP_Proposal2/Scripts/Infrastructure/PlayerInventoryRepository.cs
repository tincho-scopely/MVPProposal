using CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Model;
using MVP_Proposal2.Scripts.Domain.Repositories;

namespace MVP_Proposal2.Scripts.Infrastructure
{
    public class PlayerInventoryRepository : IPlayerInventoryRepository
    {
        private PlayerInventory _playerInventory;

        public PlayerInventoryRepository()
        {
            _playerInventory = new PlayerInventory(new[]
            {
                new Currency(CurrencyTypes.BonusRolls, 100)
            });
        }
        
        public PlayerInventory Get() => _playerInventory;

        public void Save(PlayerInventory playerInventory) => _playerInventory = playerInventory;
    }
}