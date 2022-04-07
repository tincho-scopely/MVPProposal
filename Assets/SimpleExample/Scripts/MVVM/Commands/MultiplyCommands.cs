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
        [SerializeField] private InputsDatasource inputsDatasource;
        [SerializeField] private MultiplyDatasource multiplyDatasource;


        [UsedImplicitly]
        public void SimplyMultiply()
        {
            var result = new SimpleMultiply().Execute(inputsDatasource.GetFirstValue(), inputsDatasource.GetSecondValue());
            multiplyDatasource.Set(result); 
        }

        [UsedImplicitly]
        public void ComplexMultiply() => 
            new ComplexMultiply(new DefaultMultiplyRepository())
                .Execute(inputsDatasource.GetFirstValue(), inputsDatasource.GetSecondValue())
                .DoOnSubscribe(() => multiplyDatasource.Set(-1))
                .Do(multiplyDatasource.Set)
                .Subscribe();
            
    }
}
