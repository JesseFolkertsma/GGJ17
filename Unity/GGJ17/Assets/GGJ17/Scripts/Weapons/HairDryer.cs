using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonAssets.Pool;

public class HairDryer : MonoBehaviour, IWeapon {

    public int ammo;
    public int maxAmmo;
    public float range = 200f;
    public float lifeTime = 20f;
    public BulletPool pool;

    [SerializeField]
    Transform shootPoint;

    void Start()
    {
        pool = PoolManager.Instance.GetPool("BulletPool") as BulletPool;
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

    public void Shoot(Vector3 target)
    {
        Vector3 dir = (target - shootPoint.position).normalized;
        BulletObject wave = pool.GetPooledObject() as BulletObject;
        wave.ShootBullet(shootPoint.position, Quaternion.LookRotation(dir), lifeTime);
    }
    
    public void SetLocation(Transform parent)
    {
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}
