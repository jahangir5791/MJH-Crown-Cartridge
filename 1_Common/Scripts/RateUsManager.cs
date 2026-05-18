using UnityEngine;

public class RateUsManager : MonoBehaviour
{
    private int gameSessions = 0;
    private const int sessionsBeforePrompt = 5;
    
    public void OnGameSession()
    {
        gameSessions++;
        
        if (gameSessions >= sessionsBeforePrompt)
        {
            ShowRateUsDialog();
        }
    }
    
    void ShowRateUsDialog()
    {
        #if UNITY_ANDROID
            Application.OpenURL("market://details?id=" + Application.bundleIdentifier);
        #elif UNITY_IOS
            Application.OpenURL("itms-apps://itunes.apple.com/app/id" + Application.bundleIdentifier);
        #else
            Debug.Log("Rate us dialog for desktop");
        #endif
    }
    
    public void RateLater()
    {
        // Do nothing, user will be asked again later
    }
    
    public void NoThanks()
    {
        gameSessions = 0; // Reset so they won't be asked again
    }
}
