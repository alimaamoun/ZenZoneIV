using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider))]
public class BuoyantWater : MonoBehaviour
{
    [Tooltip("Upward force applied to objects in the water.")]
    public float buoyancyForce = 10f;

    [Tooltip("Extra drag applied while in water.")]
    public float waterDrag = 5f;

    // Keeps track of original drag values
    private Dictionary<Rigidbody, float> originalDrags = new();

    private void Awake()
    {
        // Ensure the collider is set as a trigger
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
            if (!originalDrags.ContainsKey(rb))
            {
                originalDrags[rb] = rb.linearDamping;
                rb.linearDamping = waterDrag;
            }

            Debug.Log($"{other.name} entered water.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
            // Apply upward force while inside water
            Vector3 upwardForce = new Vector3(0f, buoyancyForce, 0f);
            rb.AddForce(upwardForce, ForceMode.Force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null && originalDrags.ContainsKey(rb))
        {
            rb.linearDamping = originalDrags[rb]; // Restore original drag
            originalDrags.Remove(rb);
        }

        Debug.Log($"{other.name} exited water.");
    }
}
