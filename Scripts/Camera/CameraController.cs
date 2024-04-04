using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // The target position or object you want the camera to follow
    public float smoothness = 5.0f;  // Adjust the smoothness of the camera movement

    private Vector3 initialOffset;

    private void Start()
    {
        if (target != null)
        {
            // Calculate the initial offset from the camera's position to the target
            initialOffset = transform.position - target.position;
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired camera position based on the target
            Vector3 desiredPosition = target.position + initialOffset;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);
        }
    }
}