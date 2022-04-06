using System.Collections.Generic;

namespace MVP_CleanArchitecture_Example.Scripts.Domain
{
    public class ShopBundlesRepository : IShopBundlesRepository
    {
        private List<ShopBundleDto> _bundles;

        public ShopBundlesRepository()
        {
            _bundles = new List<ShopBundleDto>();
        }
        
        public void AddBundle(ShopBundleDto bundleDto)
        {
            _bundles.Add(bundleDto);
        }

        public List<ShopBundleDto> GetBundles()
        {
            return _bundles;
        }

        public ShopBundleDto GetBundleById(int id)
        {
            return _bundles.Find(bundle => bundle.Id == id);
        }
    }
}