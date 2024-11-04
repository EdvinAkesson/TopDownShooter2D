using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 3f;
    Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("SpawnEnemy", spawnTime); // Ensure the next spawn is invoked

        int side = Random.Range(0, 4);
        Vector2 spawnPos;

        switch (side)
        {
            case 0: // Top
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
                break;
            case 1: // Bottom
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y);
                break;
            case 2: // Right
                spawnPos = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
                break;
            case 3: // Left
                spawnPos = new Vector2(-screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
                break;
            default:
                spawnPos = Vector2.zero; // Fallback
                break;
        }

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Spawn Position: " + spawnPos); // For debugging purposes
    }
}
