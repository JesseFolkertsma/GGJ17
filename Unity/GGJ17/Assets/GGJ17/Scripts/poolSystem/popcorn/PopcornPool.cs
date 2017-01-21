using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonAssets.Pool;

public class PopcornPool : BasePool {


    public virtual void Start ()
    {
        Debug.Log(PoolManager.Instance);
        Kernel.pool = PoolManager.Instance.GetPool("Popcorn") as PopcornPool;
        Debug.Log(Kernel.pool);

    }


}
