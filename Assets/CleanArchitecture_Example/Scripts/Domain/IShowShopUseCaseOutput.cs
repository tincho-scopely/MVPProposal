using System.Collections.Generic;

namespace CleanArchitecture_Example.Scripts.Domain
{
    public interface IShowShopUseCaseOutput
    {
        void SetOutput(int playerBonusRolls, List<ShopBundleDto> shopItems);
    }
}