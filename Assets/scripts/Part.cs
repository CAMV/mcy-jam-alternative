using System;
using Assets.Scripts.interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    [Serializable]
    public abstract class Part
    {
        [SerializeField]
        protected Vector3 minScale;
        [SerializeField]
        protected Vector3 maxScale;

        protected Vector3 GetRandomBetweenVectors()
        {
            Vector3 difference = maxScale - minScale;
            float randomNumber = Random.Range(0f, 1f);
            Vector3 randomVector = difference * randomNumber;
            
            return minScale + randomVector;
        }
        
        public abstract Vector3 GetRangeScale();
    }

    [Serializable]
    public class Body : Part, IUsePrefab
    {
        [field: SerializeField]
        public GameObject[] PrefabReferences { get; private set; }
        
        public override Vector3 GetRangeScale()
        {
            throw new NotImplementedException();
        }
    }
    
    [Serializable]
    public class Leg : Part, IUsePrefab
    {
        [field: SerializeField]
        public GameObject[] PrefabReferences { get; private set; }
        
        [SerializeField]
        private bool hasClaws;
        [SerializeField]
        private bool hasHooves;
        [SerializeField] 
        private bool areBroken;
        
        public override Vector3 GetRangeScale()
        {
            Vector3 rangeScale = GetRandomBetweenVectors();
            
            // Move this properties to a constant class
            if (areBroken)
                rangeScale *= 0.5f;

            if (hasClaws)
                rangeScale *= 1.2f;
            
            if (hasHooves)
                rangeScale *= 1.1f;

            return rangeScale;
        }
    }
}