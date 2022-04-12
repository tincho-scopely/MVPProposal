using System.Collections.Generic;

namespace CleanArchitecture_Example.Scripts.Domain
{
    public interface IShopBundlesRepository
    {
        void AddBundle(ShopBundleDto bundleDto);
        List<ShopBundleDto> GetBundles();
        ShopBundleDto GetBundleById(int id);
    }
}