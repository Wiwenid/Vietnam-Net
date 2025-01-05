using UnityEngine;

public class FollowRotationWithDamping : MonoBehaviour
{
    public Transform targetObject; // Object to follow
    public float damping = 5.0f; // Damping speed for smooth rotation

    private void Update()
    {
        if (targetObject != null)
        {
            Quaternion targetRotation = targetObject.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * damping);
        }
    }
}