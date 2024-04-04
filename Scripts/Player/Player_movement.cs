using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 150.0f; // Adjust the speed as needed

    private Rigidbody2D rb;

private void Awake()
{
    rb = GetComponent<Rigidbody2D>();
}
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        movement.Normalize(); // Ensure diagonal movement is not faster

               if (movement != Vector3.zero)
        {
            // Update the player's velocity directly
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            // No input, set velocity to zero to stop
            rb.velocity = Vector2.zero;
        }
    }
}
