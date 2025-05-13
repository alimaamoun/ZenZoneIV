using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject m_ballPrefab;
    [SerializeField] GameObject m_baseballPrefab;
    [SerializeField] GameObject m_golfballPrefab;

    [SerializeField] Transform m_BaseballSpawnPosition;
    [SerializeField] Transform m_GolfballSpawnPosition;

    [SerializeField] int MaxSpawnCount = 2;
    int m_spawnCount;
    float m_spawnTime = 3f;

    List<GameObject> m_spawnList = new List<GameObject>();
    [SerializeField]Queue<GameObject> m_baseballspawnQueue = new Queue<GameObject>();
    [SerializeField]Queue<GameObject> m_golfballspawnQueue = new Queue<GameObject>();

    [SerializeField]bool m_isSpawningBaseball = false;
    [SerializeField]bool m_isSpawningGolf = false;

    [SerializeField] bool m_hasBaseball = false;
    [SerializeField] bool m_hasGolfball = false;

    [SerializeField] GameObject current_ball;


    private void OnEnable()
    {
        GolfClubHit.OnBaseballHit += SpawnBaseball;
        GolfClubHit.OnGolfBallHit += SpawnGolfBall;
    }
    private void OnDisable()
    {
        GolfClubHit.OnBaseballHit -= SpawnBaseball;
        GolfClubHit.OnGolfBallHit -= SpawnGolfBall;
    }

    private void Start()
    {
        m_hasBaseball = true;
        m_hasGolfball = true;

    }

    private void SpawnBaseball()
    {
        m_hasBaseball = false;

        m_ballPrefab = m_baseballPrefab;
        StartCoroutine(WaitSpawnBaseBall());
    }

    private void SpawnGolfBall()
    {
        m_hasGolfball = false;

        m_baseballPrefab = m_golfballPrefab;
        StartCoroutine(WaitSpawnGolfBall());

    }


    private IEnumerator WaitSpawnBaseBall()
    {
        //m_isSpawningBaseball = true;
        
        yield return new WaitForSeconds(m_spawnTime);

        if (!m_hasBaseball)
        {
            GameObject newBall = Instantiate(m_baseballPrefab, m_BaseballSpawnPosition.position, Quaternion.identity);
            m_baseballspawnQueue.Enqueue(newBall);
            m_spawnCount++;
            m_hasBaseball = true;
        }
        if (m_baseballspawnQueue.Count > MaxSpawnCount && m_baseballspawnQueue.TryDequeue(out var oldest))
        {
            Debug.LogWarning($"Oldest: {oldest}");
            Destroy(oldest);
        }

        m_isSpawningBaseball = false;
    }
    
    private IEnumerator WaitSpawnGolfBall()
    {
        //m_isSpawningBaseball = true;
        
        yield return new WaitForSeconds(m_spawnTime);

        if (!m_hasGolfball)
        {
            GameObject newBall = Instantiate(m_golfballPrefab, m_GolfballSpawnPosition.position, Quaternion.identity);
            m_golfballspawnQueue.Enqueue(newBall);
            m_spawnCount++;
            m_hasGolfball = true;
        }
        if (m_golfballspawnQueue.Count > MaxSpawnCount && m_golfballspawnQueue.TryDequeue(out var oldest))
        {
            Debug.LogWarning($"Oldest: {oldest}");
            Destroy(oldest);
        }

        m_isSpawningGolf = false;
    }

}
