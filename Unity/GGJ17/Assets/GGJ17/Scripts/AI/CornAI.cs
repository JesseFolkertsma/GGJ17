using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornAI : MonoBehaviour {

    public Transform[] kernelsLocation;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < kernelsLocation.Length; i++)
        {
            Kernel sock = kernelsLocation[i].gameObject.AddComponent<Kernel>();
            sock.Heal(0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
