using System.Linq;
using System.Reflection;
using MVVMFramework.Properties;
using UnityEngine;
using static System.Convert;

namespace MVVMFramework.Bindings
{
    public class BindingComponent : BindingBase
    {
        public Component TargetComponent;
        public string TargetComponentProperty;
        PropertyInfo targetComponentPropertyInfo;


        protected override void Initialize()
        {
            disposables.Clear();
            if (!IsValid()) return;
            
            PropertyHelper.GetProperties(TargetComponent.GetType());
            UpdateComponentOnChange(new PropertyChanged(ViewModelProperty, ViewModel.GetValueOf(ViewModelProperty)));
            BindToViewModel();
        }

        protected override void UpdateComponentOnChange(PropertyChanged changed)
        {
            var updateProperty = PropertyHelper.GetProperties(TargetComponent.GetType())
                .First(property => property.Name.Equals(TargetComponentProperty));
            updateProperty.Setter(TargetComponent, ChangeType(changed.Value, updateProperty.PropertyType));
        }

        protected override bool IsValid()
        {
            return base.IsValid() &&
                   TargetComponent != null && 
                   !string.IsNullOrEmpty(TargetComponentProperty);
            
        }
    }
}