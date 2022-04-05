using System;
using SimpleExample.Scripts.Domain.Repositories;

namespace SimpleExample.Scripts.Domain.Actions
{
    public class ComplexMultiply
    {
        private readonly IMultiplyRepository _multiplyRepository;

        public ComplexMultiply(IMultiplyRepository multiplyRepository)
        {
            _multiplyRepository = multiplyRepository;
        }

        public IObservable<int> Execute(int firstNumber, int secondNumber) =>
            _multiplyRepository.Get(firstNumber, secondNumber);
    }
}