using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YingYangBulletTier1 : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to your bullet sprite prefab
    private float bulletSpeed = 200.0f; // Speed of the bullets
    public float rotationSpeed = 180.0f; // Speed at which the bullets spin
    public Sprite[] bulletSprites; // Array of bullet sprites to alternate between
    public int sortingOrder = 5; // Sorting order for the bullets

    private bool useFirstSprite = true; // Flag to alternate between sprites

        private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a new bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Set the bullet's sprite based on the flag
            SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = useFirstSprite ? bulletSprites[0] : bulletSprites[1];

            // Set the sorting order for the bullet
            spriteRenderer.sortingOrder = sortingOrder;

            // Set the scale of the bullet
            bullet.transform.localScale = new Vector3(10f, 10f, 10f);

            // Toggle the flag for the next bullet
            useFirstSprite = !useFirstSprite;

            // Access the bullet's rigidbody2D (assuming you're using 2D physics)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Set the bullet's velocity to move forward
            rb.velocity = transform.up * bulletSpeed;

            // Add rotation to the bullet
            rb.angularVelocity = rotationSpeed;

            // Attach a script to handle collisions and damage
            bullet.AddComponent<BulletCollisionHandler>();
        }
    }
}