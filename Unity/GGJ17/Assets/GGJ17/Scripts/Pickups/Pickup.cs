using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;

public class Pickup : MonoBehaviour {

    public virtual void PickUp(PlayerController pc)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            PickUp(col.GetComponent<PlayerController>());
        }
    }
}
