using System.Collections;
using UnityEngine;
using Assets.Scripts;

public class InventoryManager : MonoBehaviour
{



    // Use this for initialization
    void Awake()
    {
        Locator.ProvideInventoryManager(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
