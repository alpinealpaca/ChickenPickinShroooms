using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomSpawner : MonoBehaviour
{
    public GameObject[] ShroomsToSpawn;
    public Vector2 spawnAreaSize;
    public float spawnDelay = 2f;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void Start()
    {
        if (ShroomsToSpawn.Length == 0)
        {
            Debug.LogError("No shrooms to spawn.");
            enabled = false; // Disable the script to prevent further errors.
        }

        // Start spawning objects with a delay
        InvokeRepeating("SpawnRandomShroom", 0f, spawnDelay);
    }

    private void SpawnRandomShroom()
    {
        if (ShroomsToSpawn.Length == 0)
            return; //If no shrooms listed, return.

        Vector2 spawnPosition = Vector2.zero;

        do
        {
            // Generate a random position within the spawn area
            spawnPosition = new Vector2(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f)
            );
        }
        while (IsSpawnPositionOccupied(spawnPosition));

        // Select a random index within the valid range of the array
        int randomIndex = Random.Range(0, ShroomsToSpawn.Length);

        // Instantiate the object if it's within the valid range
        if (randomIndex >= 0 && randomIndex < ShroomsToSpawn.Length)
        {
            GameObject objectToSpawn = ShroomsToSpawn[randomIndex];
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private bool IsSpawnPositionOccupied(Vector2 spawnPosition)
    {
        // Check for obstacles at the spawn position using a raycast
        RaycastHit2D hit = Physics2D.Raycast(spawnPosition, Vector2.zero);

        if (hit.collider != null && (hit.collider.gameObject == player1 || hit.collider.gameObject == player2)) //if (hit.collider != null && hit.collider.GetComponent<CapsuleCollider2D>() != null)
            {
            // The spawn position is occupied by a player
            Debug.Log("Spawn position occupied by the player.");
            return true;
        }

        return false;
    }

    /*private void SpawnRandomShroom()
    {
        if (ShroomsToSpawn.Length == 0)
            return; // No shrooms to spawn, so just return.

        // Generate a random position within the spawn area
        Vector2 spawnPosition = new Vector2(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f)
        );

        // Select a random index within the valid range of the array
        int randomIndex = Random.Range(0, ShroomsToSpawn.Length);

        // Instantiate the object if it's within the valid range
        if (randomIndex >= 0 && randomIndex < ShroomsToSpawn.Length)
        {
            GameObject objectToSpawn = ShroomsToSpawn[randomIndex];
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);


        }
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0f));
    }
}
