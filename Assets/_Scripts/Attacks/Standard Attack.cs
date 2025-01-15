using UnityEngine;

public class StandardAttack : MonoBehaviour
{
    public float TravelTime = 0f;
    public static int damage = 10;

    void Update()
    {
        TravelTime += Time.deltaTime;

        if (TravelTime > 5f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.Damage(damage);
        }
        Destroy(gameObject);
    }

    public static void BuffDamage()
    {
        damage += 2;
    }
}
