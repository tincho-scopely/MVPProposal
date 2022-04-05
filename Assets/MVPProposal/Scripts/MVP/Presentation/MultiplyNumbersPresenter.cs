using MVPProposal.Scripts.Domain.Actions;
using UniRx;

namespace MVPProposal.Scripts.Presentation
{
    public class MultiplyNumbersPresenter 
    {
        private readonly IMultiplyNumbersView _view;
        private readonly SimpleMultiply _simpleMultiply;
        private readonly ComplexMultiply _complexMultiply;

        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        
        public MultiplyNumbersPresenter(IMultiplyNumbersView view, SimpleMultiply simpleMultiply, ComplexMultiply complexMultiply)
        {
            _view = view;
            _simpleMultiply = simpleMultiply;
            _complexMultiply = complexMultiply;
        }

        public void SimpleMultiply(int firstNumber, int secondNumber) => 
            _view.ShowResult(_simpleMultiply.Execute(firstNumber, secondNumber));

        public void ComplexMultiply(int firstNumber, int secondNumber)
        {
            _complexMultiply.Execute(firstNumber, secondNumber)
                .DoOnSubscribe(() => _view.ShowLoading())
                .Do(_view.ShowResult)
                .Subscribe()
                .AddTo(_disposables);
        }

        public void Clear() => _disposables.Clear();
    }
}
