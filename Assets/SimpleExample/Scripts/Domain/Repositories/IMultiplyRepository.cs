using System;

namespace SimpleExample.Scripts.Domain.Repositories
{
    public interface IMultiplyRepository
    {
        IObservable<int> Get(int firstNumber, int secondNumber);
    }
}