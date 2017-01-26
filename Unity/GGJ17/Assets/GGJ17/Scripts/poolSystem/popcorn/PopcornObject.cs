using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Pool;

namespace Corn.Pool
{
    [RequireComponent(typeof(Rigidbody))]
    public class PopcornObject : BasePoolObject
    {
        public float timer;
        static BasePool pool;
        public void pop (Transform pos)
        {
            this.transform.position = pos.position;
            Invoke("PlaceDummy", timer);

        }
        void PlaceDummy ()
        {
            if(pool == null)
            {
                pool = PoolManager.Instance.GetPool("PopcornDummy");
            }
            BasePoolObject corn = pool.GetPooledObject() as BasePoolObject;
            corn.SetEnable();
            corn.transform.position = this.transform.position;
            corn.transform.rotation = this.transform.rotation;
            SetDisable();
        }
        public override void SetDisable ()
        {
            CancelInvoke("PlaceDummy");
            base.SetDisable();
        }

        public void Awake ()
        {
            SetDisable();
        }
    }
}