using CleanArchitecture_Example.Scripts.Domain;
using CleanArchitecture_Example.Scripts.InterfaceAdapters;
using CleanArchitecture_Example.Scripts.View;
using CleanArchitecture_Example.Scripts.View.ImagesRepositories;
using UnityEngine;

namespace CleanArchitecture_Example.Scripts
{
    public class ProposalInstaller : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private ShopScreenView _shopScreenView;
        [SerializeField] private CommoditiesImagesRepository _commoditiesImagesRepository;
        [SerializeField] private CurrenciesImagesRepository _currenciesImagesRepository;
        
        private ShopBundlesRepository _bundlesRepository;
        private IShowShopUseCaseOutput _shopScreenPresenter;
        private IPlayerInventory _playerInventory;

        private void Awake()
        {
            LoadRepository();
        }

        private void Start()
        {
            InstallPlayerInventory();
            InstallScreen();
            ShowScreen();
        }

        private void LoadRepository()
        {
            // This load can be come through server, a json, whatever we need.
            
            _bundlesRepository = new ShopBundlesRepository();
            for (var i = 0; i < 9; i++)
            {
                var bundle = new ShopBundleDto(
                    i,
                    $"Bundle {i}",
                    new Currency(CurrencyTypes.BonusRolls, GetRandomQuantity(5, 21)),
                    new Commodity(CommodityTypes.Gift, GetRandomQuantity(1, 3)),
                    "shop"
                );
                
                _bundlesRepository.AddBundle(bundle);
            }

            int GetRandomQuantity(int min, int max)
            {
                return Random.Range(min, max);
            }
        }

        private void InstallPlayerInventory()
        {
            _playerInventory = new PlayerInventory();
        }

        private void InstallScreen()
        {
            var model = new ShopScreenViewData();

            var purchaseBundleUseCase = new PurchaseBundleUseCase(_bundlesRepository, new EndpointHelper(), _playerInventory);
            _shopScreenPresenter = new ShopScreenPresenter(
                model, 
                purchaseBundleUseCase,
                _commoditiesImagesRepository,
                _currenciesImagesRepository
            );

            _shopScreenView.InjectDependencies(model);
        }

        private void ShowScreen()
        {
            var useCase = new ShowShopUseCase(_bundlesRepository, _shopScreenPresenter);
            useCase.Show();
        }
    }
}