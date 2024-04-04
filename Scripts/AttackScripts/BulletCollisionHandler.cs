using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    // Reference to the object that spawned this bullet
    public GameObject spawner;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore collisions with other bullets or the spawner
        if (other.CompareTag("Bullet") || other.gameObject == gameObject || (spawner != null && other.gameObject == spawner))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
        }
        else
        {
            // Check if the collided object has an EnemyHealth component
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Deal damage to the enemy
                enemyHealth.TakeDamage(1);
            }

            // Destroy the bullet on contact with an enemy or any other object
            Debug.Log($"{gameObject.name} has collided with {other.gameObject.name} and is self-destructing", this);
            Destroy(gameObject);
        }
    }
}
