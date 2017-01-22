using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Movement;

public class Pickup : MonoBehaviour {

    public PickupSpawner attachedSpawner;

    public virtual void PickUp(IMovement pc)
    {
        Destroy(gameObject);
        if(attachedSpawner != null)
            attachedSpawner.PickedUpPickup();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            PickUp(col.GetComponent<IMovement>());
        }
    }
}
