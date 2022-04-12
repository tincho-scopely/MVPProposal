using System.Collections.Generic;
using CleanArchitecture_Example.Scripts.Domain;
using CleanArchitecture_Example.Scripts.Domain.UseCases;
using NUnit.Framework;
using NSubstitute;

namespace CleanArchitecture_Example.Tests.Editor
{
    public class ShowShopUseCaseTest
    {
        [Test]
        public void GivenAreShopBundles_UseCaseIsCalled_PassBundlesToOutput()
        {
            var playerInventory = Substitute.For<IPlayerInventory>();
            var repository = Substitute.For<IShopBundlesRepository>();
            var shopBundles = new List<ShopBundleDto> { 
                new ShopBundleDto(0, string.Empty, Substitute.For<ICurrency>(), Substitute.For<ICommodity>(),
                    string.Empty)
            };
            repository.GetBundles().Returns(info => shopBundles);
            var output = Substitute.For<IShowShopUseCaseOutput>();
            var useCase = new ShowShopUseCase(playerInventory, repository, output);
            
            useCase.Show();
            
            output.Received(1).SetOutput(Arg.Any<int>(), shopBundles);
        }
        
        [Test]
        public void GivenUserHasBonusRolls_UseCaseIsCalled_PassBonusRollsToOutput()
        {
            const int playerBonusRolls = 99;
            var playerInventory = Substitute.For<IPlayerInventory>();
            playerInventory.GetCurrencyQuantity(CurrencyTypes.BonusRolls).Returns(playerBonusRolls);
            
            var repository = Substitute.For<IShopBundlesRepository>();
            var output = Substitute.For<IShowShopUseCaseOutput>();
            var useCase = new ShowShopUseCase(playerInventory, repository, output);
            
            useCase.Show();
            
            output.Received(1).SetOutput(playerBonusRolls, Arg.Any<List<ShopBundleDto>>());
        }
    }
}