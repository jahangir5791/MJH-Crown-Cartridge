using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem Instance { get; private set; }

    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/savegame.dat";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(SaveData data)
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                formatter.Serialize(stream, data);
            }
            Debug.Log($"Game saved to {savePath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save game: {e.Message}");
        }
    }

    public SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(savePath, FileMode.Open))
                {
                    SaveData data = formatter.Deserialize(stream) as SaveData;
                    Debug.Log("Game loaded successfully");
                    return data;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Failed to load game: {e.Message}");
            }
        }
        return null;
    }

    public bool HasSaveFile()
    {
        return File.Exists(savePath);
    }

    public void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save file deleted");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int playerScore;
    public int playerLevel;
    public float playerHealth;
    public Vector3 playerPosition;
    public List<string> unlockedWeapons;
    public Dictionary<string, int> resources;
    public List<string> completedQuests;

    public SaveData()
    {
        unlockedWeapons = new List<string>();
        resources = new Dictionary<string, int>();
        completedQuests = new List<string>();
    }
}
