using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour {

    public static SpawnManger instance;
    public Transform[] spawnLocations;
    int lastIndex = 0;

    public void Awake ()
    {
        instance = this;
    }

    public void Respawn (ILives life)
    {
        lastIndex++;
        if(lastIndex >= spawnLocations.Length)
        {
             lastIndex = 0;
        }
        StartCoroutine(waitAndSpawn(spawnLocations[lastIndex], life));
    }
    public IEnumerator waitAndSpawn (Transform loc, ILives live)
    {
        yield return new WaitForSeconds(5);
        live.Respawn(loc);

    }

}
