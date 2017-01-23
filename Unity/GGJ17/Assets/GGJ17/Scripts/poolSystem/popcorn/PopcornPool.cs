using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Components;

namespace Corn.Pool
{
    public class PopcornPool : BasePool
    {
        void Awake ()
        {
            Kernel.pool = this;
        }
    }
}