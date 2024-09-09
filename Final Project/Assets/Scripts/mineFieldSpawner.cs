using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineFieldSpawner : MonoBehaviour
{
    public GameObject minePrefab;
    public int minefieldCost = 30;
    public int mineCount = 7;
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
            
            TrySpawnMinefield();
        }
    }
    void TrySpawnMinefield()
    {
        if (pointsManager != null && pointsManager.SpendPoints(minefieldCost))
        {
            
            for (int i = 0; i < mineCount; i++)
            {
                Vector2 spawnPosition = new Vector2(
                    transform.position.x + Random.Range(-2f, 2f),
                    transform.position.y + Random.Range(-2f, 2f)
                );
                Instantiate(minePrefab, spawnPosition, Quaternion.identity);
            }
            Destroy(gameObject);  
        }
        
    }
}
