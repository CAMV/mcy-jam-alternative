using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Locator 
    {

        private static DataLoader _dataLoader = null;

        public static void ProvideDataLoader(DataLoader dl) => _dataLoader = dl;
        public static DataLoader GetDataLoader() => _dataLoader;


    }
}