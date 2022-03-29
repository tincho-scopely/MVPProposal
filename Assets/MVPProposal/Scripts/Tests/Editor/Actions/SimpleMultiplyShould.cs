
using MVPProposal.Scripts.Domain.Actions;
using NUnit.Framework;

namespace MVPProposal.Scripts.Tests.Editor.Actions
{
    [TestFixture]
    public class SimpleMultiplyShould 
    {
        private SimpleMultiply action;
        private int _result;

        [SetUp]
        public void Setup()
        {
            action = new SimpleMultiply();
        }
        
        [TestCase(2, 3, 6)]
        [TestCase(3, 3, 9)]
        public void Multiply_Two_Numbers(int firstNumber, int secondNumber, int expectedResult)
        {
            WhenExecuting(firstNumber, secondNumber);
            ThenValueIs(expectedResult);
        }

        private void WhenExecuting(int firstNumber, int secondNumber) => 
            _result = action.Execute(firstNumber, secondNumber);

        private void ThenValueIs(int expected) => 
            Assert.AreEqual(expected, _result);
    }
}
