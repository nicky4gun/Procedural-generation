using UnityEngine;

public class StandardAttack : MonoBehaviour
{
    public float TravelTime = 0f;

    void Update()
    {
        TravelTime += Time.deltaTime;

        if (TravelTime > 5f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
