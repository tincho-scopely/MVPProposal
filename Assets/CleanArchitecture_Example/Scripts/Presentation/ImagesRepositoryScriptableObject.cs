using System;
using System.Collections.Generic;
using UnityEngine;

namespace CleanArchitecture_Example.Scripts.Presentation
{
    [CreateAssetMenu(fileName = "ImagesRepository", menuName = "ScriptableObjects/Images Repository", order = 0)]
    public class ImagesRepositoryScriptableObject : ScriptableObject
    {
        [Serializable]
        private class ImageDictionary
        {
            public Sprite Sprite;
            public string Key;
        }

        [SerializeField] private List<ImageDictionary> _images;

        public Sprite GetSprite(string key)
        {
            return _images.Find(image => image.Key == key)?.Sprite;
        }
    }
}