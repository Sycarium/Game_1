using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAttack : MonoBehaviour
{
    public GameObject bulletPrefab;     // Reference to the bullet prefab
    public float bulletSpeed = 5.0f;    // Speed of the bullets
    public float radius = 2.0f;         // Radius of the spherical pattern
    public int numBullets = 20;         // Number of bullets to spawn
    public float spacing = 0.2f;        // Spacing between bullets
    public float spawnInterval = 0.5f;  // Time interval between bullet spawns
    public int damagePerPellet = 1;    // Damage inflicted on collision with an enemy

    private void Start()
    {
        StartCoroutine(SpawnBulletsWithInterval());
    }

    private IEnumerator SpawnBulletsWithInterval()
    {
        while (true)
        {
            SpawnBullets();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnBullets()
    {
        for (int i = 0; i < numBullets; i++)
        {
            // Calculate the angle for the spherical pattern
            float angle = (i / (float)numBullets) * 360.0f;

            // Calculate the position for the bullet
            float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            float y = radius * Mathf.Sin(Mathf.Deg2Rad * angle);
            Vector3 spawnPosition = transform.position + new Vector3(x, y, 0);

            // Create the bullet
            GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            // Set the bullet's direction (forward)
            Vector3 bulletDirection = (newBullet.transform.position - transform.position).normalized;
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity = bulletDirection * bulletSpeed;

            // Adjust the position for the next bullet to create spacing
            radius += spacing;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Inflict damage on the enemy
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damagePerPellet);
            }

            // Destroy the bullet on collision
            Destroy(gameObject);
        }
    }
}
