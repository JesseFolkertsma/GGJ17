using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {
    public Text text;

    void Start()
    {
        if (GameManager.instance.hasWon)
        {
            text.text = "Victory!";
        }
        else
        {
            text.text = "Defeat";
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
