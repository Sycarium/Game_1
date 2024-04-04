using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaling : MonoBehaviour
{
    public Camera mainCamera;
    public float scaleMultiplier = 1.0f; // Adjust the scale factor as needed

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        float targetScale = mainCamera.orthographicSize * scaleMultiplier;
        transform.localScale = initialScale * targetScale;
    }
}