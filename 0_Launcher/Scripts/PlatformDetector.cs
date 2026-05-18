using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    public static bool IsMobile()
    {
        return Application.isMobilePlatform;
    }
    
    public static bool IsAndroid()
    {
        return Application.platform == RuntimePlatform.Android;
    }
    
    public static bool IsIOS()
    {
        return Application.platform == RuntimePlatform.IPhonePlayer;
    }
    
    public static bool IsWindows()
    {
        return Application.platform == RuntimePlatform.WindowsPlayer ||
               Application.platform == RuntimePlatform.WindowsEditor;
    }
    
    public static bool IsMac()
    {
        return Application.platform == RuntimePlatform.OSXPlayer ||
               Application.platform == RuntimePlatform.OSXEditor;
    }
    
    public static bool IsLinux()
    {
        return Application.platform == RuntimePlatform.LinuxPlayer ||
               Application.platform == RuntimePlatform.LinuxEditor;
    }
    
    public static bool IsWebGL()
    {
        return Application.platform == RuntimePlatform.WebGLPlayer;
    }
    
    public static string GetPlatformName()
    {
        if (IsAndroid()) return "Android";
        if (IsIOS()) return "iOS";
        if (IsWindows()) return "Windows";
        if (IsMac()) return "macOS";
        if (IsLinux()) return "Linux";
        if (IsWebGL()) return "WebGL";
        return "Unknown";
    }
}
