﻿using UnityEngine;

namespace Corn.Controller
{
    public class CameraController : MonoBehaviour
    {
        [Header("Public variables")]
        public bool isZoomed = false;
        public Vector3 offset = new Vector3(0, 2, -2);
        public Vector3 zoomOffset = new Vector3(1, 1.5f, -1f);
        public float followSpeed = 5f;
        public LayerMask mask;

        [SerializeField]
        Transform camPosition;
        [SerializeField]
        Transform camRotation;

        void Awake ()
        {
            PlayerController p = FindObjectOfType<PlayerController>();
            p.cam = this;
            camRotation = p.transform.Find("CameraRotate");
            camPosition = camRotation.Find("CameraPosition");
        }

        public Vector3 GetTarget ()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 200f, mask))
            {
                return hit.point;
            }
            else
            {
                return transform.position + transform.forward * 200f;
            }
        }

        void Update ()
        {
            if (camPosition != null)
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
                    isZoomed = true;
                }
                if (Input.GetButtonUp("Right Mouse"))
                {
                    isZoomed = false;
                }
                if (Input.GetButtonDown("Q"))
                {
                    SwitchShoulder();
                }
            }
        }

        public void SwitchShoulder ()
        {
            offset.x = -offset.x;
            zoomOffset.x = -zoomOffset.x;
        }

        public void Rotate (Vector3 xrot_)
        {
            camRotation.Rotate(xrot_);
            Mathf.Clamp(transform.rotation.x, 90, -90);
        }
    }
}