using MVP_Proposal2.Scripts.Providers;
using MVP_Proposal2.Scripts.Views;
using UnityEngine;

namespace MVP_Proposal2.Scripts
{
    public class ApplicationContext : MonoBehaviour
    {
        [SerializeField] private ShopPopupView shopPopupView;
        
        void Start()
        {
            InitViews();
            shopPopupView.Show();
        }

        private void InitViews()
        {
            shopPopupView.Init(DependencyProvider.ShopBundlesRepository, DependencyProvider.PlayerInventoryRepository);
        }
    }
}
