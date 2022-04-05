using JetBrains.Annotations;
using SimpleExample.Scripts.Domain.Actions;
using SimpleExample.Scripts.Infrastructure.Repositories;
using SimpleExample.Scripts.MVP.Presentation;
using TMPro;
using UnityEngine;

namespace SimpleExample.Scripts.MVP.UnityDelivery.Views
{
    public class MultiplyNumbersView : MonoBehaviour, IMultiplyNumbersView
    {
        [SerializeField] private TMP_InputField firstInput;
        [SerializeField] private TMP_InputField secondInput;
        [SerializeField] private TextMeshProUGUI resultText;
        
        private MultiplyNumbersPresenter presenter;

        void Start()
        {
            var simpleMultiply = new SimpleMultiply();
            var multiplyRepository = new DefaultMultiplyRepository();
            var complexMultiply = new ComplexMultiply(multiplyRepository);
            presenter = new MultiplyNumbersPresenter(this, simpleMultiply, complexMultiply);
        }

        private void OnDestroy() => presenter.Clear();
        
        [UsedImplicitly]
        public void SimpleMultiplyClick()
        {
            var firstNumber = int.Parse(firstInput.text);
            var secondNumber = int.Parse(secondInput.text);
            presenter.SimpleMultiply(firstNumber, secondNumber);
        }
        
        [UsedImplicitly]
        public void ComplexMultiplyClick()
        {
            var firstNumber = int.Parse(firstInput.text);
            var secondNumber = int.Parse(secondInput.text);
            presenter.ComplexMultiply(firstNumber, secondNumber);
        }

        public void ShowLoading()
        {
            resultText.text = "LOADING...";
        }

        public void ShowResult(int result) => 
            resultText.text = result.ToString();
    }
}
