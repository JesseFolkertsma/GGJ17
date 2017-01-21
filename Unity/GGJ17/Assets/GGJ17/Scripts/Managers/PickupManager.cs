using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {

    Pickup[] pickups;

    void Start()
    {
        pickups = FindObjectsOfType<Pickup>();
    }
}
