using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Pool;
public class BulletTerrainCollision : MonoBehaviour {

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            GetComponentInParent<BulletObject>().SetDisable();
        }
    }
}
