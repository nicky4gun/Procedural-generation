using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    public float rotationSpeed = 0.1f;
    private Rigidbody2D rb;
    public float distanceToShoot = 0.5f;
    public float distanceToStop = 0.1f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 15f;
    public float cooldown = 1f;
    public float timeToShoot = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if (Vector2.Distance(target.position, transform.position) < distanceToShoot && timeToShoot <= 0)
        {
            Fire();

            timeToShoot = cooldown;
        }

        if (timeToShoot > 0f)
        {
            timeToShoot -= Time.deltaTime;
        }
    }

    private void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
