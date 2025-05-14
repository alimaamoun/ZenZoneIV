using UnityEngine;
using System.Collections.Generic;
public class score : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem flash;
    [SerializeField]
    //private List<string> Tags;/**/


    private void OnTriggerEnter(Collider other)
    {

            if (other.CompareTag("baseball") || other.CompareTag("golf") || other.CompareTag("hockey"))
            {
                if (flash != null)
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
