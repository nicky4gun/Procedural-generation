using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject standardAttackPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float cooldown = 0f;


    void Update()
    {
        cooldown += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldown >= 1f)
        {
            Fire();

            cooldown = 0f;
        }
    }

    void Fire()
    {
        GameObject Attack = Instantiate(standardAttackPrefab, firePoint.position, firePoint.rotation);
        Attack.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
