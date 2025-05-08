using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GolfClubHit : MonoBehaviour
{
    [Tooltip("Impulse strength applied to the ball on hit.")]
    public float hitForce = 10f;

    // Last frame�s position, for computing swing direction
    private Vector3 _lastPosition;

    private void Start()
    {
        // Record initial position
        _lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // Update last position each physics step
        _lastPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Only act on the ball named "Golf"
        if (collision.gameObject.name != "Golf") return;

        // Get the ball's Rigidbody
        Rigidbody ballRb = collision.rigidbody;
        if (ballRb == null) return;

        // Compute swing direction based on club movement
        Vector3 swingDelta = transform.position - _lastPosition;
        Vector3 swingDir = swingDelta.normalized;

        // If there was essentially no movement, default to the club�s forward
        if (swingDir == Vector3.zero)
            swingDir = transform.forward;

        // Zero out any existing ball velocity (so even a tap sends it the same distance)
        ballRb.linearVelocity = Vector3.zero;

        // Apply a one-time impulse
        ballRb.AddForce(swingDir * hitForce, ForceMode.Impulse);
    }
}
