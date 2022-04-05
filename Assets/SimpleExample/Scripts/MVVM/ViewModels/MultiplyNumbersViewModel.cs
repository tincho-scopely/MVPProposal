using MVVMFramework;
using SimpleExample.Scripts.MVVM.DataSources;
using SimpleExample.Scripts.MVVM.Infrastructure;
using UniRx;
using UnityEngine;

namespace SimpleExample.Scripts.MVVM.ViewModels
{
    [CreateAssetMenu(fileName = "MultiplyNumbersViewModel", menuName = "SimpleExample/ViewModels/MultiplyNumbers")]
    public class MultiplyNumbersViewModel : ViewModel
    {
        [SerializeField] private MultiplyDatasource multiplyDatasource;

        
        public IntReactiveProperty Result = new IntReactiveProperty(0);
        public BoolReactiveProperty IsLoading = new BoolReactiveProperty(false);
        
        public MultiplyNumbersViewModel() : base(new ReactivePropertyResolverRepository())
        {
        }

        private void OnEnable()
        {
            if (multiplyDatasource == null) return;
            
            multiplyDatasource.Current
                .SkipLatestValueOnSubscribe()
                .Do(UpdateResult)
                .Subscribe();
        }

        public void ShowLoading() => IsLoading.Value = true;

        private void UpdateResult(int result)
        {
            IsLoading.Value = false;
            Result.Value = result;
        }
    }
}
