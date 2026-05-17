using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public GameState currentState = GameState.Menu;
    public int currentScore = 0;
    public int currentLevel = 1;

    [Header("Events")]
    public event Action<GameState> OnGameStateChanged;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnLevelChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadGameData();
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        OnGameStateChanged?.Invoke(newState);
        Debug.Log($"Game State Changed to: {newState}");
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        OnScoreChanged?.Invoke(currentScore);
        
        // লেভেল চেক (প্রতি 1000 স্কোরে লেভেল বাড়ে)
        int newLevel = (currentScore / 1000) + 1;
        if (newLevel > currentLevel)
        {
            currentLevel = newLevel;
            OnLevelChanged?.Invoke(currentLevel);
        }
    }

    public void SaveGameData()
    {
        PlayerPrefs.SetInt("Score", currentScore);
        PlayerPrefs.SetInt("Level", currentLevel);
        PlayerPrefs.Save();
    }

    void LoadGameData()
    {
        currentScore = PlayerPrefs.GetInt("Score", 0);
        currentLevel = PlayerPrefs.GetInt("Level", 1);
    }

    public void ResetGame()
    {
        currentScore = 0;
        currentLevel = 1;
        SaveGameData();
    }
}

public enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver,
    Victory
}
