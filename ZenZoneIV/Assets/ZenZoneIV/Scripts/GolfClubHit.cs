using System;
using UnityEngine;
using UnityEngine.Events;
using XRMultiplayer;

[RequireComponent(typeof(Collider))]
public class GolfClubHit : MonoBehaviour
{
    [Tooltip("Impulse strength applied to the ball on hit.")]
    public float hitForce = 10f;

    // Last frame�s position, for computing swing direction
    private Vector3 lastPosition;

    public static event Action OnGolfBallHit;
    public static event Action OnBaseballHit;

    bool hasCollision = false;
    Vector3 collisionPoint;


    private void Start()
    {
        // Record initial position
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // Update last position each physics step
        lastPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Only act on the ball named "Golf"
        if (collision.gameObject.tag == "golf")
        {
            OnGolfBallHit?.Invoke();
            hasCollision = true;
        }
        else if (collision.gameObject.CompareTag("baseball"))
        {
            OnBaseballHit?.Invoke();
            hasCollision = true;
        }
        else if (collision.gameObject.CompareTag("hockey"))
        {
            //OnBaseballHit?.Invoke();
            hasCollision = true;
        }
        else return;
        
        // Get the ball's Rigidbody
        Rigidbody ballRb = collision.rigidbody;
        if (ballRb == null) return;

        // Compute swing direction based on club movement
        //Vector3 swingDelta = transform.position - lastPosition;
        //Vector3 swingDir = swingDelta.normalized;
        collisionPoint = collision.contacts[0].point;

        // 1) Approach direction
        Vector3 swingDir = collision.relativeVelocity.normalized;

        // If there was essentially no movement, default to the club�s forward
        if (swingDir == Vector3.zero)
            swingDir = transform.forward;

        // Zero out any existing ball velocity (so even a tap sends it the same distance)
        ballRb.linearVelocity = Vector3.zero;

        // Apply a one-time impulse
        ballRb.AddForce(swingDir * hitForce, ForceMode.Impulse);

        //collision.rigidbody.gameObject.GetComponent<Projectile>
    }

    private void OnDrawGizmos()
    {
        if (!hasCollision) return;

        // draw the sphere
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(collisionPoint, .3f);

        hasCollision = false;
    }
}



