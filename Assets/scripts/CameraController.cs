using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public enum CamState
    {
        Desk = 0,
        DeskZoom = 1,
        TrophyRoom = 2,
        Greenhouse = 3
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
    private Image _fadeImage = null;

    [SerializeField]
    private float _camTransitionCooldown = 0.5f;

    private Color _fadeColour;
    private float _cooldown = 0;
    private CamState _camState = CamState.Desk;

    void Start()
    {
        _fadeColour = _fadeImage.color;    
    }

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
                        ChangeCamState(CamState.Greenhouse);
                    else if (hAxis > 0)
                        ChangeCamState(CamState.TrophyRoom);
                    break;
                case CamState.DeskZoom:
                    if (vAxis < 0)
                        ChangeCamState(CamState.Desk);
                    break;
                case CamState.Greenhouse:
                    if (vAxis < 0)
                        ChangeCamState(CamState.Desk);
                    break;
                case CamState.TrophyRoom:
                    if (hAxis < 0)
                        ChangeCamState(CamState.Desk);
                    break;
            }
        }
    }


    public void ChangeCamState(int targetCam)
    {
        ChangeCamState((CamState) targetCam);
    }

    private void ChangeCamState(CamState targetCam)
    {
        if (_camState == targetCam)
            return;

        switch (_camState)
        {
            case CamState.TrophyRoom:
                _trophyCam.SetActive(false);
                break;
            case CamState.Greenhouse:
                _greenhouseCam.SetActive(false);
                break;
            case CamState.Desk:
                if (targetCam != CamState.DeskZoom)
                    _deskCam.SetActive(false);
                else
                {
                    StartCoroutine(PlayFadeTransition(_camState, targetCam));
                    return;
                }
                break;
            case CamState.DeskZoom:
                StartCoroutine(PlayFadeTransition(_camState, targetCam));
                return;
        }

        switch (targetCam)
        {
            case CamState.TrophyRoom:
                _trophyCam.SetActive(true);
                _camState = CamState.TrophyRoom;
                break;
            case CamState.Greenhouse:
                _greenhouseCam.SetActive(true);
                _camState = CamState.Greenhouse;
                break;
            case CamState.Desk:
                _deskCam.SetActive(true);
                _camState = CamState.Desk;
                break;
        }

        _cooldown = 0;
    }

    private IEnumerator PlayFadeTransition(CamState sourceCam, CamState targetCam)
    {
        var t = 0.0f;
        var halfCamTC = _camTransitionCooldown / 2;
        while (t < halfCamTC )
        {
            var c = _fadeColour;
            c.a = t / halfCamTC;

            _fadeImage.color = c;

            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        switch (sourceCam)
        {
            case CamState.DeskZoom:
                _deskZoomCam.SetActive(false);
                break;
            case CamState.Desk:
                _deskCam.SetActive(false);
                break;
        }

        switch (targetCam)
        {
            case CamState.DeskZoom:
                _deskZoomCam.SetActive(true);
                _camState = CamState.DeskZoom;
                break;
            case CamState.Desk:
                _deskCam.SetActive(true);
                _camState = CamState.Desk;
                break;
        }

        while (t > 0)
        {
            var c = _fadeColour;
            c.a = t / halfCamTC;

            _fadeImage.color = c;

            t -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _cooldown = 0;
    }
}
