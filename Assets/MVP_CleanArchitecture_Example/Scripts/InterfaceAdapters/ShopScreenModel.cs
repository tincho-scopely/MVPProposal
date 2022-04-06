using System.Collections.Generic;
using UniRx;

namespace MVP_CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class ShopScreenModel
    {
        public ReactiveCommand<List<BundleModel>> Show;
        public ReactiveProperty<string> PlayerBonusRolls;

        public ShopScreenModel()
        {
            Show = new ReactiveCommand<List<BundleModel>>();
            // TODO: load properly the initial amount of the user
            PlayerBonusRolls = new ReactiveProperty<string>("100");
        }
        
    }

    public class BundleModel
    {
        public ReactiveCommand<int> OnClick;
        public ReactiveProperty<ShopBundleViewData> ViewData;

        private BundleModel()
        {
            OnClick = new ReactiveCommand<int>();
            ViewData = new ReactiveProperty<ShopBundleViewData>();
        }

        public BundleModel(ShopBundleViewData viewData) : this()
        {
            ViewData.Value = viewData;
        }
    }
}