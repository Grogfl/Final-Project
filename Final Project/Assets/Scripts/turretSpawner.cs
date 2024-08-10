using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretSpawner : MonoBehaviour
{
public GameObject turretPrefab;
    public int turretCost = 10;
    private bool isPlayerInRange = false;
    private pointsManager pointsManager;  // Reference to pointsManager

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Player"))
        {
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
        Debug.Log("Exited");
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
           
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) // Change KeyCode.E to any key you prefer
        {
            Debug.Log("Pressed E");
            TrySpawnTurret();
        }
    }

    void TrySpawnTurret()
    {
        if (pointsManager != null && pointsManager.SpendPoints(turretCost))
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
            Instantiate(turretPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Turret purchased and spawned.");
            pointsManager.UpdatePointsText();  // Update the UI text after spending points
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not enough points to purchase turret.");
        }
    }
}