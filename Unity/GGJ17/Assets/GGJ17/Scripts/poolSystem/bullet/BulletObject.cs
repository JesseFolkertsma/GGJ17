using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonAssets.Pool;

public class BulletObject : BasePoolObject {

    public float speed = 2;

    public void ShootBullet(Vector3 pos, Quaternion rot)
    {
        SetEnable();
        transform.position = pos;
        transform.rotation = rot;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Kernel")
        {
            col.GetComponent<Kernel>().PopKernel();
        }
    }
}
