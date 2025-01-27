using UnityEngine;
using UnityEngine.Tilemaps;


public class ProceduralMapGenerator2D : MonoBehaviour
{
    public int mapWidth = 50;
    public int mapHeight = 50;
    public int roomCount = 10;
    public int minRoomSize = 5;
    public int maxRoomSize = 10;

    public Tilemap floorTilemap;
    public Tilemap wallTilemap;
    public TileBase floorTile;
    public TileBase wallTile;

    private bool[,] map; // A grid to store whether a tile is walkable (floor) or not (wall)

    void Start()
    {
        GenerateMap();
        DrawMap();
    }

    void GenerateMap()
    {
        // Initialize the map as all walls
        map = new bool[mapWidth, mapHeight];
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                map[x, y] = false; // Walls
            }
        }

        // Generate rooms
        for (int i = 0; i < roomCount; i++)
        {
            int roomWidth = Random.Range(minRoomSize, maxRoomSize);
            int roomHeight = Random.Range(minRoomSize, maxRoomSize);
            int x = Random.Range(1, mapWidth - roomWidth - 1);
            int y = Random.Range(1, mapHeight - roomHeight - 1);

            // Create the room
            for (int w = 0; w < roomWidth; w++)
            {
                for (int h = 0; h < roomHeight; h++)
                {
                    map[x + w, y + h] = true; // Floor
                }
            }

            // Optionally: Save the room center for corridor generation
        }

        // Add corridors (for simplicity, straight corridors between random points)
        for (int i = 0; i < roomCount - 1; i++)
        {
            Vector2Int start = FindRandomFloorTile();
            Vector2Int end = FindRandomFloorTile();
            CreateCorridor(start, end);
        }
    }

    Vector2Int FindRandomFloorTile()
    {
        while (true)
        {
            int x = Random.Range(0, mapWidth);
            int y = Random.Range(0, mapHeight);

            if (map[x, y]) return new Vector2Int(x, y); // Return a random floor tile
        }
    }

    void CreateCorridor(Vector2Int start, Vector2Int end)
    {
        Vector2Int current = start;

        while (current != end)
        {
            if (current.x != end.x)
            {
                current.x += (end.x > current.x) ? 1 : -1;
            }
            else if (current.y != end.y)
            {
                current.y += (end.y > current.y) ? 1 : -1;
            }

            map[current.x, current.y] = true; // Carve a floor
        }
    }

    void DrawMap()
    {
        // Draw floor tiles
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                if (map[x, y])
                {
                    floorTilemap.SetTile(tilePosition, floorTile);
                }
                else
                {
                    wallTilemap.SetTile(tilePosition, wallTile);
                }
            }
        }
    }
}
