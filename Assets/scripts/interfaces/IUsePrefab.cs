using UnityEngine;

namespace Assets.Scripts.interfaces
{
    public interface IUsePrefab
    {
        public GameObject[] PrefabReferences { get; }
    }
}