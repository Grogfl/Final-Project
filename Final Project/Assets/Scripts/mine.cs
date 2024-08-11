using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    //public GameObject explosionEffect; make an explosion effect at some point
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy triggered mine.");
            
            // if (explosionEffect != null)
            // {
            //     Instantiate(explosionEffect, transform.position, Quaternion.identity);
            // }
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the mine
        }
    }
}
