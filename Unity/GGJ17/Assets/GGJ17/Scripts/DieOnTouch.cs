using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnTouch : MonoBehaviour {
    void OnTriggerEnter(Collider col)
    {
        if (col.attachedRigidbody.GetComponent<ILives>() != null)
        {
            col.attachedRigidbody.GetComponent<ILives>().Die();
        }
    }
}
