using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class FogOfWar : MonoBehaviour
{
    public Tilemap fogTilemap;   // The tilemap storing fog
    public TileBase fogTile;     // The fog tile
    public Transform player;     // The player reference
    public float revealRadius = 3f; // Vision radius
    public int mapWidth = 50;    // Set this based on your map size
    public int mapHeight = 50;

    private HashSet<Vector3Int> revealedTiles = new HashSet<Vector3Int>();

    void Start()
    {
        if (fogTilemap == null || fogTile == null)
        {
            Debug.LogError("Fog Tilemap or Fog Tile is missing!");
            return;
        }

        GenerateFog();  // Ensure the fog covers the entire map
        UpdateFog();    // Reveal the initial area
    }

    void Update()
    {
        UpdateFog();  // Update fog as the player moves
    }

    void GenerateFog()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                fogTilemap.SetTile(cellPosition, fogTile); // Fill the map with fog
            }
        }
    }

    void UpdateFog()
    {
        Vector3Int centerCell = fogTilemap.WorldToCell(player.position);
        int radius = Mathf.CeilToInt(revealRadius);

        HashSet<Vector3Int> newVisibleTiles = new HashSet<Vector3Int>();

        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                Vector3Int cellPosition = new Vector3Int(centerCell.x + x, centerCell.y + y, 0);
                if (Vector3.Distance(cellPosition, centerCell) <= revealRadius)
                {
                    fogTilemap.SetTile(cellPosition, null); // Remove fog
                    newVisibleTiles.Add(cellPosition);
                }
            }
        }

        // Restore fog to tiles that are no longer within vision range
        foreach (Vector3Int oldTile in revealedTiles)
        {
            if (!newVisibleTiles.Contains(oldTile))
            {
                fogTilemap.SetTile(oldTile, fogTile); // Bring fog back
            }
        }

        revealedTiles = newVisibleTiles;
    }
}

