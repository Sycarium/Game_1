using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player
    private int currentHealth; // Current health of the player

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health
    }

    // Method to apply damage to the player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        // Check if the player's health has reached zero
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Handle player's death or game over logic here
        }
    }
    
    // Method to restore the player's health
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        
        // Ensure health doesn't exceed the maximum
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}