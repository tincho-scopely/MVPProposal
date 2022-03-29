using System;
using MVPProposal.Scripts.Domain.Actions;
using MVPProposal.Scripts.Domain.Repositories;
using NSubstitute;
using NUnit.Framework;
using UniRx;

namespace MVPProposal.Scripts.Tests.Editor.Actions
{
    [TestFixture]
    public class ComplexMultiplyShould
    {
        private ComplexMultiply _action;
        private IMultiplyRepository _multiplyRepository;

        [SetUp]
        public void Setup()
        {
            _multiplyRepository = Substitute.For<IMultiplyRepository>();
            _action = new ComplexMultiply(_multiplyRepository);
        }

        [TestCase(2, 3, 6)]
        [TestCase(3, 3, 9)]
        public void Multiply_Two_Numbers(int firstNumber, int secondNumber, int expectedResult)
        {
            GivenAServerReturningResultWith(firstNumber, secondNumber, expectedResult);
            WhenExecuting(firstNumber, secondNumber)
                .Subscribe(result => ThenResultIs(expectedResult, result));
        }

        private void GivenAServerReturningResultWith(int firstNumber, int secondNumber, int expectedResult) =>
            _multiplyRepository.Get(firstNumber, secondNumber).Returns(Observable.Return(expectedResult));

        private IObservable<int> WhenExecuting(int firstNumber, int secondNumber) =>
            _action.Execute(firstNumber, secondNumber);

        private void ThenResultIs(int expectedResult, int result) => 
            Assert.AreEqual(expectedResult, result);
    }
}