using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    public List<GameObject> pickups;
    public bool hasItem;
    public Pickup p;

    public void SpawnRandomPickup()
    {
        int rng = Random.Range(0, pickups.Count);
        p = Instantiate(pickups[rng], transform.position + transform.up, transform.rotation).GetComponent<Pickup>();
        p.attachedSpawner = this;
        hasItem = true;
    }

    public void PickedUpPickup()
    {
        Invoke("SpawnRandomPickup", 10f);
        hasItem = false;
    }
}
