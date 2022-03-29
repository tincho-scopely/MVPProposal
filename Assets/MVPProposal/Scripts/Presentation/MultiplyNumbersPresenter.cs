using MVPProposal.Scripts.Domain.Actions;

namespace MVPProposal.Scripts.Presentation
{
    public class MultiplyNumbersPresenter 
    {
        private readonly IMultiplyNumbersView _view;
        private readonly SimpleMultiply _simpleMultiply;

        public MultiplyNumbersPresenter(IMultiplyNumbersView view, SimpleMultiply simpleMultiply)
        {
            _view = view;
            _simpleMultiply = simpleMultiply;
        }

        public void SimpleMultiply(int firstNumber, int secondNumber) => 
            _view.ShowResult(_simpleMultiply.Execute(firstNumber, secondNumber));
    }
}
