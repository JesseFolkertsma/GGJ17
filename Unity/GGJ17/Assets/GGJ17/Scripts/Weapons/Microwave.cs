﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corn.Pool;
using Corn.Components;

public class Microwave : MonoBehaviour, IWeapon {

    public int ammo;
    public int maxAmmo;
    private float range = 3;
    public float fireRate = .3f;
    public BulletPool pool;

    [SerializeField]
    Transform shootPoint;
    float cd = 0;

    public float Range
    {
        get
        {
            return range;
        }
    }

    public float CoolDownTime {
        get {
            return 1 / fireRate;
        }
    }

    void Start()
    {
        pool = PoolManager.Instance.GetPool("MicroPool") as BulletPool;
        //TestShoot();
    }

    void TestShoot()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            RaycastHit hit;
            Vector3 target = Vector3.zero;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
            {
                target = hit.point;
            }
            else
            {
                target = Camera.main.transform.position + Camera.main.transform.forward * range;
            }
            Shoot(target);
            yield return new WaitForSeconds(3f);
        }
    }

    public void Reload()
    {
        ammo = maxAmmo;
    }

    public bool Shoot(Vector3 target)
    {
        if (cd < Time.time)
        {
            cd = Time.time + 1 / fireRate;
            Vector3 dir = (target - shootPoint.position).normalized;
            BulletObject wave = pool.GetPooledObject() as BulletObject;
            wave.ShootBullet(shootPoint.position, Quaternion.LookRotation(dir));
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetLocation(Transform parent)
    {
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void SetWeapon (GameObject go)
    {
        throw new NotImplementedException();
    }
}
