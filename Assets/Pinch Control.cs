using Leap;
using UnityEngine;

public class PinchRotateObject : MonoBehaviour
{
    public GameObject targetObject; // Object to rotate
    public GameObject scaleTargetObject; // Object to scale
    public float rotationSpeed = 1.0f; // Adjustable rotation speed
    public float scalingSpeed = 0.1f; // Adjustable scaling speed
    private bool isPinching = false;
    private Vector3 lastPinchPosition;

    private void Update()
    {
        Hand hand = Hands.Provider.GetHand(Chirality.Left) ?? Hands.Provider.GetHand(Chirality.Right);

        if (hand != null)
        {
            if (hand.PinchStrength > 0.8f)
            {
                HandlePinchRotation(hand);
            }
            else
            {
                isPinching = false;
            }

            if (hand.IsPinching())
            {
                HandlePinchZoom(hand);
            }
        }
    }

    private void HandlePinchRotation(Hand hand)
    {
        Vector3 currentPinchPosition = hand.GetPinchPosition();

        if (!isPinching)
        {
            isPinching = true;
            lastPinchPosition = currentPinchPosition;
        }

        Vector3 movementDelta = currentPinchPosition - lastPinchPosition;

        float rotationX = -movementDelta.y * rotationSpeed;
        float rotationY = movementDelta.x * rotationSpeed;

        targetObject.transform.Rotate(rotationX, rotationY, 0, Space.World);

        lastPinchPosition = currentPinchPosition;
    }

    private void HandlePinchZoom(Hand hand)
    {
        float distance = hand.PinchStrength; // Adjusted to use PinchStrength for scaling
        scaleTargetObject.transform.localScale += Vector3.one * (distance * scalingSpeed * Time.deltaTime);
    }
}