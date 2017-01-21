using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
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
        if (inArena)
        {
            LockCursor(true);
        }
    }

    public void LockCursor(bool state)
    {
        if (state)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnLevelWasLoaded()
    {
        if (inArena)
        {
            LockCursor(true);
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
        PauzeMenu.instance.gameObject.SetActive(true);
        LockCursor(false);
    }

    public void ContinueGame()
    {
        Debug.Log("Continueing game");
        gamePauzed = false;
        Time.timeScale = 1;
        PauzeMenu.instance.gameObject.SetActive(false);
        LockCursor(true);
    }

    public void StartGame(int buildI = 0)
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
