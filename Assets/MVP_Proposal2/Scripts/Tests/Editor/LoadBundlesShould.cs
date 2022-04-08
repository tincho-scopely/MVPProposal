using System.Collections.Generic;
using MVP_Proposal2.Scripts.Domain.Actions;
using MVP_Proposal2.Scripts.Domain.Model;
using NSubstitute;
using NUnit.Framework;
using UniRx;
using static MVP_Proposal2.Scripts.Tests.Mothers.ShopBundleItemMother;
using IShopBundlesRepository = MVP_Proposal2.Scripts.Domain.Repositories.IShopBundlesRepository;

namespace MVP_Proposal2.Scripts.Tests.Editor
{
    [TestFixture]
    public class LoadBundlesShould 
    {
        private IShopBundlesRepository shopBundlesRepository;
        private LoadBundles action;
        private List<ShopBundleItem> result;

        private static List<ShopBundleItem> SomeBundles()
        {
            return new List<ShopBundleItem>()
            {
                ABundle(),
                ABundle(),
            };
        }

        [SetUp]
        public void Setup()
        {
            shopBundlesRepository = Substitute.For<IShopBundlesRepository>();
            action = new LoadBundles(shopBundlesRepository);
        }

        [Test]
        public void Return_Bundles()
        {
            GivenAListOfBundlesWith(SomeBundles());
            WhenExecuting();
            ThenBundlesAre(SomeBundles());
        }

        private void GivenAListOfBundlesWith(List<ShopBundleItem> shopBundleItems)
        {
            shopBundlesRepository.Get().Returns(Observable.Return(shopBundleItems));
        }

        private void WhenExecuting()
        {
            action.Execute().Subscribe(bundles => result = bundles);
        }

        private void ThenBundlesAre(List<ShopBundleItem> shopBundleItems)
        {
            Assert.AreEqual(shopBundleItems, result);
        }
    }
}
