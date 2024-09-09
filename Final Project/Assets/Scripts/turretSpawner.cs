using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretSpawner : MonoBehaviour
{
public GameObject turretPrefab;
    public int turretCost = 10;
    private bool isPlayerInRange = false;
    private pointsManager pointsManager;  

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

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) // change this to w/e for keybind
        {
            TrySpawnTurret();
        }
    }

    void TrySpawnTurret()
    {
        if (pointsManager != null && pointsManager.SpendPoints(turretCost))
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            Instantiate(turretPrefab, spawnPosition, Quaternion.identity);
            pointsManager.UpdatePointsText();  
            Destroy(gameObject);
        }
    }
}