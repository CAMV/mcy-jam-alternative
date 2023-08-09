using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "university", menuName = "Data/University")]
    public class University : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private Sprite _seal;
        [SerializeField]
        private Region _region;

        public string Name { get => _name; }
        public Sprite Icon { get => _icon; }
        public Sprite Seal { get => _seal; }
        public Region Region { get => _region; }
    }
}