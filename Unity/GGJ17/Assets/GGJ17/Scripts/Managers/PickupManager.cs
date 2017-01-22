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
    public GameObject GetPickUp (Type wanted, GameObject self)
    {
        Debug.Log(pickups);
        Debug.Log(wanted);
        float dist = 99999;
        GameObject obj = null;

        for (int i = 0; i < pickups.Length; i++)
        {
            Debug.Log(pickups[i].p.GetType());
            if (pickups[i].p.GetType() == wanted)
            {
                var mydist = Vector3.Distance(self.transform.position, pickups[i].transform.position);
                if(mydist < dist)
                {
                    dist = mydist;
                    obj = pickups[i].gameObject;
                }
            }
        }
        return obj;
    }
}
