using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    #region GameStats
    [Header ("GameStats")]
    public int totalPops;
    #endregion

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
    }

    public void PauzeGame()
    {

    }

    public void StartGame()
    {

    }

    public void EndGame()
    {

    }
}
