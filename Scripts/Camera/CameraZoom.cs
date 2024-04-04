using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform zoomTarget; // Reference to the target GameObject to zoom in on
    public float zoomSpeed = 0.5f; // Adjust the speed as needed
    public float minOrthographicSize = 600.0f; // Set the minimum allowed orthographic size
    public float maxOrthographicSize = 10.0f; // Set the maximum allowed orthographic size

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float targetOrthoSize = Mathf.Clamp(mainCamera.orthographicSize, minOrthographicSize, maxOrthographicSize);

        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetOrthoSize, Time.deltaTime * zoomSpeed);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, zoomTarget.position, Time.deltaTime * zoomSpeed);
    }
}