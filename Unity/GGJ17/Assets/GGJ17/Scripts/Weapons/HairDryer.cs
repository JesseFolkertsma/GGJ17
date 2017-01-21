using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryer : MonoBehaviour, IWeapon {

    public int ammo;
    public int maxAmmo;
    public float range = 200;

    [SerializeField]
    Transform shootPoint;
    [SerializeField]
    GameObject radiationWave;

    void Start()
    {
        RaycastHit hit;
        Vector3 target = Vector3.zero;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range)){
            target = hit.point;
        }
        else
        {
            target = Camera.main.transform.position + Camera.main.transform.forward * range;
        }
        Shoot(target);
    }

    public void Reload()
    {
        ammo = maxAmmo;
    }

    public void Shoot(Vector3 target)
    {
        Debug.DrawLine(shootPoint.position, target, Color.red, 10f);
        Debug.Log("Shooting towards: " + target);
        Vector3 dir = (target - shootPoint.position).normalized;
        GameObject wave = Instantiate(radiationWave, shootPoint.position, Quaternion.LookRotation(dir));
    }
}
