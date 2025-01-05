using UnityEngine;

public class LockAspectRatio : MonoBehaviour
{
    public float targetAspectRatio = 4f / 3f; // Target aspect ratio set to 4:3

    void Start()
    {
        // Apply the aspect ratio lock when the game starts
        LockScreenRatio();
    }

    void Update()
    {
        // Continuously ensure the aspect ratio stays locked
        LockScreenRatio();
    }

    void LockScreenRatio()
    {
        // Get the current screen width and height
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        // Calculate the desired width based on the target aspect ratio
        float targetWidth = screenHeight * targetAspectRatio;

        // If the current width does not match the desired width, adjust it
        if (Mathf.Abs(screenWidth - targetWidth) > 1)
        {
            Screen.SetResolution((int)targetWidth, screenHeight, true);
        }
    }
}
