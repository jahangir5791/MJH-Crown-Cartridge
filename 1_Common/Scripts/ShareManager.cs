using UnityEngine;
using UnityEngine.ScreenCapture;

public class ShareManager : MonoBehaviour
{
    public void ShareScreenshot()
    {
        ScreenCapture.CaptureScreenshot("screenshot.png");
        
        string path = Application.persistentDataPath + "/screenshot.png";
        
        #if UNITY_ANDROID || UNITY_IOS
            Invoke("ShareNative", 0.5f);
        #else
            Debug.Log("Screenshot saved to: " + path);
        #endif
    }
    
    void ShareNative()
    {
        #if UNITY_ANDROID
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", "android.intent.action.SEND");
            intent.Call<AndroidJavaObject>("setType", "image/*");
            currentActivity.Call("startActivity", intent);
        #elif UNITY_IOS
            // iOS share kit integration here
            Debug.Log("iOS share invoked");
        #endif
    }
}
