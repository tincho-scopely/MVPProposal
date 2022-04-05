using System;
using MVVMFramework.Properties;

namespace MVVMFramework.Repositories
{
    public interface PropertyResolverRepository
    {
        PropertyResolver GetBy(Type type);
    }
}