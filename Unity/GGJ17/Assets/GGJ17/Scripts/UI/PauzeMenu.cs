using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeMenu : MonoBehaviour {

    public void ExitToMenu()
    {
        GameManager.instance.ReturnToMenu();
    }

    public void Restart()
    {
        GameManager.instance.StartGame();
    }
}
