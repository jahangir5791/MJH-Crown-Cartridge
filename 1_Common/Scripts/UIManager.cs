using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject pauseMenuPanel;
    public GameObject settingsPanel;
    public GameObject gameOverPanel;
    public GameObject loadingScreen;

    [Header("HUD Elements")]
    public Text scoreText;
    public Text levelText;
    public Slider healthSlider;
    public Text ammoText;

    [Header("Settings UI")]
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;

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
        InitializeUI();
        SubscribeToEvents();
    }

    void InitializeUI()
    {
        // সব প্যানেল বন্ধ করে দিন
        HideAllPanels();
        mainMenuPanel?.SetActive(true);

        // সেটিংস স্লাইডার সেটআপ
        if (bgmSlider != null && AudioManager.Instance != null)
        {
            bgmSlider.value = AudioManager.Instance.bgmVolume;
            bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        }
        if (sfxSlider != null && AudioManager.Instance != null)
        {
            sfxSlider.value = AudioManager.Instance.sfxVolume;
            sfxSlider.onValueChanged.AddListener(OnSFXChanged);
        }
    }

    void SubscribeToEvents()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged += UpdateScoreUI;
            GameManager.Instance.OnLevelChanged += UpdateLevelUI;
            GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        }
    }

    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    public void UpdateLevelUI(int level)
    {
        if (levelText != null)
            levelText.text = $"Level: {level}";
    }

    public void UpdateHealthUI(float currentHealth, float maxHealth)
    {
        if (healthSlider != null)
            healthSlider.value = currentHealth / maxHealth;
    }

    public void UpdateAmmoUI(int currentAmmo, int maxAmmo)
    {
        if (ammoText != null)
            ammoText.text = $"{currentAmmo} / {maxAmmo}";
    }

    public void ShowPanel(GameObject panel)
    {
        HideAllPanels();
        if (panel != null)
            panel.SetActive(true);
    }

    public void HideAllPanels()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (pauseMenuPanel != null) pauseMenuPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void ShowLoadingScreen(bool show)
    {
        if (loadingScreen != null)
            loadingScreen.SetActive(show);
    }

    void OnGameStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Playing:
                HideAllPanels();
                break;
            case GameState.Paused:
                ShowPanel(pauseMenuPanel);
                break;
            case GameState.GameOver:
                ShowPanel(gameOverPanel);
                break;
            case GameState.Menu:
                ShowPanel(mainMenuPanel);
                break;
        }
    }

    void OnBGMChanged(float value)
    {
        AudioManager.Instance?.SetBGMVolume(value);
    }

    void OnSFXChanged(float value)
    {
        AudioManager.Instance?.SetSFXVolume(value);
    }

    public void OnResumeButton()
    {
        GameManager.Instance?.ChangeState(GameState.Playing);
        Time.timeScale = 1f;
    }

    public void OnRestartButton()
    {
        Time.timeScale = 1f;
        SceneLoader.Instance?.ReloadScene();
    }

    public void OnMainMenuButton()
    {
        Time.timeScale = 1f;
        GameManager.Instance?.ResetGame();
        SceneLoader.Instance?.LoadScene("GameLauncher");
    }
}
