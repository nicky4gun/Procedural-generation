using UnityEngine;

public class DamageBuff : MonoBehaviour
{
    StandardAttack playerDamage;

    void Start()
    {
        playerDamage = GameObject.FindGameObjectWithTag("PlayerAttack").GetComponent<StandardAttack>();
    }

    void OnCollisionEnter2D()
    {
        Activation();
    }

    void Activation()
    {
        playerDamage.BuffDamage();
    }
}
