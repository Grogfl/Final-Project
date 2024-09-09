using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoTargeting : MonoBehaviour
{
    public float detectionRadius = 10f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float shotDelay = 0f;
    public AudioClip shootSFX;
    private AudioSource audioSource;

    public Transform gunTransform; 


    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                float distance = Vector2.Distance(transform.position, hitCollider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = hitCollider.transform;
                }
            }
        }
        if (closestEnemy != null)
        {
            
            RotateGun(closestEnemy.position);

            if (Time.time >= shotDelay)
            {
                shotDelay = Time.time + 1f / fireRate;
                Shoot(closestEnemy);
            }
        }
    }

  void RotateGun(Vector3 targetPosition)
{
    Vector2 direction = (targetPosition - gunTransform.position).normalized;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    gunTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    if (angle > 90 || angle < -90)
    {
        gunTransform.localScale = new Vector3(1, -1, 1);
    }
    else
    {
        gunTransform.localScale = new Vector3(1, 1, 1);  
    }
}

    void Shoot(Transform target)
    {
        Vector2 direction = (target.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        audioSource.PlayOneShot(shootSFX);
        if (bullet != null)
        {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * 25f;
            }
        }
    }
}
