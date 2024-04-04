using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform objectToFollow; // Reference to the object you want to follow (set in the Inspector)

    void Update()
    {
        // Check if the object to follow is set
        if (objectToFollow != null)
        {
            // Set the position of this object to match the position of the object to follow
            transform.position = objectToFollow.position;
        }
    }
}

