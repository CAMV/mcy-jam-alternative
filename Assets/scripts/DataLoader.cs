using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class DataLoader : MonoBehaviour
    {

        private CollectableDefinition[] _colDefs;
        private Character[] _characters;

        // Use this for initialization
        void Awake()
        {
            Locator.ProvideDataLoader(this);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}