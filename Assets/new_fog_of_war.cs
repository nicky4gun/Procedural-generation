using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class FogOfWar : MonoBehaviour
{
    public Tilemap fogTilemapBlack;   // Black fog
    public Tilemap fogTilemapTransparent; // Transparent fog
    public TileBase fogTileBlack;     // Fully dark tile
    public TileBase fogTileTransparent; // Semi-transparent tile
    public Transform player;
    public float revealRadius = 3f;   // Full reveal radius
    public float fadeRadius = 5f;     // Buffer fade area

    private HashSet<Vector3Int> revealedTiles = new HashSet<Vector3Int>();

    void Start()
    {
        GenerateFog();  // Ensure the fog covers the entire map
        UpdateFog();
    }

    void Update()
    {
        UpdateFog();
    }

    void GenerateFog()
    {
        for (int x = 0; x < 50; x++) // Adjust map size
        {
            for (int y = 0; y < 50; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                fogTilemapBlack.SetTile(cellPosition, fogTileBlack);
                fogTilemapTransparent.SetTile(cellPosition, fogTileTransparent);
            }
        }
    }

    void UpdateFog()
    {
        Vector3Int centerCell = fogTilemapBlack.WorldToCell(player.position);
        int fadeOut = Mathf.CeilToInt(fadeRadius);
        int fullReveal = Mathf.CeilToInt(revealRadius);

        HashSet<Vector3Int> newVisibleTiles = new HashSet<Vector3Int>();

        for (int x = -fadeOut; x <= fadeOut; x++)
        {
            for (int y = -fadeOut; y <= fadeOut; y++)
            {
                Vector3Int cellPosition = new Vector3Int(centerCell.x + x, centerCell.y + y, 0);
                float distance = Vector3.Distance(cellPosition, centerCell);

                if (distance <= fullReveal)
                {
                    fogTilemapBlack.SetTile(cellPosition, null); // Remove black fog
                    fogTilemapTransparent.SetTile(cellPosition, null); // Remove transparent fog
                }
                else if (distance <= fadeOut)
                {
                    fogTilemapBlack.SetTile(cellPosition, fogTileBlack); // Ensure black fog is present
                    fogTilemapTransparent.SetTile(cellPosition, fogTileTransparent); // Keep semi-transparent buffer
                }
            }
        }

        // Restore fog outside the vision radius
        foreach (Vector3Int oldTile in revealedTiles)
        {
            if (!newVisibleTiles.Contains(oldTile))
            {
                fogTilemapBlack.SetTile(oldTile, fogTileBlack);
                fogTilemapTransparent.SetTile(oldTile, fogTileTransparent);
            }
        }

        revealedTiles = newVisibleTiles;
    }
}

