using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float initialSpawnRate = 2f;  
    public float spawnRateIncrease = 0.1f; 
    public float maxSpawnRate = 5f; 

    private float spawnRate;
    private float nextSpawn = 0f;
    private float elapsedTime = 0f; 
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = initialSpawnRate;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        spawnRate = Mathf.Min(initialSpawnRate + elapsedTime * spawnRateIncrease, maxSpawnRate);
        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + 1f / spawnRate;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = RandomSpawnPos();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

   Vector2 RandomSpawnPos()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

    
        float minX = mainCamera.transform.position.x - cameraWidth / 2 - 1f;
        float maxX = mainCamera.transform.position.x + cameraWidth / 2 + 1f;
        float minY = mainCamera.transform.position.y - cameraHeight / 2 - 1f;
        float maxY = mainCamera.transform.position.y + cameraHeight / 2 + 1f;

        int side = Random.Range(0, 3);
        Vector2 spawnPosition = Vector2.zero;
        switch (side)
        {
            case 0: 
                spawnPosition = new Vector2(Random.Range(minX, maxX), maxY);
                break;
            case 1: 
                spawnPosition = new Vector2(minX, Random.Range((minY + maxY) / 2, maxY));
                break;
            case 2: 
                spawnPosition = new Vector2(maxX, Random.Range((minY + maxY) / 2, maxY));
                break;
        }

        return spawnPosition;
    }
}
