using System;
using MVP_CleanArchitecture_Example.Scripts.Domain;
using MVP_Proposal2.Scripts.Domain.Services;
using MVP_Proposal2.Scripts.Infrastructure.DTO;
using UniRx;
using UnityEngine;
using Random = System.Random;

namespace MVP_Proposal2.Scripts.Infrastructure
{
    public class ShopApiGateway : IShopApiGateway
    {
        public IObservable<string> Get(string path)
        {
            var random = new Random();
            var bundles = new ShopBundleItemDTO[9];
            for (var i = 0; i < 9; i++)
            {
                bundles[i] = new ShopBundleItemDTO(
                    i,
                    "bundle" + i,
                    new CommodityDTO(CommodityDefinitions.BonusRolls, random.Next(5, 21)),
                    new CommodityDTO(string.Empty, new Random().Next(1, 3))
                );
            }

            // Needed this hack to make JsonUtility from unity work. PLEASE USE NEWTONSOFT
            var bundlesToSerialize = new ShopBundleItemCollection { Items = bundles };
            var json = JsonUtility.ToJson(bundlesToSerialize);
            return Observable.Return(json);
        }
    }

    [Serializable]
    public class ShopBundleItemCollection
    {
        public ShopBundleItemDTO[] Items;
    }
}