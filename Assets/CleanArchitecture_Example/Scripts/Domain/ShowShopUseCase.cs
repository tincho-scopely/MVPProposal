namespace CleanArchitecture_Example.Scripts.Domain
{
    public class ShowShopUseCase : IShowShopUseCase
    {
        private readonly IPlayerInventory _playerInventory;
        private readonly IShopBundlesRepository _shopBundlesRepository;
        private readonly IShowShopUseCaseOutput _output;

        public ShowShopUseCase(
            IPlayerInventory playerInventory,
            IShopBundlesRepository shopBundlesRepository,
            IShowShopUseCaseOutput output)
        {
            _playerInventory = playerInventory;
            _shopBundlesRepository = shopBundlesRepository;
            _output = output;
        }
        
        public void Show()
        {
            var items = _shopBundlesRepository.GetBundles();
            _output.SetOutput(_playerInventory.GetCurrencyQuantity(CurrencyTypes.BonusRolls), items);
        }
    }
}