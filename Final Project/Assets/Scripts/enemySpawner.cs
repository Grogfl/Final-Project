﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float initialSpawnRate = 2f;  // Initial spawn rate (enemies per second)
    public float spawnRateIncrease = 0.1f; // Rate at which spawn rate increases
    public float maxSpawnRate = 5f; // Maximum spawn rate

    private float spawnRate;
    private float nextSpawnTime = 0f;
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

        // Increase spawn rate over time
        spawnRate = Mathf.Min(initialSpawnRate + elapsedTime * spawnRateIncrease, maxSpawnRate);

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + 1f / spawnRate;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = GetRandomSpawnPositionOutsideScreen();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

   Vector2 GetRandomSpawnPositionOutsideScreen()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

    
        float minX = mainCamera.transform.position.x - cameraWidth / 2 - 1f;
        float maxX = mainCamera.transform.position.x + cameraWidth / 2 + 1f;
        float minY = mainCamera.transform.position.y - cameraHeight / 2 - 1f;
        float maxY = mainCamera.transform.position.y + cameraHeight / 2 + 1f;

        int side = Random.Range(0, 4);
        Vector2 spawnPosition = Vector2.zero;
        switch (side)
        {
            case 0: // Left
                spawnPosition = new Vector2(minX, Random.Range(minY, maxY));
                break;
            case 1: // Right
                spawnPosition = new Vector2(maxX, Random.Range(minY, maxY));
                break;
            case 2: // Top
                spawnPosition = new Vector2(Random.Range(minX, maxX), maxY);
                break;
            case 3: // Bottom
                spawnPosition = new Vector2(Random.Range(minX, maxX), minY);
                break;
        }

        return spawnPosition;
    }
}
