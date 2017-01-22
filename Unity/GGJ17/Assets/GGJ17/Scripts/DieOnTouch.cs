using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnTouch : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ILives>() != null)
        {
            col.GetComponent<ILives>().lives = 0;
            col.GetComponent<ILives>().Die();
        }
    }
}
