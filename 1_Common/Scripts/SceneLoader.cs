using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private float minimumLoadTime = 1f;
    private AsyncOperation asyncOperation;

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

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        LoadScene(currentScene);
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // লোডিং স্ক্রিন দেখান
        UIManager.Instance?.ShowLoadingScreen(true);
        
        float startTime = Time.time;
        
        // সিন লোড শুরু করুন
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        
        // লোডিং প্রগ্রেস দেখান
        while (asyncOperation.progress < 0.9f)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            // এখানে প্রগ্রেস বার আপডেট করতে পারেন
            yield return null;
        }
        
        // নূন্যতম লোডিং টাইম পার হয়েছে কিনা চেক করুন
        float elapsedTime = Time.time - startTime;
        if (elapsedTime < minimumLoadTime)
        {
            yield return new WaitForSeconds(minimumLoadTime - elapsedTime);
        }
        
        // সিন এক্টিভেট করুন
        asyncOperation.allowSceneActivation = true;
        
        // লোডিং স্ক্রিন লুকান
        UIManager.Instance?.ShowLoadingScreen(false);
    }

    public float GetLoadingProgress()
    {
        if (asyncOperation != null)
        {
            return Mathf.Clamp01(asyncOperation.progress / 0.9f);
        }
        return 0f;
    }
}
