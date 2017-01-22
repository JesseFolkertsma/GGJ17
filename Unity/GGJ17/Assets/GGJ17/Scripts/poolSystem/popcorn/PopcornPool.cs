using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Pool;
using Corn.Components;

namespace Corn.Pool
{
    public class PopcornPool : BasePool
    {


        public virtual void Start ()
        {
            Debug.Log(PoolManager.Instance);
            Kernel.pool = PoolManager.Instance.GetPool("Popcorn") as PopcornPool;
        }
    }
}