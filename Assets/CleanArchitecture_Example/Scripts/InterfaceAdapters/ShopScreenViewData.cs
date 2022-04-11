using System.Collections.Generic;
using UniRx;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class ShopScreenViewData
    {
        public ReactiveCommand<List<BundleViewData>> Show;
        public ReactiveProperty<string> PlayerBonusRolls;

        public ShopScreenViewData()
        {
            Show = new ReactiveCommand<List<BundleViewData>>();
            PlayerBonusRolls = new ReactiveProperty<string>();
        }
    }

    public class BundleViewData
    {
        public ReactiveCommand<int> OnClick;
        public ReactiveProperty<ShopBundleViewData> ViewData;

        private BundleViewData()
        {
            OnClick = new ReactiveCommand<int>();
            ViewData = new ReactiveProperty<ShopBundleViewData>();
        }

        public BundleViewData(ShopBundleViewData viewData) : this()
        {
            ViewData.Value = viewData;
        }
    }
}