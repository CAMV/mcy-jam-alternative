using UnityEngine;

namespace Assets.Scripts.Handlers
{
    public class StudioHandler : MonoBehaviour
    {
        [SerializeField] 
        private Bug bug;
        
        public void CreateBug()
        {
            var go = bug.CreateCollectableGO();
            go.transform.SetParent(transform);
            go.transform.position = Vector3.zero;
        }
    }
}
