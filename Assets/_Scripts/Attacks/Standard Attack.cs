using UnityEngine;

public class StandardAttack : MonoBehaviour
{
    public float TravelTime = 0f;
    public int damage = 10;

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
        Destroy(gameObject);

        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.Damage(damage);
        }
    }
}
