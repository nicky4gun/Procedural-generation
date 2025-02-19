using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class FogOfWar : MonoBehaviour
{
    public Tilemap fogTilemapBlack;        // Black fog (fully hidden)
    public Tilemap fogTilemapTransparent;  // Transparent fog (buffer)
    public TileBase fogTileBlack;          // Dark tile
    public TileBase fogTileTransparent;    // Semi-transparent tile
    public Transform player;
    public float revealRadius = 3f;   // Radius for full visibility
    public float fadeRadius = 5f;     // Buffer fade area

    private HashSet<Vector3Int> revealedTiles = new HashSet<Vector3Int>();

    void Start()
    {
        GenerateFog();  // Fill the map with fog
        UpdateFog();    // Reveal around player at start
    }

    void Update()
    {
        UpdateFog();  // Update fog as the player moves
    }

    void GenerateFog()
    {
        for (int x = -50; x < 50; x++) // Adjust to map size
        {
            for (int y = -50; y < 50; y++)
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
                    // Fully reveal area
                    fogTilemapBlack.SetTile(cellPosition, null);
                    fogTilemapTransparent.SetTile(cellPosition, null);
                }
                else if (distance <= fadeOut)
                {
                    // Add semi-transparent fog in the buffer zone
                    fogTilemapBlack.SetTile(cellPosition, null);
                    fogTilemapTransparent.SetTile(cellPosition, fogTileTransparent);
                }
                else
                {
                    // Keep fog beyond the buffer area
                    fogTilemapBlack.SetTile(cellPosition, fogTileBlack);
                    fogTilemapTransparent.SetTile(cellPosition, fogTileTransparent);
                }

                newVisibleTiles.Add(cellPosition);
            }
        }

        // Restore fog outside vision range
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
