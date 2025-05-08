using UnityEngine;

public class BallReset : MonoBehaviour
{
    [Tooltip("When ball's y-position equals this value, it will reset.")]
    [SerializeField] private int resetYValue = 0;

    private Vector3 _startPosition;

    private void Start()
    {
        // Cache the ball's original position when the scene loads
        _startPosition = transform.position;
    }

    private void Update()
    {
        // Check if the ball's Y position has become exactly the serialized integer
        if (transform.position.y <= resetYValue)
        {
            // Reset back to the original position
            transform.position = _startPosition;
            // If the ball has physics, also zero out any velocity:
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
