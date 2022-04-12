using System.Collections.Generic;

namespace CleanArchitecture_Example.Scripts.Domain.UseCases
{
    public interface IShowShopUseCaseOutput
    {
        void SetOutput(int playerBonusRolls, List<ShopBundleDto> shopItems);
    }
}