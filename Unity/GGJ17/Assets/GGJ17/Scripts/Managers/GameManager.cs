using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject pauzecanvas;
    public bool inArena = false;
    bool gamePauzed = false;

    #region GameStats
    [Header ("GameStats")]
    public int totalPops;
    #endregion

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnLevelWasLoaded()
    {
        if (inArena)
        {
            if (pauzecanvas == null)
            {
                pauzecanvas = FindObjectOfType<PauzeMenu>().gameObject;
                pauzecanvas.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (inArena)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (!gamePauzed)
                {
                    PauzeGame();
                }
                else
                {
                    ContinueGame();
                }
            }
        }
    }

    public void PauzeGame()
    {
        Debug.Log("Game pauzed");
        gamePauzed = true;
        Time.timeScale = 0;
        pauzecanvas.SetActive(true);
    }

    public void ContinueGame()
    {
        Debug.Log("Continueing game");
        gamePauzed = false;
        Time.timeScale = 1;
        pauzecanvas.SetActive(false);
    }

    public void StartGame(int buildI = 1)
    {
        Debug.Log("Starting Arena " + buildI);
        inArena = true;
        SceneManager.LoadScene(buildI);
    }

    public void EndGame()
    {
        Debug.Log("Ending game");
    }

    public void ReturnToMenu()
    {
        Debug.Log("Returning to menu");
        inArena = false;
        SceneManager.LoadScene(0);
    }
}
