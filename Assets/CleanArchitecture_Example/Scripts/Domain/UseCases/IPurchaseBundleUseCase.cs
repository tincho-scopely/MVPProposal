using System;

namespace CleanArchitecture_Example.Scripts.Domain.UseCases
{
    public interface IPurchaseBundleUseCase
    {
        void Purchase(int bundleId, Action<int> onSucceed, Action onFailed);
    }
}