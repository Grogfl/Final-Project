using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform landingCraft;
    public float detectionRadius = 5f;
    private Transform player;
    private bool isPlayerInRange = false;
    private float defaultSpeed;
    // Start is called before the first frame update
    void Start()
    {
        landingCraft = GameObject.FindGameObjectWithTag("LandingCraft").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        defaultSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }

        Transform target = isPlayerInRange ? player : landingCraft;
        MoveTowards(target);
    }

    void MoveTowards(Transform target)
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
    public void ModifySpeed(float slowAmount)
    {
        moveSpeed = defaultSpeed * slowAmount;
    }
    public void ResetSpeed()
    {
        moveSpeed = defaultSpeed;
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LandingCraft"))
        {
            landingCraft landingCraftHealth = other.GetComponent<landingCraft>();
            if (landingCraftHealth != null)
            {
                landingCraftHealth.TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }
}
