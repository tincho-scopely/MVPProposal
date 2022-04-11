using UniRx;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class LoadingScreenViewData
    {
        public ReactiveCommand Show;
        public ReactiveCommand Hide;

        public LoadingScreenViewData()
        {
            Show = new ReactiveCommand();
            Hide = new ReactiveCommand();
        }
    }
}