using UnityEngine;

namespace CleanArchitecture_Example.Scripts.InterfaceAdapters.Services
{
    public interface IImageRepository
    {
        Sprite GetSprite(string key);
    }
}