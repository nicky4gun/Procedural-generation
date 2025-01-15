using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class room_maker : MonoBehaviour
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

    public Transform player;

    private bool[,] map;
    private List<Vector2Int> roomCenters = new List<Vector2Int>();

    void Start()
    {
        GenerateMap();
        DrawMap();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void GenerateMap()
    {
        // Initialize the map as all walls
        map = new bool[mapWidth, mapHeight];
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                map[x, y] = false; // Wall
            }
        }

        // Generate rooms
        for (int i = 0; i < roomCount; i++)
        {
            int roomWidth = Random.Range(minRoomSize, maxRoomSize);
            int roomHeight = Random.Range(minRoomSize, maxRoomSize);
            int x = Random.Range(1, mapWidth - roomWidth - 1);
            int y = Random.Range(1, mapHeight - roomHeight - 1);

            // Carve out the room
            for (int w = 0; w < roomWidth; w++)
            {
                for (int h = 0; h < roomHeight; h++)
                {
                    map[x + w, y + h] = true; // Floor
                }
            }

            // Save room center for corridor connections
            int centerX = x + roomWidth / 2;
            int centerY = y + roomHeight / 2;
            roomCenters.Add(new Vector2Int(centerX, centerY));
        }

        // Connect the rooms with zig-zag corridors
        ConnectRoomsWithZigZagCorridors();
    }

    void CreateCorridor(Vector2Int start, Vector2Int end)
    {
        Vector2Int current = start;

        while (current != end)
        {
            if (Random.value > 0.8f)
            {
                // Move horizontally if not already aligned
                if (current.x != end.x)
                {
                    current.x += (end.x > current.x) ? 1 : -1;
                }
                else
                {
                    // Move vertically if already horizontally aligned
                    current.y += (end.y > current.y) ? 1 : -1;
                }
            }
            else
            {
                // Move vertically if not already aligned
                if (current.y != end.y)
                {
                    current.y += (end.y > current.y) ? 1 : -1;
                }
                else
                {
                    // Move horizontally if already vertically aligned
                    current.x += (end.x > current.x) ? 1 : -1;
                }
            }

            // Carve the floor at the current position
            map[current.x, current.y] = true;
        }
    }

    void ConnectRoomsWithZigZagCorridors()
    {
        for (int i = 0; i < roomCenters.Count - 1; i++)
        {
            CreateCorridor(roomCenters[i], roomCenters[i + 1]);
        }
    }

    void DrawMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                if (map[x, y])
                {
                    floorTilemap.SetTile(tilePosition, floorTile); // Floor
                }
                else
                {
                    wallTilemap.SetTile(tilePosition, wallTile); // Wall
                }
            }
        }
    }
}

    

