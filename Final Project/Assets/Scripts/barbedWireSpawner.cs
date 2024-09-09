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
            isPlayerInRange = true;
            pointsManager = FindObjectOfType<pointsManager>();  
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TrySpawnBarbedWire();
        } 
    }
    void TrySpawnBarbedWire()
    {
        if (pointsManager != null && pointsManager.SpendPoints(barbedWireCost))
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            Instantiate(barbedWirePrefab, spawnPosition, Quaternion.identity);
            Destroy(gameObject); 
        }
    }
}
