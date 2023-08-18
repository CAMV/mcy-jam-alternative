using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public enum CollectableType
    {
        Flower, Mushroom, Beetle
    }

    public abstract class Collectable : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private GameObject[] _prefabs;
        [SerializeField]
        private  Biome[] _biomes;
        [SerializeField]
        private Region[] _regions;



        public string Name { get => _name; }
        public List<(Region region, Biome biome)> Habitats 
        { 
            get
            {
                var habitats = new List<(Region region, Biome biome)>();
                for (int i = 0; i < _biomes.Length; i++)
                {
                    if (i >= _regions.Length)
                        break;

                    habitats.Add((_regions[i], _biomes[i]));
                }

                return habitats;
            }
         }

        public abstract GameObject CreteCollectableGO();

    }
}