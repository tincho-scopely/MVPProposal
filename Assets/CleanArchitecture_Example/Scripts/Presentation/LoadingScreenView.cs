using CleanArchitecture_Example.Scripts.InterfaceAdapters;
using UnityEngine;
using UniRx;

namespace CleanArchitecture_Example.Scripts.Presentation
{
    public class LoadingScreenView : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Animator _animator;
        private LoadingScreenViewData _viewData;

        public void SetData(LoadingScreenViewData viewData)
        {
            _viewData = viewData;

            _viewData.Show.Subscribe(Show);
            _viewData.Hide.Subscribe(Hide);
        }

        private void OnDestroy()
        {
            _viewData.Show.Dispose();
            _viewData.Hide.Dispose();
        }

        private void Show(Unit _)
        {
            _canvas.enabled = true;
            _animator.Rebind();
            _animator.enabled = true;
        }

        private void Hide(Unit _)
        {
            _canvas.enabled = false;
            _animator.enabled = false;
        }
    }
}