using UnityEngine;

public class portalLazer : MonoBehaviour
{
    [SerializeField] ParticleSystem lazerbeam;

    [SerializeField] Transform target;

    private void OnParticleCollision(GameObject other)
    {
        if (lazerbeam != null)
        {
            lazerbeam.gameObject.SetActive(true);

        }
        else
        {
            Debug.LogWarning("lazerbeam not assigned on " + name);
        }

        //Vector3 direction = transform.position - target.position;
        //direction.y = 0f;

        // Desired rotation to look at the player
        //Quaternion targetRot = Quaternion.LookRotation(direction);

        //// Smoothly rotate (you can also do instant: transform.rotation = targetRot;)
        //transform.rotation = Quaternion.RotateTowards(
        //    transform.rotation,
        //    targetRot,
        //    360f * Time.deltaTime
        //);

        // Hide (deactivate) all specified GameObjects
        lazerbeam.Play();
        
    }
}
