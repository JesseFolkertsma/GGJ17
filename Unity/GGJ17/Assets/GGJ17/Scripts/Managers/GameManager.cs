using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public SaveLoadSystem saveLoadSystem;

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

        saveLoadSystem = new SaveLoadSystem();
    }

    #region Saving
    public SaveFile file;

    public static void SaveGame()
    {
        instance.saveLoadSystem.SaveGame();
    }

    public static bool LoadGame()
    {
        instance.file = null;
        instance.file = instance.saveLoadSystem.LoadGame();

        if (instance.file != null)
            return true;
        else
            return false;

    }
    #endregion
}
