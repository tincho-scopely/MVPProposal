namespace CleanArchitecture_Example.Scripts.Domain
{
    public class ShowShopUseCase : IShowShopUseCase
    {
        private readonly IShopBundlesRepository _shopBundlesRepository;
        private readonly IShowShopUseCaseOutput _output;

        public ShowShopUseCase(
            IShopBundlesRepository shopBundlesRepository,
            IShowShopUseCaseOutput output)
        {
            _shopBundlesRepository = shopBundlesRepository;
            _output = output;
        }
        
        public void Show()
        {
            var items = _shopBundlesRepository.GetBundles();
            _output.Show(items);
        }
    }
}