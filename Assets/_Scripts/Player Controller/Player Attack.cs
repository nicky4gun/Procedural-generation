using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject standardAttackPrefab;
    public Transform firePoint;
    public float fireForce = 20f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject Attack = Instantiate(standardAttackPrefab, firePoint.position, firePoint.rotation);
        Attack.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
