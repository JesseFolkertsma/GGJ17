using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Header("Public variables")]
    public bool isZoomed = false;
    public Vector3 offset = new Vector3(0, 2, -2);
    public Vector3 zoomOffset = new Vector3(1, 1.5f, -1f);
    public float followSpeed = 5f;
        
    [SerializeField]
    Transform camPosition;

    void Update()
    {
        Vector3 _offset = Vector3.zero;
        if (!isZoomed)
        {
            _offset = offset;
        }
        else
        {
            _offset = zoomOffset;
        }
        camPosition.localPosition = _offset;

        transform.position = Vector3.Lerp(transform.position, camPosition.position, Time.deltaTime * followSpeed);
        //transform.position = camPosition.position;
        transform.rotation = camPosition.rotation;

        if (Input.GetButtonDown("Right Mouse"))
        {
            isZoomed = !isZoomed;
        }
    }
}
