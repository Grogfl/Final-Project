using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barbedWireSpawner : MonoBehaviour
{
    public GameObject barbedWirePrefab;
    public int barbedWireCost = 20;
    private bool isPlayerInRange = false;
    private pointsManager pointsManager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the spawner range.");
            isPlayerInRange = true;
            pointsManager = FindObjectOfType<pointsManager>();  // Get the pointsManager in the scene
            if (pointsManager == null)
            {
                Debug.LogError("pointsManager script not found in the scene.");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the spawner range.");
            isPlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction key pressed.");
            TrySpawnBarbedWire();
        } 
    }
    void TrySpawnBarbedWire()
    {
        if (pointsManager != null && pointsManager.SpendPoints(barbedWireCost))
        {
            Debug.Log("Spawning barbed wire.");
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            Instantiate(barbedWirePrefab, spawnPosition, Quaternion.identity);
            Destroy(gameObject);  // Destroy the spawner after spawning the barbed wire
        }
        else
        {
            Debug.Log("Not enough points to purchase barbed wire.");
        }
    }
}
