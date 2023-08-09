using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "mushroom", menuName = "Data/Collectable/Mushroom")]
    public class MushroomCollectableDefinition : CollectableDefinition
    {
        public override CollectableDefinition CreteCollectable()
        {
            throw new System.NotImplementedException();
        }
    }
}