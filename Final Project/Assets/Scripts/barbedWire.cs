using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barbedWire : MonoBehaviour
{
    public float slowAmount = 0.5f;  // 50% mvoe speed reduction
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
            Debug.Log("Enemy entered barbed wire.");
            enemyController enemyScript = other.GetComponent<enemyController>();
            if (enemyScript != null)
            {
                enemyScript.ModifySpeed(slowAmount);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy exited barbed wire.");
            enemyController enemyScript = other.GetComponent<enemyController>();
            if (enemyScript != null)
            {
                enemyScript.ResetSpeed();
            }
        }
    }
}
