using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "mushroom", menuName = "Data/Collectable/Mushroom")]
    public class MushroomCollectable: Collectable
    {
        [SerializeField]
        private Vector3 _minScale;
        [SerializeField]
        private Vector3 _maxScale;

        public override GameObject CreateCollectableGO()
        {
            throw new System.NotImplementedException();
        }
    }
}