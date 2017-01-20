using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour {


    public void SaveGame()
    {
        SaveFile file = new SaveFile();

        XmlSerializer serializer = new XmlSerializer(typeof(SaveFile));

        #region Override or new file
        if (File.Exists(Application.persistentDataPath + "/_SaveGame.xml"))
            Debug.Log("Overwriting file");
        else
            Debug.Log("Creating new file");
        #endregion

        Debug.Log("Saving to: " + Application.persistentDataPath + "/_SaveGame.xml");
        FileStream stream = new FileStream(Application.persistentDataPath + "/_SaveGame.xml", FileMode.Create);
        serializer.Serialize(stream, file);
        stream.Close();
        Debug.Log("Saved Game!");
    }

    public SaveFile LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/_SaveGame.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SaveFile));
            FileStream stream = new FileStream(Application.persistentDataPath + "/_SaveGame.xml", FileMode.Open);
            SaveFile file = serializer.Deserialize(stream) as SaveFile;
            stream.Close();

            Debug.Log("SaveFile found!");
            return file;
        }
        else
        {
            Debug.LogWarning("SaveFile not found, returing null.");
            return null;
        }
    }
}
