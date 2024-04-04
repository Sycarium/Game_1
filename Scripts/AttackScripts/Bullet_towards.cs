using UnityEngine;

public class Bullet_Towards : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform player;        // Reference to the player character
    public float bulletSpeed = 10f; // Speed of the bullets
    public float fireRate = 0.5f;   // Rate of fire (1 bullet per 0.5 seconds)
    public float orbitRadius = 2f;  // Radius of the orbit
    public float rotationSpeed = 45f; // Speed at which the firePoint rotates

    private float nextFireTime;
    private Transform firePoint; // Current fire point position

    private void Start()
    {
        nextFireTime = 0f;
        // Initialize firePoint position
        firePoint = new GameObject("FirePoint").transform;
        firePoint.parent = transform;
        firePoint.localPosition = Vector3.right * orbitRadius;
    }

    private void Update()
    {
        firePoint.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));

        if (Time.time > nextFireTime)
        {
            // Calculate direction towards the player at this moment
            Vector2 direction = (player.position - firePoint.position).normalized;

            // Create a new bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Access the bullet's rigidbody2D (assuming you're using 2D physics)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Set the bullet's velocity to move towards the player
            rb.velocity = direction * bulletSpeed;

            // Update the next fire time
            nextFireTime = Time.time + fireRate;
        }
    }
}