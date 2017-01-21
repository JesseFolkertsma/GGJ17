using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonAssets.Pool;

public class PopcornPool : BasePool {


    void Awake ()
    {
        Kernel.pool = PoolManager.Instance.GetPool("PopcornPool") as PopcornPool;
    }


}
