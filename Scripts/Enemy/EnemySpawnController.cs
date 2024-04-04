using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to your enemy prefab
    public Camera mainCamera;       // Reference to the main camera
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;
    public float moveSpeed = 5f;
    public Sprite[] enemySprites;
    private float nextSpawnTime = 0f;

    private void Start()
    {
        mainCamera = Camera.main; // Automatically find the main camera
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = CalculateSpawnPosition(randomDirection);
        
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    
        Rigidbody2D rb = newEnemy.GetComponent<Rigidbody2D>();
        
        if (rb != null)
        {
            // Set the enemy's velocity to make it move in a random direction
            rb.velocity = randomDirection * moveSpeed;
        }
    }

    private Vector3 CalculateSpawnPosition(Vector3 direction)
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 spawnPosition = cameraPosition + direction * spawnRadius;

        // Ensure the spawn position is within the camera's view
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, mainCamera.ViewportToWorldPoint(Vector3.zero).x, mainCamera.ViewportToWorldPoint(Vector3.one).x);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, mainCamera.ViewportToWorldPoint(Vector3.zero).y, mainCamera.ViewportToWorldPoint(Vector3.one).y);

        return spawnPosition;
    }
}