using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    public GameObject[] Enemys;

    public GameObject AquireTarget (GameObject self) {

        float dist = 9999999;
        GameObject closest = null;
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i] != self)
            {
                float myDist = Vector3.Distance(Enemys[i].transform.position, self.transform.position);
                if (myDist < dist)
                {
                    dist = myDist;
                    closest = Enemys[i];
                }
            }
        }
        if(closest == null)
        {
            print("NO target!");
        }
        return closest;
    }

	void Awake ()
    {
        instance = this;

	}
}
