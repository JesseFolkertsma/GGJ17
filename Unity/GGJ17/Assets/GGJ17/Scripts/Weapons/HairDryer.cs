using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonAssets.Pool;

public class HairDryer : MonoBehaviour, IWeapon {

    public int ammo;
    public int maxAmmo;
    public float range = 200;
    public BulletPool pool;

    [SerializeField]
    Transform shootPoint;
    [SerializeField]
    GameObject radiationWave;

    void Start()
    {
        pool = PoolManager.Instance.GetPool("BulletPool") as BulletPool;
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
            yield return new WaitForSeconds(1f);
        }
    }

    public void Reload()
    {
        ammo = maxAmmo;
    }

    public void Shoot(Vector3 target)
    {
        Debug.DrawLine(shootPoint.position, target, Color.red, 10);
        Debug.Log("Shooting towards: " + target);
        Vector3 dir = (target - shootPoint.position).normalized;
        BulletObject wave = pool.GetPooledObject() as BulletObject;
        wave.ShootBullet(shootPoint.position, Quaternion.LookRotation(dir));
    }
}
