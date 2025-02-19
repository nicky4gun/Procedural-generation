using UnityEngine;
using System.Collections.Generic;

public class ChestPlacer : MonoBehaviour
{
    public Grid grid;                  // Reference til dit Grid
    public GameObject chestPrefab;     // Reference til kiste-prefaben
    public int chestLimit = 10;        // Maksimalt antal kister der kan placeres

    // Dictionary til at holde styr på placerede kister pr. grid-celle
    private Dictionary<Vector3Int, GameObject> placedChests = new Dictionary<Vector3Int, GameObject>();

    void Update()
    {
        // Tjek om venstre museknap er trykket
        if (Input.GetMouseButtonDown(0))
        {
            // Hvis vi har nået grænsen for antal kister, afbryd placeringen
            if (placedChests.Count >= chestLimit)
            {
                Debug.Log("Maksimalt antal kister placeret!");
                return;
            }

            // Konverter musens position fra skærm til world position
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Få grid cellen ud fra world position
            Vector3Int cellPosition = grid.WorldToCell(mouseWorldPos);

            // Tjek om der allerede er en kiste i cellen
            if (placedChests.ContainsKey(cellPosition))
            {
                Debug.Log("Der er allerede en kiste placeret i cellen: " + cellPosition);
                return;
            }

            // Få den centrale world position for cellen
            Vector3 spawnPosition = grid.GetCellCenterWorld(cellPosition);

            // Instantiér kiste-prefaben på den beregnede position
            GameObject newChest = Instantiate(chestPrefab, spawnPosition, Quaternion.identity);

            // Registrér den nye kiste, så cellen markeres som optaget
            placedChests.Add(cellPosition, newChest);
        }
    }
}