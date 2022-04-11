using CleanArchitecture_Example.Scripts.InterfaceAdapters;
using CleanArchitecture_Example.Scripts.InterfaceAdapters.Services;
using UnityEngine;

namespace CleanArchitecture_Example.Scripts.Presentation.ImagesRepositories
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