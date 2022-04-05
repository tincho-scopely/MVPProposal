using UnityEngine;

namespace MVVMFramework.Bindings
{
    public class BindingEnabler : BindingBase
    {
        [SerializeField] private bool revert;
        
        protected override void UpdateComponentOnChange(PropertyChanged changed)
        {
            var newValue = (bool) changed.Value;
            Target.SetActive(revert ? !newValue : newValue);
        }
    }
}
