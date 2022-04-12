using System;

namespace MVP_Proposal2.Scripts.Domain.Services
{
    public interface IShopApiGateway
    {
        IObservable<string> Get(string path);
    }
}