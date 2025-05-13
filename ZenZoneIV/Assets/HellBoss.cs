using UnityEngine;

public class HellBoss : MonoBehaviour
{
    [SerializeField]GameObject Carousel;

    private int gargoylesDestroyed = 0;

    private void OnEnable()
    {
        ParticleExplosionTrigger.OnGargoyleDestroy += OnGargoyleDestroyed;
    }    
    private void OnDisable()
    {
        ParticleExplosionTrigger.OnGargoyleDestroy -= OnGargoyleDestroyed;
    }

    private void OnGargoyleDestroyed()
    {
        if (gargoylesDestroyed < 3)
        {
            gargoylesDestroyed++;
        }
        if (gargoylesDestroyed >= 3)
        {
            SpawnPortal();
        }
    }
    private void SpawnPortal()
    {
        Carousel.SetActive(true);
    }

}
