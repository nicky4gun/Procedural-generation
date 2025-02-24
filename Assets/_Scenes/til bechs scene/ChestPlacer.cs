using UnityEngine;
using System.Collections.Generic;

public class ChestSpawner : MonoBehaviour
{
    [Header("Chest Settings")]
    public GameObject chestPrefab;   // Assign your chest prefab in the Inspector.
    public int chestCount = 5;       // Number of chests to spawn.

    [Header("Grid Settings")]
    public Vector2Int gridSize = new Vector2Int(50, 50); // Dimensions of the grid.
    public float tileSize = 1f;      // Size of each grid tile (assumes square tiles).

    private bool chestsSpawned = false; // Ensure chests spawn only once

    void Start()
    {
        SpawnChests();
    }

    void SpawnChests()
    {
        if (chestsSpawned) return; // Prevent spawning more than once

        List<Vector2Int> availablePositions = new List<Vector2Int>();
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                availablePositions.Add(new Vector2Int(x, y));
            }
        }

        if (availablePositions.Count < chestCount)
        {
            Debug.LogWarning("Not enough available positions for the desired number of chests. Adjusting chest count.");
            chestCount = availablePositions.Count;
        }

        ShuffleList(availablePositions);

        for (int i = 0; i < chestCount; i++)
        {
            Vector2Int gridPos = availablePositions[i];
            Vector3 worldPos = new Vector3(gridPos.x * tileSize, gridPos.y * tileSize, 0);
            Instantiate(chestPrefab, worldPos, Quaternion.identity, transform);
        }

        chestsSpawned = true;
    }

    void ShuffleList(List<Vector2Int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            Vector2Int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
