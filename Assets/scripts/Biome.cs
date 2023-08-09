using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "biome", menuName = "Data/Biome")]
    public class Biome : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private Sprite _portrait;

        public string Name { get => _name; }
        public Sprite Icon { get => _icon; }
        public Sprite Portrait { get => _portrait; }
    }
}