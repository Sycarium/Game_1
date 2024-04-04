using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject bossPrefab;

    private float firstEnemySpawnTime = 28f;
    private float timeBetweenFirstEnemySpawns = 1.5f;
    private int numberOfFirstEnemySpawns = 10;

    private float secondEnemySpawnTime = 30f;
    private int numberOfSecondEnemySpawns = 3;

    private float bossSpawnTime = 50f;

    private int totalEnemiesSpawned = 0;

    private Camera mainCamera;
    private Transform player;

    // Distance parameters
    private float firstEnemyMoveDistance = -50f;
    private float enemySpacingAbovePlayer = 600f;
    private float bossDistanceAbovePlayer = 800f;

    void Awake()
    {
        mainCamera = Camera.main;
          // Check if the player object is found
    GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
    if (playerObject != null)
    {
        player = playerObject.transform;
    }
    else
    {
        Debug.LogError("Player not found in the scene!");
    }
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found. Ensure there is a camera tagged as 'MainCamera' in the scene.");
        }
        
    }

    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (Time.time >= firstEnemySpawnTime && totalEnemiesSpawned < numberOfFirstEnemySpawns)
        {
            SpawnEnemy1();
            firstEnemySpawnTime += timeBetweenFirstEnemySpawns;
            totalEnemiesSpawned++;
        }

        if (Time.time >= secondEnemySpawnTime && totalEnemiesSpawned < numberOfFirstEnemySpawns + numberOfSecondEnemySpawns)
        {
            SpawnEnemy2();
            secondEnemySpawnTime += timeBetweenFirstEnemySpawns;
            totalEnemiesSpawned += numberOfSecondEnemySpawns; // Increment by the number of enemies spawned in this wave
        }

        if (Time.time >= bossSpawnTime && totalEnemiesSpawned < numberOfFirstEnemySpawns + numberOfSecondEnemySpawns + 1)
        {
            SpawnBoss();
            bossSpawnTime = 100f;
            totalEnemiesSpawned++;
        }
    }

    private void SpawnEnemy1()
    {
        Vector3 spawnPosition = player.position + new Vector3(firstEnemyMoveDistance, 100f, 100f);
        GameObject enemy = Instantiate(enemyPrefab1, spawnPosition, Quaternion.identity);
        enemy.AddComponent<EnemyMovementScript>();
        SetupEnemy(enemy, 5, typeof(BulletPattern1));
    }

    private void SpawnEnemy2()
    {
        Vector3 playerPosition = player.position;

        // Spawn first enemy above player
        Vector3 spawnPosition1 = playerPosition + new Vector3(100f, enemySpacingAbovePlayer, 100f);
        GameObject enemy1 = Instantiate(enemyPrefab2, spawnPosition1, Quaternion.identity);
        //enemy1.AddComponent<EnemyMovementScript2>();
        SetupEnemy(enemy1, 10, typeof(BulletPattern2));

        // Spawn second enemy a bit to the left
        Vector3 spawnPosition2 = playerPosition + new Vector3(-enemySpacingAbovePlayer, enemySpacingAbovePlayer, 100f);
        GameObject enemy2 = Instantiate(enemyPrefab2, spawnPosition2, Quaternion.identity);
        //enemy2.AddComponent<EnemyMovementScript2>();
        SetupEnemy(enemy2, 10, typeof(BulletPattern2));

        // Spawn third enemy a bit to the right
        Vector3 spawnPosition3 = playerPosition + new Vector3(enemySpacingAbovePlayer, enemySpacingAbovePlayer, 100f);
        GameObject enemy3 = Instantiate(enemyPrefab2, spawnPosition3, Quaternion.identity);
        //enemy3.AddComponent<EnemyMovementScript2>();
        SetupEnemy(enemy3, 10, typeof(BulletPattern2));
    }

    private void SetupEnemy(GameObject enemy, int initialHealth, System.Type bulletPatternType = null)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.SetInitialHealth(initialHealth);
        }

        if (bulletPatternType != null)
        {
            Component existingComponent = enemy.GetComponent(bulletPatternType);
            
            // Add the component only if it doesn't already exist
            if (existingComponent == null)
            {
                enemy.AddComponent(bulletPatternType);
            }
        }

        // Scale the enemy
        enemy.transform.localScale = new Vector3(50f, 50f, 50f);
    }

    private void SpawnBoss()
    {
        Vector3 spawnPosition = player.position + new Vector3(100f, bossDistanceAbovePlayer, 100f);
        GameObject boss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
        //boss.AddComponent<BossMovementScript>();
        SetupEnemy(boss, 10, typeof(BossSequence));
    }
}