using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    public Material fogMaterial; // Assign your Fog of War material here
    public Transform player; // Assign the player's Transform
    public float visibilityRadius = 5f; // Radius of visibility

    void Update()
    {
        if (fogMaterial != null && player != null)
        {
            // Update the shader's player position (normalized to the fog texture)
            Vector2 playerPos = new Vector2(player.position.x / 10.0f, player.position.y / 10.0f);
            fogMaterial.SetVector("_PlayerPosition", playerPos);

            // Update visibility radius
            fogMaterial.SetFloat("_Radius", visibilityRadius / 10.0f);
        }
    }
}

