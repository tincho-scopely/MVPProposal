using System.Collections.Generic;

namespace MVP_Proposal2.Scripts.Presentation
{
    public interface IShopPopupView
    {
        void LoadBundles(List<ShopBundleItemViewData> bundles);
        void UpdateRolls(int playerRolls);
    }
}