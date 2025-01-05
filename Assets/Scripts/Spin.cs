using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector3 rotationAxis = new Vector3(0, 1, 0); // Default to Y-axis
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the object continuously based on speed and axis
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}