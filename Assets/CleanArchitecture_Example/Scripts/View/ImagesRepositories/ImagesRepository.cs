using CleanArchitecture_Example.Scripts.InterfaceAdapters;
using UnityEngine;

namespace CleanArchitecture_Example.Scripts.View
{
    public abstract class ImagesRepository : MonoBehaviour, IImageRepository
    {
        [SerializeField] private ImagesRepositoryScriptableObject _repository;

        public Sprite GetSprite(string key)
        {
            return _repository.GetSprite(key);
        }
    }
}