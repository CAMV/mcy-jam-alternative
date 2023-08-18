using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "bug", menuName = "Data/Collectable/Bug")]
    public class Bug : Collectable
    {
        [Header("Bug References")]
        [SerializeField] 
        private Body body;
        [SerializeField] 
        private Leg[] legs;
        
        public override GameObject CreateCollectableGO()
        {
            GameObject bugGO = new GameObject(Name);
            GameObject bodyGO = Instantiate(body.PrefabReferences[0], bugGO.transform);

            foreach (var leg in legs)
            {
                Transform attachablePoint = null;
                
                for (int i = 0; i < bodyGO.transform.childCount; i++)
                {
                    Transform child = bodyGO.transform.GetChild(i);
                    if (child.childCount <= 0)
                    {
                        attachablePoint = child;
                        break;
                    }
                }
                
                GameObject legGO = Instantiate(leg.PrefabReferences[0], attachablePoint);
            }

            return bugGO;
        }
    }
}