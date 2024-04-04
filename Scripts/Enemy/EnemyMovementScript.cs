using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float moveSpeed = 200f; // Adjust the speed as needed
    public float moveDistance = 1000f; // Adjust the distance as needed

    private bool movingRight = true;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }
}
