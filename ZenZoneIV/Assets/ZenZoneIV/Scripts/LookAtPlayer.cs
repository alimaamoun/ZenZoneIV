using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [Tooltip("The Transform of the player to look at. If left empty, will try to find tag 'Player' on Start.")]
    public Transform player;

    [Tooltip("How quickly to rotate toward the player (degrees per second). Set to a high value for instant snapping.")]
    public float turnSpeed = 360f;

    void Start()
    {
        if (player == null)
        {
            var go = GameObject.FindGameObjectWithTag("Player");
            if (go != null) player = go.transform;
            else Debug.LogWarning($"{name}: No player assigned and no GameObject tagged 'Player' found.");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Compute direction to player, but zero out vertical difference
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.001f)
            return; // too close or directly above/below

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
