using System;
using System.Collections.Generic;
using MVVMFramework.Properties;
using MVVMFramework.Repositories;
using UniRx;

namespace SimpleExample.Scripts.MVVM.Infrastructure
{
    public class ReactivePropertyResolverRepository : PropertyResolverRepository
    {
        readonly Dictionary<Type, PropertyResolver> propertiesResolver;

        public ReactivePropertyResolverRepository()
        {
            propertiesResolver = new Dictionary<Type, PropertyResolver>
            {
                {typeof(IntReactiveProperty), new ReactivePropertyResolver<int>()},
                {typeof(FloatReactiveProperty), new ReactivePropertyResolver<float>()},
                {typeof(StringReactiveProperty), new ReactivePropertyResolver<string>()},
                {typeof(BoolReactiveProperty), new ReactivePropertyResolver<bool>()},
                {typeof(LongReactiveProperty), new ReactivePropertyResolver<long>()},
                {typeof(DoubleReactiveProperty), new ReactivePropertyResolver<double>()},
            };
        }

        public PropertyResolver GetBy(Type type) =>
            propertiesResolver.ContainsKey(type)
                ? propertiesResolver[type]
                : null;
    }
}