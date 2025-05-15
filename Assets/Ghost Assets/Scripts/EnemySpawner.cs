using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public ARPlaneManager planeManager;

    private bool spawned = false;

    void Update()
    {
        if (!spawned)
        {
            foreach (var plane in planeManager.trackables)
            {
                Vector2 planeSize = plane.size; // width and height
                float area = planeSize.x * planeSize.y;

                if (area >= 1.0f) // at least 1m x 1m
                {
                    spawned = true;
                    StartCoroutine(SpawnEnemiesOverTime(plane));
                    break;
                }
            }
        }
    }

    IEnumerator SpawnEnemiesOverTime(ARPlane plane)
    {
        for (int i = 0; i < 10; i++) // spawn 10 enemies for example
        {
            SpawnEnemyAtRandomPosition(plane);
            yield return new WaitForSeconds(3f); // 3 second delay
        }
    }

    void SpawnEnemyAtRandomPosition(ARPlane plane)
    {
        Vector2 planeSize = plane.size;
        Vector3 center = plane.center;

        // Random offset inside plane bounds
        float xOffset = Random.Range(-planeSize.x / 2f, planeSize.x / 2f);
        float zOffset = Random.Range(-planeSize.y / 2f, planeSize.y / 2f);

        Vector3 spawnPos = center + new Vector3(xOffset, 0.05f, zOffset);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }


    void SpawnEnemy(Vector3 position)
    {
        Vector3 spawnPos = position + new Vector3(0, 0.1f, 0); // slightly above plane
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}

