using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    enum CamState
    {
        Desk,
        DeskZoom,
        Storage
    }

    [SerializeField]
    private Transform _storageCamTarget = null;
    [SerializeField]
    private Transform _storageCamTargetStart = null;
    [SerializeField]
    private GameObject _storageCam = null;
    [SerializeField]
    private GameObject _deskCam = null;
    [SerializeField]
    private GameObject _deskZoomCam = null;

    [SerializeField]
    private float _storageCamSpeed = 0.5f;
    [SerializeField]
    private float _storageCamDistanceTransition = 0.4f;

    private CamState _camState = CamState.Desk;

    // Update is called once per frame
    void Update()
    {
        var vAxis = Input.GetAxis("Vertical");
        var hAxis = Input.GetAxis("Horizontal");

        switch (_camState)
        {
            case CamState.Desk:
                if (vAxis > 0)
                {
                    _camState = CamState.DeskZoom;
                    _deskCam.SetActive(false);
                    _deskZoomCam.SetActive(true);
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    _camState = CamState.Storage;
                    _storageCamTarget.position = _storageCamTargetStart.position;
                    _deskCam.SetActive(false);
                    _storageCam.SetActive(true);
                }
                break;
            case CamState.Storage:

                if (hAxis < 0 && Vector3.Distance(_storageCamTarget.position, _storageCamTargetStart.position) < _storageCamDistanceTransition)
                {
                    _camState = CamState.Desk;
                    _storageCam.SetActive(false);
                    _deskCam.SetActive(true);
                }
                else
                {
                    var newX = _storageCamTarget.position.x;
                    var newY = _storageCamTarget.position.y;

                    if (hAxis != 0)
                        newX += hAxis * Time.deltaTime * _storageCamSpeed;

                    if (vAxis != 0)
                        newY += vAxis * Time.deltaTime * _storageCamSpeed;

                    _storageCamTarget.position = new Vector3(newX, newY, _storageCamTargetStart.position.z);
                }

                break;
            case CamState.DeskZoom:
                if (vAxis < 0)
                {
                    _camState = CamState.Desk;
                    _deskZoomCam.SetActive(false);
                    _deskCam.SetActive(true);
                }
                break;
        }
    }
}
