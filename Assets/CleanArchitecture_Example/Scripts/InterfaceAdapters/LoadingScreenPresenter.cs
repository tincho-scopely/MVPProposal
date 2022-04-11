using CleanArchitecture_Example.Scripts.Domain;
using CleanArchitecture_Example.Scripts.Domain.UseCases;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class LoadingScreenPresenter : IShowLoadingUseCaseOutput
    {
        private readonly LoadingScreenViewData _viewData;

        public LoadingScreenPresenter(LoadingScreenViewData viewData)
        {
            _viewData = viewData;
        }
        
        public void SetOutput(bool isVisible)
        {
            if (isVisible)
            {
                _viewData.Show.Execute();
                return;
            }
            
            _viewData.Hide.Execute();
        }
    }
}