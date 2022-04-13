using CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Actions;
using MVP_Proposal2.Scripts.Domain.Model;
using MVP_Proposal2.Scripts.Domain.Repositories;
using NSubstitute;
using NUnit.Framework;
using UniRx;
using static MVP_Proposal2.Scripts.Tests.Mothers.PlayerInventoryMother;
using static MVP_Proposal2.Scripts.Tests.Mothers.ShopBundleItemMother;
using IShopBundlesRepository = MVP_Proposal2.Scripts.Domain.Repositories.IShopBundlesRepository;

namespace MVP_Proposal2.Scripts.Tests.Editor
{
    [TestFixture]
    public class PurchaseBundleShould 
    {
        private const int BUNDLE_ID = 1;
        
        private IShopBundlesRepository shopBundlesRepository;
        private IPlayerInventoryRepository playerInventoryRepository;
        private PurchaseBundle action;
        private PurchaseBundleResult result;


        [SetUp]
        public void Setup()
        {
            playerInventoryRepository = Substitute.For<IPlayerInventoryRepository>();
            shopBundlesRepository = Substitute.For<IShopBundlesRepository>();
            action = new PurchaseBundle(shopBundlesRepository, playerInventoryRepository);
        }
        
        [Test]
        public void Purchase_A_Bundle()
        {
            WhenExecuting();
            ThenBundleIsPurchased();
        }

        [Test]
        public void Remove_Cost_From_Player_Coins()
        {
            var expectedResult = new PurchaseBundleResult(10);
            GivenAShopBundleWith(ABundle(withCost: new Currency(CurrencyTypes.BonusRolls, 10)));
            GivenASuccessfulPurchase();
            GivenAPlayerWithInventory(APlayerInventory(withCurrencies:new [] { new Currency(CurrencyTypes.BonusRolls, 20)}));
            WhenExecuting();
            ThenPlayerInventoryIsUpdatedWith(APlayerInventory(withCurrencies: new [] { new Currency(CurrencyTypes.BonusRolls, 10)}));
            ThenExpectedResultIs(expectedResult.PlayerRollsAmount);
        }

        private void GivenAPlayerWithInventory(PlayerInventory aPlayerInventory)
        {
            playerInventoryRepository.Get().Returns(aPlayerInventory);
        }

        private void GivenASuccessfulPurchase()
        {
            shopBundlesRepository.Purchase(Arg.Any<int>()).Returns(Observable.ReturnUnit());
        }

        private void GivenAShopBundleWith(ShopBundleItem shopBundleItem)
        {
            shopBundlesRepository.GetById(Arg.Any<int>()).Returns(shopBundleItem);
        }

        private void WhenExecuting()
        {
            action.Execute(BUNDLE_ID).Do(bundleResult => result = bundleResult).Subscribe();
        }

        private void ThenExpectedResultIs(int expectedResultPlayerCoinsAmount)
        {
            Assert.AreEqual(expectedResultPlayerCoinsAmount, result.PlayerRollsAmount);
        }

        private void ThenPlayerInventoryIsUpdatedWith(PlayerInventory aPlayerInventory)
        {
            playerInventoryRepository.Received(1).Save(aPlayerInventory);
        }

        private void ThenBundleIsPurchased()
        {
            shopBundlesRepository.Received(1).Purchase(BUNDLE_ID);
        }
    }
}
