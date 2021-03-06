using System;
using System.Reflection;

namespace MVVMFramework.Properties
{
    public interface PropertyResolver
    {
        object GetValue(FieldInfo fieldInfo, object viewModel);

        IDisposable SubscribeProperty(FieldInfo fieldInfo, object viewModel, Action<string, object> execute);
    }
}