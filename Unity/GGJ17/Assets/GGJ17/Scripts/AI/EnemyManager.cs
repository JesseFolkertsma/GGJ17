﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    //public static EnemyManager instance;

    public GameObject[] Enemys;



    public int GetTeamLivesLeft (GameObject self)
    {
        int total = 0;
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i] != self)
            {
                total = Enemys[i].GetComponent<ILives>().respawnsLeft;
            }
        }
        if(total <= 0)
        {
            GameManager.instance.LoadVictoryScreen();
        }

        return total;
    }

    public GameObject AquireTarget (GameObject self) {

        float dist = 9999999;
        GameObject closest = null;
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i] != self)
            {
                if (!Enemys[i].GetComponent<ILives>().isDead)
                {
                    float myDist = Vector3.Distance(Enemys[i].transform.position, self.transform.position);
                    if (myDist < dist)
                    {
                        dist = myDist;
                        closest = Enemys[i];
                    }
                }
            }
        }
        if(closest == null)
        {
            print("NO target!");
        }
        return closest;
    }
    //public void Awake ()
    //{

    //}
}
