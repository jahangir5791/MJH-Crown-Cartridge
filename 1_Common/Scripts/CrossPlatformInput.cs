using UnityEngine;

public class CrossPlatformInput : MonoBehaviour
{
    public static Vector2 GetInput()
    {
        if (PlatformDetector.IsMobile())
        {
            return GetTouchInput();
        }
        else
        {
            return GetPCInput();
        }
    }
    
    static Vector2 GetTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return new Vector2(touch.position.x, touch.position.y);
        }
        return Vector2.zero;
    }
    
    static Vector2 GetPCInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector2(x, y);
    }
    
    public static bool GetInputButton()
    {
        if (PlatformDetector.IsMobile())
        {
            return Input.touchCount > 0;
        }
        else
        {
            return Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
        }
    }
}
