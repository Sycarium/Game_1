using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOfDeath : MonoBehaviour
{
       private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has a specific tag (adjust as needed)
       // if (other.CompareTag("Destroyable"))
        //{
            // Destroy the colliding object
            Destroy(other.gameObject);
       // }
    }
}
