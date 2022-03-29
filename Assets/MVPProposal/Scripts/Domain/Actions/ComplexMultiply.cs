using System;
using MVPProposal.Scripts.Domain.Repositories;

namespace MVPProposal.Scripts.Domain.Actions
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