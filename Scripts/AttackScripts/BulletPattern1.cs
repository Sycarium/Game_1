using UnityEngine;

public class BulletPattern1 : MonoBehaviour
{
   [SerializeField] private GameObject bulletPrefab;
    public int numberOfBullets = 5;
    public float coneSpreadAngle = 30f;
    public float bulletSpeed = 200f;
    public float bulletLifetime = 1000f;
    public int damagePerBullet = 1;
    public float fireDelay = 1f; // Time delay between shots

    [SerializeField] private Transform player;
  //  public string bulletPrefabName = "Bullet2"; // Name of the prefab in the Resources folder

    void Start()
    {
        // Check if the player object is found
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            // Start firing bullets periodically
            InvokeRepeating("FireBulletsInCone", 0f, fireDelay);
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    void FireBulletsInCone()
    {
        float startAngle = -coneSpreadAngle / 2;
        float angleIncrement = coneSpreadAngle / (numberOfBullets - 1);
       // GameObject bulletPrefab = Resources.Load<GameObject>("Bullets/" + bulletPrefabName);

        for (int i = 0; i < numberOfBullets; i++)
        {
            float angle = startAngle + i * angleIncrement;
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            Debug.Log($"{gameObject.name} is attempting to spawn bullet prefab: {bulletPrefab}", this);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Calculate the direction towards the player
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            bulletRb.velocity = directionToPlayer * bulletSpeed;

            BulletDamage bulletDamage = bullet.GetComponent<BulletDamage>();
            if (bulletDamage != null)
            {
                bulletDamage.SetDamage(damagePerBullet);
            }

            // Destroy the bullet after its lifetime
            Destroy(bullet, bulletLifetime);
        }
    }
}
