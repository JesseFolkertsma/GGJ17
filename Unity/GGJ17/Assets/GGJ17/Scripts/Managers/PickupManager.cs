using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {

    PickupSpawner[] pickups;
    public static PickupManager instance;

    void Awake ()
    {
        instance = this;

        pickups = FindObjectsOfType<PickupSpawner>();
        foreach (PickupSpawner p in pickups)
        {
            p.SpawnRandomPickup();
        }
    }
    public GameObject GetPickUp (Type wanted)
    {
        for (int i = 0; i < pickups.Length; i++)
        {
            if(pickups[i].GetType() == wanted)
            {
                return pickups[i].gameObject;
            }
        }
        return null;
    }
}
