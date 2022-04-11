using System;
using System.Collections.Generic;
using System.Linq;
using MVP_Proposal2.Scripts.Domain.Model;

namespace MVP_Proposal2.Scripts.Infrastructure.DTO
{
    [Serializable]
    public class ShopBundlesDTO
    {
        public ShopBundleItemDTO[] Items;

        public List<ShopBundleItem> ToBundles() =>
            Items.Select(itemDto => itemDto.ToBundleItem()).ToList();
    }
}