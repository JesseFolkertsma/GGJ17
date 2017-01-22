using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeMenu : MonoBehaviour {

    public static PauzeMenu instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.SetActive(false);
    }

    public void ExitToMenu()
    {
        GameManager.instance.ReturnToMenu();
    }

    public void Restart()
    {
        GameManager.instance.ContinueGame();
        GameManager.instance.RestartGame();
    }
}
