using JetBrains.Annotations;
using SimpleExample.Scripts.Domain.Actions;
using SimpleExample.Scripts.Infrastructure.Repositories;
using SimpleExample.Scripts.MVVM.DataSources;
using SimpleExample.Scripts.MVVM.ViewModels;
using UniRx;
using UnityEngine;

namespace SimpleExample.Scripts.MVVM.Commands
{
    [CreateAssetMenu(fileName = "MultiplyCommands", menuName = "SimpleExample/Commands/Multiply")]
    public class MultiplyCommands : ScriptableObject
    {
        [SerializeField] private MultiplyNumbersViewModel multiplyNumbersViewModel;
        [SerializeField] private MultiplyDatasource multiplyDatasource;


        [UsedImplicitly]
        public void SimplyMultiply()
        {
            var result = new SimpleMultiply().Execute(4, 5);
            multiplyDatasource.Set(result); 
        }

        [UsedImplicitly]
        public void ComplexMultiply() => 
            new ComplexMultiply(new DefaultMultiplyRepository())
                .Execute(4, 5)
                .DoOnSubscribe(() => multiplyNumbersViewModel.ShowLoading())
                .Do(multiplyDatasource.Set);
            
    }
}
