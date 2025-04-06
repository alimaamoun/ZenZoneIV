using UnityEngine;

public class score : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem flash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            if (flash!= null)
            {
                flash.gameObject.SetActive(true);
                flash.Play();
                Debug.Log("Score!");
            }
            else
            {
                Debug.LogWarning("Particle effect not assigned on " + gameObject.name);
            }
        }
    }
}
