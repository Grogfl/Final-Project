using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private pointsManager pointsManager;
    public float lifeTime = 2f; 

    void Start()
    {
        Destroy(gameObject, lifeTime);  
        pointsManager = GameObject.FindWithTag("pointsManager").GetComponent<pointsManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); 
            pointsManager.AddPoints(10);  // Bandaid fix for adding points
            Destroy(gameObject); 
        }
    }
}
