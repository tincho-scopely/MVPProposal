using UnityEngine;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters
{
    public interface IImageRepository
    {
        Sprite GetCommoditySprite(string key);
    }
}