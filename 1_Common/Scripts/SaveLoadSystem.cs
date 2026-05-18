using UnityEngine;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    private string savePath;
    
    void Start()
    {
        savePath = Application.persistentDataPath + "/savegame.dat";
    }
    
    public void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
        Debug.Log("Game saved!");
    }
    
    public GameData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game loaded!");
            return data;
        }
        return new GameData();
    }
    
    public void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save deleted!");
        }
    }
}

[System.Serializable]
public class GameData
{
    public int playerLevel;
    public int score;
    public int currency;
    public bool isUnlocked;
    public string lastLevel;
}
