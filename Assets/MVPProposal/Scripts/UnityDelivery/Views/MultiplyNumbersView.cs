using JetBrains.Annotations;
using MVPProposal.Scripts.Domain.Actions;
using MVPProposal.Scripts.Presentation;
using TMPro;
using UnityEngine;

namespace MVPProposal.Scripts.UnityDelivery.Views
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
            presenter = new MultiplyNumbersPresenter(this, simpleMultiply);
        }

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
            presenter.SimpleMultiply(firstNumber, secondNumber);
        }

        public void ShowResult(int result) => 
            resultText.text = result.ToString();
    }
}
