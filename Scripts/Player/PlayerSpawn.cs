using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab; // Reference to your player character prefab
    public float yOffset = 1.0f; // Adjust the vertical offset as needed

    void Start()
    {
        SpawnPlayerAtCenter(); // Call the spawn method at the start of the game
    }

    public void RespawnPlayerAtCenter()
    {
        SpawnPlayerAtCenter(); // Call the spawn method when the player needs to respawn
    }

    private void SpawnPlayerAtCenter()
    {
        // Calculate the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // Convert the screen point to a world point
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(screenCenter);

        // Apply the vertical offset
        spawnPosition.y -= yOffset;

        // Spawn the player character at the calculated position
        GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);

        // Assign the "Player" tag to the spawned player character
        player.tag = "Player";
    }
}
