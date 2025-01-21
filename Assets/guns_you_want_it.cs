using UnityEngine;

public class Guns_you_want_it: MonoBehaviour
{
    [Header("Shooting Settings")]
    public Transform shootPoint; // The point where bullets are fired
    public GameObject bulletPrefab; // Bullet prefab
    public int bulletsPerShot = 1; // Number of bullets per shot
    public float bulletSpeed = 10f; // Speed of each bullet
    public float fireRate = 0.2f; // Delay between shots
    public float spreadAngle = 10f; // Maximum spread angle in degrees

    [Header("Effects")]
    public GameObject muzzleFlashPrefab; // Muzzle flash effect
    public AudioClip shootSound; // Gunshot sound
    private AudioSource audioSource;

    private float nextFireTime = 0f; // Time until the next shot is allowed

    void Start()
    {
        // Initialize audio source
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Shooting
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Create muzzle flash
        if (muzzleFlashPrefab)
        {
            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, shootPoint.position, shootPoint.rotation);
            Destroy(muzzleFlash, 0.1f); // Destroy the flash after a short time
        }

        // Play gunshot sound
        if (shootSound && audioSource)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // Fire multiple bullets
        for (int i = 0; i < bulletsPerShot; i++)
        {
            // Calculate spread
            float spread = Random.Range(-spreadAngle, spreadAngle);
            Quaternion bulletRotation = Quaternion.Euler(shootPoint.eulerAngles + new Vector3(0, 0, spread));

            // Spawn the bullet
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, bulletRotation);

            // Apply velocity to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = bulletRotation * Vector2.right * bulletSpeed;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2f);
        }
    }
}
