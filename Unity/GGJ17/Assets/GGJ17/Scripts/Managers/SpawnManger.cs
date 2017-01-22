using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour {

    public static SpawnManger instance;
    public Transform[] spawnLocations;
    int lastIndex = 0;


    public Transform GetSpawnLocation ()
    {
        if(lastIndex >= spawnLocations.Length)
        {
            lastIndex = 0;
        }
        for (int i = lastIndex; i < spawnLocations.Length; i++)
        {

        }

        return null;
    }

}
