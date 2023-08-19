using System.Collections;
using UnityEngine;

public static class Locator 
{

    private static DataLoader _dataLoader = null;
    private static CameraController _cameraController = null;
    private static InventoryManager _inventoryManager = null;
    private static InputManager _inputManager = null;
    private static SceneManager _sceneManager = null;


    public static void ProvideDataLoader(DataLoader dl) => _dataLoader = dl;
    public static DataLoader GetDataLoader() => _dataLoader;

    public static void ProvideCameraController(CameraController cc) => _cameraController = cc;
    public static CameraController GetCameraController() => _cameraController;

    public static void ProvideInventoryManager(InventoryManager im) => _inventoryManager = im;
    public static InventoryManager GetInventoryManager() => _inventoryManager;

    public static void ProvideInputManager(InputManager im) => _inputManager = im;
    public static InputManager GetInputManager() => _inputManager;


    public static void ProvideSceneManager(SceneManager sm) => _sceneManager = sm;
    public static SceneManager GetSceneManager() => _sceneManager;


}
