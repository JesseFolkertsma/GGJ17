using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonAssets.Pool;

public class BulletObject : BasePoolObject {

    public float speed = 2;
    public float timer;

    public void ShootBullet(Vector3 pos, Quaternion rot, float lifeTime)
    {
        SetEnable();
        transform.position = pos;
        transform.rotation = rot;
        Invoke("SetDisable", lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Kernel>())
            col.GetComponent<Kernel>().lives = 0;
        else
            Destroy(gameObject);
    }
}
