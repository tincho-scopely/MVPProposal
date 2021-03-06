using CleanArchitecture_Example.Scripts.Domain;
using CleanArchitecture_Example.Scripts.Domain.UseCases;
using CleanArchitecture_Example.Scripts.InterfaceAdapters;
using CleanArchitecture_Example.Scripts.InterfaceAdapters.Services;
using CleanArchitecture_Example.Scripts.Presentation;
using CleanArchitecture_Example.Scripts.Presentation.ImagesRepositories;
using UnityEngine;

namespace CleanArchitecture_Example.Scripts
{
    public class ProposalInstaller : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] private ShopScreenView _shopScreenView;
        [SerializeField] private LoadingScreenView _loadingScreenView;
        
        [Header("Dependencies")]
        [SerializeField] private CommoditiesImagesRepository _commoditiesImagesRepository;
        [SerializeField] private CurrenciesImagesRepository _currenciesImagesRepository;
        
        private IShopBundlesRepository _bundlesRepository;
        private IPlayerInventory _playerInventory;
        private IShowShopUseCaseOutput _showShopScreenOutput;
        private IShowLoadingUseCaseOutput _showLoadingUseCaseOutput;
        private IEndpointHelper _endpointHelper;

        private void Awake()
        {
            LoadRepository();
            
            InstallLoadingScreen();
            InstallEndpointHelper();
            InstallPlayerInventory();
            InstallShopScreen();
        }

        private void Start()
        {
            ShowShopScreen();
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
        
        private void InstallLoadingScreen()
        {
            var viewData = new LoadingScreenViewData();
            _showLoadingUseCaseOutput = new LoadingScreenPresenter(viewData);
            _loadingScreenView.SetData(viewData);
        }
        
        private void InstallEndpointHelper()
        {
            _endpointHelper = new EndpointHelper(new ShowLoadingScreenUseCase(_showLoadingUseCaseOutput));
        }

        private void InstallPlayerInventory()
        {
            _playerInventory = new PlayerInventory();
        }

        private void InstallShopScreen()
        {
            var model = new ShopScreenViewData();

            var purchaseBundleUseCase = new PurchaseBundleUseCase(_bundlesRepository, _endpointHelper, _playerInventory);
            _showShopScreenOutput = new ShopScreenPresenter(
                model, 
                purchaseBundleUseCase,
                _commoditiesImagesRepository,
                _currenciesImagesRepository
            );

            _shopScreenView.InjectDependencies(model);
        }

        private void ShowShopScreen()
        {
            var useCase = new ShowShopUseCase(_playerInventory, _bundlesRepository, _showShopScreenOutput);
            useCase.Show();
        }
    }
}