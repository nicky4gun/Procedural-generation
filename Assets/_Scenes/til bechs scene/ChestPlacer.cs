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

    // Optionally, you could define a 2D array to mark walkable tiles.
    // For this example, we assume every tile is walkable.
    // If you have specific conditions (like obstacles), update the logic below.

    void Start()
    {
        // Create a list to hold positions that are walkable.
        List<Vector2Int> walkablePositions = new List<Vector2Int>();

        // Populate the grid.
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                // Example condition: If the tile is walkable.
                // For this example, every tile is walkable.
                bool isWalkable = true; // Replace with your condition if needed.
                if (isWalkable)
                {
                    walkablePositions.Add(new Vector2Int(x, y));
                }
            }
        }

        // Check if there are enough positions.
        if (walkablePositions.Count < chestCount)
        {
            Debug.LogWarning("Not enough walkable positions for the number of chests. Adjusting chest count.");
            chestCount = walkablePositions.Count;
        }

        // Randomize the order of the walkable positions.
        ShuffleList(walkablePositions);

        // Spawn chests at the first 'chestCount' positions.
        for (int i = 0; i < chestCount; i++)
        {
            Vector2Int gridPos = walkablePositions[i];
            Vector3 worldPos = new Vector3(gridPos.x * tileSize, gridPos.y * tileSize, 0);
            Instantiate(chestPrefab, worldPos, Quaternion.identity, transform);
        }
    }

    // Fisher-Yates shuffle to randomize the list.
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
