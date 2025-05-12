using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject m_ballPrefab;
    [SerializeField] Transform m_spawnPosition;

    [SerializeField] int MaxSpawnCount;
    int m_spawnCount;
    float m_spawnTime = 3f;

    List<GameObject> m_spawnList = new List<GameObject>();
    Queue<GameObject> m_spawnQueue = new Queue<GameObject>();

    bool m_hasBall = true;

    [SerializeField] GameObject current_ball;


    private void OnEnable()
    {
        GolfClubHit.OnBallHit += WaitSpawnBall;
    }
    private void OnDisable()
    {
        GolfClubHit.OnBallHit -= WaitSpawnBall;
    }

    bool m_isSpawning = false;

    private void WaitSpawnBall()
    {
        // Only start a new spawn if we’re not already waiting for one
        if (!m_isSpawning)
            StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        m_isSpawning = true;
        m_hasBall = false;
        yield return new WaitForSeconds(m_spawnTime);

        if (m_spawnCount < MaxSpawnCount)
        {
            GameObject newBall = Instantiate(m_ballPrefab, m_spawnPosition.position, Quaternion.identity);
            m_spawnQueue.Enqueue(newBall);
            m_spawnCount++;
            m_hasBall = true;
        }
        else if (m_spawnQueue.TryDequeue(out var oldest))
        {
            Destroy(oldest);
            m_spawnCount--;
        }

        m_isSpawning = false;
    }


    private IEnumerator Waiting(float seconds)
    {
        yield return new WaitForSeconds(seconds);

    }
}
