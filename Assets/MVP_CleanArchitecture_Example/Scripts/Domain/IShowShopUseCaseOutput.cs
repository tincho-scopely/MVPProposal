using System.Collections.Generic;

namespace MVP_CleanArchitecture_Example.Scripts.Domain
{
    public interface IShowShopUseCaseOutput
    {
        void Show(List<ShopBundleDto> shopItems);
    }
}