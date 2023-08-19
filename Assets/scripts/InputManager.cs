using System.Collections;
using UnityEngine;
using Assets.Scripts;

public class InputManager : MonoBehaviour
{

    private SceneManager _sceneManager;

    // Use this for initialization
    void Awake()
    {
        Locator.ProvideInputManager(this);
    }

    void Start()
    {
        _sceneManager = Locator.GetSceneManager();
    }

    // Update is called once per frame
    void Update()
    {
        var vAxis = Input.GetAxis("Vertical");
        var hAxis = Input.GetAxis("Horizontal");

        switch (_sceneManager.CurrentScene)
        {
            case SceneType.Desk:
                if (vAxis > 0)
                    _sceneManager.ChangeScene(SceneType.Greenhouse);
                else if (hAxis > 0)
                    _sceneManager.ChangeScene(SceneType.TrophyRoom);
                break;
            case SceneType.DeskZoom:
                if (vAxis < 0)
                    _sceneManager.ChangeScene(SceneType.Desk);
                break;
            case SceneType.Greenhouse:
                if (vAxis < 0)
                    _sceneManager.ChangeScene(SceneType.Desk);
                break;
            case SceneType.TrophyRoom:
                if (hAxis < 0)
                    _sceneManager.ChangeScene(SceneType.Desk);
                break;
            case SceneType.Invetory:
            case SceneType.Mail:
                _sceneManager.ChangeToPrevioesScene();
                break;

        }
    }
}
