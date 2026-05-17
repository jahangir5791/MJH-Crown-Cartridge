using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    [Header("UI Buttons")]
    public Button survivorShooterButton;
    public Button kingsReturnButton;
    public Button quitButton;

    [Header("Settings")]
    public string survivorShooterScene = "Level_Shooter_01";
    public string kingsReturnScene = "Level_King_Kingdom";

    void Start()
    {
        if (survivorShooterButton != null)
            survivorShooterButton.onClick.AddListener(PlaySurvivorShooter);

        if (kingsReturnButton != null)
            kingsReturnButton.onClick.AddListener(PlayKingsReturn);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);

        // অডিও ম্যানেজার চেক
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("AudioManager not found in scene!");
        }
    }

    public void PlaySurvivorShooter()
    {
        AudioManager.Instance?.PlaySFX("Button_Click");
        SceneLoader.Instance?.LoadScene(survivorShooterScene);
    }

    public void PlayKingsReturn()
    {
        AudioManager.Instance?.PlaySFX("Button_Click");
        SceneLoader.Instance?.LoadScene(kingsReturnScene);
    }

    public void QuitGame()
    {
        AudioManager.Instance?.PlaySFX("Button_Click");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
