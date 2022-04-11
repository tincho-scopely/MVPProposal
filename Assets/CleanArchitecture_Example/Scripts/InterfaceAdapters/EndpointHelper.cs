using System;
using System.Threading.Tasks;
using CleanArchitecture_Example.Scripts.Domain;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public class EndpointHelper : IEndpointHelper
    {
        private readonly IShowLoadingScreenUseCase _showLoadingUseCase;

        public EndpointHelper(IShowLoadingScreenUseCase showLoadingUseCase)
        {
            _showLoadingUseCase = showLoadingUseCase;
        }
        
        public async Task PurchaseBundle(int bundleId, Action onSucceed, Action onFailed)
        {
            _showLoadingUseCase.Show();
            var delayTime = TimeSpan.FromSeconds(UnityEngine.Random.Range(.5f, 1.5f));
            await Task.Delay(delayTime);
            
            onSucceed?.Invoke();
            _showLoadingUseCase.Hide();
        }
    }
}