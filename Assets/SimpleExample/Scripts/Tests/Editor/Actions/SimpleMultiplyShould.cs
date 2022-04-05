using NUnit.Framework;
using SimpleExample.Scripts.Domain.Actions;

namespace SimpleExample.Scripts.Tests.Editor.Actions
{
    [TestFixture]
    public class SimpleMultiplyShould 
    {
        private SimpleMultiply _action;
        private int _result;

        [SetUp]
        public void Setup()
        {
            _action = new SimpleMultiply();
        }
        
        [TestCase(2, 3, 6)]
        [TestCase(3, 3, 9)]
        public void Multiply_Two_Numbers(int firstNumber, int secondNumber, int expectedResult)
        {
            WhenExecuting(firstNumber, secondNumber);
            ThenValueIs(expectedResult);
        }

        private void WhenExecuting(int firstNumber, int secondNumber) => 
            _result = _action.Execute(firstNumber, secondNumber);

        private void ThenValueIs(int expected) => 
            Assert.AreEqual(expected, _result);
    }
}
