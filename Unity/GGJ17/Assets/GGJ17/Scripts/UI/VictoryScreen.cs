using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour {

    public GameObject win;
    public GameObject lose;

    void Start()
    {
        if (GameManager.instance.hasWon)
        {
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameManager.instance.ReturnToMenu();
        }
    }
}
