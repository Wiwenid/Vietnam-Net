using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject; // The object to orbit around
    [SerializeField]
    private float rotationSpeed = 5f;   // Speed of rotation
    [SerializeField]
    private float zoomSpeed = 10f;      // Speed of zooming
    [SerializeField]
    private float damping = 5f;         // Damping factor for smooth transitions
    [SerializeField]
    private float minZoomDistance = 2f; // Minimum zoom distance
    [SerializeField]
    private float maxZoomDistance = 50f; // Maximum zoom distance

    private float targetZoomDistance; // Distance between the camera and the object
    private Vector3 targetEulerAngles; // Target rotation stored as Euler angles
    private Vector3 currentEulerAngles; // Current rotation
    private bool isRotating = false;

    private void Start()
    {
        // Initialize the target values
        if (targetObject != null)
        {
            targetZoomDistance = Vector3.Distance(transform.position, targetObject.position);
            targetEulerAngles = transform.eulerAngles;
            currentEulerAngles = targetEulerAngles;
        }
        else
        {
            Debug.LogError("Target Object is not assigned!");
        }
    }

    private void Update()
    {
        // Rotate the camera around the target object with left mouse button
        if (Input.GetMouseButtonDown(0)) 
        {
            isRotating = true;
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float deltaX = Input.GetAxis("Mouse X") * rotationSpeed;
            float deltaY = -Input.GetAxis("Mouse Y") * rotationSpeed;

            // Adjust target rotation based on mouse movement
            targetEulerAngles.y += deltaX;
            targetEulerAngles.x += deltaY;
        }

        // Zoom in and out using the scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            targetZoomDistance -= scroll * zoomSpeed;
            targetZoomDistance = Mathf.Clamp(targetZoomDistance, minZoomDistance, maxZoomDistance);
        }

        // Apply damping for smooth camera movement
        currentEulerAngles = Vector3.Lerp(currentEulerAngles, targetEulerAngles, Time.deltaTime * damping);
        transform.rotation = Quaternion.Euler(currentEulerAngles);

        // Move the camera towards the target object
        Vector3 direction = transform.rotation * Vector3.back;
        transform.position = Vector3.Lerp(
            transform.position, 
            targetObject.position - direction * targetZoomDistance, 
            Time.deltaTime * damping
        );

        // Ensure the camera always looks at the target
        transform.LookAt(targetObject.position);
    }
}
