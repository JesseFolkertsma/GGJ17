using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Components;

public class DieOnTouch : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ILives>() != null)
        {
            foreach(Kernel k in col.GetComponent<ILives>().GetKernals)
            {
                if (!k.isDead)
                    k.Die();
            }
            //col.GetComponent<ILives>().lives = 0;
            //col.GetComponent<ILives>().Die();
        }
    }
}
