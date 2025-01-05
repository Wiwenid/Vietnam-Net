using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject; // The GameObject whose rotation will be followed

    private void Update()
    {
        if (targetObject != null)
        {
            // Update this object's rotation to match the target's rotation
            transform.rotation = targetObject.rotation;
        }
    }
}