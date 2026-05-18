using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Launching on platform: " + PlatformDetector.GetPlatformName());
        
        // Auto-load game launcher after splash
        Invoke("LoadGameLauncher", 2f);
    }
    
    void LoadGameLauncher()
    {
        SceneManager.LoadScene("GameLauncher");
    }
}
