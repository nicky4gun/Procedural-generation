using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapFog : MonoBehaviour
{
    public Tilemap fogTilemap;
    public TileBase fogTile;

    public void RevealTile(Vector3 worldPosition)
    {
        Vector3Int cellPosition = fogTilemap.WorldToCell(worldPosition);
        fogTilemap.SetTile(cellPosition, null); // Remove fog tile
    }
}

