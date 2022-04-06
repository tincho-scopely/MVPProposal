using MVP_CleanArchitecture_Example.Scripts.Domain;
using MVP_CleanArchitecture_Example.Scripts.InterfaceAdapters;
using MVP_CleanArchitecture_Example.Scripts.View;
using UnityEngine;

namespace MVP_CleanArchitecture_Example.Scripts
{
    public class ProposalInstaller : MonoBehaviour
    {
        [SerializeField] private ShopScreenView _shopScreenView;
        
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
                    new Commodity(CommodityDefinitions.BonusRolls, GetRandomQuantity(5, 21)),
                    new Commodity(string.Empty, GetRandomQuantity(1, 3)),
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
            var model = new ShopScreenModel();

            var purchaseBundleUseCase = new PurchaseBundleUseCase(_bundlesRepository, new EndpointHelper(), _playerInventory);
            _shopScreenPresenter = new ShopScreenPresenter(model, purchaseBundleUseCase);

            _shopScreenView.InjectDependencies(model);
        }

        private void ShowScreen()
        {
            var useCase = new ShowShopUseCase(_bundlesRepository, _shopScreenPresenter);
            useCase.Show();
        }
    }
}