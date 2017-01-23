using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Pool;


public class PopcornDeathtrigger : MonoBehaviour
{
    void OnTriggerEnter (Collider col)
    {
        col.GetComponent<BasePoolObject>().SetDisable();
    }
}

