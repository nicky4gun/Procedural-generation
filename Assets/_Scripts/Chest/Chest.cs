using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<string> lootTable = new List<string> { "Health", "Strength", "Speed" };
    private bool isOpened = false;

    private void Start()
    {
        // Tjekker om kisten har en Collider2D og advarer hvis ikke
        Collider2D col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError("Fejl! Kisten mangler en Collider2D. Tilføj en i Inspector.");
        }
        else if (!col.isTrigger)
        {
            Debug.LogWarning("Advarsel! Kistens Collider2D er ikke sat til 'isTrigger'. Sæt 'isTrigger = true' i Inspector.");
        }
    }

    public void OpenChest()
    {
        if (!isOpened)
        {
            isOpened = true;
            string loot = lootTable[Random.Range(0, lootTable.Count)];
            Debug.Log("🎁 Du har fundet: " + loot);
            Destroy(gameObject, 2f); // Fjerner kisten efter 2 sekunder
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenChest();
        }
        else
        {
            Debug.Log("🔍 Objekter uden 'Player' tag kan ikke åbne kisten: " + other.gameObject.name);
        }
    }
}
