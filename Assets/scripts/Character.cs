using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Character", menuName = "Data/Character")]
    public class Character : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private University _university;
        [SerializeField]
        private Sprite _signature;

        public string Name { get => _name; }
        public University University { get => _university; }
        public Sprite Signature { get => _signature; }
    }
}