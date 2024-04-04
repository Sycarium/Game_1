using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeAttack : MonoBehaviour
{
    public GameObject bulletPrefab;     // Reference to the bullet prefab
    public float bulletSpeed = 5.0f;    // Speed of the bullets
    public float coneAngle = 45.0f;      // Angle of the cone in degrees
    public int numBulletsPerSet = 5;    // Number of bullets to spawn in each set
    public float spacing = 0.1f;        // Spacing between bullets in each set
    public float setInterval = 0.5f;    // Time interval between bullet sets

    private void Start()
    {
        StartCoroutine(ShootBulletSets());
    }

    private IEnumerator ShootBulletSets()
    {
        while (true)
        {
            ShootBulletsInCone();
            yield return new WaitForSeconds(setInterval);
        }
    }

    private void ShootBulletsInCone()
    {
        float startAngle = -coneAngle / 2.0f;
        float angleIncrement = coneAngle / (numBulletsPerSet - 1);

        for (int i = 0; i < numBulletsPerSet; i++)
        {
            float angle = startAngle + i * angleIncrement;
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
            Vector3 spawnPosition = transform.position;
            
            // Create the bullet
            GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            // Set the bullet's direction
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;

            // Adjust the position for the next bullet to create spacing
            spawnPosition += direction * spacing;
        }
    }
}