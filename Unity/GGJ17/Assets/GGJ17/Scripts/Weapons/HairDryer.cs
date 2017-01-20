using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryer : MonoBehaviour, IWeapon {

    public int ammo;
    public int maxAmmo;

    [SerializeField]
    Transform shootPoint;
    [SerializeField]
    GameObject radiationWave;

    public void Reload()
    {
        ammo = maxAmmo;
    }

    public void Shoot(Vector3 target)
    {
        Vector3 dir = (shootPoint.position - target).normalized;
        GameObject wave = Instantiate(radiationWave, shootPoint.position, Quaternion.identity);
        wave.transform.rotation.SetLookRotation(dir);
    }
}
