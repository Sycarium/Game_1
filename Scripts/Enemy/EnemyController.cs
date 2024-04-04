using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health of the enemy
    private int currentHealth;  // Current health of the enemy

    public float movementSpeed = 3.0f;  // Movement speed of the enemy
    public Vector2 movementDirection = Vector2.left;  // Initial movement direction

    public GameObject bulletPrefab;  // Bullet prefab to be spawned by the enemy
    public Transform bulletSpawner; // Transform of the bullet spawn point
    public float shootInterval = 1.0f;  // Time interval between shots

    private void Start()
    {
        currentHealth = maxHealth;  // Initialize current health
        StartCoroutine(MoveAndShoot());
    }

    private IEnumerator MoveAndShoot()
    {
        while (currentHealth > 0)
        {
            MoveEnemy();
            yield return new WaitForSeconds(shootInterval);
            Shoot();
        }

        Destroy(gameObject); // Destroy the enemy when health reaches 0
    }

    private void MoveEnemy()
    {
        // Implement enemy movement logic based on speed and direction
        // Update the enemy's position using movementSpeed and movementDirection
    }

    private void Shoot()
    {
        // Implement shooting logic here, e.g., instantiate bullets
        if (bulletPrefab != null && bulletSpawner != null)
        {
            Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
}