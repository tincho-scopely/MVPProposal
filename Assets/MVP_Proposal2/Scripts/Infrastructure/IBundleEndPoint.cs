using System;
using System.Collections.Generic;
using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Infrastructure
{
    public interface IBundleEndPoint
    {
        IObservable<List<ShopBundleItem>> Get();
    }
}