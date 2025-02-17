using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chestPrefab;
    public int numberOfChests = 5;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    void Start()
    {
        SpawnChests();
    }

    void SpawnChests()
    {
        for (int i = 0; i < numberOfChests; i++)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Instantiate(chestPrefab, randomPos, Quaternion.identity);
        }
    }
}
