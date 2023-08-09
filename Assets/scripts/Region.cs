using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "location", menuName = "Data/Region")]
    public class Region : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _flag;
        [SerializeField]
        private Sprite[] _stamps;
        [SerializeField]
        private Sprite _mapHighlight;
        [SerializeField]
        private Biome[] _biomes;

        public string Name { get => _name; }
        public Sprite Flag { get => _flag; }
        public Sprite[] Stamps { get => _stamps; }
        public Sprite MapHighlight { get => _mapHighlight; }
        public Biome[] Biomes { get => _biomes; }
    }
}