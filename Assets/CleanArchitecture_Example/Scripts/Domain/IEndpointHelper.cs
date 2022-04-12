using System;
using System.Threading.Tasks;

namespace CleanArchitecture_Example.Scripts.Domain
{
    public interface IEndpointHelper
    {
        Task PurchaseBundle(int bundleId, Action onSucceed, Action onFailed);
    }
}