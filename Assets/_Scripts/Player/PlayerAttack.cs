using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject standardAttackPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float cooldown = 0f;
    public float attackSpeed = 1f;

    private void Start()
    {
        attackSpeed -= AttackSpeedBuff.AttackSpeedBuffAmount;
    }
    void Update()
    {
        cooldown += Time.deltaTime;

        if (Input.GetMouseButton(0) && cooldown >= attackSpeed)
        {
            Fire();

            cooldown = 0f;
        }

        if (attackSpeed < 0.1f)
        {
            attackSpeed = 0.1f;
        }
    }

    void Fire()
    {
        GameObject Attack = Instantiate(standardAttackPrefab, firePoint.position, firePoint.rotation);
        Attack.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void AttackspeedBuff()
    {
        attackSpeed -= 0.05f;
    }
}
