using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Pool;
using Corn.Components;

namespace Corn.Pool
{
    public class BulletObject : BasePoolObject
    {

        public float speed = 2;
        public float timer;

        public void ShootBullet (Vector3 pos, Quaternion rot)
        {
            SetEnable();
            transform.position = pos;
            transform.rotation = rot;
            Invoke("SetDisable", timer);
        }
        public override void SetDisable ()
        {
            //if (IsInvoking("SetDisable"))
            //{
                CancelInvoke("SetDisable");
            //}
            base.SetDisable();
        }
        void Update ()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        void OnTriggerEnter (Collider col)
        {
            if (col.GetComponent<Kernel>())
                col.GetComponent<Kernel>().lives = 0;
            else
            {
                print("destroyed by " + col.name );
                SetDisable();
            }
        }
        public void Awake ()
        {
            SetDisable();
        }
    }
}