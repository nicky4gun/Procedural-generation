using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float speed = 2f; // Movement speed
    public float stopDistance = 1.5f; // Distance to stop before hitting the player
    public float detectionRange = 10f; // Range where the enemy starts seeking the player
    public float shootingRange = 5f; // Range within which the enemy shoots
    public GameObject projectilePrefab; // Prefab for the projectile
    public float shootingCooldown = 2f; // Time between shots

    private float nextShotTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // If the player exists
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            // Check if the player is within detection range
            if (distance <= detectionRange)
            {
                // Move towards the player if not within stopDistance
                if (distance > stopDistance)
                {
                    Vector2 direction = (player.position - transform.position).normalized;
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }

                // Check if within shooting range and ready to shoot
                if (distance <= shootingRange && Time.time >= nextShotTime)
                {
                    ShootAtPlayer();
                    nextShotTime = Time.time + shootingCooldown;
                }
            }
        }
    }

    void ShootAtPlayer()
    {
        // Instantiate the projectile and set its direction
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;

        // Set velocity for the projectile's Rigidbody2D
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 5f; // Adjust speed as needed
        }
    }
}
