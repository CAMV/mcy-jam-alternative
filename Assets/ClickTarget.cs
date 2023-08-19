using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ClickTarget : MonoBehaviour
{
    [SerializeField]
    UnityEvent _clickEvent = null;

    private Collider _collider = null;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            var r = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit rh;
            if (_collider.Raycast(r, out rh, 10) && _clickEvent != null)
                _clickEvent.Invoke();
        }
    }
}
