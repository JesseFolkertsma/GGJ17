using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuButtons;
    public GameObject levelSelect;

    public void StartGame(int i)
    {
        GameManager.instance.StartGame(i);
    }

    public void ChooseLevel()
    {
        mainMenuButtons.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Back()
    {
        mainMenuButtons.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void ExitGame()
    {
        GameManager.instance.QuitGame();
    }
}
