using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<string> lootTable = new List<string> { "Gold", "Potion", "Sword", "Shield", "Gem" };
    private bool isOpened = false;

    public void OpenChest()
    {
        if (!isOpened)
        {
            isOpened = true;
            string loot = lootTable[Random.Range(0, lootTable.Count)];
            Debug.Log("You found: " + loot);
            Destroy(gameObject, 2f); // Fjerner kisten efter 2 sek.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenChest();
        }
    }
}
