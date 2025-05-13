using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(BoxCollider))]
public class ParticleExplosionTrigger : MonoBehaviour
{
    [Header("Explosion Effect")]
    [Tooltip("ParticleSystem to play when a particle enters this trigger.")]
    [SerializeField]
    private GameObject explosionEffect;

    [Header("Objects to Hide")]
    [Tooltip("All these GameObjects will be deactivated when triggered.")]
    [SerializeField]
    private List<GameObject> objectsToHide = new List<GameObject>();

    public static event Action OnGargoyleDestroy;

    private void Reset()
    {
        // Ensure BoxCollider exists and is set up correctly for particle collisions
        var col = GetComponent<BoxCollider>();
        col.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        // Play the explosion effect at this GameObject's position
        if (explosionEffect != null)
        {
            explosionEffect.SetActive(true);
        }
        else
        {
            Debug.LogWarning("ExplosionEffect not assigned on " + name);
        }

        // Hide (deactivate) all specified GameObjects
        foreach (var go in objectsToHide)
        {
            if (go != null)
                go.SetActive(false);
        }
        OnGargoyleDestroy?.Invoke();
    }
}
