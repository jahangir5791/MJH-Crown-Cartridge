using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    public GameObject pauseMenu;
    public GameObject loadingScreen;
    public Text scoreText;
    public Text levelText;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ShowPauseMenu()
    {
        if (pauseMenu != null) pauseMenu.gameObject.SetActive(true);
    }
    
    public void HidePauseMenu()
    {
        if (pauseMenu != null) pauseMenu.gameObject.SetActive(false);
    }
    
    public void ShowLoading()
    {
        if (loadingScreen != null) loadingScreen.gameObject.SetActive(true);
    }
    
    public void HideLoading()
    {
        if (loadingScreen != null) loadingScreen.gameObject.SetActive(false);
    }
    
    public void UpdateScore(int score)
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }
    
    public void UpdateLevel(int level)
    {
        if (levelText != null) levelText.text = "Level: " + level;
    }
}
