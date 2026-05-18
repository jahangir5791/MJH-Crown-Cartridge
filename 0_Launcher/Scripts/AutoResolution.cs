using UnityEngine;

public class AutoResolution : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, true);
        
        var canvas = GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.scaleFactor = Screen.width / 1920f;
            canvas.referenceResolution = new Vector2(1920, 1080);
        }
    }
}
