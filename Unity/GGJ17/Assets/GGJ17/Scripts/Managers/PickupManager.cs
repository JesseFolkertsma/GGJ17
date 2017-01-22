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
        Debug.Log(pickups);
        Debug.Log(wanted);

        for (int i = 0; i < pickups.Length; i++)
        {
            Debug.Log(pickups[i].p.GetType());
            if (pickups[i].p.GetType() == wanted)
            {
                return pickups[i].gameObject;
            }
        }
        return null;
    }
}
