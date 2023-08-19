using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
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
    private float _transitionDuration = 0.5f;

    private Color _fadeColour;
    private CameraType _camState = CameraType.Desk;

    void Awake()
    {
        Locator.ProvideCameraController(this);
        _fadeColour = _fadeImage.color;
    }

    private IEnumerator SetFadeAlpha(float alpha, float duration)
    {
        var t = 0.0f;
        var c = _fadeColour;

        while (t < duration)
        {
            c.a = Mathf.Lerp(0, alpha, t / duration);
            _fadeImage.color = c;
            t += Time.deltaTime;
            
            yield return new WaitForEndOfFrame();
        }

        c.a = alpha;
        _fadeImage.color = c;
    }

    public void ChangeCamState(CameraType targetCam)
    {
        if (_camState == targetCam)
            return;

        switch (_camState)
        {
            case CameraType.TrophyRoom:
                _trophyCam.SetActive(false);
                break;
            case CameraType.Greenhouse:
                _greenhouseCam.SetActive(false);
                break;
            case CameraType.Desk:
                if (targetCam != CameraType.DeskZoom)
                    _deskCam.SetActive(false);
                else
                {
                    StartCoroutine(PlayFadeTransition(_camState, targetCam));
                    return;
                }
                break;
            case CameraType.DeskZoom:
                if (targetCam == CameraType.FocusMode)
                {
                    _deskZoomCam.SetActive(false);
                }
                else
                {
                    StartCoroutine(PlayFadeTransition(_camState, targetCam));
                    return;
                }
                break;
            case CameraType.FocusMode:
                StartCoroutine(SetFadeAlpha(0, _transitionDuration));
                break;
        }

        switch (targetCam)
        {
            case CameraType.TrophyRoom:
                _trophyCam.SetActive(true);
                _camState = CameraType.TrophyRoom;
                break;
            case CameraType.Greenhouse:
                _greenhouseCam.SetActive(true);
                _camState = CameraType.Greenhouse;
                break;
            case CameraType.Desk:
                _deskCam.SetActive(true);
                _camState = CameraType.Desk;
                break;
            case CameraType.FocusMode:
                StartCoroutine(SetFadeAlpha(0.9f, _transitionDuration));
                _camState = CameraType.FocusMode;
                break;
        }
    }

    private IEnumerator PlayFadeTransition(CameraType sourceCam, CameraType targetCam)
    {
        var halfCamTC = _transitionDuration / 2;
        yield return SetFadeAlpha(1, halfCamTC);

        switch (sourceCam)
        {
            case CameraType.DeskZoom:
                _deskZoomCam.SetActive(false);
                break;
            case CameraType.Desk:
                _deskCam.SetActive(false);
                break;
        }

        switch (targetCam)
        {
            case CameraType.DeskZoom:
                _deskZoomCam.SetActive(true);
                _camState = CameraType.DeskZoom;
                break;
            case CameraType.Desk:
                _deskCam.SetActive(true);
                _camState = CameraType.Desk;
                break;
        }

        yield return SetFadeAlpha(0, halfCamTC);
    }
}
