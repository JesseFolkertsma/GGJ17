using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {

    PickupSpawner[] pickups;

    void Start()
    {
        pickups = FindObjectsOfType<PickupSpawner>();
        foreach(PickupSpawner p in pickups)
        {
            p.SpawnRandomPickup();
        }
    }
}
