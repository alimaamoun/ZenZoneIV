using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CarouselManager : MonoBehaviour
{
    public Transform centerPoint; // The central point of the carousel
    public float radius = 3f;
    public Transform[] cards; // Array of card transforms

    public Transform player;

    public float currentAngleOffset = 0f; // Rotation offset in degrees
    public float spinVelocity = 0f;       // Angular velocity (degrees per second)
    public float friction = 2f;           // Damping factor

    void Start()
    {
        ArrangeCards();
    }

    void Update()
    {
        // Apply momentum and friction if the carousel is spinning
        if (Mathf.Abs(spinVelocity) > 0.01f || true)
        {
            currentAngleOffset += spinVelocity * Time.deltaTime;
            spinVelocity = Mathf.Lerp(spinVelocity, 0f, friction * Time.deltaTime);
            ArrangeCards();
        }
    }

    // Calculate and update positions of each card
    public void ArrangeCards()
    {
        int cardCount = cards.Length;
        for (int i = 0; i < cardCount; i++)
        {
            float angleDeg = currentAngleOffset + (360f / cardCount) * i;
            float angleRad = angleDeg * Mathf.Deg2Rad;
            Vector3 pos = centerPoint.position + new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad)) * radius;
            cards[i].position = pos;
            // Optionally, have each card face the center
            cards[i].rotation = new Quaternion(0,1,0,0f);
        }
    }

    // Called when dragging to update the rotation
    public void OnDrag(float deltaAngle)
    {
        currentAngleOffset += deltaAngle;
        ArrangeCards();
    }

    // Called on drag release to set flick momentum
    public void OnRelease(float flickVelocity)
    {
        spinVelocity = flickVelocity;
    }
}
