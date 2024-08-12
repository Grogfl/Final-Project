using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoTargeting : MonoBehaviour
{
    public float detectionRadius = 10f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    public Transform gunTransform; // Reference to the gun's transform

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
            // Rotate the gun towards the closest enemy
            RotateGunTowardsTarget(closestEnemy.position);

            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + 1f / fireRate;
                Shoot(closestEnemy);
            }
        }
    }

    void RotateGunTowardsTarget(Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - gunTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot(Transform target)
    {
        Vector2 direction = (target.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        if (bullet != null)
        {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * 15f;
            }
        }
    }
}
