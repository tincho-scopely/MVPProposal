using System.Collections.Generic;

namespace CleanArchitecture_Example.Scripts.Domain
{
    public interface IShowShopUseCaseOutput
    {
        void SetOutput(List<ShopBundleDto> shopItems);
    }
}