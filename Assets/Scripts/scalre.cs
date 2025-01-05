using UnityEngine;

public class ScaleObjectWithIntervals : MonoBehaviour
{
    private Vector3 originalScale; // The object's original scale
    [SerializeField] private float maxScale = 2.0f; // Maximum scale factor
    [SerializeField] private float interval = 0.2f; // Interval for scaling (e.g., 0.2)
    
    private void Start()
    {
        // Store the object's original scale
        originalScale = transform.localScale;
    }

    public void UpdateScale(float sliderValue)
    {
        // Map the slider value (0 to 1) to the range of intervals
        int numIntervals = Mathf.RoundToInt((maxScale - originalScale.x) / interval);
        float clampedValue = Mathf.Clamp(sliderValue, 0, 1);
        int intervalIndex = Mathf.RoundToInt(clampedValue * numIntervals);

        // Calculate the new scale
        float scaleMultiplier = originalScale.x + (interval * intervalIndex);

        // Clamp the scale to not exceed the maxScale
        scaleMultiplier = Mathf.Clamp(scaleMultiplier, originalScale.x, maxScale);

        // Apply the new scale to the object while preserving aspect ratio
        transform.localScale = originalScale * (scaleMultiplier / originalScale.x);
    }
}