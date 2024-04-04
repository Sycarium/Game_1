using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health; // The initial health value for each enemy

    // Method to set the initial health value during instantiation
    public void SetInitialHealth(int initialHealth)
    {
        health = initialHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        // Additional logic for handling damage, possibly destroying the enemy when health reaches zero
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}