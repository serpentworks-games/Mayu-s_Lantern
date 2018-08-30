using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Sirenix.OdinInspector;

public class GameController : MonoBehaviour
{


    [TabGroup("Saved Player Data")]
    public PlayerData savedPlayerData = new PlayerData();
    [TabGroup("Local Copy of Data")]
    public PlayerData localCopyOfData;

    public bool isSceneBeingLoaded = false;
    public bool inputEnabled;

    public ResettableScriptableObject[] resettableScriptableObjects;

    public static GameController instance;

    float timer;
    float resetTimer = 3.5f;
    AreaController levelController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        } else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    [ButtonGroup("SaveLoad")]
    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
        {
            Directory.CreateDirectory("Saves");
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/saveFile.binary");
        localCopyOfData = PlayerController.instance.localPlayerData;

        bf.Serialize(saveFile, localCopyOfData);

        saveFile.Close();
    }

    [ButtonGroup("SaveLoad")]
    public void LoadData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/saveFile.binary", FileMode.Open);
        localCopyOfData = (PlayerData)bf.Deserialize(saveFile);

        saveFile.Close();
    }


    public void ResetLevel()
    {
        timer += Time.deltaTime;

        if (timer >= resetTimer)
        {
            LoadData();
            levelController.ResetLevelData();
        }

    }

    void ResetGameData()
    {
        for (int i = 0; i < resettableScriptableObjects.Length; i++)
        {
            resettableScriptableObjects[i].Reset();
        }
    }
}
