using System.Collections;
using UnityEngine;
using Assets.Scripts;

public class SceneManager : MonoBehaviour
{

    [SerializeField]
    private float _changeSceneCooldown = 0.5f;

    private SceneType _cScene = SceneType.Desk;
    private SceneType _pScene = SceneType.Desk;

    private CameraController _cameraController;
    private bool _isCooldown = false;

    // Use this for initialization
    void Awake()
    {
        Locator.ProvideSceneManager(this);
    }

    void Start()
    {
        _cameraController = Locator.GetCameraController();
    }

    private IEnumerator WaitCooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_changeSceneCooldown);
        _isCooldown = false;
    }

    public SceneType CurrentScene
    {
        get => _cScene;
    }

    public void ChangeToPrevioesScene()
    {
        ChangeScene(_pScene);
    }

    public void ChangeScene(int targetScene)
    {
        ChangeScene((SceneType) targetScene);
    }

    public void ChangeScene(SceneType targetScene)
    {
        if (_isCooldown)
            return;
        
        if (_cScene == targetScene)
            return;

        StartCoroutine(WaitCooldown());

        _pScene = _cScene;
        _cScene = targetScene;

        CameraType camType = CameraType.Desk;

        switch (targetScene)
        {
            case SceneType.DeskZoom:
                camType = CameraType.DeskZoom;
                break;
            case SceneType.Greenhouse:
                camType = CameraType.Greenhouse;
                break;
            case SceneType.TrophyRoom:
                camType = CameraType.TrophyRoom;
                break;
            case SceneType.Mail:
            case SceneType.Invetory:
                camType = CameraType.FocusMode;
                break;
        }

        _cameraController.ChangeCamState(camType);
    }
}
