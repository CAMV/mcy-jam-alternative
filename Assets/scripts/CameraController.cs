using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    enum CamState
    {
        Desk,
        DeskZoom,
        TrophyRoom,
        Greenhouse
    }

    [SerializeField]
    private GameObject _trophyCam = null;
    [SerializeField]
    private GameObject _deskCam = null;
    [SerializeField]
    private GameObject _deskZoomCam = null;
    [SerializeField]
    private GameObject _greenhouseCam = null;

    [SerializeField]
    private float _camTransitionCooldown = 0.5f;

    private float _cooldown = 0;
    private CamState _camState = CamState.Desk;

    // Update is called once per frame
    void Update()
    {
        var vAxis = Input.GetAxis("Vertical");
        var hAxis = Input.GetAxis("Horizontal");

        if (_camTransitionCooldown > _cooldown)
            _cooldown += Time.deltaTime;
        else
        {
            switch (_camState)
            {
                case CamState.Desk:
                    if (vAxis > 0)
                    {
                        _camState = CamState.Greenhouse;
                        _deskCam.SetActive(false);
                        _greenhouseCam.SetActive(true);
                        _cooldown = 0;
                    }
                    else if (hAxis > 0)
                    {
                        _camState = CamState.TrophyRoom;
                        _trophyCam.SetActive(true);
                        _deskCam.SetActive(false);
                        _cooldown = 0;
                    }
                    break;
                case CamState.DeskZoom:
                    if (vAxis < 0)
                    {
                        _camState = CamState.Desk;
                        _deskZoomCam.SetActive(false);
                        _deskCam.SetActive(true);
                        _cooldown = 0;
                    }
                    break;
                case CamState.Greenhouse:
                    if (vAxis < 0)
                    {
                        _camState = CamState.Desk;
                        _greenhouseCam.SetActive(false);
                        _deskCam.SetActive(true);
                        _cooldown = 0;
                    }
                    break;
                case CamState.TrophyRoom:
                    if (hAxis < 0)
                    {
                        _camState = CamState.Desk;
                        _trophyCam.SetActive(false);
                        _deskCam.SetActive(true);
                        _cooldown = 0;
                    }
                    break;
            }
        }
    }
}
