using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Pool;

namespace Corn.Pool
{
    [RequireComponent(typeof(Rigidbody))]
    public class PopcornObject : BasePoolObject
    {

        public void pop (Transform pos)
        {
            this.transform.position = pos.position;

        }
        public void Awake ()
        {
            SetDisable();
        }
    }
}