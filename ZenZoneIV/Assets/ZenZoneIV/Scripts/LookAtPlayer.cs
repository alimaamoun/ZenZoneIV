using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [Tooltip("The Transform of the player to look at. If left empty, will try to find tag 'Player' on Start.")]
    public Transform player;

    [Tooltip("How quickly to rotate toward the player (degrees per second). Set to a high value for instant snapping.")]
    public float turnSpeed = 360f;

    void Update()
    {
        if (player == null) return;

        // Compute direction to player, but zero out vertical difference
        Vector3 direction = transform.position - player.position;
        direction.y = 0f;

        // Desired rotation to look at the player
        Quaternion targetRot = Quaternion.LookRotation(direction);

        // Smoothly rotate (you can also do instant: transform.rotation = targetRot;)
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRot,
            turnSpeed * Time.deltaTime
        );
    }
}
