using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private pointsManager pointsManager;
    public float lifeTime = 2f;  // Time before bullet despawns

    void Start()
    {
        Destroy(gameObject, lifeTime);  // Destroy bullet after lifeTime seconds
        pointsManager = GameObject.FindWithTag("pointsManager").GetComponent<pointsManager>(); // Implement the points manager
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);  // Destroy the enemy
            pointsManager.AddPoints(10);  // Bandaid fix for adding points
            Destroy(gameObject);  // Destroy the bullet
        }
    }
}
