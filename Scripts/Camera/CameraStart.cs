using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(700, 450, -1);
    public float targetSize = 300f;

    private void Start()
    {
        // Set the camera's position
        transform.position = targetPosition;

        // Set the camera's orthographic size
        Camera mainCamera = GetComponent<Camera>();
        if (mainCamera != null)
        {
            mainCamera.orthographicSize = targetSize;
        }
    }
}
