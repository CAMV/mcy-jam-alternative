using System.Collections;
using UnityEngine;
using Assets.Scripts;

public class DataLoader : MonoBehaviour
{

    private Collectable[] _colDefs;
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
