using System;
using SimpleExample.Scripts.Domain.Repositories;
using UniRx;

namespace SimpleExample.Scripts.Infrastructure.Repositories
{
    public class DefaultMultiplyRepository : IMultiplyRepository
    {
        public IObservable<int> Get(int firstNumber, int secondNumber) =>
            Observable.ReturnUnit()
                .Delay(TimeSpan.FromSeconds(3))
                .Select(_ => firstNumber * secondNumber);
    }
}