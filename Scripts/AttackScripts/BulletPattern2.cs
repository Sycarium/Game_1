using UnityEngine;

public class BulletPattern2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int numberOfBullets = 8;
    public float circleRadius = 2f;
    public float bulletSpeed = 5f;
    public float rotationSpeed = 20f;
    public float launchInterval = 1.5f;
    public int damagePerBullet = 1; // Adjust damage as needed

    private void Start()
    {
        // Start firing bullets in a circle
        InvokeRepeating("FireBulletsInCircle", 0f, launchInterval);
    }

    private void FireBulletsInCircle()
    {
        float angleIncrement = 360f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float angle = i * angleIncrement;
            Vector3 spawnPosition = transform.position + Quaternion.Euler(0, 0, angle) * Vector3.right * circleRadius;

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = bullet.transform.up * bulletSpeed;

            // Pass the damage value to the bullet
            BulletDamage bulletDamage = bullet.GetComponent<BulletDamage>();
            if (bulletDamage != null)
            {
                bulletDamage.SetDamage(damagePerBullet);
            }

            // Scale the bullet
            bullet.transform.localScale = new Vector3(100f, 100f, 100f);
        }

        // Rotate the entire circle
        transform.Rotate(Vector3.forward * rotationSpeed * launchInterval);
    }
}
